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
using Net4Sage.CIUtils;
using Net4Sage.Controls;
using Sage500AppModel;

namespace RHSMGE001
{
    public partial class frmGrupoEscala : Form
    {
        private Sage500AppEntities mycontexo;
        ControllerRHSMGE001 controler;
        public frmGrupoEscala()
        {
            InitializeComponent();
            controler = new ControllerRHSMGE001();
        }
        public frmGrupoEscala(ref SageSession session): this()
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
            mycontexo = new Sage500AppEntities(connectionString.ToString());
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
            txtnombreGrupo.Enabled = false;
            txtSalarioEscala.Enabled = true;           
            txtdescripcion.Enabled = true;

        }
        private void DisableControls()
        {
            txtnombreGrupo.Enabled = true;
            txtSalarioEscala.Enabled = false;
            txtdescripcion.Enabled = false;
        }
        public void MostrarDatosRegistro(ThrEscalaGroup data)
        {
            try
            {
                if (data != null)
                {
                    txtnombreGrupo.Text = data.EscalaGroupID;
                    txtSalarioEscala.Text = data.EscalaSalario.ToString();
                    txtdescripcion.Text = data.Descripcion;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtnombreGrupo.Tag != null && txtnombreGrupo.Tag.ToString() == txtnombreGrupo.Text) return;
            MainBS.Clear();
            if (txtnombreGrupo.Text.Length > 0)
            {                
                ThrEscalaGroup data = controler.GetGrupoEscala(txtnombreGrupo.Text);
                if (data != null)
                {
                    MainBS.Add(data);
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
            txtnombreGrupo.Tag = txtnombreGrupo.Text;
        }        
        private void TxtnombreGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!IDHandler.IsAlphaNumeric(txtnombreGrupo.Text))
                {
                    MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var data = controler.GetGrupoEscala(txtnombreGrupo.Text);
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
            }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtnombreGrupo.Text = "";
            txtSalarioEscala.Text = "";
            txtdescripcion.Text = "";           
            LoadContext();
            On_IDChange(null, null);
            DisableControls();
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtnombreGrupo.Text != "")
                {
                    bool result;
                    result = controler.DeleteEscalaGroup(txtnombreGrupo.Text);
                    if (result)
                    {                     
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, el grupo de escala ha sido asignado a personas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtnombreGrupo.Text != "")
                {
                    var objData = new ThrEscalaGroup();
                    objData.EscalaGroupID = txtnombreGrupo.Text;
                    objData.EscalaSalario = Convert.ToDecimal(txtSalarioEscala.Text);
                    objData.Descripcion = txtdescripcion.Text;
                    controler.AddEscalaGroup(objData);
                    UpdateLookup();
                }                             

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }      
        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        { 
            try
            {
                ThrEscalaGroup data = eventArgs.ReturnValue as ThrEscalaGroup;
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null, null);
                    EnableControls();
                }                
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

            if (this.txtnombreGrupo.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Nombre válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnombreGrupo.Focus();
                return false;
            }

            if (txtSalarioEscala.Text.Length > 0)
            {
                if (IDHandler.IsAlphaNumeric(txtSalarioEscala.Text))
                {
                    MessageBox.Show("El valor del Salario Escala no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSalarioEscala.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("El valor del Salario Escala no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void TxtSalarioEscala_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar)&&(e.KeyChar != '.'))
            { e.Handled = true; }
            if((e.KeyChar=='.') && ((sender as TextBox).Text.IndexOf('.')>-1))
             { e.Handled = true; }
        }
    }
}
