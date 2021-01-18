using Entidades.General;
using Entidades.Rpt;
using Negocio;
using Net4Sage;
using RHSGPN001.PlantillasRpt;
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

namespace RHSGPN001
{
    public partial class frmGestionarPrenomina : Form
    {
        ThrOperationsPeriod periodo;
        public frmGestionarPrenomina()
        {
            InitializeComponent();
        }                  
        public frmGestionarPrenomina(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);            
            LoadContext();
            cmbUnidadOrganizativas.Enabled = false;
            CargarDatosIniciales();

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

                    ControllerRHSGI001 controller = new ControllerRHSGI001();
                    cmbUnidadOrganizativas.DataSource = controller.GetaAllsUnidadesAdministrativas();
                    cmbUnidadOrganizativas.DisplayMember = "Name";
                    cmbUnidadOrganizativas.ValueMember = "OrgUnitKey";

                    cmbperiodos.DataSource = open.GetPeriodos();
                    cmbperiodos.DisplayMember = "PeriodoDescription";
                    cmbperiodos.ValueMember = "Periodkey";
                }
                else
                {
                    MessageBox.Show("No existe un período abierto para gestionar Pre-nóminas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar datos iniciales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }      

        private void BtnBuscar_Click(object sender, EventArgs e)
        {           
            ControllerRHSGPN001 controller = new ControllerRHSGPN001();
            if (rdbTodos.Checked)
            {
                var listaDatosNomina = controller.GetAllDatosNomina(periodo.Periodkey);
                MostrarDatos(listaDatosNomina);
            }
            else
            {
                var listaDatosNominaXUnidad = controller.GetAllDatosNominaXUnidad(periodo.Periodkey, Convert.ToInt32(cmbUnidadOrganizativas.SelectedValue));
                MostrarDatos(listaDatosNominaXUnidad);
            }

        }
        public void MostrarDatos(List<clsDatosNomina> listaDatosNomina)
        {
            try
            {
                if (listaDatosNomina.Count > 0)
                {
                    datagridResult.DataSource = null;
                    datagridResult.DataSource = listaDatosNomina;
                    datagridResult.Columns[0].HeaderText = "Número de Expediente";
                    datagridResult.Columns[1].HeaderText = "Nombre y Apellidos";
                    datagridResult.Columns[2].HeaderText = "Unidad Organizativa";
                    datagridResult.Columns[3].HeaderText = "Ausencias";
                    datagridResult.Columns[4].HeaderText = "Licencias";
                    datagridResult.Columns[5].HeaderText = "Subsidios";
                    datagridResult.Columns[6].HeaderText = "Vacaciones";

                }
                else
                {
                    datagridResult.DataSource = null;
                    MessageBox.Show("No existen datos relacionados para mostrar", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        } 

        IEnumerable<Object> Data;
        private void LoadData(object sender, DoWorkEventArgs e)
        {
            List<object> data = new List<object>();
            if (datagridResult.Rows.Count > 0)
            {
                var ParamPeriodo = "Período:";
                var ParamPeriodoValue = periodo.PeriodFechaInicio.ToShortDateString() + " - " + periodo.PeriodFechaFin.ToShortDateString();
                var ParamExpediente = "Expediente:";
                var ParamExpedienteValue = "";
                var ParamNombresApellidos = "Nombres y Apellidos";
                var ParamNombresApellidosValue = "";
                var ParamUnidad = "Area";
                var ParamUnidadValue = "";
                var ParamAusencias = "Ausencias";
                var ParamAusenciasValue = "";
                var ParamLicencias = "Licencias";
                var ParamLicenciasValue = "";
                var ParamSubsidios = "Subsidios:";
                var ParamSubsidiosValue = "";
                var ParamVacaciones = "Vacaciones:";
                var ParamVacacionesValue = "";
                var ParamNoConsecutivo = "No Modelo:";
                //var ParamNoCnsecutivoValue = "";

                for (int i = 0; i < datagridResult.RowCount; i++)
                {
                    if (datagridResult.Rows[i].Cells["Expediente"].ToString() == "")
                    { ParamExpedienteValue = ""; }
                    else
                    { ParamExpedienteValue = datagridResult.Rows[i].Cells["Expediente"].Value.ToString(); }

                    if (datagridResult.Rows[i].Cells["Nombre"].ToString() == "")
                    {
                        ParamNombresApellidosValue = "";
                    }
                    else
                    { ParamNombresApellidosValue = datagridResult.Rows[i].Cells["Nombre"].Value.ToString(); }

                    if (datagridResult.Rows[i].Cells["UnidadOrganizativa"].ToString() == "")
                    {
                        ParamUnidadValue = "";
                    }
                    else
                    { ParamUnidadValue = datagridResult.Rows[i].Cells["UnidadOrganizativa"].Value.ToString(); }

                    if (datagridResult.Rows[i].Cells["TiempoAusencia"].ToString() == "")
                    {
                        ParamAusenciasValue = "";
                    }
                    else
                    { ParamAusenciasValue = datagridResult.Rows[i].Cells["TiempoAusencia"].Value.ToString(); }
                    if (datagridResult.Rows[i].Cells["TiempoLicencia"].ToString() == "")
                    {
                        ParamLicenciasValue = "";
                    }
                    else
                    { ParamLicenciasValue = datagridResult.Rows[i].Cells["TiempoLicencia"].Value.ToString(); }
                    if (datagridResult.Rows[i].Cells["TiempoSubsidio"].ToString() == "")
                    {
                        ParamSubsidiosValue = "";
                    }
                    else
                    { ParamSubsidiosValue = datagridResult.Rows[i].Cells["TiempoSubsidio"].Value.ToString(); }
                    if (datagridResult.Rows[i].Cells["TiempoVacaciones"].ToString() == "")
                    {
                        ParamVacacionesValue = "";
                    }
                    else
                    { ParamVacacionesValue = datagridResult.Rows[i].Cells["TiempoVacaciones"].Value.ToString(); }


                    data.Add(new ReportEntryPreNomina
                    {
                        ParametroNameRpt = "Modelo SC 405 Pre-Nómina",

                        ParametroPeriodo = ParamPeriodo,
                        ParametroValorPeriodo = ParamPeriodoValue,

                        ParametroExpediente = ParamExpediente,
                        ParametroValorExpediente = ParamExpedienteValue,

                        ParametroNombre = ParamNombresApellidos,
                        ParametroValorNombre = ParamNombresApellidosValue,

                        ParametroUnidadOrganizativa = ParamUnidad,
                        ParametroValorUnidadOrganizativa = ParamUnidadValue,

                        ParametroAusencia = ParamAusencias,
                        ParametroValorAusencia = ParamAusenciasValue,

                        ParametroLicencia = ParamLicencias,
                        ParametroValorLicencia = ParamLicenciasValue,

                        ParametroSubsidio = ParamSubsidios,
                        ParametroValorSubsidio = ParamSubsidiosValue,

                        ParametroVacaciones = ParamVacaciones,
                        ParametroValorVacaciones = ParamVacacionesValue,

                        ParametroNoConsecutivo = ParamNoConsecutivo,
                        ParametroValorNoConsecutivo = periodo.NumeroConsecuitvo.ToString(),
                    });
                    Data = data;
                }
            }
        }           

        private void ShowData(object sender, RunWorkerCompletedEventArgs e)
        {
            menuStrip1.Enabled = true;
            if (Data == null || Data.Count() == 0)
            {
                MessageBox.Show("No hay datos para mostrar", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalReportPreNomina rpt = new CrystalReportPreNomina();
            ReportEngine.Report = rpt;
            for (var i = 1; i < ReportEngine.Report.Database.Tables.Count; i++)
                ReportEngine.LoginDataSource(i);
            ReportEngine.Report.Database.Tables[0].SetDataSource(Data);
            ReportEngine.Show();
        }

        private void ToolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            ReportWorker.RunWorkerAsync();
        }

        private void RdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTodos.Checked)
            {
                datagridResult.DataSource = null;
                cmbUnidadOrganizativas.Enabled = false;
            }            
        }
        private void RdbUnidad_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUnidad.Checked)
            {
                datagridResult.DataSource = null;
                cmbUnidadOrganizativas.Enabled = true;
            }          
        }
    }
}
