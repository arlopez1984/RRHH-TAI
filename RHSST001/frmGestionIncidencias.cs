using Entidades.General;
using Negocio;
using Net4Sage;
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

namespace RHSST001
{
    public partial class frmIncidenciasTrabajador : Form
    {
        ControllerRHSGI001 controler;
        List<ThrPeople> listaPersonasSeleccionadas;
        List<clsAusencia> listaAusenciasSeleccionadas;
        List<clsSubsidios> listaSubsidiosSeleccionados;
        List<clsLicencia> listaLicenciaSeleccionadas;
        List<clsOtraIncidencia> listaOtrasIncidenciasSeleccionadas;
        ThrOperationsPeriod periodo;
        ThrPeople person;
        public frmIncidenciasTrabajador()
        {
            InitializeComponent();
            controler = new ControllerRHSGI001();
            menuBar1.Items[3].Visible = false;
        }
        public frmIncidenciasTrabajador(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            listaPersonasSeleccionadas = new List<ThrPeople>();
            listaAusenciasSeleccionadas = new List<clsAusencia>();
            listaSubsidiosSeleccionados = new List<clsSubsidios>();
            listaLicenciaSeleccionadas = new List<clsLicencia>();
            listaOtrasIncidenciasSeleccionadas = new List<clsOtraIncidencia>();
            LoadContext();            
            CargarDatosIniciales();
            DisableControls();
        }
        private void DisableControls()
        {
            lvResumenLicencias.Enabled = false;
            lvResumenOtrasIncidencias.Enabled = false;
            lvResumenAusencias.Enabled = false;
            lvResumenSubsidios.Enabled = false;
            btnAusencia.Enabled = false;
            btnLicencia.Enabled = false;
            btnSubsidios.Enabled = false;
            btnOtrasIncidencias.Enabled = false;
        }
        private void EnableControls()
        {
            lvResumenLicencias.Enabled = true;
            lvResumenOtrasIncidencias.Enabled = true;
            lvResumenAusencias.Enabled = true;
            lvResumenSubsidios.Enabled = true;
            btnAusencia.Enabled = true;
            btnLicencia.Enabled = true;
            btnSubsidios.Enabled = true;
            btnOtrasIncidencias.Enabled = true;
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
                    MessageBox.Show("No existe un periodo abierto para gestionar las incidencias a los trabajadores.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DisableControls();
                    cmbUnidadesOrganizativas.Enabled = false;
                    txtCi.Enabled = false;
                    btnBuscar.Enabled = false;
                    grbSeleccionarTRabajador.Enabled = false;
                };

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar datos iniciales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }          
            
        }        
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var unitKey = Convert.ToInt16(cmbUnidadesOrganizativas.SelectedValue);
            if (txtCi.Text != "")
            {              
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
                    btnAusencia.Enabled = true;
                    btnLicencia.Enabled = true;
                    btnOtrasIncidencias.Enabled = true;
                    btnSubsidios.Enabled = true;
                    ListViewItem nuevoitem = new ListViewItem(person.PrimerNombre.ToString());
                    nuevoitem.SubItems.Add(person.PrimerApellido.ToString());
                    nuevoitem.SubItems.Add(person.SegundoApellido.ToString());
                    nuevoitem.SubItems.Add(person.CI.ToString());
                    EnableControls();
                    txtCi.Clear();
                }

            }
            else
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
        }        
        public void MostrarPersonasSeleccionadas(List<ThrPeople> listaSeleccion)
        {
            try
            {
                if (listaSeleccion.Count > 0)
                {
                    ControllerRHSGTTT001 control = new ControllerRHSGTTT001();
                    var tiempoTrabajado = control.GetTiempoTrabajado(listaSeleccion[0].PersonKey, periodo.Periodkey);
                    if (tiempoTrabajado == null)
                    {
                        lvResumenSubsidios.Items.Clear();
                        lvResumenOtrasIncidencias.Items.Clear();
                        lvResumenLicencias.Items.Clear();
                        lvResumenAusencias.Items.Clear();
                        var ausencias = controler.GetaAllsAusenciasxPersona(listaSeleccion[0].PersonKey, periodo.Periodkey);
                        var licencias = controler.GetaAllsLicenciasxPersona(listaSeleccion[0].PersonKey, periodo.Periodkey);
                        var otrasIncidencias = controler.GetaAllsOtrasIncidenciasxPersona(listaSeleccion[0].PersonKey, periodo.Periodkey);
                        var subsidios = controler.GetaAllsSubsidiosxPersona(listaSeleccion[0].PersonKey, periodo.Periodkey);

                        person = new ThrPeople();
                        person = listaSeleccion[0];
                        lbldatosPersona.Text = person.PrimerNombre + " " + person.SegundoNombre + " " + person.PrimerApellido + " " + person.SegundoApellido + " " + " " + " " + "CI:" + person.CI;
                        if (ausencias.Any())
                        {
                            clsAusencia objAusencia;
                            listaAusenciasSeleccionadas = new List<clsAusencia>();
                            foreach (ThrPeopleAbsence item in ausencias)
                            {
                                objAusencia = new clsAusencia();
                                objAusencia.tipoAusencia = item.AbsenceKey;
                                objAusencia.fechInicio = item.AbsenceFechaInicio;
                                objAusencia.fechaFin = item.AbsenceFechaFin;
                                objAusencia.HorasDisfrutadas = item.HoursDifrutadas.ToString();
                                listaAusenciasSeleccionadas.Add(objAusencia);
                            }
                            MostrarAusenciasSeleccionadas(listaAusenciasSeleccionadas);
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
                                objLicencias.Horas = item.HoursDifrutadas;
                                listaLicenciaSeleccionadas.Add(objLicencias);
                            }
                            MostrarLicenciasSeleccionados(listaLicenciaSeleccionadas);
                        }
                        if (otrasIncidencias.Any())
                        {
                            clsOtraIncidencia objOtraIncidencia;
                            listaOtrasIncidenciasSeleccionadas = new List<clsOtraIncidencia>();
                            foreach (ThrPeopleIncidence item in otrasIncidencias)
                            {
                                objOtraIncidencia = new clsOtraIncidencia();
                                objOtraIncidencia.tipoOtraIncidencia = item.IncidenceKey;
                                objOtraIncidencia.fechInicio = item.IncidenceFechaInicio;
                                objOtraIncidencia.fechaFin = item.IncidenceFechaFin;
                                objOtraIncidencia.Horas = item.HoursDifrutadas;
                                listaOtrasIncidenciasSeleccionadas.Add(objOtraIncidencia);
                            }
                            MostrarOtrasIncidenciasSeleccionados(listaOtrasIncidenciasSeleccionadas);
                        }
                        if (subsidios.Any())
                        {
                            clsSubsidios subsidy;
                            listaSubsidiosSeleccionados = new List<clsSubsidios>();
                            foreach (ThrPeopleSubsidy item in subsidios)
                            {
                                subsidy = new clsSubsidios();
                                subsidy.tipoSubsidio = item.SubsidyKey;
                                subsidy.fechInicio = item.SubsidyFechaInicio;
                                subsidy.fechaFin = item.SubsidyFechaFin;
                                subsidy.Subsidioinicio = item.SubsidyInicio;
                                subsidy.hospitalizado = item.SubsidyHospitalizado;
                                subsidy.Horas = item.HoursDifrutadas;
                                listaSubsidiosSeleccionados.Add(subsidy);
                            }
                            MostrarSubsidiosSeleccionados(listaSubsidiosSeleccionados);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La persona seleccionada ya tiene gestionado el Tiempo Trabajado en ese período.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisableControls();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos de la persona seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
           
        }
        public void MostrarAusenciasSeleccionadas(List<clsAusencia> listaAusenciaSeleccion)
        {
            try
            {
                if (listaAusenciaSeleccion.Count > 0)
                {
                    ListViewItem nuevoItem;
                    foreach (clsAusencia item in listaAusenciaSeleccion)
                    {
                        var nombreAusencia = controler.GetAusencia(item.tipoAusencia);
                        nuevoItem = new ListViewItem();
                        nuevoItem.Text = nombreAusencia.AbsenceName.ToString();
                        nuevoItem.SubItems.Add(item.fechInicio.ToString());
                        nuevoItem.SubItems.Add(item.fechaFin.ToString());
                        nuevoItem.SubItems.Add(item.HorasDisfrutadas.ToString());
                        lvResumenAusencias.Items.Add(nuevoItem);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos relacionados a las ausencias de la persona seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            
        }
        public void MostrarSubsidiosSeleccionados(List<clsSubsidios> listaSubsidiosSeleccion)
        {
            try
            {
                if (listaSubsidiosSeleccion.Count > 0)
                {
                    ListViewItem nuevoItem;
                    foreach (clsSubsidios item in listaSubsidiosSeleccion)
                    {
                        var Subsidio = controler.GetSubsidio(item.tipoSubsidio);
                        nuevoItem = new ListViewItem();
                        nuevoItem.Text = Subsidio.SubsidyName.ToString();
                        nuevoItem.SubItems.Add(item.fechInicio.ToShortDateString());
                        nuevoItem.SubItems.Add(item.fechaFin.ToShortDateString());
                        if (item.Subsidioinicio == 1)
                        { nuevoItem.SubItems.Add("Si"); }
                        else { nuevoItem.SubItems.Add("No"); }
                        if (item.hospitalizado == 1)
                        { nuevoItem.SubItems.Add("Si"); }
                        else { nuevoItem.SubItems.Add("No"); }
                        nuevoItem.SubItems.Add(item.Horas.ToString());
                        lvResumenSubsidios.Items.Add(nuevoItem);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos relacionados a los subsidios de la persona seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            
        }
        public void MostrarLicenciasSeleccionados(List<clsLicencia> listaLicenciaSeleccion)
        {
            try
            {
                if (listaLicenciaSeleccion.Count > 0)
                {
                    ListViewItem nuevoItem;
                    foreach (clsLicencia item in listaLicenciaSeleccion)
                    {
                        var licencia = controler.GetLicence(item.tipoLicencia);
                        nuevoItem = new ListViewItem();
                        nuevoItem.Text = licencia.LicenceName.ToString();
                        nuevoItem.SubItems.Add(item.fechInicio.ToShortDateString());
                        nuevoItem.SubItems.Add(item.fechaFin.ToShortDateString());
                        nuevoItem.SubItems.Add(item.Horas.ToString());
                        lvResumenLicencias.Items.Add(nuevoItem);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos relacionados a las licencias de la persona seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            
        }
        public void MostrarOtrasIncidenciasSeleccionados(List<clsOtraIncidencia> listaOtrasIncidenciasSeleccion)
        {
            try
            {
                if (listaOtrasIncidenciasSeleccion.Count > 0)
                {
                    ListViewItem nuevoItem;
                    foreach (clsOtraIncidencia item in listaOtrasIncidenciasSeleccion)
                    {
                        var otraIncidencia = controler.GetOtraIncidencia(item.tipoOtraIncidencia);
                        nuevoItem = new ListViewItem();
                        nuevoItem.Text = otraIncidencia.IncidenceID.ToString();
                        nuevoItem.SubItems.Add(item.fechInicio.ToShortDateString());
                        nuevoItem.SubItems.Add(item.fechaFin.ToShortDateString());
                        nuevoItem.SubItems.Add(item.Horas.ToString());
                        lvResumenOtrasIncidencias.Items.Add(nuevoItem);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos relacionados a las otras incidencias de la persona seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            
        }       
        private void TxtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCi.Text != "")
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
        }        
        private void BtnAusencia_Click(object sender, EventArgs e)
        {           
            if (lbldatosPersona.Text != "")
            {
                frmAusencias formAusencias = new frmAusencias(listaPersonasSeleccionadas[0], listaAusenciasSeleccionadas, listaLicenciaSeleccionadas, listaSubsidiosSeleccionados, listaOtrasIncidenciasSeleccionadas);
                if (formAusencias.ShowDialog() == DialogResult.OK)
                {
                    lvResumenAusencias.Items.Clear();
                    listaAusenciasSeleccionadas = formAusencias.listaAusenciasSeleccionadas;
                    if (listaAusenciasSeleccionadas.Count > 0)
                    {
                        MostrarAusenciasSeleccionadas(listaAusenciasSeleccionadas);
                    }
                    else { lvResumenAusencias.Items.Clear(); }
                }
            }
            else { MessageBox.Show("Debe seleccionar la persona que desea procesar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }            
        }        
        private void Do_Cancel(object sender, EventArgs e)
        {
            lbldatosPersona.Text = "";
            lvResumenAusencias.Items.Clear();
            lvResumenLicencias.Items.Clear();
            lvResumenSubsidios.Items.Clear();
            lvResumenOtrasIncidencias.Items.Clear();
            txtCi.Text = "";
            lvResumenAusencias.Items.Clear();
            listaPersonasSeleccionadas.Clear();
            listaAusenciasSeleccionadas.Clear();
            listaSubsidiosSeleccionados.Clear();
            listaLicenciaSeleccionadas.Clear();
            listaOtrasIncidenciasSeleccionadas.Clear();
            DisableControls();
        }
        private void BtnSubsidios_Click(object sender, EventArgs e)
        {
            if (lbldatosPersona.Text != "")
            {                
                frmSubsidios formSubsidios = new frmSubsidios(listaPersonasSeleccionadas[0], listaSubsidiosSeleccionados,listaLicenciaSeleccionadas,listaAusenciasSeleccionadas,listaOtrasIncidenciasSeleccionadas);
                if (formSubsidios.ShowDialog() == DialogResult.OK)
                {
                    lvResumenSubsidios.Items.Clear();
                    listaSubsidiosSeleccionados = formSubsidios.listaSubsidiosSeleccionados;                   
                    if (listaSubsidiosSeleccionados.Count > 0)
                    {
                        lvResumenSubsidios.Items.Clear();
                        MostrarSubsidiosSeleccionados(listaSubsidiosSeleccionados);
                    }
                    else { lvResumenSubsidios.Items.Clear(); }
                }

            }
            else { MessageBox.Show("Debe seleccionar la(s) persona que desea procesar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void BtnLicencia_Click(object sender, EventArgs e)
        {
            if (lbldatosPersona.Text != "")
            {                
                frmLicencias formlicencia = new frmLicencias(listaPersonasSeleccionadas[0], listaLicenciaSeleccionadas, listaAusenciasSeleccionadas,listaSubsidiosSeleccionados,listaOtrasIncidenciasSeleccionadas);
                if (formlicencia.ShowDialog() == DialogResult.OK)
                {
                    lvResumenLicencias.Items.Clear();
                    listaLicenciaSeleccionadas = formlicencia.listaLicenciasSeleccionadas; 
                    if (listaLicenciaSeleccionadas.Count > 0)
                    {
                        lvResumenLicencias.Items.Clear();
                        MostrarLicenciasSeleccionados(listaLicenciaSeleccionadas);
                    }
                    else { lvResumenLicencias.Items.Clear(); }
                }
            }
            else { MessageBox.Show("Debe seleccionar la(s) persona que desea procesar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnOtrasIncidencias_Click(object sender, EventArgs e)
        {
            if (lbldatosPersona.Text !="")
            {
                frmOtrasIncidencias formIncidencias = new frmOtrasIncidencias(listaPersonasSeleccionadas[0], listaOtrasIncidenciasSeleccionadas,listaLicenciaSeleccionadas,listaSubsidiosSeleccionados,listaAusenciasSeleccionadas);
                if (formIncidencias.ShowDialog() == DialogResult.OK)
                {
                    lvResumenOtrasIncidencias.Items.Clear();
                    listaOtrasIncidenciasSeleccionadas = formIncidencias.listaOtrasIncidenciasSeleccionadas;
                    if (listaOtrasIncidenciasSeleccionadas.Count > 0)
                    {
                        lvResumenOtrasIncidencias.Items.Clear();
                        MostrarOtrasIncidenciasSeleccionados(listaOtrasIncidenciasSeleccionadas);
                    }
                    else { lvResumenOtrasIncidencias.Items.Clear(); }
                }

            }
            else { MessageBox.Show("Debe seleccionar la(s) persona que desea procesar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            { 
                if (listaAusenciasSeleccionadas.Count == 0 && listaLicenciaSeleccionadas.Count == 0 && listaOtrasIncidenciasSeleccionadas.Count == 0 && listaSubsidiosSeleccionados.Count == 0)
                {
                    MessageBox.Show("Verifique, no ha seleccionado incidencias al trabajador seleccionado.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ControlllerRHSMP001 controlador = new ControlllerRHSMP001();
                    List<ThrPeople> listaPersonas = new List<ThrPeople>();
                    listaPersonas.Add(person);
                    controler.AddIncidencias(listaPersonas, listaAusenciasSeleccionadas, listaSubsidiosSeleccionados, listaOtrasIncidenciasSeleccionadas, listaLicenciaSeleccionadas, periodo.Periodkey,sageSession1.CompanyID,sageSession1.UserID);
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar las incidencia a los trabajadores seleccionados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
    }
}
