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
    public partial class frmOtrasIncidencias : Form
    {
        ControllerRHSGI001 controler = new ControllerRHSGI001();
        public List<clsOtraIncidencia> listaOtrasIncidenciasSeleccionadas;
        public List<clsSubsidios> listaSubsidiosSeleccionados;
        public List<clsAusencia> listaAusenciasSeleccionadas;
        public List<clsLicencia> listaLicenciaSeleccionadas;
        ControllerRHSMGP001 open = new ControllerRHSMGP001();
        ThrOperationsPeriod periodoAbierto;
        ThrPeople persona;
        public frmOtrasIncidencias(ThrPeople person, List<clsOtraIncidencia> listaotrasIncidencias, List<clsLicencia> listaLicencias, List<clsSubsidios> listaSubsidios, List<clsAusencia> listaAusencias)
        {
            InitializeComponent();
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;
            persona = person;
            CargarTiposOtrasIncidencias();
            listaLicenciaSeleccionadas = listaLicencias;
            listaAusenciasSeleccionadas = listaAusencias;
            listaSubsidiosSeleccionados = listaSubsidios;
            periodoAbierto = open.GetPeriodoActivo();
            if (listaotrasIncidencias.Count > 0)
            { MostrarOtrasIncidenciasSeleccionadas(listaotrasIncidencias); }
        }
        public void CargarTiposOtrasIncidencias()
        {
            try
            {
                ControllerRHSGI001 controler = new ControllerRHSGI001();
                cmbTipoOtraIncidencia.DataSource = controler.GetaAllsOtrasIncidencias();
                cmbTipoOtraIncidencia.DisplayMember = "IncidenceID";
                cmbTipoOtraIncidencia.ValueMember = "Incidencekey";
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique, no existen los tipos de Otras Incidencias establecidas por ley.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
        public bool VerificacionIncidencias()
        {
            if (listaLicenciaSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaLicenciaSeleccionadas.Count; i++)
                {
                    if ((dtpfehaInicio.Value.Date >= listaLicenciaSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaLicenciaSeleccionadas[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaLicenciaSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date >= listaLicenciaSeleccionadas[i].fechInicio.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaLicenciaSeleccionadas[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaLicenciaSeleccionadas[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaLicenciaSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaLicenciaSeleccionadas[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaLicenciaSeleccionadas[i].fechInicio.Date))
                    {
                        return false;
                    }
                }
            }
            if (listaAusenciasSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaAusenciasSeleccionadas.Count; i++)
                {
                    if ((dtpfehaInicio.Value.Date >= listaAusenciasSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaAusenciasSeleccionadas[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaAusenciasSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date >= listaAusenciasSeleccionadas[i].fechInicio.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaAusenciasSeleccionadas[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaAusenciasSeleccionadas[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaAusenciasSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaAusenciasSeleccionadas[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaAusenciasSeleccionadas[i].fechInicio.Date))
                    {
                        return false;
                    }
                }
            }
            if (listaSubsidiosSeleccionados.Count > 0)
            {
                for (int i = 0; i < listaSubsidiosSeleccionados.Count; i++)
                {
                    if ((dtpfehaInicio.Value.Date >= listaSubsidiosSeleccionados[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaSubsidiosSeleccionados[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaSubsidiosSeleccionados[i].fechInicio.Date) && (dtpfechaFin.Value.Date >= listaSubsidiosSeleccionados[i].fechInicio.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaSubsidiosSeleccionados[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaSubsidiosSeleccionados[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaSubsidiosSeleccionados[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaSubsidiosSeleccionados[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaSubsidiosSeleccionados[i].fechInicio.Date))
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
                    if ((dtpfehaInicio.Value >= Vacaciones[i].fechInicio) && (dtpfechaFin.Value <= Vacaciones[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= Vacaciones[i].fechInicio) && (dtpfechaFin.Value >= Vacaciones[i].fechInicio))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= Vacaciones[i].fechaFin) && (dtpfechaFin.Value >= Vacaciones[i].fechaFin))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value <= Vacaciones[i].fechInicio) && (dtpfechaFin.Value <= Vacaciones[i].fechaFin) && (dtpfechaFin.Value >= Vacaciones[i].fechInicio))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void MostrarOtrasIncidenciasSeleccionadas(List<clsOtraIncidencia> listadoSeleecionado)
        {
            try
            {
                foreach (clsOtraIncidencia Otraincidence in listadoSeleecionado)
                {
                    ListViewItem item = new ListViewItem();
                    var ObjOtraincidence = controler.GetOtraIncidencia(Otraincidence.tipoOtraIncidencia);
                    item.Text = ObjOtraincidence.IncidenceID;
                    item.SubItems.Add(Otraincidence.fechInicio.ToShortDateString());
                    item.SubItems.Add(Otraincidence.fechaFin.ToShortDateString());
                    lvOtraIncidencias.Items.Add(item);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar las Otras Incidencias seleccionadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                listaOtrasIncidenciasSeleccionadas = new List<clsOtraIncidencia>();
                clsOtraIncidencia nuevoObj;
                foreach (ListViewItem item in lvOtraIncidencias.Items)
                {
                    nuevoObj = new clsOtraIncidencia();
                    ThrIncidence tipoincidence = controler.GetIncidenciaKey(item.Text);
                    nuevoObj.tipoOtraIncidencia = tipoincidence.Incidencekey;
                    nuevoObj.fechInicio = Convert.ToDateTime(item.SubItems[1].Text);
                    nuevoObj.fechaFin = Convert.ToDateTime(item.SubItems[2].Text);
                    nuevoObj.Horas = Convert.ToInt32(item.SubItems[3].Text);
                    listaOtrasIncidenciasSeleccionadas.Add(nuevoObj);
                }
                DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al seleccionar las Otras Incidencias.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        private void BtnAdicionrOtraIncidencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarVacaciones())
                {
                    if ((dtpfehaInicio.Value.Date >= periodoAbierto.PeriodFechaInicio.Date) && (dtpfechaFin.Value.Date <= periodoAbierto.PeriodFechaFin.Date))
                    {
                        if (dtpfechaFin.Value > dtpfehaInicio.Value)
                        {
                            if (VerificacionIncidencias())
                            {
                                TimeSpan result1 = dtpfechaFin.Value.Subtract(dtpfehaInicio.Value);
                                double totalhoras = result1.TotalHours;
                                double day = result1.Days +1;
                                double hours = result1.Hours;
                                double minutes = result1.Minutes;
                                if ((hours > 0) || (minutes > 0) || (day > 0))
                                {
                                    bool bandera = false;
                                    foreach (ListViewItem obj in lvOtraIncidencias.Items)
                                    {
                                        DateTime fechaInicio = Convert.ToDateTime(obj.SubItems[1].Text).Date;
                                        DateTime fechaFin = Convert.ToDateTime(obj.SubItems[2].Text).Date;

                                        if ((dtpfehaInicio.Value.Date <= fechaInicio) && (dtpfechaFin.Value.Date >= fechaInicio))
                                        {
                                            MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            bandera = true;
                                            return;
                                        }
                                        if ((dtpfehaInicio.Value.Date <= fechaFin) && (dtpfechaFin.Value.Date >= fechaFin))
                                        {
                                            MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            bandera = true;
                                            return;
                                        }
                                        if ((dtpfehaInicio.Value.Date >= fechaInicio) && (dtpfechaFin.Value.Date <= fechaFin))
                                        {
                                            MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            bandera = true;
                                            return;
                                        }
                                        //if ((dtpfehaInicio.Value.Date <= fechaInicio) && (dtpfechaFin.Value.Date <= fechaFin))
                                        //{
                                        //    MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //    bandera = true;
                                        //    return;
                                        //}
                                        if ((dtpfehaInicio.Value.Date <= fechaInicio) && (dtpfechaFin.Value.Date <= fechaFin) && (dtpfechaFin.Value.Date >= fechaInicio))
                                        {
                                            MessageBox.Show("Verifique, la fecha que esta seleccionando se encuentra dentro de las fechas anteriormente selecionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            bandera = true;
                                            return;
                                        }
                                    }
                                    if (!bandera)
                                    {
                                        //if (totalhoras <= 8)
                                        //{
                                        ListViewItem item = new ListViewItem();
                                        item.Text = cmbTipoOtraIncidencia.Text;
                                        item.SubItems.Add(dtpfehaInicio.Value.ToShortDateString());
                                        item.SubItems.Add(dtpfechaFin.Value.ToShortDateString());
                                        item.SubItems.Add(day.ToString());
                                        lvOtraIncidencias.Items.Add(item);
                                        dtpfehaInicio.Value = DateTime.Now;
                                        dtpfechaFin.Value = DateTime.Now;  
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
                        {
                            MessageBox.Show("La fecha de inicio no puede ser mayor o igual a la fecha fín.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else { MessageBox.Show("Verifique. La fechas de inicio y fin de la Ausencia no se encuentran dentro del periodo activo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("En la fecha seleccionada hay vacaciones planificadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al adicionar los datos de Otras Incidencias.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
            
        }

        private void BtnEliminarOtraIncidencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvOtraIncidencias.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvOtraIncidencias.SelectedItems)
                    {
                        lvOtraIncidencias.Items.Remove(item);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la(s) incidencias que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar Otras Incidencias.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        private void Do_Cancel(object sender, EventArgs e)
        {
            if (lvOtraIncidencias.Items.Count > 0)
            {
                lvOtraIncidencias.Items.Clear();
            }
        }
    }
}
