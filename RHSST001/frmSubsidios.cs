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
    public partial class frmSubsidios : Form
    {
        public List<clsSubsidios> listaSubsidiosSeleccionados;
        public List<clsAusencia> listaAusenciasSeleccionadas;
        public List<clsLicencia> listaLicenciaSeleccionadas;
        public List<clsOtraIncidencia> listaOtrasSeleccionadas;
        ControllerRHSGI001 controler = new ControllerRHSGI001();
        ControllerRHSMGP001 open = new ControllerRHSMGP001();
        ThrPeople persona;
        ThrOperationsPeriod periodoAbierto;
        public frmSubsidios(ThrPeople person,  List<clsSubsidios> listaSubsidios, List<clsLicencia> listaLicencias, List<clsAusencia> listaAusencias, List<clsOtraIncidencia> listaOtras)
        {
            InitializeComponent();
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;
            persona = person;
            CargarTiposSubsidios();
            listaLicenciaSeleccionadas = listaLicencias;
            listaAusenciasSeleccionadas = listaAusencias;
            listaOtrasSeleccionadas = listaOtras;
            periodoAbierto = open.GetPeriodoActivo();
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;
            if (listaSubsidios.Count > 0)
            { MostrarSubsidiosSeleccionados(listaSubsidios); }
        }
        public void CargarTiposSubsidios()
        {
            try
            {
                ControllerRHSGI001 controler = new ControllerRHSGI001();
                cmbTipoSubsidios.DataSource = controler.GetaAllsSubsidios();
                cmbTipoSubsidios.DisplayMember = "SubsidyName";
                cmbTipoSubsidios.ValueMember = "SubsidyKey";
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique, no existen los tipos de subsidios establecidos por ley.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
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
        private void btnAdicionrSubsidios_Click(object sender, EventArgs e)
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
                                var totalhoras = result1.TotalHours;
                                var day = result1.Days + 1;
                                var hours = result1.Hours;
                                var minutes = result1.Minutes;
                                if ((hours > 0) || (minutes > 0) || (day > 0))
                                {
                                    bool bandera = false;
                                    foreach (ListViewItem obj in lvSubsidios.Items)
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
                                        item.Text = cmbTipoSubsidios.Text;
                                        item.SubItems.Add(dtpfehaInicio.Value.ToShortDateString());
                                        item.SubItems.Add(dtpfechaFin.Value.ToShortDateString());
                                        if (chkSubInicio.Checked == true)
                                        {
                                            item.SubItems.Add("Si");
                                        }
                                        else { item.SubItems.Add("No"); }
                                        if (chkhospitalizado.Checked == true)
                                        {
                                            item.SubItems.Add("Si");
                                        }
                                        else { item.SubItems.Add("No"); }
                                        item.SubItems.Add(day.ToString());
                                        lvSubsidios.Items.Add(item);
                                        chkhospitalizado.Checked = false;
                                        chkSubInicio.Checked = false;
                                        dtpfehaInicio.Value = DateTime.Now;
                                        dtpfechaFin.Value = DateTime.Now;                                        
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Verifique, el Tiempo de Subsidio es 0.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al adicionar los subsidios seleccionados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnEliminarSubsidios_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvSubsidios.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvSubsidios.SelectedItems)
                    {
                        lvSubsidios.Items.Remove(item);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el(los) subsidios que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el subsidio seleccionado.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
        public void MostrarSubsidiosSeleccionados(List<clsSubsidios> listadoSeleecionado)
        {
            try
            {
                foreach (clsSubsidios subsidio in listadoSeleecionado)
                {
                    ListViewItem item = new ListViewItem();
                    var ObjSubsidio = controler.GetSubsidio(subsidio.tipoSubsidio);
                    item.Text = ObjSubsidio.SubsidyName;
                    item.SubItems.Add(subsidio.fechInicio.ToShortDateString());
                    item.SubItems.Add(subsidio.fechaFin.ToShortDateString());
                    if (subsidio.Subsidioinicio == 1)
                    { item.SubItems.Add("Si"); }
                    else { item.SubItems.Add("No"); }
                    if (subsidio.hospitalizado == 1)
                    { item.SubItems.Add("Si"); }
                    else { item.SubItems.Add("No"); }
                    lvSubsidios.Items.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los subsidio seleccionado.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                listaSubsidiosSeleccionados = new List<clsSubsidios>();
                clsSubsidios nuevoObj;
                foreach (ListViewItem item in lvSubsidios.Items)
                {
                    nuevoObj = new clsSubsidios();
                    ThrSubsidy tiposubidy = controler.GetSubsidioKey(item.Text);
                    nuevoObj.tipoSubsidio = tiposubidy.SubsidyKey;
                    nuevoObj.fechInicio = Convert.ToDateTime(item.SubItems[1].Text);
                    nuevoObj.fechaFin = Convert.ToDateTime(item.SubItems[2].Text);
                    if (item.SubItems[3].Text == "Si")
                    { nuevoObj.Subsidioinicio = 1; }
                    else { nuevoObj.Subsidioinicio = 0; }
                    if (item.SubItems[4].Text == "Si")
                    { nuevoObj.hospitalizado = 1; }
                    else { nuevoObj.hospitalizado = 0; }
                    nuevoObj.Horas = Convert.ToInt32(item.SubItems[5].Text);
                    listaSubsidiosSeleccionados.Add(nuevoObj);
                }
                DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al seleccionar los subsidios.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }    

        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            if (lvSubsidios.Items.Count > 0)
            {
                lvSubsidios.Items.Clear();
            }
        }
    }
}
