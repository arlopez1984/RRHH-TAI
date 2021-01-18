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

namespace RHSMOI001
{
    public partial class frmOtrasIncidencias : Form
    {
        public frmOtrasIncidencias()
        {
            InitializeComponent();
        }
        public frmOtrasIncidencias(ref SageSession session) : this()
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
            ControllerRHSMOI001 controler = new ControllerRHSMOI001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtCodigo.Enabled = false;
            txtNombreIncidencia.Enabled = true;
            txtPorcientoaPagar.Enabled = true;
            txtResolucion.Enabled = true;
        }
        private void DisableControls()
        {
            txtCodigo.Enabled = true;
            txtNombreIncidencia.Enabled = false;
            txtPorcientoaPagar.Enabled = false;
            txtResolucion.Enabled = false;
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCodigo.Tag != null && txtCodigo.Tag.ToString() == txtCodigo.Text) return;
            MainBS.Clear();

            if (txtCodigo.Text.Length > 0)
            {
                ControllerRHSMOI001 controler = new ControllerRHSMOI001();
                var data = controler.GetIncidencia(txtCodigo.Text);
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
        public void MostrarDatosRegistro(ThrIncidence dato)
        {
            txtCodigo.Text = dato.IncidenceCod;
            txtNombreIncidencia.Text = dato.IncidenceID;
            txtPorcientoaPagar.Text = dato.IncidencePCientoPagar.ToString();
            txtResolucion.Text = dato.Resolution;
        }

        private void Do_Cancel(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombreIncidencia.Text = "";
            txtPorcientoaPagar.Text = "";
            txtResolucion.Text = "";
            txtPorcientoaPagar.Text = "0";
            DisableControls();
            LoadContext();
        }

        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    bool result;
                    ControllerRHSMOI001 controler = new ControllerRHSMOI001();
                    result = controler.DeleteIncidencia(txtCodigo.Text);
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
                if (txtNombreIncidencia.Text != "")
                {
                    ThrIncidence objData = new ThrIncidence();
                    objData.IncidenceCod = txtCodigo.Text;
                    objData.IncidenceID = txtNombreIncidencia.Text;
                    objData.IncidencePCientoPagar = Convert.ToDecimal(txtPorcientoaPagar.Text);
                    objData.Resolution = txtResolucion.Text;
                    ControllerRHSMOI001 controler = new ControllerRHSMOI001();
                    controler.AddIncidencia(objData);
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
                txtCodigo.Focus();
                return false;
            }
            if (txtNombreIncidencia.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un nombre válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreIncidencia.Focus();
                return false;
            }
            if (txtResolucion.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir una resolución válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResolucion.Focus();
                return false;
            }
            if (txtPorcientoaPagar.Text == "" || txtPorcientoaPagar.Text == "0")
            {
                MessageBox.Show("Debe introducir un Por ciento válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPorcientoaPagar.Focus();
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
            ThrIncidence data = eventArgs.ReturnValue as ThrIncidence;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMOI001 controler = new ControllerRHSMOI001();
                    var incidence = controler.GetIncidencia(txtCodigo.Text);
                    MostrarDatosRegistro(incidence);
                    On_IDChange(null, null);
                }
                EnableControls();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void TxtPorcientoaPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        } 
       
        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodigo.Text != "")
                {
                    On_IDChange(null, null);
                }
                else { MessageBox.Show("El nombre de la Incidencia no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
    }
}
