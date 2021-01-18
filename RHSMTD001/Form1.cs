using Entidades.General;
using Negocio;
using Net4Sage;
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

namespace RHSMTD001
{
    public partial class frmtipoDeduccion : Form
    {

        private Sage500AppEntities mycontext;
        public frmtipoDeduccion()
        {
            InitializeComponent();
        }
        public frmtipoDeduccion(ref SageSession session) : this()
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
            ControllerRHSMTD001 controler = new ControllerRHSMTD001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtCodigo.Enabled = false;
            txtNombrededuccion.Enabled = true;           
            txtDescripcion.Enabled = true;
        }
        private void DisableControls()
        {
            txtCodigo.Enabled = true;
            txtNombrededuccion.Enabled = false;
            txtDescripcion.Enabled = false;
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCodigo.Tag != null && txtCodigo.Tag.ToString() == txtCodigo.Text) return;
            MainBS.Clear();

            if (txtCodigo.Text.Length > 0)
            {
                ControllerRHSMTD001 controler = new ControllerRHSMTD001();
                var data = controler.GetDeduction(txtCodigo.Text);
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
            txtCodigo.Tag = txtCodigo.Text;

        }
        public void MostrarDatosRegistro(ThrDeduction dato)
        {
            txtCodigo.Text = dato.DeductionCod;
            txtNombrededuccion.Text = dato.DeductionID;
            txtDescripcion.Text = dato.DeductionDescrip;
        }

        private void Do_Cancel(object sender, EventArgs e)
        {
            txtCodigo.Text= "";
            txtNombrededuccion.Text = "";
            txtDescripcion.Text = "";
            DisableControls();
            LoadContext();
        }

        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtNombrededuccion.Text != "")
                {
                    bool result;
                    ControllerRHSMTD001 controler = new ControllerRHSMTD001();
                    result = controler.DeleteDeduction(txtCodigo.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, el tipo de incidencia ha sido asignado a personas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtCodigo.Text != "")
                {
                    ThrDeduction objData = new ThrDeduction();
                    objData.DeductionCod = txtCodigo.Text;
                    objData.DeductionID = txtNombrededuccion.Text;
                    objData.DeductionDescrip = txtDescripcion.Text;                    
                    ControllerRHSMTD001 controler = new ControllerRHSMTD001();
                    controler.AddDeduction(objData);
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

            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un código válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);                
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
            ThrDeduction data = eventArgs.ReturnValue as ThrDeduction;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMTD001 controler = new ControllerRHSMTD001();
                    var deduccion = controler.GetDeduction(txtCodigo.Text);
                    MostrarDatosRegistro(deduccion);
                    On_IDChange(null, null);
                }
                EnableControls();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodigo.Text != "")
                {
                    On_IDChange(null, null);
                }
                else { MessageBox.Show("El nombre no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
    }
}
