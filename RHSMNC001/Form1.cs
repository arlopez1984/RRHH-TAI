using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.General;
using Negocio;
using Net4Sage;
using Net4Sage.Controls;
using RRHH.Datamodel;
using Sage500AppModel;

namespace RHSMNC001
{
    public partial class frmNivelEscolar : Form
    {
        public frmNivelEscolar()
        {
            InitializeComponent();
        }
        public frmNivelEscolar(ref SageSession session) : this()
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
            ControllerRHSMNC001 controler = new ControllerRHSMNC001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txtCulturalLevID.Enabled = false;           
            txtdescripcion.Enabled = true;
        }
        private void DisableControls()
        {
            txtCulturalLevID.Enabled = true;
            txtdescripcion.Enabled = false;
        }        
        public void MostrarDatosRegistro(ThrCulturalLevel dato)
        {
            ThrCulturalLevel data = dato;
            txtCulturalLevID.Text = data.CulturalID;          
            txtdescripcion.Text = data.CulturalDesc;
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtCulturalLevID.Text = "";
            txtdescripcion.Text = "";
            DisableControls();
            LoadContext();

        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCulturalLevID.Text != "")
                {
                    bool result;
                    ControllerRHSMNC001 controler = new ControllerRHSMNC001();
                    result = controler.DeleteNivelCultural(txtCulturalLevID.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el nivel cultural, está asignado a personas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el nivel cultural.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {
            ThrCulturalLevel data = eventArgs.ReturnValue as ThrCulturalLevel;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMNC001 controler = new ControllerRHSMNC001();
                    ThrCulturalLevel level = controler.GetNivelCultural(txtCulturalLevID.Text);
                    MostrarDatosRegistro(level);
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

            if (this.txtCulturalLevID.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Nombre válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCulturalLevID.Focus();
                return false;
            }
            return true;
        }
        private void TxtCodTrabaj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCulturalLevID.Text != "")
                {
                    
                        MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtCulturalLevID.Tag = null;
                    On_IDChange(null, null);

                }
                
            }
        }
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCulturalLevID.Text != "")
                {
                    ThrCulturalLevel objData = new ThrCulturalLevel();
                    objData.CulturalID = txtCulturalLevID.Text;                   
                    objData.CulturalDesc = txtdescripcion.Text;
                    ControllerRHSMNC001 controler = new ControllerRHSMNC001();
                    controler.AddNivelCultural(objData);
                    UpdateLookup();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar, los datos seleccionables no pueden ser modificados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }      
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCulturalLevID.Tag != null && txtCulturalLevID.Tag.ToString() == txtCulturalLevID.Text) return;
            MainBS.Clear();

            if (txtCulturalLevID.Text.Length > 0)
            {
                ControllerRHSMNC001 controler = new ControllerRHSMNC001();
                ThrCulturalLevel data = controler.GetNivelCultural(txtCulturalLevID.Text);
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
            txtCulturalLevID.Tag = txtCulturalLevID.Text;

        }

        private void IDValidate(object sender, CancelEventArgs e)
        {
           
        }

        private void TxtCulturalLevID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCulturalLevID.Text != "")
                {
                    if (txtCulturalLevID.Text == "")
                    {
                        MessageBox.Show("El nivel cultural no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtCulturalLevID.Tag = null;
                        On_IDChange(null, null);

                    }
                }
            }
        }
    }
}
