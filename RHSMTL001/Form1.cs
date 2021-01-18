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

namespace RHSMTL001
{
    public partial class frmLicencia : Form
    {
        public frmLicencia()
        {
            InitializeComponent();
        }
        public frmLicencia(ref SageSession session) : this()
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
            ControllerRHSMTL001 controler = new ControllerRHSMTL001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtlicenceCod.Enabled = false;
            txtNombre.Enabled = true;
            txtResolucion.Enabled = true;
            chkAcumulaVacac.Enabled = true;
            
        }
        private void DisableControls()
        {
            txtlicenceCod.Enabled = true;
            txtNombre.Enabled = false;
            txtResolucion.Enabled = false;            
            chkAcumulaVacac.Enabled = false;
            chkAcumulaVacac.Checked = false;
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtlicenceCod.Tag != null && txtlicenceCod.Tag.ToString() == txtlicenceCod.Text) return;
            MainBS.Clear();

            if (txtlicenceCod.Text.Length > 0)
            {
                ControllerRHSMTL001 controler = new ControllerRHSMTL001();
                var data = controler.GetLicence(txtlicenceCod.Text);
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
            txtlicenceCod.Tag = txtlicenceCod.Text;

        }
        public void MostrarDatosRegistro(ThrLicence dato)
        {
            txtlicenceCod.Text = dato.LicenceID;
            txtNombre.Text = dato.LicenceName;
            txtResolucion.Text = dato.Resolution;
            if (dato.AcumulaVacaciones == 0)
            {
                chkAcumulaVacac.Checked = false;
            }
            else
            { chkAcumulaVacac.Checked = true; }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtlicenceCod.Text = "";
            txtNombre.Text = "";
            txtResolucion.Text = "";
            chkAcumulaVacac.Checked = false;
            txtlicenceCod.Focus();
            DisableControls();
            LoadContext();
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtlicenceCod.Text != "")
                {
                    bool result;
                    ControllerRHSMTA001 controler = new ControllerRHSMTA001();
                    result = controler.DeleteAusencia(txtlicenceCod.Text);
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
                if (txtlicenceCod.Text != "")
                {
                    ThrLicence objData = new ThrLicence();
                    objData.LicenceID = txtlicenceCod.Text;
                    objData.LicenceName = txtNombre.Text;
                    objData.Resolution = txtResolucion.Text;
                    if(chkAcumulaVacac.Checked)
                    { objData.AcumulaVacaciones = 1; }
                    else
                    {
                        objData.AcumulaVacaciones = 0;
                    }
                    ControllerRHSMTL001 controler = new ControllerRHSMTL001();
                    controler.AddLicencia(objData);
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

            if (txtlicenceCod.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un código válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtlicenceCod.Focus();
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
            ThrLicence data = eventArgs.ReturnValue as ThrLicence;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMTL001 controler = new ControllerRHSMTL001();
                    var licence = controler.GetLicence(txtlicenceCod.Text);
                    MostrarDatosRegistro(licence);
                    On_IDChange(null, null);
                }
                EnableControls();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtlicenceCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtlicenceCod.Text != "")
                {
                    if (!IDHandler.IsAlphaNumeric(txtlicenceCod.Text))
                    {
                        MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtlicenceCod.Tag = null;
                        On_IDChange(null, null);

                    }
                }
            }
        }
    }
}
