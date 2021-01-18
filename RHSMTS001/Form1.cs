using Net4Sage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sage500AppModel;
using Negocio;
using Net4Sage.Controls;
using Net4Sage.CIUtils;
using Entidades.General;

namespace RHSMTS001
{
    public partial class frmTipoSubsidio : Form
    {
        public frmTipoSubsidio()
        {
            InitializeComponent();
        }
        public frmTipoSubsidio(ref SageSession session) : this()
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
            ControllerRHSMTS001 controler = new ControllerRHSMTS001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtSubsidioCod.Enabled = false;
            txtNombre.Enabled = true;
            txtPorCientoPagar.Enabled = true;
            txtResolucion.Enabled = true;
        }
        private void DisableControls()
        {
            txtSubsidioCod.Enabled = true;
            txtNombre.Enabled = false;
            txtResolucion.Enabled = false;
            txtPorCientoPagar.Enabled = false;
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtSubsidioCod.Tag != null && txtSubsidioCod.Tag.ToString() == txtSubsidioCod.Text) return;
            MainBS.Clear();

            if (txtSubsidioCod.Text.Length > 0)
            {
                ControllerRHSMTS001 controler = new ControllerRHSMTS001();
                var data = controler.GetSubsidy(txtSubsidioCod.Text);
                if (data != null)
                {
                    MainBS.Add(data);
                    MostrarDatosRegistro(data);
                    strbar.SetFormStatus(FormBindingStatus.Editing);
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
            txtSubsidioCod.Tag = txtSubsidioCod.Text;

        }
        public void MostrarDatosRegistro(ThrSubsidy dato)
        {           
            txtSubsidioCod.Text = dato.SubsideID;
            txtNombre.Text = dato.SubsidyName;
            txtPorCientoPagar.Text = dato.PorCientoPagar.ToString();
            txtResolucion.Text = dato.Resolucion;
        }

        private void Do_Cancel(object sender, EventArgs e)
        {
            txtSubsidioCod.Text = "";
            txtNombre.Text = "";
            txtPorCientoPagar.Text = "";
            txtResolucion.Text ="";
            txtSubsidioCod.Focus();
            DisableControls();
            LoadContext();
        }

        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtSubsidioCod.Text != "")
                {
                    bool result;
                    ControllerRHSMTS001 controler = new ControllerRHSMTS001();
                    result = controler.DeleteSubsidy(txtSubsidioCod.Text);
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
                if (txtSubsidioCod.Text != "")
                {
                    ThrSubsidy objData = new ThrSubsidy();
                    objData.SubsideID = txtSubsidioCod.Text;
                    objData.SubsidyName = txtNombre.Text;
                    objData.PorCientoPagar = Convert.ToDecimal(txtPorCientoPagar.Text);
                    objData.Resolucion = txtResolucion.Text;
                    ControllerRHSMTS001 controler = new ControllerRHSMTS001();
                    controler.AddSubsidio(objData);
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

            if (this.txtSubsidioCod.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un código válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubsidioCod.Focus();
                return false;
            }
            if (this.txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un nombre válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (this.txtResolucion.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir una resolución válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResolucion.Focus();
                return false;
            }
            if (this.txtPorCientoPagar.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Por Ciento válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPorCientoPagar.Focus();
                return false;
            }
            return true;
        }

        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();

        }

        private void TxtSubsidioCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtSubsidioCod.Text != "")
                {
                    if (!IDHandler.IsAlphaNumeric(txtSubsidioCod.Text))
                    {
                        MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtSubsidioCod.Tag = null;
                        On_IDChange(null, null);

                    }
                }
            }

        }

        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {
            ThrSubsidy data = eventArgs.ReturnValue as ThrSubsidy;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMTS001 controler = new ControllerRHSMTS001();
                    var subsidy = controler.GetSubsidy(txtSubsidioCod.Text);
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

        private void TxtPorCientoPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
    }
}
