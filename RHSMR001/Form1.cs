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
using RHSMR001.Object;
using Negocio;
using Net4Sage.Controls;
using Entidades.General;

namespace RHSMR001
{
    public partial class frmRiesgos : Form
    {
        ControllerRHSMR001 controlador;
        private Sage500AppEntities mycontext;
        List<ThrRisk> listaCompleRiesgos;
        public frmRiesgos()
        {
            InitializeComponent();
            controlador = new ControllerRHSMR001();
        }
        public frmRiesgos(ref SageSession session) : this()
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
            mycontext = new Sage500AppEntities(connectionString.ToString());
        }   
        public void CargarDatosIniciales()
        {
            //Cargar datos iniciales relacionados a los tipos de Competencia
            cmbtipoRiesgos.DataSource = Enum.GetValues(typeof(TiposRiesgos));
            cmbtipoRiesgos.SelectedItem = TiposRiesgos.Mecánicos;

            TiposRiesgos selectipo = (TiposRiesgos)cmbtipoRiesgos.SelectedItem;
            int tipo = ((SByte)selectipo);
            
            listaCompleRiesgos = controlador.GetRiesgos();

            for (int i = 0; i < listaCompleRiesgos.Count; i++)
            {
                ListViewItem item = new ListViewItem(listaCompleRiesgos[i].RiskID);
                item.SubItems.Add(listaCompleRiesgos[i].RiskDescription);
                if (listaCompleRiesgos[i].RiskType == 1)
                { item.SubItems.Add("Mecánicos"); }
                if (listaCompleRiesgos[i].RiskType == 2)
                { item.SubItems.Add("Físicos"); }
                if (listaCompleRiesgos[i].RiskType == 3)
                { item.SubItems.Add("Locativos"); }
                if (listaCompleRiesgos[i].RiskType == 4)
                { item.SubItems.Add("Psicosociales"); }
                if (listaCompleRiesgos[i].RiskType == 5)
                { item.SubItems.Add("Información"); }
                if (listaCompleRiesgos[i].RiskType == 6)
                { item.SubItems.Add("Meteorológicos"); }
                lvRiesgos.Items.Add(item);                
            }
        }        
        private void TxtNombreRiesgo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtNombreRiesgo.Text != "")
                {
                    for (int i = 0; i < lvRiesgos.Items.Count; i++)
                    {
                        if (txtNombreRiesgo.Text == lvRiesgos.Items[i].Text)
                        {
                            lvRiesgos.Items.RemoveAt(i);
                        }
                    }
                    ListViewItem lvitem = new ListViewItem(txtNombreRiesgo.Text);
                    lvitem.SubItems.Add(txtDescrpRiesgos.Text);
                    lvitem.SubItems.Add(cmbtipoRiesgos.Text);
                    lvRiesgos.Items.Add(lvitem);
                    txtNombreRiesgo.Text = "";
                    txtDescrpRiesgos.Text = "";
                }
                else
                {
                    MessageBox.Show("El nombre no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void TxtDescrpRiesgos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtNombreRiesgo.Text != "")
                {
                    for (int i = 0; i < lvRiesgos.Items.Count; i++)
                    {
                        if (txtNombreRiesgo.Text == lvRiesgos.Items[i].Text)
                        {
                            lvRiesgos.Items.RemoveAt(i);
                        }
                    }
                    ListViewItem lvitem = new ListViewItem(txtNombreRiesgo.Text);
                    lvitem.SubItems.Add(txtDescrpRiesgos.Text);
                    lvitem.SubItems.Add(cmbtipoRiesgos.Text);
                    lvRiesgos.Items.Add(lvitem);
                    txtNombreRiesgo.Text = "";
                    txtDescrpRiesgos.Text = "";
                }
                else
                {
                    MessageBox.Show("El nombre no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }      
        private bool Do_Delete(object sender, EventArgs e)
        {
            if (lvRiesgos.SelectedItems.Count > 0)
            {
                ListViewItem listItem = lvRiesgos.SelectedItems[0];
                var riesgo = controlador.BuscarRiesgoKey(listItem.Text);
                if (riesgo != null)
                {
                    var respuesta = controlador.EliminarRiesgo(listItem.Text);
                    if (respuesta)
                    {
                        for (int i = 0; i < lvRiesgos.SelectedItems.Count; i++)
                        {

                            lvRiesgos.Items.Remove(lvRiesgos.SelectedItems[i]);
                            txtDescrpRiesgos.Text = "";
                            txtNombreRiesgo.Text = "";
                        }
                        MessageBox.Show("El riesgo laboral ha sido eliminado exitosamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("El riesgo laboral no puede ser eliminado, esta asociado a cargos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    for (int i = 0; i < lvRiesgos.SelectedItems.Count; i++)
                    {
                        lvRiesgos.Items.Remove(lvRiesgos.SelectedItems[i]);
                        txtDescrpRiesgos.Text = "";
                        txtNombreRiesgo.Text = "";
                    }
                    MessageBox.Show("El riesgo laboral ha sido eliminado exitosamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el riesgo laboral que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                TiposRiesgos selectipo = (TiposRiesgos)cmbtipoRiesgos.SelectedItem;
                int tipo = ((SByte)selectipo);
                listaCompleRiesgos.Clear();
                ThrRisk obj;
                for (int i = 0; i < lvRiesgos.Items.Count; i++)
                {
                    obj = new ThrRisk();
                    obj.RiskID = lvRiesgos.Items[i].Text;
                    obj.RiskDescription = lvRiesgos.Items[i].SubItems[1].Text;
                    if (lvRiesgos.Items[i].SubItems[2].Text == "Mecánicos")
                    { obj.RiskType = 1; }
                    if (lvRiesgos.Items[i].SubItems[2].Text == "Físicos")
                    { obj.RiskType = 2; }
                    if (lvRiesgos.Items[i].SubItems[2].Text == "Locativos")
                    { obj.RiskType = 3; }
                    if (lvRiesgos.Items[i].SubItems[2].Text == "Psicosociales")
                    { obj.RiskType = 4; }
                    if (lvRiesgos.Items[i].SubItems[2].Text == "Información")
                    { obj.RiskType = 5; }
                    if (lvRiesgos.Items[i].SubItems[2].Text == "Meteorológicos")
                    { obj.RiskType = 6; }
                    listaCompleRiesgos.Add(obj);
                }
                controlador.AdionarRiesgos(listaCompleRiesgos);
                MessageBox.Show("Los riesgos laborales han sido salvados correctamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar las riesgos laborales seleccionados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtNombreRiesgo.Text = "";
            txtDescrpRiesgos.Text = "";           
        }

        private void BtnSelecc_Click(object sender, EventArgs e)
        {
            if (txtNombreRiesgo.Text != "")
            {
                for (int i = 0; i < lvRiesgos.Items.Count; i++)
                {
                    if (txtNombreRiesgo.Text == lvRiesgos.Items[i].Text)
                    {
                        lvRiesgos.Items.RemoveAt(i);
                    }
                }
                ListViewItem lvitem = new ListViewItem(txtNombreRiesgo.Text);
                lvitem.SubItems.Add(txtDescrpRiesgos.Text);
                lvitem.SubItems.Add(cmbtipoRiesgos.Text);
                lvRiesgos.Items.Add(lvitem);
                txtNombreRiesgo.Text = "";
                txtDescrpRiesgos.Text = "";
            }
            else
            {
                MessageBox.Show("El nombre no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
