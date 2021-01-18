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

namespace RHSMCA001
{
    public partial class frmCondicionesAnormales : Form
    {       
        ControllerRHSMCA001 controler;
        public frmCondicionesAnormales()
        {
            InitializeComponent();
            controler = new ControllerRHSMCA001();
        }
        public frmCondicionesAnormales(ref SageSession session) : this()
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
            lkuNav.SetData(controler.ActualizarLista());
        }
        private void EnableControls()
        {            
            txtCodAnorCond.Enabled = false;
            txtNombre.Enabled = true;
            txtTarifaMonto.Enabled = true;
            txtResolucion.Enabled = true;
        }
        private void DisableControls()
        {
            txtCodAnorCond.Enabled = true;
            txtNombre.Enabled = false;
            txtTarifaMonto.Enabled = false;
            txtResolucion.Enabled = false;
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCodAnorCond.Tag != null && txtCodAnorCond.Tag.ToString() == txtCodAnorCond.Text) return;
            MainBS.Clear();

            if (txtCodAnorCond.Text.Length > 0)
            {
                ThrAnormalCondition data = controler.GetAnormalConditionXID(txtCodAnorCond.Text);
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
            txtCodAnorCond.Tag = txtCodAnorCond.Text;
        }
        private void IDValidate(object sender, CancelEventArgs e)
        {
            if (!IDHandler.IsAlphaNumeric(txtCodAnorCond.Text))
            {
                MessageBox.Show("El código no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtCodAnorCond.Text = "";
            txtNombre.Text = "";
            txtTarifaMonto.Text = "";
            txtResolucion.Text = "";
            DisableControls();
            LoadContext();
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCodAnorCond.Text != "")
                {
                    bool result;
                    result = controler.DeleteAnormalCondition(txtCodAnorCond.Text);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, la Condición Anormal ha sido asignada a Cargos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la Condición Anormal", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCodAnorCond.Text != "")
                {
                    var objData = new ThrAnormalCondition();
                    objData.AnormalCondID = txtCodAnorCond.Text;
                    objData.AnormalName = txtNombre.Text;
                    if (txtTarifaMonto.Text != "")
                    {
                        objData.AnormalTarifa = Convert.ToDecimal(txtTarifaMonto.Text);
                    }
                    else
                    { objData.AnormalTarifa = Convert.ToDecimal(0.00); }
                    objData.AnormalResolution = txtResolucion.Text;                    
                    controler.AddAnormalCondition(objData);
                    UpdateLookup();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar los datos de la Condición Anormal.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateForm(object sender, EventArgs e)
        {
            if (MainBS.Current == null) return false;
            ValidateChildren();
            Validate();
            
            if (txtCodAnorCond.Text.Length > 0)
            {
                if (!IDHandler.IsAlphaNumeric(txtCodAnorCond.Text))
                {
                    MessageBox.Show("Código no válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodAnorCond.Focus();
                    return false;
                }
            }
            if (txtNombre.Text == "")
            {                
                MessageBox.Show("Nombre no válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodAnorCond.Focus();
                return false;                
            }
            return true;
        }
        public void MostrarDatosRegistro(ThrAnormalCondition dato)
        {
            ThrAnormalCondition data = dato;
            txtCodAnorCond.Text = data.AnormalCondID;
            txtNombre.Text = data.AnormalName;
            txtTarifaMonto.Text = data.AnormalTarifa.ToString();
            txtResolucion.Text = data.AnormalResolution;
        }
        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {
            ThrAnormalCondition data = eventArgs.ReturnValue as ThrAnormalCondition;
            try
            {
                if (data != null)
                {
                    MostrarDatosRegistro(data);
                    On_IDChange(null,null);
                    EnableControls();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos de la Condición Anormal.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void TxtCodAnorCond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodAnorCond.Text != "")
                {
                    if (!IDHandler.IsAlphaNumeric(txtCodAnorCond.Text))
                    {
                        MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ControllerRHSMCA001 controler = new ControllerRHSMCA001();
                        ThrAnormalCondition data = controler.GetAnormalConditionXID(txtCodAnorCond.Text);
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
        }
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }
        private void TxtTarifaMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
    }
}
