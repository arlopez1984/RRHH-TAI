using Entidades.General;
using Negocio;
using Net4Sage;
using Net4Sage.Controls;
using RHSMCP001.Objects;
using Sage500AppModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace RHSMCP001
{
    public partial class frmCompetencias : Form
    {
        ControllerRHSMCP001 controlador;
        List<ThrCompetencia> listaCompleCompetencias;
        public frmCompetencias()
        {
            InitializeComponent();
            controlador = new ControllerRHSMCP001();
        }
        public frmCompetencias(ref SageSession session) : this()
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
        public void CargarDatosIniciales()
        {
            //Cargar datos iniciales relacionados a los tipos de Competencia
            cmbtipoCompetencia.DataSource = Enum.GetValues(typeof(TipoCompetencias));
            cmbtipoCompetencia.SelectedItem = TipoCompetencias.Básicas;

            TipoCompetencias selectipo = (TipoCompetencias)cmbtipoCompetencia.SelectedItem;
            int tipo = ((SByte)selectipo);
            ControllerRHSMCP001 controlador = new ControllerRHSMCP001();
            listaCompleCompetencias = controlador.GetCompetencias();

            for (int i = 0; i < listaCompleCompetencias.Count; i++)
            {                
                ListViewItem item = new ListViewItem(listaCompleCompetencias[i].CompetenciaID);
                item.SubItems.Add(listaCompleCompetencias[i].CompetenciaDescrip);
                if (listaCompleCompetencias[i].TipoCompetencia == 1)
                { item.SubItems.Add("Básicas"); }
                if (listaCompleCompetencias[i].TipoCompetencia == 2)
                { item.SubItems.Add("Generales"); }
                if (listaCompleCompetencias[i].TipoCompetencia == 3)
                { item.SubItems.Add("Específicas"); }
                item.Tag = listaCompleCompetencias[i].CompetenciaKey;
                lvBasicas.Items.Add(item);                      
            }
        }                
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                TipoCompetencias selectipo = (TipoCompetencias)cmbtipoCompetencia.SelectedItem;
                int tipo = ((SByte)selectipo);
                listaCompleCompetencias.Clear();                
                ThrCompetencia obj;
                for (int i = 0; i < lvBasicas.Items.Count; i++)
                {
                    obj = new ThrCompetencia();
                    obj.CompetenciaKey = Convert.ToInt32(lvBasicas.Items[i].Tag);
                    obj.CompetenciaID = lvBasicas.Items[i].Text;
                    obj.CompetenciaDescrip = lvBasicas.Items[i].SubItems[1].Text;
                    if (lvBasicas.Items[i].SubItems[2].Text == "Básicas")
                    { obj.TipoCompetencia = 1; }
                    if (lvBasicas.Items[i].SubItems[2].Text == "Generales")
                    { obj.TipoCompetencia = 2; }
                    if (lvBasicas.Items[i].SubItems[2].Text == "Específicas")
                    { obj.TipoCompetencia = 3; }                    
                    listaCompleCompetencias.Add(obj);
                }               
                controlador.AdionarCompetencias(listaCompleCompetencias);
                MessageBox.Show("Las competencias han sido salvadas correctamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar las competencias.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }       
        private void TxtDescrpCompet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtNombreCompet.Text != "")
                {
                    for (int i = 0; i < lvBasicas.Items.Count; i++)
                    {
                        if (txtNombreCompet.Text == lvBasicas.Items[i].Text)
                        {
                            lvBasicas.Items.RemoveAt(i);
                        }
                    }
                    ListViewItem lvitem = new ListViewItem(txtNombreCompet.Text);
                    lvitem.SubItems.Add(txtDescrpCompet.Text);
                    lvitem.SubItems.Add(cmbtipoCompetencia.Text);
                    lvBasicas.Items.Add(lvitem);
                    txtNombreCompet.Text = "";
                    txtDescrpCompet.Text = "";
                }
                else
                {
                    MessageBox.Show("El nombre de la Competencia no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }        
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtNombreCompet.Text = "";
            txtDescrpCompet.Text = "";
            cmbtipoCompetencia.Text = "Básicas";
        }           
        private bool Do_Delete(object sender, EventArgs e)
        {
            if (lvBasicas.SelectedItems.Count > 0)
            {                
                ListViewItem listItem = lvBasicas.SelectedItems[0];
                var competencia = controlador.BuscarCompetenciaKey(listItem.Text);
                if (competencia != null)
                {                   
                    var respuesta= controlador.EliminarCompetencia(listItem.Text);
                    if (respuesta)
                    {
                        for (int i = 0; i < lvBasicas.SelectedItems.Count; i++)
                        {

                            lvBasicas.Items.Remove(lvBasicas.SelectedItems[i]);
                            txtDescrpCompet.Text = "";
                            txtNombreCompet.Text = "";
                        }
                        MessageBox.Show("La competencia ha sido eliminada exitosamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("La competencia no puede ser eliminada, esta asociada a cargos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    for (int i = 0; i < lvBasicas.SelectedItems.Count; i++)
                    {
                        lvBasicas.Items.Remove(lvBasicas.SelectedItems[i]);
                        txtDescrpCompet.Text = "";
                        txtNombreCompet.Text = "";
                    }
                    MessageBox.Show("La competencia ha sido eliminada exitosamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }                
            }
            else
            {
                MessageBox.Show("Debe seleccionar la competencia que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }   
        }      
        private void BtnSelecc_Click(object sender, EventArgs e)
        {
            if (txtNombreCompet.Text != "")
            {                
                for (int i = 0; i < lvBasicas.Items.Count; i++)
                {
                    if (txtNombreCompet.Text == lvBasicas.Items[i].Text)
                    {
                        lvBasicas.Items.RemoveAt(i);
                    }
                }
                ListViewItem lvitem = new ListViewItem(txtNombreCompet.Text);
                lvitem.SubItems.Add(txtDescrpCompet.Text);
                lvitem.SubItems.Add(cmbtipoCompetencia.Text);                
                lvBasicas.Items.Add(lvitem);
                txtNombreCompet.Text = "";
                txtDescrpCompet.Text = "";
            }
            else
            {
                MessageBox.Show("El nombre de la Competencia no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
    }
}

