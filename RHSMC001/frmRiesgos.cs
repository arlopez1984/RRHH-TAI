using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negocio;
using Entidades.General;
using Negocio.Objetos;

namespace RHSMC001
{
    public partial class frmRiesgos : Form
    {
        string codigoID = "";
        public List<clsRiesgo> listaRiesgoSeleccionadas = new List<clsRiesgo>();
        public List<ThrPositionRisk> listaRiesgosCargo = new List<ThrPositionRisk>();
        public List<ThrRisk> listaRiesgosBD = new List<ThrRisk>();
        int tipoRiesgo = 0;

        public frmRiesgos(List<clsRiesgo> lista, string codigoCargo)
        {
            InitializeComponent();
            listaRiesgoSeleccionadas = lista;
            codigoID = codigoCargo;
            ControllerRHSMR001 controlador = new ControllerRHSMR001();
            listaRiesgosBD = controlador.GetRiesgos();
            CargarRiesgos(listaRiesgosBD);
            MostrarRiesgoSeleccionados(lista);
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;
              
        }
        public void CargarRiesgos(List<ThrRisk> listRiesgosBD)
        {
            try
            {
                clsRiesgo riesgo;
                for (int i = 0; i < listRiesgosBD.Count; i++)
                {
                    riesgo = new clsRiesgo();
                    riesgo.nombreRiesgo = listRiesgosBD[i].RiskID;
                    riesgo.descripcionRiesgo = listRiesgosBD[i].RiskDescription;                    
                    riesgo.tipo = listRiesgosBD[i].RiskType;
                    var riesgoType = "";
                    if (riesgo.tipo == 1)
                    { riesgoType = "Mecánicos"; }
                    else if (riesgo.tipo == 2)
                    { riesgoType = "Físicos"; }
                    else if (riesgo.tipo == 3)
                    { riesgoType = "Locativos"; }
                    else if (riesgo.tipo == 4)
                    { riesgoType = "Psicosociales"; }
                    else if (riesgo.tipo == 5)
                    { riesgoType = "Información"; }
                    else if (riesgo.tipo == 6)
                    { riesgoType = "Meteorológicos"; }
                    datagridviewRiesgo.Rows.Add(false, listRiesgosBD[i].RiskID, listRiesgosBD[i].RiskDescription, "Medio", riesgoType);
                }
                datagridviewRiesgo.AllowUserToAddRows = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los riesgos", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MostrarRiesgoSeleccionados(List<clsRiesgo> listaRiesgos)
        {
            try
            {
                if (listaRiesgos.Count > 0)
                {
                    foreach (DataGridViewRow row in datagridviewRiesgo.Rows)
                    {
                        foreach (clsRiesgo item in listaRiesgos)
                        {
                            if (row.Cells[1].Value.ToString() == item.nombreRiesgo)
                            {
                                row.Cells[0].Value = true;
                                if (item.nivel == 1)
                                {
                                    row.Cells[3].Value = "Alto";
                                }
                                else if (item.nivel == 2)
                                {
                                    row.Cells[3].Value = "Medio";
                                }
                                else if (item.nivel == 3)
                                { row.Cells[3].Value = "Bajo"; }

                                row.Visible = false;
                            }
                        }
                    }
                }
                datagridviewRiesgo.AllowUserToAddRows = false;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void MostrarRiesgosCargoXTipo(int tipo)
        {
            try
            {
                var tipoRiesgo = "";
                if (tipo == 1)
                {
                    tipoRiesgo = "Mecánicos";
                }
                else if (tipo == 2)
                {
                    tipoRiesgo = "Físicos";
                }
                else if (tipo == 3)
                {
                    tipoRiesgo = "Locativos";
                }
                else if (tipo == 4)
                {
                    tipoRiesgo = "Psicosociales";
                }
                else if (tipo == 5)
                {
                    tipoRiesgo = "Información";
                }
                else { tipoRiesgo = "Meteorológicos"; }

                foreach (DataGridViewRow row in datagridviewRiesgo.Rows)
                {
                    if (row.Cells[4].Value.ToString() == tipoRiesgo)
                    {
                        row.Visible = true;                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                datagridviewRiesgo.AllowUserToAddRows = false;

            }
            catch (Exception)
            {
                throw;
            }
        }      
        private void frmRiesgos_Load(object sender, EventArgs e)
        {
            cbxTipoRiesgo.DataSource = Enum.GetValues(typeof(TiposRiesgos));
            cbxTipoRiesgo.SelectedItem = TiposRiesgos.Mecánicos;
        }
        private void CmbTipoRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {           
            TiposRiesgos selectipo = (TiposRiesgos)cbxTipoRiesgo.SelectedItem;
            tipoRiesgo = ((SByte)selectipo);
            MostrarRiesgosCargoXTipo(tipoRiesgo);
           
        }
        private void Do_Save(object sender, EventArgs e)
        {
            clsRiesgo riesgo;
            listaRiesgoSeleccionadas.Clear();          
            foreach (DataGridViewRow row in datagridviewRiesgo.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells[0].Value);

                if (isChecked)
                {
                    riesgo = new clsRiesgo();
                    riesgo.nombreRiesgo = row.Cells[1].Value.ToString();
                    riesgo.descripcionRiesgo = row.Cells[2].Value.ToString();
                    string nivel = row.Cells["ColNivel"].Value.ToString();
                    if (nivel == "Alto")
                    {
                        riesgo.nivel = 1;
                    }
                    else if (nivel == "Medio")
                    {
                        riesgo.nivel = 2;
                    }
                    else { riesgo.nivel = 3; }

                    if (row.Cells[4].Value.ToString() == "Mecánicos")
                    { riesgo.tipo = 1; }
                    else if (row.Cells[4].Value.ToString() == "Físicos")
                    { riesgo.tipo = 2; }
                    else if (row.Cells[4].Value.ToString() == "Locativos")
                    { riesgo.tipo = 3; }
                    else if (row.Cells[4].Value.ToString() == "Psicosociales")
                    { riesgo.tipo = 4; }
                    else if (row.Cells[4].Value.ToString() == "Información")
                    { riesgo.tipo = 5; }
                    else 
                    { riesgo.tipo = 6; }
                    listaRiesgoSeleccionadas.Add(riesgo);
                }

            }



           /* foreach (DataGridViewRow row in datagridviewReisgos.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells[0].Value);

                if (isChecked)
                {
                    riesgo = new clsRiesgo();
                    riesgo.nombreRiesgo = row.Cells[1].Value.ToString();
                    riesgo.descripcionRiesgo = row.Cells[2].Value.ToString();                    
                    if (row.Cells[3].Value.ToString() == "Alto")
                    {
                        riesgo.nivel = 1;
                    }
                    else if (row.Cells[3].Value.ToString() == "Medio")
                    {
                        riesgo.nivel = 2;
                    }
                    else { riesgo.nivel = 3; }
                    listaRiesgoSeleccionadas.Add(riesgo);
                }

            }*/
            DialogResult = DialogResult.OK;
        }        
        private void DatagridviewRiesgo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >-1)
            {
                bool estado = (bool)datagridviewRiesgo.Rows[e.RowIndex].Cells[0].Value;
                datagridviewRiesgo.Rows[e.RowIndex].Cells[0].Value = estado;
                if (!estado)
                    datagridviewRiesgo.Rows[e.RowIndex].Cells[3].Value = "Medio";
            }
            
        }
        private void DatagridviewRiesgo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (datagridviewRiesgo.IsCurrentCellDirty)
            {
                datagridviewRiesgo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void DatagridviewRiesgo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
