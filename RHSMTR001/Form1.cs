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

namespace RHSMTR001
{
    public partial class frmRetenciones : Form
    {
        public frmRetenciones()
        {
            InitializeComponent();
        }
        public frmRetenciones(ref SageSession session) : this()
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
            ControllerRHSMTR001 controler = new ControllerRHSMTR001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtcodigo.Enabled = false;
            txtnombre.Enabled = true;
            txtDescrpcion.Enabled = true;
        }
        private void DisableControls()
        {
            txtcodigo.Enabled = true;
            txtnombre.Enabled = false;
            txtDescrpcion.Enabled = false;
            
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtcodigo.Tag != null && txtcodigo.Tag.ToString() == txtcodigo.Text) return;
            MainBS.Clear();

            if (txtcodigo.Text.Length > 0)
            {
                ControllerRHSMTR001 controler = new ControllerRHSMTR001();
                var data = controler.GetRetencion(txtcodigo.Text);
                if (data != null)
                {
                    MainBS.Add(data);                   
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
            txtcodigo.Tag = txtcodigo.Text;

        }
        public void MostrarDatosRegistro(ThrRetention dato)
        {
            txtcodigo.Text = dato.RetentionCod;
            txtnombre.Text = dato.RetentionName;
            txtDescrpcion.Text = dato.RetentionDescription;
            
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtDescrpcion.Text = "";          
            DisableControls();
            LoadContext();
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtcodigo.Text != "")
                {
                    bool result;
                    ControllerRHSMTR001 controler = new ControllerRHSMTR001();
                    result = controler.DeleteRetencion(txtcodigo.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, el tipo de retención ha sido asignado a personas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el tipo de retención", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtcodigo.Text != "")
                {
                    var objData = new ThrRetention();
                    objData.RetentionCod = txtcodigo.Text;
                    objData.RetentionName = txtnombre.Text;
                    objData.RetentionDescription = txtDescrpcion.Text;                   
                    ControllerRHSMTR001 controler = new ControllerRHSMTR001();
                    controler.AddRetencion(objData);
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

            if (txtcodigo.Text.Length == 0)
            {
                MessageBox.Show("Código no válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcodigo.Focus();
                return false;
            }
            if (txtnombre.Text.Length == 0)
            {
                MessageBox.Show("Nombre no válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnombre.Focus();
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
            ThrRetention data = eventArgs.ReturnValue as ThrRetention;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMTR001 controler = new ControllerRHSMTR001();
                    var retention = controler.GetRetencion(txtcodigo.Text);
                    MostrarDatosRegistro(retention);
                    On_IDChange(null, null);
                }
                EnableControls();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNombreRetencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtcodigo.Text == "")
                {
                    MessageBox.Show("El nombre de Retención no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ControllerRHSMTR001 controler = new ControllerRHSMTR001();
                    var data = controler.GetRetencion(txtcodigo.Text);
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
               
            }
        }     
        
    }
}
