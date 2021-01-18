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

namespace RHSMDE001
{
    public partial class frmDatosEmpresa : Form
    {
        ControllerRHSMDE001 controler;
        public frmDatosEmpresa()
        {
            InitializeComponent();
            controler = new ControllerRHSMDE001();
        }
        public frmDatosEmpresa(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            LoadContext();
        }
        public void MostrarDatosRegistro(TsmCompany dato)
        {
            try
            {
                if (dato.StateTaxID != "")
                {
                    MainBS.Clear();
                    ControlllerRHSMP001 controller = new ControlllerRHSMP001();
                    txtSector.Text = "";
                    masktxtCuenta.Text = "";
                    txtContravalorPagoAdicional.Text = "";
                    txtContravalorPagoCuC.Text = "";
                    txtCodEmpresa.Text = dato.CompanyID;
                    txtNombre.Text = dato.CompanyName;
                    txttelefono.Text = dato.Phone;
                    txtfax.Text = dato.FAX;
                    txtcorreo.Text = dato.EMailAddr;
                    txtDireccion.Text = dato.AddrLine1;
                    txtCodigo.Text = dato.StateTaxID;
                    var data = controler.GetCompania(txtCodEmpresa.Text);
                    if (data != null)
                    {
                        CargarDatosIniciales();
                        masktxtCuenta.Text = data.CuentaBancaria;
                        txtContravalorPagoAdicional.Text = data.ContraEstipendioAlimenticio.ToString();
                        txtContravalorPagoCuC.Text = data.ContraValoPägoCuc.ToString();
                        cmbProvince.Text = controller.GetProvince(data.Province);
                        cmbMunicipality.Text = controller.GetMunicipality(data.Municipy);
                        cmbsegmento.SelectedValue = data.NoSegmentoCentro;
                        txtSector.Text = data.Sector;
                        ControllerRHSMUO001 control = new ControllerRHSMUO001();
                        var resultado = control.GetUnidadOrgaXCompania(txtCodEmpresa.Text);
                        if (resultado == null)
                        {
                            cmbsegmento.Enabled = true;
                        }
                        cmbsegmento.Enabled = false;
                    }
                    else { CargarDatosIniciales(); }
                }
                else
                {
                    MessageBox.Show("Debe configurar el Código ONEI de la empresa.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisableControls();
                    txtCodEmpresa.Enabled = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            txtCodEmpresa.Enabled = false;           
            txtContravalorPagoCuC.Enabled = true;
            txtContravalorPagoAdicional.Enabled = true;            
            cmbProvince.Enabled = true;
            cmbMunicipality.Enabled = true;           
            masktxtCuenta.Enabled = true;
            txtSector.Enabled = true;
        }
        private void DisableControls()
        {
            txtCodEmpresa.Enabled = true;
            txtNombre.Enabled = false;
            txtfax.Enabled = false;
            txtContravalorPagoCuC.Enabled = false;
            txtContravalorPagoAdicional.Enabled = false;
            txtDireccion.Enabled = false;
            txtcorreo.Enabled = false;
            cmbMunicipality.Enabled = false;
            txttelefono.Enabled = false;
            cmbProvince.Enabled = false;
            cmbsegmento.Enabled = false;
            masktxtCuenta.Enabled = false;
            txtCodigo.Enabled = false;
        }
        public void CargarDatosIniciales()
        {
            try
            {
                ControlllerRHSMP001 controldor = new ControlllerRHSMP001();
                cmbProvince.DataSource = controldor.GetaAllsStates();
                cmbProvince.DisplayMember = "StateID";
                cmbProvince.ValueMember = "Statekey";

                cmbsegmento.DataSource = controler.GetSegmentosCuenta(sageSession1.CompanyID);
                cmbsegmento.DisplayMember = "Description";
                cmbsegmento.ValueMember = "Segmentkey";
                cmbsegmento.Enabled = true;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar Datos Iniciales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           

        }       
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }        
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCodEmpresa.Tag != null && txtCodEmpresa.Tag.ToString() == txtCodEmpresa.Text) return;
            MainBS.Clear();

            if (txtCodEmpresa.Text.Length > 0)
            {
                var data = controler.GetCompaniaExistente(txtCodEmpresa.Text);                         
                if (data != null)
                {
                    MainBS.Add(data);
                    starBar.SetFormStatus(FormBindingStatus.Editing);
                }                
                EnableControls();              
            }
            else
            {
                DisableControls();
                starBar.SetFormStatus(FormBindingStatus.Waiting);
            }
            txtCodEmpresa.Tag = txtCodEmpresa.Text;
        }
        private void Do_Cancel(object sender, EventArgs e)
        {           
            txtCodEmpresa.Text = "";
            txtSector.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            txtfax.Text = "";
            txtContravalorPagoCuC.Text = "0";
            txtContravalorPagoAdicional.Text = "0";
            masktxtCuenta.Text = "";
            txtDireccion.Text = "";
            cmbProvince.Text = "";
            cmbMunicipality.Text = "";
            cmbsegmento.Text = "";
            DisableControls();
            On_IDChange(null, null);
            LoadContext();

        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    var resultado =  controler.DeleteDatosEmpresa(txtCodEmpresa.Text);
                    if (resultado)
                    {
                        MessageBox.Show("La empresa ha sido eliminada exitosamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbProvince.SelectedIndex = 0;
                        cmbMunicipality.SelectedIndex = 0;
                        cmbsegmento.SelectedIndex = 0;
                        UpdateLookup();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("La empresa no puede ser eliminada, contiene Unidades Organizativas asociadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar los datos de la empresa.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {                
                var objcomp = new ThrCompany();
                objcomp.CodigoCompany = txtCodEmpresa.Text;
                objcomp.Sector = txtSector.Text;
                objcomp.Province = Convert.ToInt16(cmbProvince.SelectedValue.ToString());
                objcomp.Municipy = Convert.ToInt16(cmbMunicipality.SelectedValue.ToString());
                objcomp.ContraValoPägoCuc = Convert.ToDecimal(txtContravalorPagoCuC.Text);
                objcomp.ContraEstipendioAlimenticio = Convert.ToDecimal(txtContravalorPagoAdicional.Text);
                objcomp.NoSegmentoCentro = Convert.ToInt16(cmbsegmento.SelectedValue.ToString());
                objcomp.CuentaBancaria = masktxtCuenta.Text;
                controler.AddDatosEmpresa(objcomp);

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
                TsmCompany data = eventArgs.ReturnValue as TsmCompany;
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
        private void CmbProvince_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ThrState estado = (cmbProvince.SelectedItem) as ThrState;
            using (var mycontext = new Sage500AppEntities(Conection.connectionString))
            {
                try
                {
                    if (cmbProvince.Text != "")
                    {
                        ControlllerRHSMP001 controler = new ControlllerRHSMP001();
                        cmbMunicipality.DataSource = controler.GetaAllsMunicipalyties(estado.Statekey);
                        cmbMunicipality.DisplayMember = "MunicipalityID";
                        cmbMunicipality.ValueMember = "Municipalitykey";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cargar municipios por provincias", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void TxtContravalorEstimpendio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void TxtContravalorPagoCuC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }       
        private bool ValidateForm(object sender, EventArgs e)
        {         
            if (this.txtCodEmpresa.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un valor de Empresa válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodEmpresa.Focus();
                return false;
            }
            if (this.txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Nombre válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (this.txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Código válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }
            if (this.masktxtCuenta.Text == "    -    -    -")
            {
                MessageBox.Show("Debe introducir un Número de Cuenta válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                masktxtCuenta.Focus();
                return false;
            }
            if (!this.masktxtCuenta.MaskFull)
            {
                MessageBox.Show("Debe introducir un Número de Cuenta válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                masktxtCuenta.Focus();
                return false;
            }
            if (this.txtContravalorPagoAdicional.Text == "0" || this.txtContravalorPagoAdicional.Text == "" || this.txtContravalorPagoAdicional.Text == "0.00")
            {
                MessageBox.Show("Debe introducir el Contravalor de Pago Adicional válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContravalorPagoAdicional.Focus();
                return false;
            }
            if (this.txtContravalorPagoCuC.Text == "0" || this.txtContravalorPagoCuC.Text == "" || this.txtContravalorPagoCuC.Text == "0.00")
            {
                MessageBox.Show("Debe introducir un Contravalor de Pago Alimenticio válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContravalorPagoCuC.Focus();
                return false;
            }
            if (this.cmbsegmento.Text == "")
            {
                MessageBox.Show("Debe introducir un Segmento de Cuenta de Centro de Costo válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbsegmento.Focus();
                return false;
            }
            return true;  
        }
        private void TxtCodEmpresa_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (txtCodEmpresa.Text != "")
                    {
                        if (!IDHandler.IsAlphaNumeric(txtCodEmpresa.Text))
                        {
                            MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var data = controler.GetCompaniaExistente(txtCodEmpresa.Text);
                            if (data != null)
                            {
                                MainBS.Add(data);
                                MostrarDatosRegistro(data);
                                starBar.SetFormStatus(FormBindingStatus.Editing);
                                EnableControls();
                            }
                            else
                            {
                                MessageBox.Show("La empresa no existe. Debe configurar los datos de la empresa en el Módulo Administración.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Do_Cancel(null, null);
                                DisableControls();
                            }

                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
