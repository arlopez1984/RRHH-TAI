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
    public partial class frmLicencias : Form
    {
        ControllerRHSGI001 controler = new ControllerRHSGI001();
        ControllerRHSMGP001 open = new ControllerRHSMGP001();
        ThrOperationsPeriod periodoAbierto;
        ThrPeople persona;
        public List<clsLicencia> listaLicenciasSeleccionadas;
        public List<clsAusencia> listaAusenciasSeleccionadas;
        public List<clsSubsidios> listaSubsidiosSeleccionadas;
        public List<clsOtraIncidencia> listaOtrasSeleccionadas;
        public frmLicencias(ThrPeople person, List<clsLicencia> listaLicencias, List<clsAusencia> listaAusencias, List<clsSubsidios> listaSubsidios, List<clsOtraIncidencia> listaOtras)
        {
            InitializeComponent();
            persona = person;
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;
            listaAusenciasSeleccionadas = listaAusencias;
            listaSubsidiosSeleccionadas = listaSubsidios;
            listaOtrasSeleccionadas = listaOtras;           
            CargarTiposLicencias();            
            periodoAbierto = open.GetPeriodoActivo();
            if (listaLicencias.Count > 0)
            { MostrarLicenciasSeleccionadas(listaLicencias); }
        }
        public void CargarTiposLicencias()
        {
            try
            {
                ControllerRHSGI001 controler = new ControllerRHSGI001();
                cmbTipoLicencias.DataSource = controler.GetaAllsLicencias();
                cmbTipoLicencias.DisplayMember = "LicenceName";
                cmbTipoLicencias.ValueMember = "Licencekey";

            }
            catch (Exception)
            {
                MessageBox.Show("Verifique, no existen los tipos de licencia establecidos por ley.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        public bool VerificacionIncidencias()
        {
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
            if (listaSubsidiosSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaSubsidiosSeleccionadas.Count; i++)
                {
                    if ((dtpfehaInicio.Value.Date >= listaSubsidiosSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaSubsidiosSeleccionadas[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaSubsidiosSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date >= listaSubsidiosSeleccionadas[i].fechInicio.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaSubsidiosSeleccionadas[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaSubsidiosSeleccionadas[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaSubsidiosSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaSubsidiosSeleccionadas[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaSubsidiosSeleccionadas[i].fechInicio.Date))
                    {
                        return false;
                    }
                }
            }
            if (listaOtrasSeleccionadas.Count > 0)
            {
                for (int i = 0; i < listaOtrasSeleccionadas.Count; i++)
                {
                    if ((dtpfehaInicio.Value.Date >= listaOtrasSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaOtrasSeleccionadas[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaOtrasSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date >= listaOtrasSeleccionadas[i].fechInicio.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaOtrasSeleccionadas[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaOtrasSeleccionadas[i].fechaFin.Date))
                    {
                        return false;
                    }
                    if ((dtpfehaInicio.Value.Date <= listaOtrasSeleccionadas[i].fechInicio.Date) && (dtpfechaFin.Value.Date <= listaOtrasSeleccionadas[i].fechaFin.Date) && (dtpfechaFin.Value.Date >= listaOtrasSeleccionadas[i].fechInicio.Date))
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
        public void MostrarLicenciasSeleccionadas(List<clsLicencia> listadoSeleecionado)
        {
            try
            {
                foreach (clsLicencia licence in listadoSeleecionado)
                {
                    ListViewItem item = new ListViewItem();
                    var ObjLicence = controler.GetLicence(licence.tipoLicencia);
                    item.Text = ObjLicence.LicenceName;
                    item.SubItems.Add(licence.fechInicio.ToShortDateString());
                    item.SubItems.Add(licence.fechaFin.ToShortDateString());
                    lvlicencias.Items.Add(item);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos de licencias seleccionadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            
        }     
        private void BtnAdicionrLicencias_Click(object sender, EventArgs e)
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
                                TimeSpan result = dtpfechaFin.Value.Subtract(dtpfehaInicio.Value);
                                double totalhoras = result.TotalHours;
                                double day = result.Days + 1;
                                double hours = result.Hours;
                                double minutes = result.Minutes;
                                if ((hours > 0) || (minutes > 0) || (day > 0))
                                {
                                    bool bandera = false;
                                    foreach (ListViewItem obj in lvlicencias.Items)
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
                                        ListViewItem item = new ListViewItem();
                                        item.Text = cmbTipoLicencias.Text;
                                        item.SubItems.Add(dtpfehaInicio.Value.ToShortDateString());
                                        item.SubItems.Add(dtpfechaFin.Value.ToShortDateString());
                                        item.SubItems.Add(day.ToString());
                                        lvlicencias.Items.Add(item);
                                        dtpfehaInicio.Value = DateTime.Now;
                                        dtpfechaFin.Value = DateTime.Now;
                                        // }
                                        //else
                                        //{
                                        //    DialogResult resul = MessageBox.Show("La cantidad de horas supera la jornada laboral, desea continuar?.", "Sage MAS 500", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                        //    if (resul == DialogResult.Yes)
                                        //    {
                                        //        ListViewItem item = new ListViewItem();
                                        //        item.Text = cmbTipoLicencias.Text;
                                        //        item.SubItems.Add(dtpfehaInicio.Value.ToString());
                                        //        item.SubItems.Add(dtpfechaFin.Value.ToString());
                                        //        lvlicencias.Items.Add(item);
                                        //        dtpfehaInicio.Value = DateTime.Now;
                                        //        dtpfechaFin.Value = DateTime.Now;
                                        //    }
                                        //}
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Verifique, el Tiempo de Licencia es 0.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
                else
                { MessageBox.Show("En la fecha seleccionada hay vacaciones planificadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch (Exception)
            {

                MessageBox.Show("Error al seleccionar los datos de la licancia.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        private void BtnEliminarLicencias_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvlicencias.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvlicencias.SelectedItems)
                    {
                        lvlicencias.Items.Remove(item);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la(s) licencias que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la licencia seleccionada.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                listaLicenciasSeleccionadas = new List<clsLicencia>();
                clsLicencia nuevoObj;
                foreach (ListViewItem item in lvlicencias.Items)
                {
                    nuevoObj = new clsLicencia();
                    ThrLicence tipoLicence = controler.GetLicenciaKey(item.Text);
                    nuevoObj.tipoLicencia = tipoLicence.Licencekey;
                    nuevoObj.fechInicio = Convert.ToDateTime(item.SubItems[1].Text);
                    nuevoObj.fechaFin = Convert.ToDateTime(item.SubItems[2].Text);
                    nuevoObj.Horas = Convert.ToInt32(item.SubItems[3].Text);
                    listaLicenciasSeleccionadas.Add(nuevoObj);
                }
                DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al seleccionar las licencias.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
           
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            if (lvlicencias.Items.Count > 0)
            {
                lvlicencias.Items.Clear();
            }
        }
    }
}
