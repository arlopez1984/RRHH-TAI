using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.General;
using Sage500AppModel;
using RHSMCP001.Objects;

namespace RHSMC001
{
    public partial class frmCompetencia : Form
    {
        public List<clsCompetencias> listCompeteSelecionadas = new List<clsCompetencias>();
        public List<ThrCompetenciaCargo> listaCompetenciasCargo = new List<ThrCompetenciaCargo>();
        public List<ThrCompetencia> listaCompetenciasBD = new List<ThrCompetencia>();
        int TipoCompetencia = 0;
        string codigoID = "";
        public frmCompetencia(List<clsCompetencias> lista, string codigoCargo)
        {
            InitializeComponent();
            listCompeteSelecionadas = lista;
            codigoID = codigoCargo;
            DataGridViewComboBoxColumn comboColumn = this.dataGridView1.Columns[4] as DataGridViewComboBoxColumn;
            comboColumn.FlatStyle = FlatStyle.Flat;
            ControllerRHSMCP001 controlador = new ControllerRHSMCP001();
            listaCompetenciasBD = controlador.GetCompetencias(); 
            CargarCompetencias(listaCompetenciasBD);
            MostrarCompetenciasSeleccionadas(lista);
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;
            
        }
        public void MostrarCompetenciasSeleccionadas(List<clsCompetencias> listaCompSeleccionadas)
        {
            try
            {
                if (listaCompSeleccionadas.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (clsCompetencias item in listaCompSeleccionadas)
                        {
                            if (row.Cells[1].Value.ToString() == item.nombre)
                            {
                                row.Cells[0].Value = true;
                                if (item.requerido)
                                {
                                    row.Cells[3].Value = true;
                                }
                                if (item.niveles == 1)
                                {
                                    row.Cells[4].Value = "Alto";
                                }
                                else if (item.niveles == 2)
                                {
                                    row.Cells[4].Value = "Medio";
                                }
                                else if (item.niveles == 3)
                                { row.Cells[4].Value = "Bajo"; }
                                row.Visible = false;
                            } 
                        }
                    }
                } 
                dataGridView1.AllowUserToAddRows = false;

            }
            catch (Exception)
            {
                throw;
            }
        }       
        public void MostrarCompetenciasCargoXTipo(int tipo)
        {
            try
            {
                var tipoCompetencia = "";
                if (tipo == 1)
                {
                    tipoCompetencia = "Básicas";
                }
                else if (tipo == 2)
                {
                    tipoCompetencia = "Generales";
                }
                else { tipoCompetencia = "Específicas"; }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[5].Value.ToString() == tipoCompetencia)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                } 
                dataGridView1.AllowUserToAddRows = false;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void CargarCompetencias(List<ThrCompetencia> listCompetenciasBD)
        {
            try
            {
                clsCompetencias competencia;
                var nametipo = "";
                for (int i = 0; i < listCompetenciasBD.Count; i++)
                {
                    competencia = new clsCompetencias();
                    competencia.nombre = listCompetenciasBD[i].CompetenciaID;
                    competencia.descripcion = listCompetenciasBD[i].CompetenciaDescrip;
                    competencia.tipo = listCompetenciasBD[i].TipoCompetencia;
                    if (competencia.tipo == 1)
                        nametipo = "Básicas";
                    else if (competencia.tipo == 2)
                    { nametipo = "Generales"; }
                    else { nametipo = "Específicas"; }
                    dataGridView1.Rows[i].Tag = competencia;
                    dataGridView1.Rows.Add(false, listCompetenciasBD[i].CompetenciaID, listCompetenciasBD[i].CompetenciaDescrip, false, "Medio", nametipo);

                }
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar las competencias", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            cmbTipoCompetencia.DataSource = Enum.GetValues(typeof(TipoCompetencias));
            cmbTipoCompetencia.SelectedItem = TipoCompetencias.Básicas; 
        }           
        private void CmbTipoCompetencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoCompetencias selectipo = (TipoCompetencias)cmbTipoCompetencia.SelectedItem;
            TipoCompetencia = ((SByte)selectipo);            
            MostrarCompetenciasCargoXTipo(TipoCompetencia);
        }
        private void Do_Save(object sender, EventArgs e)
        {
            clsCompetencias competencia;
            listCompeteSelecionadas.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells[0].Value);

                if (isChecked)
                {
                    competencia = new clsCompetencias();
                    competencia.nombre = row.Cells[1].Value.ToString();
                    competencia.descripcion = row.Cells[2].Value.ToString();
                    bool isRequerida = Convert.ToBoolean(row.Cells["ColRequerido"].Value);
                    if (isRequerida)
                    {
                        competencia.requerido = true;
                    }
                    else
                    { competencia.requerido = false; }
                    string nivel = row.Cells["ColNivel"].Value.ToString();
                    if (nivel == "Alto")
                    {
                        competencia.niveles = 1;
                    }
                    else if (nivel == "Medio")
                    {
                        competencia.niveles = 2;
                    }
                    else { competencia.niveles = 3; }
                    if (row.Cells[5].Value.ToString() == "Básicas")
                    { competencia.tipo = 1; }
                    else if (row.Cells[5].Value.ToString() == "Generales")
                        { competencia.tipo = 2; }
                    else { competencia.tipo = 3; }
                    listCompeteSelecionadas.Add(competencia);
                }

            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                bool estado = (bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = estado;
                if (!estado)
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = false;
            }

        }
        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
           // DialogResult = DialogResult.Cancel;
        }
    }
    
}
