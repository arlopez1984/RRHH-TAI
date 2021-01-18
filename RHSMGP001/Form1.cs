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

namespace RHSMGP001
{
    public partial class frmPeriodo : Form
    {
        ControllerRHSMGP001 controler;
        ThrOperationsPeriod periodo;
        public frmPeriodo()
        {
            InitializeComponent();
            controler = new ControllerRHSMGP001();
            //menuBar1.Items[3].Visible = false;
            menuBar1.Items[1].Visible = false;
        }
        public frmPeriodo(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            LoadContext();
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
        public void MostrarDatosRegistro(ThrOperationsPeriod dato)
        {
            try
            {
                if (dato != null)
                {
                    dtpFechaInicio.Value = dato.PeriodFechaInicio;
                    dtpFechaFin.Value = dato.PeriodFechaFin;
                    txtdescripcion.Text = "El período activo tiene como fecha de Inicio el día" + " "+ dtpFechaInicio.Value.ToShortDateString() + " y como fecha de fín" + " "+ dtpFechaFin.Value.ToShortDateString();
                    rdbIniciarOperacion.Checked = true;
                }
                else
                {
                   MessageBox.Show("No existe en estos momentos un período abierto. Debe iniciar el período en el cuál desea realizar las operaciones .", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   txtdescripcion.Text = "El período activo tiene como fecha de Inicio el día" + " " + dtpFechaInicio.Value.ToShortDateString() + " " + " y como fecha de fín" + " " + " " + dtpFechaFin.Value.ToShortDateString();
                   dtpFechaInicio.Value = DateTime.Now;
                   dtpFechaFin.Value = DateTime.Now;
                   TimeSpan result = dtpFechaFin.Value.Date - dtpFechaInicio.Value.Date;
                   lblTotalDias.Text = result.Days.ToString();
                   rdbIniciarOperacion.Checked = true;
                   rdbCerrarOperacion.Checked = false;
                   rdbCerrarOperacion.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void CargarDatosIniciales()
        {         
            periodo = controler.GetPeriodoActivo();            
            MostrarDatosRegistro(periodo);            
        }
        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtdescripcion.Text = "El período activo tiene como fecha de Inicio el día" + " " + dtpFechaInicio.Value.ToShortDateString() + " " + " y como fecha de fín" + " " + " " + dtpFechaFin.Value.ToShortDateString() + ".";
            TimeSpan result = dtpFechaFin.Value.Date - dtpFechaInicio.Value.Date;
            lblTotalDias.Text = result.Days.ToString();
        }       
        private void DtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            txtdescripcion.Text = "El período activo tiene como fecha de Inicio el día" + " " + dtpFechaInicio.Value.ToShortDateString() + " " + " y como fecha de fín" + " " + " " + dtpFechaFin.Value.ToShortDateString() + ".";
            TimeSpan result = dtpFechaFin.Value.Date - dtpFechaInicio.Value.Date;
            lblTotalDias.Text = result.Days.ToString();
        }       
        public bool ValidarFechasPeriodo()
        {
            var dataPeriodos = controler.GetPeriodos();
            bool resultado = true;
            if (dataPeriodos.Count > 0)
            {
                foreach (ThrOperationsPeriod item in dataPeriodos)
                {
                    if ((item.PeriodFechaInicio <= dtpFechaInicio.Value && item.PeriodFechaFin >= dtpFechaFin.Value) // dentro de las dos
                        || (item.PeriodFechaInicio >= dtpFechaInicio.Value && item.PeriodFechaInicio >= dtpFechaFin.Value) // fechaInicio en medio 
                        || (item.PeriodFechaFin >= dtpFechaInicio.Value && item.PeriodFechaFin <= dtpFechaFin.Value)) // fechaFin en medio
                    {
                        resultado = false;
                    }
                }
            }
            return resultado;
        }
        private void Do_Save(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value <= dtpFechaFin.Value)
            {
                if (rdbIniciarOperacion.Checked)
                {
                    var objOperacion = new ThrOperationsPeriod();
                    {
                        objOperacion.PeriodFechaInicio = dtpFechaInicio.Value;
                        objOperacion.PeriodFechaFin = dtpFechaFin.Value;
                        objOperacion.PeriodEstado = 1;
                        objOperacion.PeriodoDescription = dtpFechaInicio.Value.ToShortDateString() + " " + " - " + " " + dtpFechaFin.Value.ToShortDateString();
                    }                    
                    bool salvar = controler.AddPeriodoActivo(objOperacion);
                    if (!salvar)
                    {
                        MessageBox.Show("No es posible, puede existir un período sin cerrar o las fechas se encuentran incluidas en otro período.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        rdbCerrarOperacion.Enabled = true;
                        MessageBox.Show("El período ha sido creado con éxito.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosIniciales();
                    }                   

                }
                if (rdbCerrarOperacion.Checked)
                {
                    bool cerrar = controler.CerrarPeriodoActivo();
                    if (!cerrar)
                    {
                        MessageBox.Show("No se pudo cerrar el período deseado.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("El período ha sido cerrado con éxito.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rdbCerrarOperacion.Enabled = false;
                        rdbIniciarOperacion.Checked = true;
                    }
                }
            }
            else { MessageBox.Show("Verifique, fechas incorrectas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void RdbCerrarOperacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCerrarOperacion.Checked)
            {
                var periodo = controler.GetPeriodoActivo();
                if (periodo != null)
                {
                    dtpFechaInicio.Value = periodo.PeriodFechaInicio;
                    dtpFechaFin.Value = periodo.PeriodFechaFin;
                    txtdescripcion.Text = "El período activo tiene como fecha de Inicio el día" + " " + dtpFechaInicio.Value.ToShortDateString() + " y como fecha de fín" + " " + dtpFechaFin.Value.ToShortDateString();
                }
            }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            var periodo = controler.GetPeriodoActivo();
            MostrarDatosRegistro(periodo);
        }
        private void RdbIniciarOperacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIniciarOperacion.Checked)
            {
                var periodo = controler.GetPeriodoActivo();
                if (periodo != null)
                {
                    dtpFechaInicio.Value = periodo.PeriodFechaInicio;
                    dtpFechaFin.Value = periodo.PeriodFechaFin;
                    txtdescripcion.Text = "El período activo tiene como fecha de Inicio el día" + " " + dtpFechaInicio.Value.ToShortDateString() + " y como fecha de fín" + " " + dtpFechaFin.Value.ToShortDateString();
                }
            }
        }
        private bool Delete(object sender, EventArgs e)
        {
            var objOperacion = new ThrOperationsPeriod();
            {
                objOperacion.PeriodFechaInicio = dtpFechaInicio.Value;
                objOperacion.PeriodFechaFin = dtpFechaFin.Value;
            }
            bool result = controler.EliminarPeriodoActivo(objOperacion);
            if (!result)
            {
                MessageBox.Show("Verifique, el período no puede ser eliminado. Puede tener registros asociados o puede no ser un período real", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else 
            { 
                MessageBox.Show("Período eliminado con éxito.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
           
        }
    }
}
