using Negocio;
using Net4Sage;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net4Sage.Controls;
using Net4Sage.CIUtils;
using Entidades.General;

namespace RHSMTM001
{
    public partial class frmTipoMovimiento : Form
    {
        private Sage500AppEntities mycontext;
        public frmTipoMovimiento()
        {
            InitializeComponent();
        }
        public frmTipoMovimiento(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            LoadContext();
        }
        public void LoadContext()
        {
            System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
            {
                Metadata = "res://*/DataModel1.csdl|res://*/DataModel1.ssdl|res://*/DataModel1.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sageSession1.GetConnectionString()
            };
            Conection.connectionString = connectionString.ToString();
            mycontext = new Sage500AppEntities(connectionString.ToString());
        }
        private void UpdateLookup()
        {
            ControllerRHSMTM001 controler = new ControllerRHSMTM001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtCodMovimiento.Enabled = false;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;

        }
        private void DisableControls()
        {
            txtCodMovimiento.Enabled = true;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCodMovimiento.Tag != null && txtCodMovimiento.Tag.ToString() == txtCodMovimiento.Text) return;
            MainBS.Clear();

            if (txtCodMovimiento.Text.Length > 0)
            {
                ControllerRHSMTM001 controler = new ControllerRHSMTM001();
                var data = controler.GetMoviemiento(txtCodMovimiento.Text);
                if (data != null)
                {
                    MainBS.Add(data);
                    MostrarDatosRegistro(data);
                    starBar.SetFormStatus(FormBindingStatus.Editing);
                }
                else
                {
                    MainBS.AddNew();
                    starBar.SetFormStatus(FormBindingStatus.Adding);
                }
                EnableControls();

            }
            else
            {
                DisableControls();
                starBar.SetFormStatus(FormBindingStatus.Waiting);
            }
            txtCodMovimiento.Tag = txtCodMovimiento.Text;

        }
        public void MostrarDatosRegistro(ThrMovement dato)
        {
            txtCodMovimiento.Text = dato.MovementID;
            txtNombre.Text = dato.MovementName;
            txtDescripcion.Text = dato.MovementDescrip;
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtCodMovimiento.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";            
            txtCodMovimiento.Focus();
            DisableControls();
            LoadContext();
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCodMovimiento.Text != "")
                {
                    bool result;
                    ControllerRHSMTM001 controler = new ControllerRHSMTM001();
                    result = controler.DeleteMovimiento(txtCodMovimiento.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, el tipo de movimiento ha sido asignado a personas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el tipo de subsidio", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCodMovimiento.Text != "")
                {
                    ThrMovement objData = new ThrMovement();
                    objData.MovementID = txtCodMovimiento.Text;
                    objData.MovementName = txtNombre.Text;
                    objData.MovementDescrip = txtDescripcion.Text;                   
                    ControllerRHSMTM001 controler = new ControllerRHSMTM001();
                    controler.AddMovimiento(objData);
                    UpdateLookup();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar, los datos seleccionables no pueden ser modificados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool ValidateForm(object sender, EventArgs e)
        {
            if (MainBS.Current == null) return false;
            ValidateChildren();
            Validate();

            if (txtCodMovimiento.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un código válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodMovimiento.Focus();
                return false;
            }
            if (txtCodMovimiento.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un código válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodMovimiento.Focus();
                return false;
            }
            if (txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un nombre válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }

        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {
            ThrMovement data = eventArgs.ReturnValue as ThrMovement;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMTM001 controler = new ControllerRHSMTM001();
                    var movement = controler.GetMoviemiento(txtCodMovimiento.Text);
                    MostrarDatosRegistro(movement);
                    On_IDChange(null, null);
                }
                EnableControls();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCodMovimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodMovimiento.Text != "")
                {
                    if (!IDHandler.IsAlphaNumeric(txtCodMovimiento.Text))
                    {
                        MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtCodMovimiento.Tag = null;
                        On_IDChange(null, null);

                    }
                }
            }
        }
    }
}
