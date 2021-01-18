using Net4Sage;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sage500AppModel;
using Negocio.Objetos;
using Negocio;
using Entidades.General;

namespace RHSMCL001
{
    public partial class frmCondicionesLaborales : Form
    {
        List<ThrLaboralCondition> listaCompleCondiciones;
        ControllerRHSMCL001 controlador;
        public frmCondicionesLaborales()
        {
            InitializeComponent();
            controlador = new ControllerRHSMCL001();
        }
        public frmCondicionesLaborales(ref SageSession session) : this()
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
            //Cargar datos iniciales relacionados a los tipos de condiciones
            cmbtipoCondicion.DataSource = Enum.GetValues(typeof(TipoCondicion));
            cmbtipoCondicion.SelectedItem = TipoCondicion.Básicas;

            TipoCondicion selectipo = (TipoCondicion)cmbtipoCondicion.SelectedItem;
            int tipo = ((SByte)selectipo);
            ControllerRHSMCL001 controlador = new ControllerRHSMCL001();
            listaCompleCondiciones = controlador.GetCondicionesLaborales();

            for (int i = 0; i < listaCompleCondiciones.Count; i++)
            {
                ListViewItem item = new ListViewItem(listaCompleCondiciones[i].ConditionlabID);
                item.SubItems.Add(listaCompleCondiciones[i].ConditionLabDescription);
                if (listaCompleCondiciones[i].TipoConditionLab == 1)
                { item.SubItems.Add("Básicas"); }
                if (listaCompleCondiciones[i].TipoConditionLab == 2)
                { item.SubItems.Add("Específicas"); }
                if (listaCompleCondiciones[i].TipoConditionLab == 3)
                { item.SubItems.Add("Generales"); }
                lvCondiciones.Items.Add(item);                            
            }
        }      
        private void TxtNombreCondicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtNombreCondicion.Text != "")
                {
                    for (int i = 0; i < lvCondiciones.Items.Count; i++)
                    {
                        if (txtNombreCondicion.Text == lvCondiciones.Items[i].Text)
                        {
                            lvCondiciones.Items.RemoveAt(i);
                        }
                    }
                    ListViewItem lvitem = new ListViewItem(txtNombreCondicion.Text);
                    lvitem.SubItems.Add(txtDescrpCondicion.Text);
                    lvitem.SubItems.Add(cmbtipoCondicion.Text);
                    lvCondiciones.Items.Add(lvitem);
                    txtNombreCondicion.Text = "";
                    txtDescrpCondicion.Text = "";
                }
                else
                {
                    MessageBox.Show("El nombre de la Condición no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void TxtDescrpCondicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtNombreCondicion.Text != "")
                {
                    for (int i = 0; i < lvCondiciones.Items.Count; i++)
                    {
                        if (txtNombreCondicion.Text == lvCondiciones.Items[i].Text)
                        {
                            lvCondiciones.Items.RemoveAt(i);
                        }
                    }
                    ListViewItem lvitem = new ListViewItem(txtNombreCondicion.Text);
                    lvitem.SubItems.Add(txtDescrpCondicion.Text);
                    lvitem.SubItems.Add(cmbtipoCondicion.Text);
                    lvCondiciones.Items.Add(lvitem);
                    txtNombreCondicion.Text = "";
                    txtDescrpCondicion.Text = "";
                }
                else
                {
                    MessageBox.Show("El nombre de la Condición no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtNombreCondicion.Text = "";
            txtDescrpCondicion.Text = "";
            cmbtipoCondicion.SelectedIndex = 0;
        }        
        private bool Do_Delete(object sender, EventArgs e)
        {
            if (lvCondiciones.SelectedItems.Count > 0)
            {
                ListViewItem listItem = lvCondiciones.SelectedItems[0];
                var condicion = controlador.BuscarConditionlaboralKey(listItem.Text);
                if (condicion != null)
                {
                    var respuesta = controlador.EliminarCondicion(listItem.Text);
                    if (respuesta)
                    {
                        for (int i = 0; i < lvCondiciones.SelectedItems.Count; i++)
                        {

                            lvCondiciones.Items.Remove(lvCondiciones.SelectedItems[i]);
                            txtDescrpCondicion.Text = "";
                            txtNombreCondicion.Text = "";
                        }
                        MessageBox.Show("La condición laboral ha sido eliminada exitosamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("La condición laboral no puede ser eliminada, esta asociada a cargos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    for (int i = 0; i < lvCondiciones.SelectedItems.Count; i++)
                    {
                        lvCondiciones.Items.Remove(lvCondiciones.SelectedItems[i]);
                        txtDescrpCondicion.Text = "";
                        txtNombreCondicion.Text = "";
                    }
                    MessageBox.Show("La Condición Laboral ha sido eliminada exitosamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar la Condición Laboral que desea eliminar.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                TipoCondicion selectipo = (TipoCondicion)cmbtipoCondicion.SelectedItem;
                int tipo = ((SByte)selectipo);
                listaCompleCondiciones.Clear();               
                ThrLaboralCondition obj;
                for (int i = 0; i < lvCondiciones.Items.Count; i++)
                {
                    obj = new ThrLaboralCondition();
                    obj.ConditionlabID = lvCondiciones.Items[i].Text;
                    obj.ConditionLabDescription = lvCondiciones.Items[i].SubItems[1].Text;
                    if (lvCondiciones.Items[i].SubItems[2].Text == "Básicas")
                    { obj.TipoConditionLab = 1; }
                    if (lvCondiciones.Items[i].SubItems[2].Text == "Específicas")
                    { obj.TipoConditionLab = 2; }
                    if (lvCondiciones.Items[i].SubItems[2].Text == "Generales")
                    { obj.TipoConditionLab = 3; }
                    listaCompleCondiciones.Add(obj);
                }                
                controlador.AdionarCondicionLaboral(listaCompleCondiciones);
                MessageBox.Show("Las condiciones laborales han sido salvadas correctamente.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar las condiciones laborales seleccionadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }       
        private void BtnSelecc_Click(object sender, EventArgs e)
        {
            if (txtNombreCondicion.Text != "")
            {
                for (int i = 0; i < lvCondiciones.Items.Count; i++)
                {
                    if (txtNombreCondicion.Text == lvCondiciones.Items[i].Text)
                    {
                        lvCondiciones.Items.RemoveAt(i);
                    }
                }
                ListViewItem lvitem = new ListViewItem(txtNombreCondicion.Text);
                lvitem.SubItems.Add(txtDescrpCondicion.Text);
                lvitem.SubItems.Add(cmbtipoCondicion.Text);
                lvCondiciones.Items.Add(lvitem);
                txtNombreCondicion.Text = "";
                txtDescrpCondicion.Text = "";
            }
            else
            {
                MessageBox.Show("El nombre de la Condición no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
