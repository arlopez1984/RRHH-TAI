using Entidades.General;
using Negocio;
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
    public partial class frmAusencias : Form
    {
        public List<clsAusencia> listaAusenciasSeleccionadas;
        public List<clsLicencia> listaLicenciaSeleccionadas;
        public List<clsSubsidios> listaSubsidiosSeleccionadas;
        public List<clsOtraIncidencia> listaOtrasSeleccionadas;
        ControllerRHSGI001 controler = new ControllerRHSGI001();
        ControllerRHSMGP001 open = new ControllerRHSMGP001();
        ThrOperationsPeriod periodoAbierto;
        ThrPeople persona;        
        public frmAusencias(ThrPeople person ,List<clsAusencia> listaAusencias, List<clsLicencia> listaLicencia, List<clsSubsidios> listaSubsidios, List<clsOtraIncidencia> listaOtras)
        {
            InitializeComponent();
            CargarTiposAusencia(); 
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;
            periodoAbierto = open.GetPeriodoActivo();
            listaLicenciaSeleccionadas = listaLicencia;
            listaSubsidiosSeleccionadas = listaSubsidios;
            listaOtrasSeleccionadas = listaOtras;
            persona = person;
            if (listaAusencias.Count > 0)
            { MostrarAusenciasSeleccionadas(listaAusencias); }
        }        
        public void CargarTiposAusencia()
        {
            ControllerRHSGI001 controler = new ControllerRHSGI001();
            cmbTipoAusencias.DataSource = controler.GetaAllsAusencias();
            cmbTipoAusencias.DisplayMember = "AbsenceName";
            cmbTipoAusencias.ValueMember = "Absencekey";
        }
        public bool VerificacionIncidencias()
        {   
            if (listaLicenciaSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaLicenciaSeleccionadas.Count; i++)
                {
                    if ((dtpfehaInicio.Value >= listaLicenciaSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaLicenciaSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaLicenciaSeleccionadas[i].fechInicio) && (dtpfechaFin.Value >= listaLicenciaSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaLicenciaSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaLicenciaSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaLicenciaSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaLicenciaSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaLicenciaSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                }
            }
            if (listaSubsidiosSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaSubsidiosSeleccionadas.Count; i++)
                {
                    if ((dtpfehaInicio.Value >= listaSubsidiosSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaSubsidiosSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaSubsidiosSeleccionadas[i].fechInicio) && (dtpfechaFin.Value >= listaSubsidiosSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaSubsidiosSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaSubsidiosSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaSubsidiosSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaSubsidiosSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaSubsidiosSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                }
            }
            if (listaOtrasSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaOtrasSeleccionadas.Count; i++)
                {
                    if ((dtpfehaInicio.Value >= listaOtrasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaOtrasSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaOtrasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value >= listaOtrasSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaOtrasSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaOtrasSeleccionadas[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= listaOtrasSeleccionadas[i].fechInicio) && (dtpfechaFin.Value <= listaOtrasSeleccionadas[i].fechaFin) && (dtpfechaFin.Value >= listaOtrasSeleccionadas[i].fechInicio))
                    {
                        return false;
                    }
                }
            }           
            return true;
        }
        public bool VerificarVacaciones()
        {
            ControllerRHSGVT001 control = new ControllerRHSGVT001();
            var Vacaciones = control.GetVacacionesXTrabajados(persona.PersonKey, periodoAbierto.Periodkey);
            if (Vacaciones.Count > 0)
            {
                for (int i = 0; i < Vacaciones.Count; i++)
                {
                    if ((dtpfehaInicio.Value.Date >= Vacaciones[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= Vacaciones[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= Vacaciones[i].fechInicio.Date) && (dtpfechaFin.Value.Date >= Vacaciones[i].fechInicio.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= Vacaciones[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= Vacaciones[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= Vacaciones[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= Vacaciones[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= Vacaciones[i].fechInicio.Date))
                    {
                        return false;
                    }
                }
            }            
            return true;
        }
        private void BtnAdicionrAusencias_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dtpfehaInicio.Value.Date >= periodoAbierto.PeriodFechaInicio.Date) && (dtpfechaFin.Value.Date <= periodoAbierto.PeriodFechaFin.Date))
                {
                    if (dtpfechaFin.Value > dtpfehaInicio.Value)
                    {
                        if (VerificarVacaciones())
                        {
                            if (VerificacionIncidencias())
                            {
                                string horas = "";
                                string minutos = "";
                                TimeSpan result = dtpfechaFin.Value.Subtract(dtpfehaInicio.Value);
                                double totalhoras = result.TotalHours;
                                double day = result.Days;
                                double hours = result.Hours;
                                double minutes = result.Minutes;
                                if (day == 0)
                                {
                                    if (hours < 10)
                                    {
                                        horas = "0" + hours.ToString();
                                    }
                                    else { horas = hours.ToString(); }
                                    if (minutes < 10)
                                    {
                                        minutos = "0" + minutes.ToString();
                                    }
                                    else { minutos = minutes.ToString(); }
                                }
                                else
                                {
                                    horas = (day * 24).ToString();
                                    if (minutes < 10)
                                    {
                                        minutos = "0" + minutes.ToString();
                                    }
                                    else { minutos = minutes.ToString(); }
                                }
                                if ((hours > 0) || (minutes > 0) || (day > 0))
                                {
                                    bool bandera = false;
                                    foreach (ListViewItem obj in lvAusencias.Items)
                                    {
                                        DateTime fechaInicio = Convert.ToDateTime(obj.SubItems[1].Text);
                                        DateTime fechaFin = Convert.ToDateTime(obj.SubItems[2].Text);

                                        if ((dtpfehaInicio.Value <= fechaInicio) && (dtpfechaFin.Value >= fechaInicio))
                                        {
                                            MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            bandera = true;
                                            return;
                                        }
                                        if ((dtpfehaInicio.Value <= fechaFin) && (dtpfechaFin.Value >= fechaFin))
                                        {
                                            MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            bandera = true;
                                            return;
                                        }
                                        //if ((dtpfehaInicio.Value >= fechaInicio) && (dtpfechaFin.Value <= fechaFin))
                                        //{
                                        //    MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //    bandera = true;
                                        //    return;
                                        //}
                                        if ((dtpfehaInicio.Value <= fechaInicio) && (dtpfechaFin.Value <= fechaFin) && (dtpfechaFin.Value >= fechaInicio))
                                        {
                                            MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            bandera = true;
                                            return;
                                        }
                                    }
                                    if (!bandera)
                                    {
                                        if (dtpfehaInicio.Value.Date == dtpfechaFin.Value.Date)
                                        {
                                            ListViewItem item = new ListViewItem();
                                            item.Text = cmbTipoAusencias.Text;
                                            item.SubItems.Add(dtpfehaInicio.Value.ToString());
                                            item.SubItems.Add(dtpfechaFin.Value.ToString());
                                            item.SubItems.Add(horas+ "." + minutos);
                                            //item.SubItems.Add(day.ToString());
                                            lvAusencias.Items.Add(item);
                                            dtpfehaInicio.Value = DateTime.Now;
                                            dtpfechaFin.Value = DateTime.Now;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Las ausencias deben ser registrada especificamente por día.", "Sage MAS 500", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                     
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
                                MessageBox.Show("En la fecha seleccionada se encuentra registrada una incidencia.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        { MessageBox.Show("En la fecha seleccionada hay vacaciones planificadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("La fecha de inicio no puede ser mayor o igual a la fecha fín.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else { MessageBox.Show("Verifique. La fechas de inicio y fin de la Ausencia no se encuentran dentro del periodo activo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al seleccionar los datos del período.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }                   
        private void BtnEliminarAusencias_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvAusencias.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvAusencias.SelectedItems)
                    {
                        lvAusencias.Items.Remove(item);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la(s) ausencias que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar los datos seleccionados de la ausencia.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
           
        }
        public void MostrarAusenciasSeleccionadas(List<clsAusencia> listadoSeleecionado)
        {
            try
            {
                foreach (clsAusencia ausencia in listadoSeleecionado)
                {
                    string horas = "";
                    string minutos = "";
                    TimeSpan result = ausencia.fechaFin.Subtract(ausencia.fechInicio);
                    double day = result.Days;
                    double hours = result.Hours;
                    double minutes = result.Minutes;
                    if (day == 0)
                    {
                        if (hours < 10)
                        {
                            horas = "0" + hours.ToString();
                        }
                        else { horas = hours.ToString(); }
                        if (minutes < 10)
                        {
                            minutos = "0" + minutes.ToString();
                        }
                        else { minutos = minutes.ToString(); }
                    }
                    else
                    {
                        horas = (day * 24).ToString();
                        if (minutes < 10)
                        {
                            minutos = "0" + minutes.ToString();
                        }
                        else { minutos = minutes.ToString(); }
                    }
                    ListViewItem item = new ListViewItem();
                    var Objausencia = controler.GetAusencia(ausencia.tipoAusencia);
                    item.Text = Objausencia.AbsenceName;
                    item.SubItems.Add(ausencia.fechInicio.ToString());
                    item.SubItems.Add(ausencia.fechaFin.ToString());
                    item.SubItems.Add(horas + "." + minutos);
                    lvAusencias.Items.Add(item);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los datos seleccionados de la ausencia.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                listaAusenciasSeleccionadas = new List<clsAusencia>();
                clsAusencia nuevoObj;
                foreach (ListViewItem item in lvAusencias.Items)
                {
                    nuevoObj = new clsAusencia();
                    ThrAbsence tipoAusencia = controler.GetAusenciaKey(item.Text);
                    nuevoObj.tipoAusencia = tipoAusencia.Absencekey;
                    nuevoObj.fechInicio = Convert.ToDateTime(item.SubItems[1].Text);
                    nuevoObj.fechaFin = Convert.ToDateTime(item.SubItems[2].Text);
                    nuevoObj.HorasDisfrutadas = item.SubItems[3].Text;
                    listaAusenciasSeleccionadas.Add(nuevoObj);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al seleccionar los datos de la ausencia.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            if (lvAusencias.Items.Count > 0)
            {
                lvAusencias.Items.Clear();
            }
        }
    }
}
