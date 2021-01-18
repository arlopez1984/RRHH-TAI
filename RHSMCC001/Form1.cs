using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls;
using Net4Sage.Controls.Lookup;
using Net4Sage.DataAccessModel;
using System;
using Sage500AppModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Entidades.General;

namespace RHSMCO001
{
    public partial class frmCategoriaCientifica : Form
    {
        private Sage500AppEntities mycontext;
        ControllerRHSMCC001 controler;
        public frmCategoriaCientifica()
        {
            InitializeComponent();
            controler = new ControllerRHSMCC001();
        }
        public frmCategoriaCientifica(ref SageSession session) : this()
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
            mycontext = new Sage500AppEntities(connectionString.ToString());
            Conection.connectionString = connectionString.ToString();
        }
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }
        private void UpdateLookup()
        {
           
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtCategoriaName.Enabled = false;          
            txtdescripcion.Enabled = true;
            
        }
        private void DisableControls()
        {
            txtCategoriaName.Enabled = true;            
             txtdescripcion.Enabled = false;            
        }
        public void MostrarDatosRegistro(ThrScientificCategory data)
        {
            if (data != null)
            {
                txtCategoriaName.Text = data.ScientificCategoryID;               
                txtdescripcion.Text = data.ScientificCategoryDescripcion;
            }

        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCategoriaName.Tag != null && txtCategoriaName.Tag.ToString() == txtCategoriaName.Text) return;
            MainBS.Clear();
            if (txtCategoriaName.Text.Length > 0)
            {                
                var data = controler.GetCategoriaScientifica(txtCategoriaName.Text);
                if (data != null)
                {
                    MainBS.Add(data);
                    strbar.SetFormStatus(FormBindingStatus.Editing);
                    MostrarDatosRegistro(data);
                }
                else
                {
                    MainBS.AddNew();
                    strbar.SetFormStatus(FormBindingStatus.Adding);
                }
                EnableControls();
            }
            else
            {
                DisableControls();
                strbar.SetFormStatus(FormBindingStatus.Waiting);
            }
            txtCategoriaName.Tag = txtCategoriaName.Text;
        }
        private void Do_Cancel(object sender, EventArgs e)
        {      
            txtCategoriaName.Text = "";           
            txtdescripcion.Text = "";           
            LoadContext();
            On_IDChange(null, null);
            DisableControls();
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoriaName.Text != "")
                {
                    ThrScientificCategory objData = new ThrScientificCategory();
                    objData.ScientificCategoryID = txtCategoriaName.Text;                   
                    objData.ScientificCategoryDescripcion = txtdescripcion.Text;                   
                    controler.AddCategoriaScientifica(objData);
                    UpdateLookup();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar, los datos seleccionables no pueden ser modificados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OnNavChange(object sender, LookupReturnEventArgs eventArgs)
        {
            var data = eventArgs.ReturnValue as ThrScientificCategory;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    var catOScientif = controler.GetCategoriaScientifica(txtCategoriaName.Text);
                    MostrarDatosRegistro(catOScientif);
                    On_IDChange(null, null);
                }
                EnableControls();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoriaName.Text != "")
                {
                    bool result;
                    result = controler.DeleteCategoriaScientifica(txtCategoriaName.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, la categoría ha sido asignada a alguna persona.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la persona", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool ValidateForm(object sender, EventArgs e)
        {

            if (MainBS.Current == null) return false;
            ValidateChildren();
            Validate();

            if (this.txtCategoriaName.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Nombre válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoriaName.Focus();
                return false;
            }  
            return true;
        }
        private void IDValidate(object sender, CancelEventArgs e)
        {
           /* if (!IDHandler.IsNumeric(txtPagoCategoria.Text))
            {
                MessageBox.Show("El Pago por Categoría no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPagoCategoria.Focus();
                e.Cancel = true;
            }
            if (!IDHandler.IsNumeric(txtPagoPerfecc.Text))
            {
                MessageBox.Show("El Pago por Perfección no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPagoPerfecc.Focus();
                e.Cancel = true;
            }   */         
        }
        private void TxtCategoriaName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCategoriaName.Text != "")
                {
                    On_IDChange(null, null);                  
                }
                else
                {
                    MessageBox.Show("El nombre de Categpría no es válido", "Sage MAS 500", MessageBoxButtons.OK);
                }
               
            }

        }       
        
    }
}
