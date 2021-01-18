using Entidades.General;
using Negocio;
using Net4Sage;
using Net4Sage.Controls;
using RHSST001;
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

namespace RHSGDT001
{
    public partial class frmGestionDeducciones : Form
    {
        ControllerRHSGDT001 controller;
        ControllerRHSGI001 controler;       
        ThrPeople person;
        List<ThrPeople> listaPersonasSeleccionadas;
        List<clsDeduccion> listaDeduccionesSeleccionadas;
        ThrOperationsPeriod periodo;
        public frmGestionDeducciones()
        {
            InitializeComponent();
        }
        public frmGestionDeducciones(ref SageSession session) : this()
        {
            listaPersonasSeleccionadas = new List<ThrPeople>();
            controller = new ControllerRHSGDT001();
            controler = new ControllerRHSGI001();
            this.sageSession1.InitializeSession(session);            
            LoadContext();
            CargarDatosIniciales();
            DisableControls();

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
        private void Form_Show(object sender, EventArgs e)
        {

        }
        public void CargarDatosIniciales()
        {
            try
            {
                ControllerRHSMGP001 open = new ControllerRHSMGP001();
                periodo = open.GetPeriodoActivo();
                if (periodo != null)
                {
                    lblPeriodoActivo.Text = periodo.PeriodFechaInicio.ToShortDateString() + " " + "-" + " " + periodo.PeriodFechaFin.ToShortDateString();
                    ControllerRHSGI001 controler = new ControllerRHSGI001();
                    cmbUnidadesOrganizativas.DataSource = controler.GetaAllsUnidadesAdministrativas();
                    cmbUnidadesOrganizativas.DisplayMember = "Name";
                    cmbUnidadesOrganizativas.ValueMember = "OrgUnitKey";

                }
                else
                {
                    MessageBox.Show("No existe un periodo abierto para gestionar el tiempo de trabajo a los trabajadores.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DisableControls();
                    cmbUnidadesOrganizativas.Enabled = false;
                    txtCi.Enabled = false;
                    btnBuscar.Enabled = false;
                    grbSeleccionarTRabajador.Enabled = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar datos iniciales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }      
        public void MostrarPersonasSeleccionadas(List<ThrPeople> listaSeleccion)
        {
            try
            {
                if (listaSeleccion.Count > 0)
                {
                    person = new ThrPeople();
                    person = listaSeleccion[0];
                    lbldatosPersona.Text = person.PrimerNombre + " " + person.SegundoNombre + " " + person.PrimerApellido + " " + person.SegundoApellido + " " + " " + " " + "CI:" + person.CI;
                    txtCi.Text = "";
                    ControllerRHSMTD001 access = new ControllerRHSMTD001();
                    cmbdeduccion.DataSource = access.ActualizarLista();
                    cmbdeduccion.DisplayMember = "DeductionID";
                    cmbdeduccion.ValueMember = "DeductionKey";
                }
                MostrarDeduccionesTrabajadores(person.PersonKey, periodo.Periodkey);

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar datos de la Persona.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }
        public void MostrarDeduccionesTrabajadores(int personkey, int periodo)
        {
            try
            {
                lvDeducciones.Items.Clear();
                ControllerRHSGDT001 controler = new ControllerRHSGDT001();
                var Listdeducciones = controler.GetDeduccionesXTrabajador(personkey, periodo);
                if (Listdeducciones.Count > 0)
                {
                    ListViewItem items;
                    ControllerRHSMTD001 control = new ControllerRHSMTD001();
                    starbar.SetFormStatus(FormBindingStatus.Editing);
                    foreach (clsDeduccion item in Listdeducciones)
                    {
                        items = new ListViewItem();
                        var deduction = control.GetDeductionKey(item.deductionkey);
                        items.Text = deduction.DeductionID;
                        items.SubItems.Add(item.fechInicio.ToString());
                        items.SubItems.Add(item.saldoTotal.ToString());
                        items.SubItems.Add(item.cuotaMensual.ToString());
                        items.SubItems.Add(item.saldoPendiente.ToString());
                        lvDeducciones.Items.Add(items);
                        dtpfechaInicio.Value = DateTime.Now;
                    }
                    EnableControls();
                }
                else
                {
                    starbar.SetFormStatus(FormBindingStatus.Adding);
                    EnableControls();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos de las deducciones asociadas al trabajador.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EnableControls()
        {
            lvDeducciones.Enabled = true;
            btnEliminar.Enabled = true;
            btnAdicionar.Enabled = true;
            txtSaldoTotal.Enabled = true;
            txtCuotaMensual.Enabled = true;
            txtSaldoTotal.Enabled = true;
            dtpfechaInicio.Enabled = true;
            cmbdeduccion.Enabled = true;
        }
        private void DisableControls()
        {
            lvDeducciones.Enabled = false;
            dtpfechaInicio.Enabled = false;
            btnEliminar.Enabled = false;
            btnAdicionar.Enabled = false;
            txtSaldoTotal.Enabled = false;
            txtCuotaMensual.Enabled = false;
            txtSaldoTotal.Enabled = false;
            cmbdeduccion.Enabled = false;
        }
        private void TxtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                int unitKey = Convert.ToInt16(cmbUnidadesOrganizativas.SelectedValue);
                var person = controler.GetPersona(unitKey, txtCi.Text);
                if (person == null)
                {
                    frmBuscarTrabajador formBuscarTrabajador = new frmBuscarTrabajador(Convert.ToInt16(cmbUnidadesOrganizativas.SelectedValue));
                    if (formBuscarTrabajador.ShowDialog() == DialogResult.OK)
                    {
                        listaPersonasSeleccionadas = formBuscarTrabajador.listaPersonasSeleccionadas;
                        if (listaPersonasSeleccionadas.Count > 0)
                        {
                            var persona = controler.GetPersona(unitKey, listaPersonasSeleccionadas[0].CI);
                            listaPersonasSeleccionadas.Clear();
                            listaPersonasSeleccionadas.Add(persona);
                            MostrarPersonasSeleccionadas(listaPersonasSeleccionadas);
                            EnableControls();
                        }
                    }
                }
                else
                {
                    listaPersonasSeleccionadas.Clear();
                    listaPersonasSeleccionadas.Add(person);
                    MostrarPersonasSeleccionadas(listaPersonasSeleccionadas);
                    EnableControls();
                    txtCi.Clear();
                }
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int unitKey = Convert.ToInt16(cmbUnidadesOrganizativas.SelectedValue);
                var person = controler.GetPersona(unitKey, txtCi.Text);
                if (person == null)
                {
                    frmBuscarTrabajador formBuscarTrabajador = new frmBuscarTrabajador(Convert.ToInt16(cmbUnidadesOrganizativas.SelectedValue));
                    if (formBuscarTrabajador.ShowDialog() == DialogResult.OK)
                    {
                        listaPersonasSeleccionadas = formBuscarTrabajador.listaPersonasSeleccionadas;
                        if (listaPersonasSeleccionadas.Count > 0)
                        {
                            var persona = controler.GetPersona(unitKey, listaPersonasSeleccionadas[0].CI);
                            listaPersonasSeleccionadas.Clear();
                            listaPersonasSeleccionadas.Add(persona);
                            MostrarPersonasSeleccionadas(listaPersonasSeleccionadas);
                        }
                    }
                }
                else
                {
                    listaPersonasSeleccionadas.Clear();
                    listaPersonasSeleccionadas.Add(person);
                    MostrarPersonasSeleccionadas(listaPersonasSeleccionadas);
                    txtCi.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos de la persona con sus deducciones.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtSaldoTotal.Text != "" && txtSaldoTotal.Text != "0") && (txtCuotaMensual.Text != "" && txtCuotaMensual.Text != "0"))
                {
                    if (Convert.ToDecimal(txtCuotaMensual.Text) <= Convert.ToDecimal(txtSaldoTotal.Text))
                    {
                        if (dtpfechaInicio.Value >= periodo.PeriodFechaInicio && dtpfechaInicio.Value <= periodo.PeriodFechaFin)
                        {
                            bool bandera = false;
                            if (lvDeducciones.Items.Count > 0)
                            {
                                foreach (ListViewItem lvitem in lvDeducciones.Items)
                                {
                                    if (lvitem.Text == cmbdeduccion.Text && dtpfechaInicio.Value.ToString() == lvitem.SubItems[1].Text)
                                    {
                                        MessageBox.Show("La deducción que trata de adicionar coincide con los datos de otra deducción ya seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bandera = true;
                                        return;
                                    }
                                    if (!bandera)
                                    {
                                        ListViewItem item = new ListViewItem();
                                        item.Text = cmbdeduccion.Text;
                                        item.SubItems.Add(dtpfechaInicio.Value.ToString());
                                        item.SubItems.Add(txtSaldoTotal.Text);
                                        item.SubItems.Add(txtCuotaMensual.Text);
                                        decimal Pendiente = (Convert.ToDecimal(txtSaldoTotal.Text));
                                        item.SubItems.Add(Pendiente.ToString());
                                        lvDeducciones.Items.Add(item);
                                        dtpfechaInicio.Value = DateTime.Now;
                                        txtSaldoTotal.Text = "0";
                                        txtCuotaMensual.Text = "0";
                                        cmbdeduccion.SelectedIndex = 0;
                                    }

                                }
                            }
                            else
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = cmbdeduccion.Text;
                                item.SubItems.Add(dtpfechaInicio.Value.ToString());
                                item.SubItems.Add(txtSaldoTotal.Text);
                                item.SubItems.Add(txtCuotaMensual.Text);
                                decimal Pendiente = (Convert.ToDecimal(txtSaldoTotal.Text));
                                item.SubItems.Add(Pendiente.ToString());
                                lvDeducciones.Items.Add(item);
                                dtpfechaInicio.Value = DateTime.Now;
                                txtSaldoTotal.Text = "0";
                                txtCuotaMensual.Text = "0";
                                cmbdeduccion.SelectedIndex = 0;
                            }

                        }
                        else
                        {
                            MessageBox.Show("La fecha de inicio no se encuentra dentro del período activo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    { MessageBox.Show("Verifique, la cuota mensual no puede ser mayor q el saldo Total.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                { MessageBox.Show("Verifique, el campo Saldo Total y el campo Cuota Mensual tienen que ser mayor que 0.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al adicionar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvDeducciones.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvDeducciones.SelectedItems)
                    {
                        lvDeducciones.Items.Remove(item);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la(s) deducción que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la(s) deducciones seleccionadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (lvDeducciones.Items.Count > 0)
                {
                    listaDeduccionesSeleccionadas = new List<clsDeduccion>();
                    clsDeduccion nuevoObj;
                    foreach (ListViewItem item in lvDeducciones.Items)
                    {
                        nuevoObj = new clsDeduccion();
                        nuevoObj.FechaRegister = DateTime.Now;
                        nuevoObj.personKey = person.PersonKey;
                        ControllerRHSMTD001 controler = new ControllerRHSMTD001();
                        var deduction = controler.GetDeductionName(item.Text);
                        nuevoObj.deductionkey = deduction.DeductionKey;
                        nuevoObj.fechInicio = Convert.ToDateTime(item.SubItems[1].Text);
                        nuevoObj.saldoTotal = Convert.ToDecimal(item.SubItems[2].Text);
                        nuevoObj.cuotaMensual = Convert.ToDecimal(item.SubItems[3].Text);
                        nuevoObj.saldoPendiente = Convert.ToDecimal(item.SubItems[4].Text);
                        nuevoObj.CreateUserID = sageSession1.UserID;
                        nuevoObj.CompanyID = sageSession1.CompanyID;

                        listaDeduccionesSeleccionadas.Add(nuevoObj);
                    }
                    controller.AddDeduccionesTrabajador(listaDeduccionesSeleccionadas, periodo.Periodkey);
                }
                else
                { MessageBox.Show("Verifique, no ha seleccionado ningún tipo de deducción.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ; }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar las deducciones seleccionadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            var resultado = false;
            try
            {
                DialogResult resul = MessageBox.Show("Desea eliminar las deducciones definidas para el trabajador seleccionado?.", "Sage MAS 500", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                
                if (resul == DialogResult.Yes)
                {
                    resultado = controller.EliminarDeduccionesXPersonas(person.PersonKey, periodo.Periodkey);
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la deducción seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }              
            return resultado;
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            lbldatosPersona.Text = "";
            txtCi.Text = "";
            txtSaldoTotal.Text = "0";
            txtCuotaMensual.Text = "0";
            cmbdeduccion.SelectedIndex = 0;
            lvDeducciones.Items.Clear();
            DisableControls();
        }
        private void TxtSaldoTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void TxtCuotaMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
    }
}
