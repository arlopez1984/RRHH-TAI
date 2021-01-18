using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net4Sage.DataAccessModel;
using Sage500AppModel;
using Net4Sage.Controls;
using Net4Sage;
using Negocio;
using Entidades.General;

namespace RHSMCLO001
{
    public partial class frmClasificacionOcupacional : Form
    {
        private Sage500AppEntities mycontexto;

        public frmClasificacionOcupacional()
        {
           InitializeComponent();
        }
        public frmClasificacionOcupacional(ref SageSession session) : this()
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
            mycontexto = new Sage500AppEntities(connectionString.ToString());
            Conection.connectionString = connectionString.ToString();
        }       
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }
        public void MostrarDatosRegistro(ThrOcupationClasification data)
        {
            if (data != null)
            {
                txt.Text = data.SpecialtyID;
                txtdescripcion.Text = data.Descripcion;
            }

        }
        private void UpdateLookup()
        {
            ControllerRHSMCLO001 controler = new ControllerRHSMCLO001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {
            txt.Enabled = false;
            txtdescripcion.Enabled = true;
        }
        private void DisableControls()
        {
            txt.Enabled = true;
            txtdescripcion.Enabled = false;
        }
        private void On_Save(object sender, EventArgs e)
        {
            try
            {
                if (txt.Text != "")
                {
                    ThrOcupationClasification objData = new ThrOcupationClasification();
                    objData.SpecialtyID = txt.Text;
                    objData.Descripcion = txtdescripcion.Text;
                    ControllerRHSMCLO001 controler = new ControllerRHSMCLO001();
                    controler.AddClasificacionOcupacional(objData);
                    UpdateLookup();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar, los datos seleccionables no pueden ser modificados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool On_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txt.Text != "")
                {
                    bool result;
                    ControllerRHSMCLO001 controler = new ControllerRHSMCLO001();
                    result = controler.DeleteClasificacionOcupacional(txt.Text);
                    if (result)
                    {
                        UpdateLookup();
                        On_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, ha sido asignado a personas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception)
            {  
                MessageBox.Show("Error al eliminar la Clasificicación.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void On_Cancel(object sender, EventArgs e)
        {
            txt.Text = "";
            txtdescripcion.Text = "";
            LoadContext();
            On_IDChange(null, null);
            DisableControls();
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txt.Tag != null && txt.Tag.ToString() == txt.Text) return;
            MainBS.Clear();
            if (txt.Text.Length > 0)
            {
                ControllerRHSMCLO001 controler = new ControllerRHSMCLO001();
                ThrOcupationClasification data = controler.GetClasificacionOcupacion(txt.Text);
                if (data != null)
                {
                    MainBS.Add(data);
                    strBar.SetFormStatus(FormBindingStatus.Editing);
                    MostrarDatosRegistro(data);
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
            txt.Tag = txt.Text;
        }
        
        private void LookupButton1_OnLookupReturn(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {
            ThrOcupationClasification data = eventArgs.ReturnValue as ThrOcupationClasification;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                }
                else
                {
                    ControllerRHSMCLO001 controler = new ControllerRHSMCLO001();
                    var clasf = controler.GetClasificacionOcupacion(txt.Text);
                    MostrarDatosRegistro(clasf);
                    On_IDChange(null, null);
                }
                EnableControls();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txt.Text != "")
                {
                    On_IDChange(null, null);
                }
                else { MessageBox.Show("El nombre de la especialidad no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
    }
}
