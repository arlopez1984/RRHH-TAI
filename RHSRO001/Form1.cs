using Entidades.General;
using Entidades.Rpt;
using Negocio;
using Net4Sage;
using RHSRO001.PlantillasRpt;
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

namespace RHSRO001
{
    public partial class frmReportes : Form
    {
        ControllerRHSRO001 controller;
        ThrOperationsPeriod periodo;
        public string TipoReporte = "";
        public frmReportes()
        {
            InitializeComponent();
            controller = new ControllerRHSRO001();
        }
        public frmReportes(ref SageSession session) : this()
        {
            this.sageSession2.InitializeSession(session);
            LoadContext();
            CargarDatosIniciales();
            cmbSeleccReporte.SelectedIndex = 0;
            DisableControls();
        }
        public void CargarDatosIniciales()
        {
            ControllerRHSMGP001 open = new ControllerRHSMGP001();
            periodo = open.GetPeriodoActivo();
            if (periodo != null)
            {
                lblPeriodoActivo.Text = periodo.PeriodFechaInicio.ToShortDateString() + " " + "-" + " " + periodo.PeriodFechaFin.ToShortDateString();

                cmbperiodos.DataSource = open.GetPeriodos();
                cmbperiodos.DisplayMember = "PeriodoDescription";
                cmbperiodos.ValueMember = "Periodkey";
            }
            else
            {
                MessageBox.Show("No existe un periodo abierto para gestionar movimientos a Tabajadores.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableControls();
            }
        }
        public void LoadContext()
        {
            System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
            {
                Metadata = "res://*/DataModel1.csdl|res://*/DataModel1.ssdl|res://*/DataModel1.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sageSession2.GetConnectionString()
            };
            Conection.connectionString = connectionString.ToString();
        }       
        private void EnableControls()
        {
            cmbperiodos.Enabled = true;
            btnBuscar.Enabled = true;
            //txtNombre.Enabled = true;
            //txtResolucion.Enabled = true;
            //chkAcumulaVacac.Enabled = true;

        }
        private void DisableControls()
        {
            cmbperiodos.Enabled = false;
            btnBuscar.Enabled = false;
            //txtNombre.Enabled = true;
            //txtResolucion.Enabled = true;
            //chkAcumulaVacac.Enabled = true;
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {            
            if (cmbSeleccReporte.Text == "Reporte de Ausencias")
            {
                var listaDatosAusencias = controller.GetAllAusenciasXPeriodo(periodo.Periodkey);
                MostrarDatosAusencias(listaDatosAusencias);
            }
            if (cmbSeleccReporte.Text == "Reporte de Licencias")
            {
                var listaDatosLicencias = controller.GetAllLicenciasXPeriodo(periodo.Periodkey);
                MostrarDatosLicencias(listaDatosLicencias);
            }
            if (cmbSeleccReporte.Text == "Reporte de Subsidios")
            {
                var listaDatosSubsidios = controller.GetAllSubsidiosXPeriodo(periodo.Periodkey);
                MostrarDatosSubsidios(listaDatosSubsidios);
            }
            if (cmbSeleccReporte.Text == "Reporte de Vacaciones")
            {
                var listaDatosVacaciones = controller.GetAllVacacionesXPeriodo(periodo.Periodkey);
                MostrarDatosVacaciones(listaDatosVacaciones);
            }
            if (cmbSeleccReporte.Text == "Reporte de Certificados y Accidentes")
            {
                var listaDatosCertificadosAccidentes = controller.GetAllCertificadosAccidentesXPeriodo(periodo.Periodkey);
                MostrarDatosCertificadosAccidentes(listaDatosCertificadosAccidentes);
            }
        }        
        public void MostrarDatosAusencias(List<clsAusencias> listaDatosAusencias)
        {
            if (listaDatosAusencias.Count > 0)
            {
                TipoReporte = "Modelo SC 405 Ausencias";
                datagridResult.DataSource = null;
                datagridResult.DataSource = listaDatosAusencias;
                datagridResult.Columns[0].HeaderText = "Número de Expediente";
                datagridResult.Columns[1].HeaderText = "Nombre y Apellidos";
                datagridResult.Columns[2].HeaderText = "Tipo";
                datagridResult.Columns[3].HeaderText = "Feha Inicio";
                datagridResult.Columns[4].HeaderText = "Fecha Fin";
                datagridResult.Columns[5].HeaderText = "Horas disfrutadas";                
            }
            else
            {
                datagridResult.DataSource = null;
                MessageBox.Show("No existen datos relacionados para mostrar", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void MostrarDatosSubsidios(List<Entidades.Rpt.clsSubsidios> listaDatosSubsidios)
        {

            if (listaDatosSubsidios.Count > 0)
            {
                TipoReporte = "Modelo SC 405 Subsidios";
                datagridResult.DataSource = null;
                datagridResult.DataSource = listaDatosSubsidios;               
                datagridResult.Columns[0].HeaderText = "Número de Expediente";
                datagridResult.Columns[1].HeaderText = "Nombre y Apellidos";
                datagridResult.Columns[2].HeaderText = "Tipo";
                datagridResult.Columns[3].HeaderText = "Feha Inicio";
                datagridResult.Columns[4].HeaderText = "Fecha Fin";
                datagridResult.Columns[5].HeaderText = "Horas disfrutadas";
            }
            else
            {
                datagridResult.DataSource = null;
                MessageBox.Show("No existen datos relacionados para mostrar", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void MostrarDatosLicencias(List<clsLicencias> listaDatosLicencias)
        {
            if (listaDatosLicencias.Count > 0)
            {
                TipoReporte = "Modelo SC 405 Licencias";
                datagridResult.DataSource = null;
                datagridResult.DataSource = listaDatosLicencias;
               // datagridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                datagridResult.Columns[0].HeaderText = "Número de Expediente";
                datagridResult.Columns[1].HeaderText = "Nombre y Apellidos";
                datagridResult.Columns[2].HeaderText = "Tipo";
                datagridResult.Columns[3].HeaderText = "Feha Inicio";
                datagridResult.Columns[4].HeaderText = "Fecha Fin";
                datagridResult.Columns[5].HeaderText = "Horas disfrutadas";
            }
            else
            {
                datagridResult.DataSource = null;
                MessageBox.Show("No existen datos relacionados para mostrar", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void MostrarDatosVacaciones(List<Entidades.Rpt.clsVacaciones> listaDatosVacaciones)
        {
            if (listaDatosVacaciones.Count > 0)
            {
                TipoReporte = "Modelo SC 405 Vacaciones";
                datagridResult.DataSource = null;
                datagridResult.DataSource = listaDatosVacaciones;
                datagridResult.Columns[0].HeaderText = "Número de Expediente";
                datagridResult.Columns[1].HeaderText = "Nombre y Apellidos";
                datagridResult.Columns[2].HeaderText = "Tipo";
                datagridResult.Columns[3].HeaderText = "Feha Inicio";
                datagridResult.Columns[4].HeaderText = "Fecha Fin";
                datagridResult.Columns[5].HeaderText = "Horas disfrutadas";
            }
            else
            {
                datagridResult.DataSource = null;
                MessageBox.Show("No existen datos relacionados para mostrar", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void MostrarDatosCertificadosAccidentes(List<Entidades.Rpt.clsSubsidios> listaDatosCertificadosAccidentes)
        {
            if (listaDatosCertificadosAccidentes.Count > 0)
            {
                TipoReporte = "Modelo SC 405 Certificados y Accidentes";
                datagridResult.DataSource = null;
                datagridResult.DataSource = listaDatosCertificadosAccidentes;
                datagridResult.Columns[0].HeaderText = "Número de Expediente";
                datagridResult.Columns[1].HeaderText = "Nombre y Apellidos";
                datagridResult.Columns[2].HeaderText = "Tipo";
                datagridResult.Columns[3].HeaderText = "Feha Inicio";
                datagridResult.Columns[4].HeaderText = "Fecha Fin";
                datagridResult.Columns[5].HeaderText = "Horas disfrutadas";
            }
            else
            {
                datagridResult.DataSource = null;
                MessageBox.Show("No existen datos relacionados para mostrar", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        IEnumerable<Object> Data;
        private void LoadData(object sender, DoWorkEventArgs e)
        {
            List<object> data = new List<object>();
            if (datagridResult.Rows.Count > 0)
            {
                var ParamNameRpt = TipoReporte;
                var ParamPeriodo = "Período:";
                var ParamPeriodoValue = periodo.PeriodFechaInicio.ToShortDateString() + " - " + periodo.PeriodFechaFin.ToShortDateString();

                var ParamExpediente = "Expediente:";
                var ParamExpedienteValue = "";

                var ParamNombresApellidos = "Nombres y Apellidos";
                var ParamNombresApellidosValue = "";

                var ParamTipo = "Tipo";
                var ParamTipoValue = "";

                var ParamFechaInicio = "Fecha Inicio";
                var ParamFechaInicioValue = "";

                var ParamFechaFin = "Fecha Fin";
                var ParamFechaFinValue = "";

                var ParamHorasDisfrutadas = "Horas";
                var ParamHorasDisfrutadasValue = "";
                
                var ParamNoConsecutivo = "No. Modelo:";
                var ParamValorNoConsecutivos = "";

                var ParamEmpresa = "Empresa:";


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

                   

                    if (datagridResult.Rows[i].Cells["Tipo"].ToString() == "")
                    {
                        ParamTipoValue = "";
                    }
                    else
                    { ParamTipoValue = datagridResult.Rows[i].Cells["Tipo"].Value.ToString(); }

                    if (datagridResult.Rows[i].Cells["FechaInicio"].ToString() == "")
                    {
                        ParamFechaInicioValue = "";
                    }
                    else
                    { ParamFechaInicioValue = datagridResult.Rows[i].Cells["FechaInicio"].Value.ToString(); }

                    if (datagridResult.Rows[i].Cells["FechaFin"].ToString() == "")
                    {
                        ParamFechaFinValue = "";
                    }
                    else
                    { ParamFechaFinValue = datagridResult.Rows[i].Cells["FechaFin"].Value.ToString(); }

                    if (datagridResult.Rows[i].Cells["HorasDisfrutadas"].ToString() == "")
                    {
                        ParamHorasDisfrutadasValue = "";
                    }
                    else
                    {
                        ParamHorasDisfrutadasValue = datagridResult.Rows[i].Cells["HorasDisfrutadas"].Value.ToString(); }


                    data.Add(new ReportEntryIncidencias
                    {
                        ParametroNameRpt = ParamNameRpt,

                        ParametroPeriodo = ParamPeriodo,
                        ParametroValorPeriodo = ParamPeriodoValue,

                        ParametroExpediente = ParamExpediente,
                        ParametroValorExpediente = ParamExpedienteValue,

                        ParametroNombre = ParamNombresApellidos,
                        ParametroValorNombre = ParamNombresApellidosValue,

                        ParametroTipo = ParamTipo,
                        ParametroValorTipo = ParamTipoValue,

                        ParametroFechaInicio = ParamFechaInicio,
                        ParametroValorFechaInicio = ParamFechaInicioValue,

                        ParametroFechaFin = ParamFechaFin,
                        ParametroValorFechaFin = ParamFechaFinValue,

                        ParametroHorasDisfrutadas = ParamHorasDisfrutadas,
                        ParametroValorHorasDisfrutadas = ParamHorasDisfrutadasValue,

                        ParametroNoConsecutivos = ParamNoConsecutivo,
                        ParametroValorNoConsecutivos = periodo.NumeroConsecuitvo.ToString(),

                        ParametroNombreEmpresa = ParamEmpresa,
                        ParametroValorNombreEmpresa = sageSession2.CompanyID.ToString(),

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
            CrystalReportIncidencias rpt = new CrystalReportIncidencias();
            ReportEngine.Report = rpt;
            for (var i = 1; i < ReportEngine.Report.Database.Tables.Count; i++)
                ReportEngine.LoginDataSource(i);
            ReportEngine.Report.Database.Tables[0].SetDataSource(Data);
            ReportEngine.Show();
        }
        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ReportWorker.RunWorkerAsync();
        }
        private void CmbSeleccReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeleccReporte.Text != "Todos")
            {
                EnableControls();
            }
        }
        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableControls();
        }
    }
}
