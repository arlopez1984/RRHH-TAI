using Entidades.General;
using Negocio;
using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls;
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

namespace RHSMTA001
{
    public partial class frmAusencias : Form
    {
        public frmAusencias()
        {
            InitializeComponent();
        }
        public frmAusencias(ref SageSession session) : this()
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
        }
        private void UpdateLookup()
        {
            ControllerRHSMTA001 controler = new ControllerRHSMTA001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtAusenciaCod.Enabled = false;
            txtNombre.Enabled = true;
            txtResolucion.Enabled = true;
        }
        private void DisableControls()
        {
            txtAusenciaCod.Enabled = true;
            txtNombre.Enabled = false;
            txtResolucion.Enabled = false;
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtAusenciaCod.Tag != null && txtAusenciaCod.Tag.ToString() == txtAusenciaCod.Text) return;
            MainBS.Clear();

            if (txtAusenciaCod.Text.Length > 0)
            {
                ControllerRHSMTA001 controler = new ControllerRHSMTA001();
                var data = controler.GetAusencia(txtAusenciaCod.Text);
                if (data != null)
                {
                    MainBS.Add(data);
                    MostrarDatosRegistro(data);
                    strBar.SetFormStatus(FormBindingStatus.Editing);
                }
                else
                {
                    MainBS.AddNew();
                    strBar.SetFormStatus(FormBindingStatus.Adding);
                }
                EnableControls();

            }
            else
            {
                DisableControls();
                strBar.SetFormStatus(FormBindingStatus.Waiting);
            }
            txtAusenciaCod.Tag = txtAusenciaCod.Text;

        }
        public void MostrarDatosRegistro(ThrAbsence dato)
        {
            txtAusenciaCod.Text = dato.AbsenceID;
            txtNombre.Text = dato.AbsenceName;
            txtResolucion.Text = dato.Resolucion;
        }

        private void Do_Cancel(object sender, EventArgs e)
        {
            txtAusenciaCod.Text = "";
            txtNombre.Text = "";
            txtResolucion.Text = "";
            txtAusenciaCod.Focus();
            DisableControls();
            LoadContext();
        }

        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtAusenciaCod.Text != "")
                {
                    bool result;
                    ControllerRHSMTA001 controler = new ControllerRHSMTA001();
                    result = controler.DeleteAusencia(txtAusenciaCod.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, el tipo de subsidio ha sido asignado a personas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtAusenciaCod.Text != "")
                {
                    ThrAbsence objData = new ThrAbsence();
                    objData.AbsenceID = txtAusenciaCod.Text;
                    objData.AbsenceName = txtNombre.Text;
                    objData.Resolucion = txtResolucion.Text;
                    ControllerRHSMTA001 controler = new ControllerRHSMTA001();
                    controler.AddAusencia(objData);
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

            if (txtAusenciaCod.Text.Length==0)
            {
                MessageBox.Show("Debe introducir un código válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAusenciaCod.Focus();
                return false;
            }
            if (txtResolucion.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir una resolución válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResolucion.Focus();
                return false;
            }
            if (txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un nombre válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResolucion.Focus();
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
            ThrAbsence data = eventArgs.ReturnValue as ThrAbsence;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMTA001 controler = new ControllerRHSMTA001();
                    var subsidy = controler.GetAusencia(txtAusenciaCod.Text);
                    MostrarDatosRegistro(subsidy);
                    On_IDChange(null, null);
                }
                EnableControls();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtAusenciaCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtAusenciaCod.Text != "")
                {
                    if (!IDHandler.IsAlphaNumeric(txtAusenciaCod.Text))
                    {
                        MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtAusenciaCod.Tag = null;
                        On_IDChange(null, null);

                    }
                }
            }

        }
    }
}
