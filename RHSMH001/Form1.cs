using Entidades.General;
using Negocio;
using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls;
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

namespace RHSMH001
{
    public partial class Form1 : Form
    {
        private Sage500AppEntities mycontext;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            LoadContext();
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
            mycontext = new Sage500AppEntities(connectionString.ToString());
        }
        private void UpdateLookup()
        {
            ControllerRHSMH001 controler = new ControllerRHSMH001();
            lkuNav.SetData(controler.ActualizarLista());
        }
        public void MostrarDatosRegistro(clsHorario dato)
        {
            if (dato != null)
            {
                lvciclos.Items.Clear();
                ControlllerRHSMP001 controler = new ControlllerRHSMP001();
                txtnombreHorario.Text = dato.nombrehorario;
                txtDescripcion.Text = dato.descripcionhorario;
                if (dato.listaCiclos.Count > 0)
                {
                    int count = 1;
                    ListViewItem nuevoitem;
                    foreach (clsCicloHorario item in dato.listaCiclos)
                    {
                        nuevoitem = new ListViewItem(count.ToString());
                        nuevoitem.SubItems.Add(item.horainicio.ToString());
                        nuevoitem.SubItems.Add(item.horafin.ToString());
                        nuevoitem.SubItems.Add(item.tiempotrabajo.ToString());
                        nuevoitem.SubItems.Add(item.duracionJornada.ToString());
                        nuevoitem.SubItems.Add(item.tiempodescanso.ToString());
                        lvciclos.Items.Add(nuevoitem);
                        count++;
                    }
                    nmDia.Value = lvciclos.Items.Count + 1;
                }

            }

        }
        private void EnableControls()
        {
            txtnombreHorario.Enabled = false;
            txtDescripcion.Enabled = true;
            pnlDatosJornada.Enabled = true;
            txtDescripcion.Enabled = true;
            dtpInicio.Enabled = true;
            dtpFin.Enabled = true;
            dtpTiempoTrabajo.Enabled = true;
            lvciclos.Enabled = true;
            btnAdd.Enabled = true;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void GrbCategoriaOcup_Enter(object sender, EventArgs e)
        {

        }
        private void TabPage1_Click(object sender, EventArgs e)
        {

        }
        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {
            ThrShedule data = eventArgs.ReturnValue as ThrShedule;
            try
            {
                clsHorario horario;
                ControllerRHSMH001 controler = new ControllerRHSMH001();
                if (data != null)
                {
                    horario = controler.CargarDatosObjHorario(data.HorarioID);
                    MostrarDatosRegistro(horario);
                    On_IDChange(null, null);
                }
                else
                {
                    ThrShedule horar = controler.GetHorario(txtnombreHorario.Text);
                    if (horar != null)
                    {
                        var shedule = controler.CargarDatosObjHorario(horar.HorarioID);
                        MostrarDatosRegistro(shedule);
                        On_IDChange(null, null);
                    }
                    else
                    { On_IDChange(null, null); }
                }
                EnableControls();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DisableControls()
        {
            txtnombreHorario.Enabled = true;
            txtDescripcion.Enabled = false;
            pnlDatosJornada.Enabled = false;
            txtDescripcion.Enabled = false;
            dtpInicio.Enabled = false;
            dtpFin.Enabled = false;
            dtpTiempoTrabajo.Enabled = false;
            lvciclos.Enabled = false;
            btnAdd.Enabled = false;
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtnombreHorario.Text = "";
            txtDescripcion.Text = "";
            nmDia.Value = 0;
            lvciclos.Items.Clear();
            dtpInicio.Text = "0:00:00";
            dtpFin.Text = "0:00:00";
            dtpTiempoTrabajo.Text = "0:00:00";
            dateTimePicker1.Text = "0:00:00";
            DisableControls();
            LoadContext();
        }
        private bool ValidateForm(object sender, EventArgs e)
        {
            if (MainBS.Current == null) return false;
            ValidateChildren();
            Validate();

            if (txtnombreHorario.Text == "")
            {
                MessageBox.Show("Nombre no válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnombreHorario.Focus();
                return false;
            }
            return true;
        }
        private void TxtnombreHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtnombreHorario.Text.Length == 0)
                {
                    MessageBox.Show("El nombre no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtnombreHorario.Tag = null;
                    On_IDChange(null, null);
                }

            }
        }
        public void On_IDChange(object sender, EventArgs e)
        {
            if (txtnombreHorario.Tag != null && txtnombreHorario.Tag.ToString() == txtnombreHorario.Text) return;
            MainBS.Clear();

            if (txtnombreHorario.Text.Length > 0)
            {
                ControllerRHSMH001 controler = new ControllerRHSMH001();
                ThrShedule data = controler.GetHorario(txtnombreHorario.Text);
                if (data != null)
                {
                    clsHorario horario = controler.CargarDatosObjHorario(data.HorarioID);
                    if (horario != null)
                    {
                        MainBS.Add(horario);
                        MostrarDatosRegistro(horario);
                        strbar.SetFormStatus(FormBindingStatus.Editing);
                    }
                }
                else
                {
                    MainBS.AddNew();
                    nmDia.Value = 1;
                    strbar.SetFormStatus(FormBindingStatus.Adding);
                }
                EnableControls();
            }
            else
            {
                DisableControls();
                strbar.SetFormStatus(FormBindingStatus.Waiting);
            }
            txtnombreHorario.Tag = txtnombreHorario.Text;
        }       
        private void On_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtnombreHorario.Text != "")
                {
                    ControllerRHSMH001 controler = new ControllerRHSMH001();
                    if (lvciclos.Items.Count > 0)
                    {
                        var horario = new clsHorario();
                        horario.nombrehorario = txtnombreHorario.Text;
                        horario.descripcionhorario = txtDescripcion.Text;
                        horario.listaCiclos = this.DevolverListaCiclos();
                        controler.AddHorario(horario);
                        UpdateLookup();
                    }
                    else { MessageBox.Show("Debe seleccionar el ciclo de la jornada que describe el Horario.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar, los datos seleccionables no pueden ser modificados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<clsCicloHorario> DevolverListaCiclos()
        {
            List<clsCicloHorario> listaJornada = new List<clsCicloHorario>();
            foreach (ListViewItem item in lvciclos.Items)
            {
                var objjornada = new clsCicloHorario();
                objjornada.horainicio = item.SubItems[1].Text;
                objjornada.horafin = item.SubItems[2].Text;
                objjornada.tiempotrabajo = item.SubItems[3].Text;
                objjornada.duracionJornada = item.SubItems[4].Text;
                objjornada.tiempodescanso = item.SubItems[5].Text;
                listaJornada.Add(objjornada);
            }
            return listaJornada;
        }                
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (lvciclos.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvciclos.Items)
                {
                    if (item.Selected)
                    {
                        lvciclos.Items.Remove(item);
                        nmDia.Value = lvciclos.Items.Count + 1;
                    }

                }
            }
            else
            { MessageBox.Show("Debe seleccionar un registro.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void DtpInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                dtpFin.Focus();
            }

        }
        private void DtpFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                dtpTiempoTrabajo.Focus();
            }
        }
        private void DtpTiempoTrabajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnAdd_Click(null, null);
            }
        }       
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = nmDia.Value.ToString();
            item.SubItems.Add(dtpInicio.Text);
            item.SubItems.Add(dtpFin.Text);
            item.SubItems.Add(dtpTiempoTrabajo.Text);
            TimeSpan result = dtpFin.Value.Subtract(dtpInicio.Value);
            item.SubItems.Add(result.ToString());
            dtpInicio.Value = DateTime.Now.Add(result);
            var valor = dateTimePicker1.Value + result;
            TimeSpan result1 = valor.Subtract(dtpTiempoTrabajo.Value);
            item.SubItems.Add(result1.ToString());
            lvciclos.Items.Add(item);
            nmDia.Value = lvciclos.Items.Count + 1;
            dtpInicio.Text = "0:00:00";
            dtpFin.Text = "0:00:00";
            dtpTiempoTrabajo.Text = "0:00:00";
            dateTimePicker1.Text = "0:00:00";
        }

        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }

        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtnombreHorario.Text != "")
                {
                    ControllerRHSMH001 controler = new ControllerRHSMH001();
                    ThrShedule horario = controler.GetHorario(txtnombreHorario.Text);
                    bool resultado = controler.DeleteHorario(txtnombreHorario.Text);
                    if (resultado)
                    {                      
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Recuerde vincular los horarios con la persona o la entidad q no esta echo, existen personas que tienen asignado este horario.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("No se puede eliminar el horario, existen personas que tienen asignado este horario.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique, Error al eliminar el horario.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
