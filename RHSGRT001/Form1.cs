using Entidades.General;
//using Entidades.RHSGRT001;
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


namespace RHSGRT001
{
    public partial class frmRetencionesTrabajador : Form
    {
        ControllerRHSGRT001 controller;
        ControllerRHSGI001 controler;
        ThrPeople person;
        List<ThrPeople> listaPersonasSeleccionadas;
        List<clsRetencion> listaRetencionesSeleccionadas;
        ThrOperationsPeriod periodo;
        public frmRetencionesTrabajador()
        {
            InitializeComponent();
        }
        public frmRetencionesTrabajador(ref SageSession session) : this()
        {
            listaPersonasSeleccionadas = new List<ThrPeople>();
            controller = new ControllerRHSGRT001();
            controler = new ControllerRHSGI001();
            this.sageSession1.InitializeSession(session);
            LoadContext();
            CargarDatosIniciales();
            DisableControls();
        }
        private void EnableControls()
        {
            lvRetencion.Enabled = true;
            btnEliminar.Enabled = true;
            btnAdicionar.Enabled = true;
            txtSaldoTotal.Enabled = true;
            txtSaldoMensual.Enabled = true;
            txtSaldoTotal.Enabled = true;
            txtCausa.Enabled = true;
            dtpfechaInicio.Enabled = true;
            cmbretencion.Enabled = true;
        }
        private void DisableControls()
        {
            lvRetencion.Enabled = false;
            dtpfechaInicio.Enabled = false;
            btnEliminar.Enabled = false;
            btnAdicionar.Enabled = false;
            txtSaldoTotal.Enabled = false;
            txtSaldoMensual.Enabled = false;
            txtSaldoTotal.Enabled = false;
            cmbretencion.Enabled = false;
            txtCausa.Enabled = false;
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
                MessageBox.Show("Error en la carga de datos iniciales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    ControllerRHSMTR001 access = new ControllerRHSMTR001();
                    cmbretencion.DataSource = access.ActualizarLista();
                    cmbretencion.DisplayMember = "RetentionName";
                    cmbretencion.ValueMember = "Retentionkey";
                }
                MostrarRetecionesTrabajadores(person.PersonKey, periodo.Periodkey);

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos del trabajador seleccionado.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
           
        }
        public void MostrarRetecionesTrabajadores(int personkey, int periodo)
        {
            lvRetencion.Items.Clear();
            ControllerRHSGRT001 controler = new ControllerRHSGRT001();
            var ListaRetenciones = controler.GetRetencionesXTrabajador(personkey, periodo);
            if (ListaRetenciones.Count > 0)
            {
                ListViewItem items;
                ControllerRHSMTR001 control = new ControllerRHSMTR001();
                strbar.SetFormStatus(FormBindingStatus.Editing);
                foreach (clsRetencion item in ListaRetenciones)
                {
                    items = new ListViewItem();
                    var retention = control.GetRetencionKey(item.retentionkey);
                    items.Text = retention.RetentionName;
                    items.SubItems.Add(item.fechInicio.ToString());
                    items.SubItems.Add(item.saldoTotal.ToString());
                    items.SubItems.Add(item.saldoMensual.ToString());
                    items.SubItems.Add(item.saldoPendiente.ToString());
                    items.SubItems.Add(item.causa.ToString());
                    lvRetencion.Items.Add(items);
                    dtpfechaInicio.Value = DateTime.Now;                        
                }
                EnableControls();
            }
            else
            {
                strbar.SetFormStatus(FormBindingStatus.Adding);
                EnableControls();
            }

            
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
                MessageBox.Show("Error al cargar los datos de la persona.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if ((txtSaldoTotal.Text != "" && txtSaldoTotal.Text != "0") && (txtSaldoMensual.Text != "" && txtSaldoMensual.Text != "0") && txtCausa.Text != "")
            {
                if (Convert.ToDecimal(txtSaldoMensual.Text) <= Convert.ToDecimal(txtSaldoTotal.Text))
                {
                    if (dtpfechaInicio.Value >= periodo.PeriodFechaInicio && dtpfechaInicio.Value <= periodo.PeriodFechaFin)
                    {
                        bool bandera = false;
                        if (lvRetencion.Items.Count > 0)
                        {
                            foreach (ListViewItem lvitem in lvRetencion.Items)
                            {
                                if (lvitem.Text == cmbretencion.Text && dtpfechaInicio.Value.ToString() == lvitem.SubItems[1].Text)
                                {
                                    MessageBox.Show("La deducción que trata de adicionar coincide con los datos de otra deducción ya seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    bandera = true;
                                    return;
                                }
                                if (!bandera)
                                {
                                    ListViewItem item = new ListViewItem();
                                    item.Text = cmbretencion.Text;
                                    item.SubItems.Add(dtpfechaInicio.Value.ToString());
                                    item.SubItems.Add(txtSaldoTotal.Text);
                                    item.SubItems.Add(txtSaldoMensual.Text);
                                    decimal Pendiente = (Convert.ToDecimal(txtSaldoTotal.Text));
                                    item.SubItems.Add(Pendiente.ToString());
                                    item.SubItems.Add(txtCausa.Text);
                                    lvRetencion.Items.Add(item);
                                    dtpfechaInicio.Value = DateTime.Now;
                                    txtCausa.Text = "";
                                    txtSaldoMensual.Text = "0";
                                    txtSaldoTotal.Text = "0";
                                    txtCausa.Text = "";
                                    cmbretencion.SelectedIndex = 0;
                                }

                            }
                        }
                        else
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = cmbretencion.Text;
                            item.SubItems.Add(dtpfechaInicio.Value.ToString());
                            item.SubItems.Add(txtSaldoTotal.Text);
                            item.SubItems.Add(txtSaldoMensual.Text);
                            decimal Pendiente = (Convert.ToDecimal(txtSaldoTotal.Text));
                            item.SubItems.Add(Pendiente.ToString());
                            item.SubItems.Add(txtCausa.Text);
                            lvRetencion.Items.Add(item);
                            dtpfechaInicio.Value = DateTime.Now;
                            txtSaldoMensual.Text = "0";
                            txtSaldoTotal.Text = "0";
                            txtCausa.Text = "";
                            cmbretencion.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La fecha de inicio no se encuentra dentro del período activo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                { MessageBox.Show("Verifique, el saldo mensual no puede ser mayor al saldo total.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            { MessageBox.Show("Verifique, hay campos obligatorios que tienen que ser llenados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void TxtSaldoTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void TxtSaldoMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (lvRetencion.Items.Count > 0)
                {
                    listaRetencionesSeleccionadas = new List<clsRetencion>();
                    clsRetencion nuevoObj;
                    foreach (ListViewItem item in lvRetencion.Items)
                    {
                        nuevoObj = new clsRetencion();
                        nuevoObj.FechaRegister = DateTime.Now;
                        nuevoObj.personKey = person.PersonKey;
                        ControllerRHSMTR001 controler = new ControllerRHSMTR001();
                        var retention = controler.GetRetencionName(item.Text);
                        nuevoObj.retentionkey = retention.Retentionkey;
                        nuevoObj.fechInicio = Convert.ToDateTime(item.SubItems[1].Text);
                        nuevoObj.saldoTotal = Convert.ToDecimal(item.SubItems[2].Text);
                        nuevoObj.saldoMensual = Convert.ToDecimal(item.SubItems[3].Text);
                        nuevoObj.saldoPendiente = Convert.ToDecimal(item.SubItems[4].Text);
                        nuevoObj.causa = item.SubItems[5].Text;
                        nuevoObj.CreateUserID = sageSession1.UserID;
                        nuevoObj.CompanyID = sageSession1.CompanyID;
                        listaRetencionesSeleccionadas.Add(nuevoObj);
                    }
                    controller.AddRetencionesTrabajador(listaRetencionesSeleccionadas, periodo.Periodkey);
                }
                else
                { MessageBox.Show("Verifique, no ha seleccionado ningún tipo de retención.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ; }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar las retenciones.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            var resultado = false;
            try
            {
                DialogResult resul = MessageBox.Show("Desea eliminar las retenciones definidas para el trabajador seleccionado?.", "Sage MAS 500", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (resul == DialogResult.Yes)
                {
                    resultado = controller.EliminarDeduccionesXPersonas(person.PersonKey, periodo.Periodkey);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la retencion seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                throw;
            }
            return resultado;
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            lbldatosPersona.Text = "";
            txtCi.Text = "";
            txtSaldoTotal.Text = "0";
            txtSaldoMensual.Text = "0";
            cmbretencion.SelectedIndex = 0;
            txtCausa.Text = "";
            lvRetencion.Items.Clear();
            DisableControls();
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvRetencion.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvRetencion.SelectedItems)
                    {
                        lvRetencion.Items.Remove(item);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la(s) retenciones que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la(s) retención(es) seleccionada(s).", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
