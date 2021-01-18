using Negocio;
using Net4Sage;
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
using Net4Sage.Controls;
//using Entidades.RHSGVT001;
using Entidades.General;

namespace RHSGVT001
{
    public partial class frmVacaciones : Form
    {
        ControllerRHSGVT001 controller;
        ControllerRHSGI001 controler;
        List<ThrPeople> listaPersonasSeleccionadas;
        List<clsVacaciones> listaVacacionesSeleccionadas;
        public List<clsAusencia> listaAusenciasSeleccionadas;
        public List<clsLicencia> listaLicenciaSeleccionadas;
        public List<clsSubsidios> listaSubsidiosSeleccionadas;
        public List<clsOtraIncidencia> listaOtrasSeleccionadas;
        int acumulado;
        ThrPeople person;
        ThrOperationsPeriod periodo;
        public frmVacaciones()
        {
            InitializeComponent();           
        }
        public frmVacaciones(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            person = new ThrPeople();
            acumulado = 0;
            controller = new ControllerRHSGVT001();
            controler = new ControllerRHSGI001();
            listaPersonasSeleccionadas = new List<ThrPeople>();
            listaAusenciasSeleccionadas = new List<clsAusencia>();
            listaLicenciaSeleccionadas = new List<clsLicencia>();
            listaSubsidiosSeleccionadas = new List<clsSubsidios>();
            listaOtrasSeleccionadas = new List<clsOtraIncidencia>();
            LoadContext();
            CargarDatosIniciales();
            DisableControls();
        }
        private void EnableControls()
        {
            dtpfechaFin.Enabled = true;
            dtpfechaInicio.Enabled = true;
            lvVacaciones.Enabled = true;
            btnAdicionrVacaciones.Enabled = true;
            grbDatosvac.Enabled = true;
            btnAdicionrVacaciones.Enabled = true;
        }
        private void DisableControls()
        {
            txtaumuladoVacaciones.Enabled = false;
            dtpfechaFin.Enabled = false;
            dtpfechaInicio.Enabled = false;
            lvVacaciones.Enabled = false;
            btnAdicionrVacaciones.Enabled = false;
            grbDatosvac.Enabled = false;
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
        public void MostrarPersonasSeleccionadas(List<ThrPeople> listaSeleccion)
        {
           
            if (listaSeleccion.Count > 0)
            {
                acumulado = 0;
                var ausencias = controler.GetaAllsAusenciasxPersona(listaSeleccion[0].PersonKey, periodo.Periodkey);
                var licencias = controler.GetaAllsLicenciasxPersona(listaSeleccion[0].PersonKey, periodo.Periodkey);
                var otrasIncidencias = controler.GetaAllsOtrasIncidenciasxPersona(listaSeleccion[0].PersonKey, periodo.Periodkey);
                var subsidios = controler.GetaAllsSubsidiosxPersona(listaSeleccion[0].PersonKey, periodo.Periodkey);
                if (ausencias.Any())
                {
                    listaAusenciasSeleccionadas = new List<clsAusencia>();
                    clsAusencia objAusencia;                    
                    foreach (ThrPeopleAbsence item in ausencias)
                    {
                        objAusencia = new clsAusencia();
                        objAusencia.tipoAusencia = item.AbsenceKey;
                        objAusencia.fechInicio = item.AbsenceFechaInicio;
                        objAusencia.fechaFin = item.AbsenceFechaFin;
                        listaAusenciasSeleccionadas.Add(objAusencia);
                    }
                }
                if (licencias.Any())
                {
                    clsLicencia objLicencias;
                    listaLicenciaSeleccionadas = new List<clsLicencia>();
                    foreach (ThrPeopleLicence item in licencias)
                    {
                        objLicencias = new clsLicencia();
                        objLicencias.tipoLicencia = item.LicenceKey;
                        objLicencias.fechInicio = item.LicenceFechaInicio;
                        objLicencias.fechaFin = item.LicenceFechaFin;
                        listaLicenciaSeleccionadas.Add(objLicencias);
                    }
                }
                if (otrasIncidencias.Any())
                {
                    clsOtraIncidencia objOtraIncidencia;
                    listaOtrasSeleccionadas = new List<clsOtraIncidencia>();
                    foreach (ThrPeopleIncidence item in otrasIncidencias)
                    {
                        objOtraIncidencia = new clsOtraIncidencia();
                        objOtraIncidencia.tipoOtraIncidencia = item.IncidenceKey;
                        objOtraIncidencia.fechInicio = item.IncidenceFechaInicio;
                        objOtraIncidencia.fechaFin = item.IncidenceFechaFin;
                        listaOtrasSeleccionadas.Add(objOtraIncidencia);
                    }
                }
                if (subsidios.Any())
                {
                    clsSubsidios subsidy;
                    listaSubsidiosSeleccionadas = new List<clsSubsidios>();
                    foreach (ThrPeopleSubsidy item in subsidios)
                    {
                        subsidy = new clsSubsidios();
                        subsidy.tipoSubsidio = item.SubsidyKey;
                        subsidy.fechInicio = item.SubsidyFechaInicio;
                        subsidy.fechaFin = item.SubsidyFechaFin;
                        subsidy.Subsidioinicio = item.SubsidyInicio;
                        subsidy.hospitalizado = item.SubsidyHospitalizado;
                        listaSubsidiosSeleccionadas.Add(subsidy);
                    }
                }
                person = listaSeleccion[0];                
                lbldatosPersona.Text = person.PrimerNombre + " " + person.SegundoNombre + " " + person.PrimerApellido + " " + person.SegundoApellido + " " + " " + " " + "CI:" + person.CI;
                txtCi.Text = person.CI;
                txtaumuladoVacaciones.Text = person.AcumuladoVacations.ToString();
                txtaumuladoVacaciones.Enabled = false;
            }
            MostrarVacacionesTrabajador(person, periodo.Periodkey);
        }
        public void MostrarVacacionesTrabajador(ThrPeople persona, int periodo)
        {
            try
            {
                lvVacaciones.Items.Clear();
                ControllerRHSGVT001 controler = new ControllerRHSGVT001();
                var Listvacaciones = controler.GetVacacionesXTrabajados(persona.PersonKey , periodo);
                ControllerRHSGTTT001 control = new ControllerRHSGTTT001();
                var datosTiempotrabajado = control.GetTiempoTrabajado(persona.PersonKey, periodo);
                if (datosTiempotrabajado == null)
                {
                    if (persona.AcumuladoVacations > 0)
                    {
                        if (Listvacaciones.Count > 0)
                        {
                            ListViewItem items;
                            strbar.SetFormStatus(FormBindingStatus.Editing);
                            foreach (clsVacaciones item in Listvacaciones)
                            {
                                items = new ListViewItem();
                                items.Text = item.fechInicio.ToString();
                                items.SubItems.Add(item.fechaFin.ToString());
                                items.SubItems.Add(item.horasDisfrutadas.ToString());
                                lvVacaciones.Items.Add(items);
                                dtpfechaInicio.Value = DateTime.Now;
                                dtpfechaFin.Value = DateTime.Now;
                            }
                            EnableControls();
                        }
                        else
                        {
                            strbar.SetFormStatus(FormBindingStatus.Adding);
                            EnableControls();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La persona seleccionada no tiene acumulado de vacaciones.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                        DisableControls();
                    }
                }
                else
                {
                    MessageBox.Show("La persona seleccionada tiene gestionado su Tiempo de Trabajo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DisableControls();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos de las vacaciones asociadas al trabajador.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
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
            }
        }
        public bool VerificacionIncidencias()
        {
            if (listaLicenciaSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaLicenciaSeleccionadas.Count; i++)
                {
                    if ((dtpfechaInicio.Value >= listaLicenciaSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaLicenciaSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaLicenciaSeleccionadas[i].fechInicio) && (dtpfechaFin.Value >= listaLicenciaSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaLicenciaSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaLicenciaSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaLicenciaSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaLicenciaSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaLicenciaSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                }
            }
            if (listaAusenciasSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaAusenciasSeleccionadas.Count; i++)
                {
                    if ((dtpfechaInicio.Value >= listaAusenciasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaAusenciasSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaAusenciasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value >= listaAusenciasSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaAusenciasSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaAusenciasSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaAusenciasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaAusenciasSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaAusenciasSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                }
            }
            if (listaSubsidiosSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaSubsidiosSeleccionadas.Count; i++)
                {
                    if ((dtpfechaInicio.Value >= listaSubsidiosSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaSubsidiosSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaSubsidiosSeleccionadas[i].fechInicio) && (dtpfechaFin.Value >= listaSubsidiosSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaSubsidiosSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaSubsidiosSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaSubsidiosSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaSubsidiosSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaSubsidiosSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                }
            }
            if (listaOtrasSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaOtrasSeleccionadas.Count; i++)
                {
                    if ((dtpfechaInicio.Value >= listaOtrasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaOtrasSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaOtrasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value >= listaOtrasSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaOtrasSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaOtrasSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfechaInicio.Value <= listaOtrasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaOtrasSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaOtrasSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void BtnAdicionrVacaciones_Click(object sender, EventArgs e)
        {
            try
            {             
                if (VerificacionIncidencias())
                {                   
                    TimeSpan resultado = periodo.PeriodFechaFin.Subtract(periodo.PeriodFechaInicio);
                    DateTime FechaMax = periodo.PeriodFechaFin.AddDays(resultado.TotalDays);
                    if (((dtpfechaInicio.Value.Date >= periodo.PeriodFechaInicio.Date) && (dtpfechaFin.Value.Date <= periodo.PeriodFechaFin.Date)) || ((dtpfechaInicio.Value.Date >= periodo.PeriodFechaFin.Date) && (dtpfechaFin.Value.Date <= FechaMax)))
                    {
                        if (dtpfechaFin.Value > dtpfechaInicio.Value)
                        {
                            TimeSpan result = dtpfechaFin.Value.Subtract(dtpfechaInicio.Value);
                            double totalhoras = result.TotalHours;
                            double day = result.Days + 1;
                            double hours = result.Hours;
                            double minutes = result.Minutes;
                            if ((hours > 0) || (minutes > 0) || (day > 0))
                            {
                                bool bandera = false;
                                foreach (ListViewItem obj in lvVacaciones.Items)
                                {
                                    DateTime fechaInicio = Convert.ToDateTime(obj.Text);
                                    DateTime fechaFin = Convert.ToDateTime(obj.SubItems[1].Text);

                                    if ((dtpfechaInicio.Value.Date <= fechaInicio.Date) && (dtpfechaFin.Value.Date >= fechaInicio.Date))
                                    {
                                        MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bandera = true;
                                        return;
                                    }
                                    if ((dtpfechaInicio.Value.Date <= fechaFin.Date) && (dtpfechaFin.Value.Date >= fechaFin.Date))
                                    {
                                        MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bandera = true;
                                        return;
                                    }
                                    if ((dtpfechaInicio.Value.Date >= fechaInicio.Date) && (dtpfechaFin.Value.Date <= fechaFin.Date))
                                    {
                                        MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bandera = true;
                                        return;
                                    }
                                    //if ((dtpfechaInicio.Value.Date <= fechaInicio) && (dtpfechaFin.Value.Date <= fechaFin))
                                    //{
                                    //    MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //    bandera = true;
                                    //    return;
                                    //}
                                    if ((dtpfechaInicio.Value.Date <= fechaInicio.Date) && (dtpfechaFin.Value.Date <= fechaFin.Date) && (dtpfechaFin.Value.Date >= fechaInicio.Date))
                                    {
                                        MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bandera = true;
                                        return;
                                    }
                                }
                                if (!bandera)
                                {                                   
                                    var dias = 0;
                                    double total = 0;
                                    if (day > 0 || hours > 0 || minutes > 0)
                                    {
                                        DateTime fechaInicio = dtpfechaInicio.Value;
                                        DateTime fechaFin = dtpfechaFin.Value;
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
                                        if (dias == 0)
                                        {
                                            MessageBox.Show("Verifique, ha seleccionado días no laborables.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        else if (day == 1)
                                        {
                                            total = hours;
                                            if (total <= Convert.ToInt32(txtaumuladoVacaciones.Text))
                                            {
                                                ListViewItem item = new ListViewItem();
                                                item.Text = dtpfechaInicio.Value.ToString();
                                                item.SubItems.Add(dtpfechaFin.Value.ToString());
                                                item.SubItems.Add(total.ToString());
                                                lvVacaciones.Items.Add(item);
                                                txtaumuladoVacaciones.Text = (Convert.ToInt32(txtaumuladoVacaciones.Text) - total).ToString();
                                                dtpfechaInicio.Value = DateTime.Now;
                                                dtpfechaFin.Value = DateTime.Now;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Verifique, el período insertado supera el acumulado de vacaciones.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                txtaumuladoVacaciones.Text = (Convert.ToInt32(txtaumuladoVacaciones.Text) - total).ToString();
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            total = dias * 8;
                                            if (total <= Convert.ToInt32(txtaumuladoVacaciones.Text))
                                            {
                                                ListViewItem item = new ListViewItem();
                                                item.Text = dtpfechaInicio.Value.ToString();
                                                item.SubItems.Add(dtpfechaFin.Value.ToString());
                                                item.SubItems.Add(total.ToString());
                                                lvVacaciones.Items.Add(item);
                                                txtaumuladoVacaciones.Text = (Convert.ToInt32(txtaumuladoVacaciones.Text) - total).ToString();
                                                dtpfechaInicio.Value = DateTime.Now;
                                                dtpfechaFin.Value = DateTime.Now;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Verifique, el período insertado supera el acumulado de vacaciones.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        }
                                    }


                                }                              
                            }
                            else
                            {
                                MessageBox.Show("Verifique, el Tiempo de Ausencia es 0.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fín del período.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else { MessageBox.Show("Verifique. La fechas de inicio y fin de las Vacaciones no se encuentran dentro del periodo aceptado.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("En la fecha seleccionada se encuentra registrada una incidencia.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al seleccionar los datos de las vacaciones.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvVacaciones.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvVacaciones.SelectedItems)
                    {
                        lvVacaciones.Items.Remove(item);                       
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la(s) vacaciones que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la(s) vacaciones seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (lvVacaciones.Items.Count > 0)
                {
                    listaVacacionesSeleccionadas = new List<clsVacaciones>();
                    clsVacaciones nuevoObj;
                    foreach (ListViewItem item in lvVacaciones.Items)
                    {
                        nuevoObj = new clsVacaciones();
                        nuevoObj.FechaRegister = DateTime.Now;
                        nuevoObj.personKey = person.PersonKey;
                        nuevoObj.fechInicio = Convert.ToDateTime(item.Text);
                        nuevoObj.fechaFin = Convert.ToDateTime(item.SubItems[1].Text);
                        nuevoObj.horasDisfrutadas = Convert.ToDecimal(item.SubItems[2].Text);
                        nuevoObj.CreateUserID = sageSession1.UserID;
                        nuevoObj.CompanyID = sageSession1.CompanyID;
                        listaVacacionesSeleccionadas.Add(nuevoObj);
                    }
                    controller.AddVacacionesTrabajador(listaVacacionesSeleccionadas, periodo.Periodkey);
                }               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                //MessageBox.Show("Error al salvar los datos de las Vacaciones.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            lbldatosPersona.Text = "";
            txtCi.Text = "";
            lvVacaciones.Items.Clear();
            txtaumuladoVacaciones.Text = "";
            acumulado = 0;
            DisableControls();
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            var resultado = false;
            if (lvVacaciones.SelectedItems.Count > 0)
            {            
                DialogResult resul = MessageBox.Show("Desea eliminar las vacaciones seleccionadas?.", "Sage MAS 500", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resul == DialogResult.Yes)
                {
                   resultado = controller.EliminarVacacionesXPersonas(person.PersonKey, Convert.ToDateTime(lvVacaciones.SelectedItems[0].Text), Convert.ToDateTime(lvVacaciones.SelectedItems[0].SubItems[1].Text), periodo.Periodkey);
                    if (!resultado)
                    {
                        acumulado = acumulado - Convert.ToInt32(lvVacaciones.SelectedItems[0].SubItems[2].Text);
                        txtaumuladoVacaciones.Text = (Convert.ToInt32(txtaumuladoVacaciones.Text) + Convert.ToInt32(lvVacaciones.SelectedItems[0].SubItems[2].Text)).ToString();
                        lvVacaciones.Items.Remove(lvVacaciones.SelectedItems[0]);

                       
                    }                  
                }                
            }
            return resultado;
        }
    }
}
