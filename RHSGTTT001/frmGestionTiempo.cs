using Entidades.General;
//using Entidades.RHSGVT001;
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

namespace RHSGTTT001
{   
    public partial class frmGestionTiempo : Form
    {
        ControllerRHSGI001 controler = new ControllerRHSGI001();
        List<ThrPeople> listaPersonasSeleccionadas;
        ThrOperationsPeriod periodo;
        List<clsHorasCondiciones> listaCondicionesHoras;
        ThrPeople person;
        public frmGestionTiempo()
        {
            InitializeComponent();           
        }
        public frmGestionTiempo(ref SageSession session) : this()
        {
            listaPersonasSeleccionadas = new List<ThrPeople>();
            listaCondicionesHoras = new List<clsHorasCondiciones>();
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
                    ControllerRHSGTTT001 controler = new ControllerRHSGTTT001();
                    var position = controler.GetCargoTrabajador(person.PositionKey);
                    if (position != null)
                    {
                        // Si esta persona segun el cargo pertenece a la clasificacion de Tarifa 
                        if (position.ClasificationWorker == 1)
                        {
                            //txtdiasFeriados.Text = datatiempo.HolidayDays.ToString();
                            //txtHorasExtras.Text = datatiempo.ExtraHours.ToString();
                            //txthorasTrabajadas.Text = datatiempo.WorkedHours.ToString();
                            txthorasTrabajadas.Enabled = false;
                        }
                        else
                        {
                            //txtdiasFeriados.Text = datatiempo.HolidayDays.ToString();
                            //txtHorasExtras.Text = datatiempo.ExtraHours.ToString();
                            //txthorasTrabajadas.Text = datatiempo.WorkedHours.ToString();
                            txthorasTrabajadas.Enabled = true;
                        }
                    }
                    lbldatosPersona.Text = person.PrimerNombre + " " + person.SegundoNombre + " " + person.PrimerApellido + " " + person.SegundoApellido + " " + " " + " " + "CI:" + person.CI;
                    txtCi.Text = "";
                }
                MostrarDatosTiempoTrabajado(person.PersonKey, periodo.Periodkey);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos relacionados a la persona seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        public void MostrarDatosTiempoTrabajado(int personkey, int periodo)
        {                           
            ControllerRHSGTTT001 controler = new ControllerRHSGTTT001();
            var datatiempo = controler.GetTiempoTrabajado(personkey, periodo);
            if (datatiempo != null)
            {
                txtdiasFeriados.Text = datatiempo.HolidayDays.ToString();
                txtHorasExtras.Text = datatiempo.ExtraHours.ToString();
                txthorasTrabajadas.Text = datatiempo.WorkedHours.ToString();
                var condicionesAnormales = controler.GetCondicionesAnormalesXTrabajador(datatiempo.WorkedTimeKey);
                if (condicionesAnormales.Count > 0)
                {
                    listaCondicionesHoras = new List<clsHorasCondiciones>();
                    clsHorasCondiciones condicion;
                    ControllerRHSMCA001 control = new ControllerRHSMCA001();
                    foreach (ThrWorkedTimeAnormalCondition item in condicionesAnormales)
                    {
                        condicion = new clsHorasCondiciones();
                        var condi = control.GetAnormalCondicion(item.AnormalConditionkey);
                        condicion.CondicionName = condi.AnormalName;
                        condicion.CantHoras = item.WorkAnormalHours;
                        listaCondicionesHoras.Add(condicion);
                    }
                    MostrarCondicionesSeleccionadas(listaCondicionesHoras);
                }
                else
                { grbCondicionesAnorm.Enabled = true; }
            }
            else
            {
                decimal valortotalHoras = Convert.ToDecimal(190.6);
                decimal calculohoras = CantidadHorasIncidencias();
                decimal calculoVacaciones = CantidadHorasVacaciones();
                decimal horasTrabaj = valortotalHoras - calculohoras - calculoVacaciones;
                txthorasTrabajadas.Text = horasTrabaj.ToString();
                EnableControls();
                grbCondicionesAnorm.Enabled = true;                    
            } 
        }
        public void MostrarCondicionesSeleccionadas(List<clsHorasCondiciones> listaSeleccion)
        {
            if (listaSeleccion.Count > 0)
            {
                ListViewItem objitem;
                lvCondiciones.Items.Clear();
                foreach (clsHorasCondiciones condhoras in listaSeleccion)
                {
                    objitem = new ListViewItem(condhoras.CondicionName);
                    objitem.SubItems.Add(condhoras.CantHoras.ToString());
                    lvCondiciones.Items.Add(objitem);
                }
                btnBuscarCondAnormales.Enabled = false;
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
        private void BtnBuscarCondAnormales_Click(object sender, EventArgs e)
        {
            frmCondicionesAnormales formBuscarCondicionesHoras = new frmCondicionesAnormales(listaCondicionesHoras,person.PositionKey);
            if (formBuscarCondicionesHoras.ShowDialog() == DialogResult.OK)
            {
                listaCondicionesHoras = formBuscarCondicionesHoras.listCondicionesHoras;
                if (listaCondicionesHoras.Count > 0)
                {                    
                    MostrarCondicionesSeleccionadas(listaCondicionesHoras);
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
                MessageBox.Show("Error al cargar los datos de la persona con sus datos de tiempo trabajado y condiciones anormales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }
        public List<clsHorasCondiciones> DevolverListaCondicionesHours()
        {
            List<clsHorasCondiciones> listaCondiciones = new List<clsHorasCondiciones>();
            clsHorasCondiciones objCondition;
            ControllerRHSMCA001 controler = new ControllerRHSMCA001();
            foreach (ListViewItem item in lvCondiciones.Items)
            {                
                var condicion = controler.GetAnormalCondition(item.Text.ToString());
                objCondition = new clsHorasCondiciones();
                objCondition.conditionkey = condicion.AnormalConditionkey;
                objCondition.CantHoras = Convert.ToDecimal(item.SubItems[1].Text);
                listaCondiciones.Add(objCondition);
            }
            return listaCondiciones;
        }
        public decimal CantidadHorasIncidencias()
        {
            try
            {
                ControllerRHSGI001 controler = new ControllerRHSGI001();
                decimal totalHorasXIncidencias = 0;
                var ausencias = controler.GetaAllsAusenciasxPersona(person.PersonKey, periodo.Periodkey);
                var licencias = controler.GetaAllsLicenciasxPersona(person.PersonKey, periodo.Periodkey);
                var otrasIncidencias = controler.GetaAllsOtrasIncidenciasxPersona(person.PersonKey, periodo.Periodkey);
                var subsidios = controler.GetaAllsSubsidiosxPersona(person.PersonKey, periodo.Periodkey);
                if (ausencias.Count > 0)
                {
                    decimal totalHorasAusencias = 0;
                    foreach (ThrPeopleAbsence item in ausencias)
                    {
                        TimeSpan result = item.AbsenceFechaFin.Subtract(item.AbsenceFechaInicio);
                        totalHorasAusencias = totalHorasAusencias + Convert.ToDecimal(result.TotalHours);
                    }
                    totalHorasXIncidencias = totalHorasXIncidencias + totalHorasAusencias;
                }
                if (licencias.Count > 0)
                {
                    var dias = 0;
                    foreach (ThrPeopleLicence item in licencias)
                    {
                        DateTime fechaInicio = item.LicenceFechaInicio.Date;
                        DateTime fechaFin = item.LicenceFechaFin.Date;
                        while (fechaInicio <= fechaFin)
                        {
                            if (fechaInicio.DayOfWeek != DayOfWeek.Saturday && fechaInicio.DayOfWeek != DayOfWeek.Sunday)
                            {
                                dias++;
                                fechaInicio = fechaInicio.AddDays(1);
                            }
                            else
                            { fechaInicio = fechaInicio.AddDays(1); }
                        }
                    }
                    totalHorasXIncidencias = totalHorasXIncidencias + dias * 8;
                }
                if (otrasIncidencias.Count > 0)
                {
                    var dias = 0;
                    foreach (ThrPeopleIncidence item in otrasIncidencias)
                    {
                        DateTime fechaInicio = item.IncidenceFechaInicio.Date;
                        DateTime fechaFin = item.IncidenceFechaFin.Date;
                        while (fechaInicio <= fechaFin)
                        {
                            if (fechaInicio.DayOfWeek != DayOfWeek.Saturday && fechaInicio.DayOfWeek != DayOfWeek.Sunday)
                            {
                                dias++;
                                fechaInicio = fechaInicio.AddDays(1);
                            }
                            else
                            { fechaInicio = fechaInicio.AddDays(1); }
                        }
                    }
                    totalHorasXIncidencias = totalHorasXIncidencias + (dias * 8);
                }
                if (subsidios.Count > 0)
                {
                    var dias = 0;
                    foreach (ThrPeopleSubsidy item in subsidios)
                    {
                        DateTime fechaInicio = item.SubsidyFechaInicio.Date;
                        DateTime fechaFin = item.SubsidyFechaFin.Date;
                        while (fechaInicio <= fechaFin)
                        {
                            if (fechaInicio.DayOfWeek != DayOfWeek.Saturday && fechaInicio.DayOfWeek != DayOfWeek.Sunday)
                            {
                                dias++;
                                fechaInicio = fechaInicio.AddDays(1);
                            }
                            else
                            { fechaInicio = fechaInicio.AddDays(1); }
                        }
                    }
                    totalHorasXIncidencias = totalHorasXIncidencias + (dias * 8);
                }
                return totalHorasXIncidencias;

            }
            catch (Exception)
            {
                MessageBox.Show("Error en el cálculo de las horas de incidencia.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }
        public decimal CantidadHorasVacaciones()
        {
            ControllerRHSGVT001 controler = new ControllerRHSGVT001();
            var vacation = controler.GetVacacionesXTrabajados(person.PersonKey, periodo.Periodkey);
            decimal horasDisfrutadas = 0;
            foreach (clsVacaciones item in vacation)
            {
                if (item.fechInicio >= periodo.PeriodFechaInicio && item.fechaFin <= periodo.PeriodFechaFin)
                {
                    horasDisfrutadas = horasDisfrutadas + item.horasDisfrutadas;
                }
            }
            return horasDisfrutadas;
        }
        private void Do_Save(object sender, EventArgs e)
        { 
            if (periodo != null)
            {
                var objtiempoTrabajado = new clsTiempoTrabajo();
                objtiempoTrabajado.PersonKey = person.PersonKey;
                objtiempoTrabajado.periodoActivo = periodo.Periodkey;
                if (txtHorasExtras.Text.Length > 0)
                {
                    objtiempoTrabajado.horasExtras = Convert.ToDecimal(txtHorasExtras.Text);
                }
                else
                { objtiempoTrabajado.horasExtras = 0; }
                if (txtdiasFeriados.Text.Length > 0)
                {
                    objtiempoTrabajado.diasFeriados = Convert.ToInt32(txtdiasFeriados.Text);
                }
                else
                {
                    objtiempoTrabajado.diasFeriados = 0;
                } 
                //decimal valortotalHoras = Convert.ToDecimal(190.6);
                //decimal calculohoras = CantidadHorasIncidencias();
                //objtiempoTrabajado.horasTabajadas = valortotalHoras - calculohoras;
                objtiempoTrabajado.listaCondicionesHoras = DevolverListaCondicionesHours();
                objtiempoTrabajado.horasTabajadas = Convert.ToDecimal(txthorasTrabajadas.Text);
                ControllerRHSGTTT001 controller = new ControllerRHSGTTT001();
                controller.AddTiempoTrabajado(objtiempoTrabajado);
            }
            else
            { MessageBox.Show("No existe un periodo abierto para gestionar el tiempo de trabajo a los trabajadores.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            lbldatosPersona.Text = "";
            txtCi.Text = "";
            lvCondiciones.Items.Clear();
            txtdiasFeriados.Text = "0";
            txtHorasExtras.Text = "0";
            txthorasTrabajadas.Text = "0";
            DisableControls();
        }
        private void EnableControls()
        {            
            lvCondiciones.Enabled = true;
            txtHorasExtras.Enabled = true;
            //txthorasTrabajadas.Enabled = true;
            txtdiasFeriados.Enabled = true;
            btnBuscarCondAnormales.Enabled = true;
        }
        private void DisableControls()
        {
            lvCondiciones.Enabled = false;
            txtHorasExtras.Enabled = false;
           // txthorasTrabajadas.Enabled = false;
            txtdiasFeriados.Enabled = false;
            btnBuscarCondAnormales.Enabled = false;
        }
        private void FrmGestionTiempo_Load(object sender, EventArgs e)
        {

        }
        private bool ValidateForm(object sender, EventArgs e)
        {
            if (this.txtdiasFeriados.Text == "")
            {
                MessageBox.Show("Debe introducir un Nombre válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtNombre.Focus();
                return false;
            }
            return true;

        }
        private void TxtHorasExtras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void TxtdiasFeriados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { e.Handled = true; }            
        }
        private void TxthorasTrabajadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }

        private void GrbTrabajadores_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LvCondiciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GrbDatosJornalero_Enter(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void TxtHorasExtras_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
