using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net4Sage;
using Sage500AppModel;
using Negocio;
using Net4Sage.Controls;
using Net4Sage.CIUtils;
using Entidades.General;

namespace RHSMTT001
{
    public partial class frmTipoTrabajador : Form
    {
        public frmTipoTrabajador()
        {
            InitializeComponent();
        }
        public frmTipoTrabajador(ref SageSession session) : this()
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
            ControllerRHSMTT001 controler = new ControllerRHSMTT001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtCodTrabaj.Enabled = false;
            txtNombre.Enabled = true;
            txtdescripcion.Enabled = true;           
        }
        private void DisableControls()
        {
            txtCodTrabaj.Enabled = true;
            txtNombre.Enabled = false;
            txtdescripcion.Enabled = false;           
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCodTrabaj.Tag != null && txtCodTrabaj.Tag.ToString() == txtCodTrabaj.Text) return;
            MainBS.Clear();

            if (txtCodTrabaj.Text.Length > 0)
            {
                ControllerRHSMTT001 controler = new ControllerRHSMTT001();
                ThrWorkerType data = controler.GetTipoTrabajador(txtCodTrabaj.Text);
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
            txtCodTrabaj.Tag = txtCodTrabaj.Text;

        }
        private void IDValidate(object sender, CancelEventArgs e)
        {
            if (!IDHandler.IsAlphaNumeric(txtCodTrabaj.Text))
            {              
                MessageBox.Show("El código del tipo de trabajador no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;               
            }          

        }
        public void MostrarDatosRegistro(ThrWorkerType dato)
        {
            ThrWorkerType data = dato;
            txtCodTrabaj.Text = data.WorkerTypeCod;
            txtNombre.Text = data.WorkerTypeID;
            txtdescripcion.Text = data.WorkerTypeDescription;            
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtCodTrabaj.Text = "";
            txtNombre.Text = "";
            txtdescripcion.Text = "";
            txtCodTrabaj.Focus();
            DisableControls();
            LoadContext();

        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCodTrabaj.Text != "")
                {
                    bool result;
                    ControllerRHSMTT001 controler = new ControllerRHSMTT001();
                    result = controler.DeleteWorkerType(txtCodTrabaj.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, el tipo de trabajador ha sido asignado a personas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el tipo de Trabajador", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCodTrabaj.Text != "")
                {
                    ThrWorkerType objData = new ThrWorkerType();
                    objData.WorkerTypeCod = txtCodTrabaj.Text;
                    objData.WorkerTypeID = txtNombre.Text;
                    objData.WorkerTypeDescription = txtdescripcion.Text;                    
                    ControllerRHSMTT001 controler = new ControllerRHSMTT001();
                    controler.AddWorkerType(objData);
                    UpdateLookup();
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar, los datos seleccionables no pueden ser modificados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {
            ThrWorkerType data = eventArgs.ReturnValue as ThrWorkerType;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMTT001 controler = new ControllerRHSMTT001();
                    ThrWorkerType Workertype = controler.GetTipoTrabajador(txtCodTrabaj.Text);
                    MostrarDatosRegistro(Workertype);
                    On_IDChange(null, null);
                }
                EnableControls();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool ValidateForm(object sender, EventArgs e)
        {
            if (MainBS.Current == null) return false;
            ValidateChildren();
            Validate();

            if (this.txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Nombre válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }            
            return true;
        }
        private void TxtCodTrabaj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodTrabaj.Text != "")
                {
                    if (!IDHandler.IsAlphaNumeric(txtCodTrabaj.Text))
                    {
                        MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtCodTrabaj.Tag = null;
                        On_IDChange(null, null);

                    }
                }
            }
        }
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }
    }
}
