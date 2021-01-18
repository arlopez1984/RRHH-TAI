using Entidades.General;
using Negocio;
using Net4Sage;
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

namespace RHSGTTT001
{
    public partial class frmCondicionesAnormales : Form
    {
        List<ThrAnormalCondPosition> listaCondicionesAnormalesBD;
        public List<clsHorasCondiciones> listCondicionesHoras;
        public frmCondicionesAnormales(List<clsHorasCondiciones> listaCondicones, int cargo)
        {
            InitializeComponent();
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;
            ControllerRHSGTTT001 controlador = new ControllerRHSGTTT001();
            listaCondicionesAnormalesBD = controlador.GetCondicionesXCargo(cargo);
            listCondicionesHoras = new List<clsHorasCondiciones>();
            listCondicionesHoras = listaCondicones;
            CargarCondicionesAnormales(listaCondicionesAnormalesBD);
            MostrarCondicionesAnormalesXPersona(listCondicionesHoras);
        }
        public void CargarCondicionesAnormales(List<ThrAnormalCondPosition> listCondiciones)
        {
            try
            {
                ControllerRHSMCA001 controler = new ControllerRHSMCA001();
                for (int i = 0; i < listCondiciones.Count; i++)
                {
                    var condicion = controler.GetAnormalCondicion(listCondiciones[i].AnormalConditionKey);
                    dataGridView2.Rows.Add(false, condicion.AnormalName);
                }
                dataGridView2.AllowUserToAddRows = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar las Condiciones Anormales", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MostrarCondicionesAnormalesXPersona(List<clsHorasCondiciones> listaCondiciones)
        {
            try
            {
                if (listaCondiciones.Count > 0)
                {
                    ControllerRHSMCP001 controlador = new ControllerRHSMCP001();
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        foreach (clsHorasCondiciones item in listaCondiciones)
                        {
                            if (row.Cells[1].Value.ToString() == item.CondicionName)
                            {
                                row.Cells[0].Value = true;
                                row.Cells[2].Value = item.CantHoras.ToString();
                            }
                        }

                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            
        }       
        private void Form2_Load(object sender, EventArgs e)
        {/*
            cmbTipoCompetencia.DataSource = Enum.GetValues(typeof(TipoCompetencias));
            cmbTipoCompetencia.SelectedItem = TipoCompetencias.Básicas; */
        }  
        private void Do_Save(object sender, EventArgs e)
        {
            clsHorasCondiciones objHorasCondiciones;
            listCondicionesHoras.Clear();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                if (isChecked)
                {
                    if (row.Cells[2].Value != null)
                    {
                        objHorasCondiciones = new clsHorasCondiciones();
                        objHorasCondiciones.CondicionName = row.Cells[1].Value.ToString();
                        objHorasCondiciones.CantHoras = Convert.ToDecimal(row.Cells[2].Value.ToString());
                        listCondicionesHoras.Add(objHorasCondiciones);
                    }
                    else
                    {
                        MessageBox.Show("Debe introducir la cantidad de horas a las condiciones anormales seleccionadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }        
        private void Do_Cancel(object sender, EventArgs e)
        {
            // DialogResult = DialogResult.Cancel;
        }      

        private void DataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 2)
            {
                e.Control.KeyPress += new KeyPressEventHandler(DataGridView2_KeyPress);
            }
        }
        private void DataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = (bool)dataGridView2.Rows[e.RowIndex].Cells[0].Value;
            dataGridView2.Rows[e.RowIndex].Cells[0].Value = estado;           
        }
        private void DataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}


