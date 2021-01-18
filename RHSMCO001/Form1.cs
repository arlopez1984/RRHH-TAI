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
    public partial class frmCategoriaOcupacional : Form
    {
        private Sage500AppEntities mycontext;
        public frmCategoriaOcupacional()
        {
            InitializeComponent();
        }
        public frmCategoriaOcupacional(ref SageSession session) : this()
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
            ControllerRHSMCO001 controler = new ControllerRHSMCO001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtCategoriaName.Enabled = false;
            txtPagoCategoria.Enabled = true;
            txtPagoPerfecc.Enabled = true;
            txtdescripcion.Enabled = true;
            
        }
        private void DisableControls()
        {
            txtCategoriaName.Enabled = true;
            txtPagoCategoria.Enabled = false;
             txtPagoPerfecc.Enabled = false;
             txtdescripcion.Enabled = false;            
        }
        public void MostrarDatosRegistro(ThrOcupationalCategory data)
        {
            if (data != null)
            {
                txtCategoriaName.Text = data.CategoryID;
                txtPagoCategoria.Text = data.CategoryPay.ToString();
                txtPagoPerfecc.Text = data.CategoryPerfeccion.ToString();
                txtdescripcion.Text = data.CategoryDescripcion;
            }

        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCategoriaName.Tag != null && txtCategoriaName.Tag.ToString() == txtCategoriaName.Text) return;
            MainBS.Clear();
            if (txtCategoriaName.Text.Length > 0)
            {
                ControllerRHSMCO001 controler = new ControllerRHSMCO001();
                ThrOcupationalCategory data = controler.GetCategoriaOcupacional(txtCategoriaName.Text);
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
            txtPagoCategoria.Text = "";
            txtPagoPerfecc.Text = "";
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
                    ThrOcupationalCategory objData = new ThrOcupationalCategory();
                    objData.CategoryID = txtCategoriaName.Text;
                    objData.CategoryPay = Convert.ToDecimal(txtPagoCategoria.Text);
                    objData.CategoryPerfeccion = Convert.ToDecimal(txtPagoPerfecc.Text);
                    objData.CategoryDescripcion = txtdescripcion.Text;
                    ControllerRHSMCO001 controler = new ControllerRHSMCO001();
                    controler.AddCategoriaOcupacional(objData);
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
            ThrOcupationalCategory data = eventArgs.ReturnValue as ThrOcupationalCategory;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMCO001 controler = new ControllerRHSMCO001();
                    ThrOcupationalCategory catOcup = controler.GetCategoriaOcupacional(txtCategoriaName.Text);
                    MostrarDatosRegistro(catOcup);
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
                    ControllerRHSMCO001 controler = new ControllerRHSMCO001();
                    result = controler.DeleteCategoriaOcupacional(txtCategoriaName.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, la categoría ha sido asignada a algún cargo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
            if (txtPagoCategoria.Text == "")
            {
                MessageBox.Show("Debe introducir un pago válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPagoCategoria.Focus();
                return false;
            }
            if (txtPagoPerfecc.Text == "")
            {
                MessageBox.Show("Debe introducir un pago válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPagoPerfecc.Focus();
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

        private void TxtPagoCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void TxtPagoPerfecc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }

        private void FrmCategoriaOcupacional_Load(object sender, EventArgs e)
        {

        }

        private void Txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
