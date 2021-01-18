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
        ControllerRHSMH001 controlador;
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
            controlador = new ControllerRHSMH001();
            this.sageSession1.InitializeSession(session);
            LoadContext();
            CargarDatosIniciales();
            DisableControls();
        }
        private void EnableControls()
        {
           
        }
        private void DisableControls()
        {
            
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
                    dtpFechaGestion.Text = periodo.PeriodFechaInicio.ToShortDateString();

                }
                else
                {
                    MessageBox.Show("No existe un período abierto para gestionar las asistencias a los trabajadores.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            /*try
            {
                if (listaSeleccion.Count > 0)
                {
                    foreach (ThrPeople item in listaSeleccion)
                    {
                        var dataJornada = controlador.GetJornadaHorario(item.SheduleKey);
                        dvtrabajadores.Rows.Add(item.PrimerNombre + " " + item.SegundoNombre + " " + item.PrimerApellido + " " + item.SegundoApellido,  dataJornada.HoraInicio, dataJornada.HoraFin, 0);
                        
                    }                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos del trabajador seleccionado.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }*/

        }      
       
        private void btnBuscar_Click(object sender, EventArgs e)
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

        private void chxMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chxMostrarTodos.Checked)
                {
                    var unitKey = Convert.ToInt16(cmbUnidadesOrganizativas.SelectedValue);
                    ControllerRHSGI001 controlador = new ControllerRHSGI001();
                    var listaPersonasUnidadBD = controlador.BuscarPersonasxUnidad(unitKey);
                    if (listaPersonasUnidadBD.Count > 0)
                    {
                        MostrarPersonasSeleccionadas(listaPersonasUnidadBD);

                    }
                    else
                    {
                        MessageBox.Show("No existen personas en la unidad seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        chxMostrarTodos.Checked = false;
                    }
                }
                else { dvtrabajadores.Rows.Clear(); }
            }
            catch (Exception)
            {

                throw;
            }
            
        }        
    }
}
