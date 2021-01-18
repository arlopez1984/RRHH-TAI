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
    public partial class frmBuscarTrabajador : Form
    {        
        int unidadKey = 0; 
        public List<ThrPeople> listaPersonasSeleccionadas;
        public frmBuscarTrabajador()
        {
            InitializeComponent();
        }
        public frmBuscarTrabajador(int unitKey)
        {
            InitializeComponent();
            menuBar1.Items[1].Visible = false;
            menuBar1.Items[3].Visible = false;            
            unidadKey = unitKey;
            ControllerRHSGI001 controlador = new ControllerRHSGI001();
            var listaPersonasUnidadBD = controlador.BuscarPersonasxUnidad(unitKey);
            CargarTRabajadoresUnidad(listaPersonasUnidadBD);
        }
        public void CargarTRabajadoresUnidad(List<ThrPeople> listaPersonas)
        {
            if (listaPersonas.Count > 0)
            {
                ListViewItem nuevoitem;
                foreach (ThrPeople item in listaPersonas)
                {
                    nuevoitem = new ListViewItem(item.PrimerNombre.ToString());
                    nuevoitem.SubItems.Add(item.SegundoNombre.ToString());
                    nuevoitem.SubItems.Add(item.PrimerApellido.ToString());
                    nuevoitem.SubItems.Add(item.SegundoApellido.ToString());
                    nuevoitem.SubItems.Add(item.CI.ToString());
                    nuevoitem.SubItems.Add(item.AcumuladoVacations.ToString());
                    lvPersonas.Items.Add(nuevoitem);
                    
                }
            }

        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        public void BuquedaNombre(string nombre)
        {
            foreach (ListViewItem item in lvPersonas.Items)
            {
                if (item.Text.Contains(nombre))
                {
                    item.Selected = true;                  
                }
            }
        }
        public void BuquedaSegNombre(string Segnombre)
        {  
            foreach (ListViewItem item in lvPersonas.Items)
            {
                if (item.SubItems[1].Text.Contains(Segnombre))
                {
                    item.Selected = true;                   
                }
            }
        }
        public void BuquedaPApellido(string pApellido)
        {
            foreach (ListViewItem item in lvPersonas.Items)
            {
                if (item.SubItems[2].Text.Contains(pApellido))
                {
                    item.Selected = true;                   
                }
            }
        }
        public void BuquedaSApellido(string sApellido)
        {
            foreach (ListViewItem item in lvPersonas.Items)
            {
                if (item.SubItems[3].Text.Contains(sApellido))
                {
                    item.Selected = true;                    
                }
            }
        }
        private void LvPersonas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Do_Save(null, null);
        }         
        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {                
                this.BuquedaNombre(txtNombre.Text);
            }
            else
            {
                foreach (ListViewItem item in lvPersonas.Items)
                {
                    item.Selected = false;
                }
            }
        }

        private void TxtPrimerApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtPrimerApellido.Text != "")
            {
                this.BuquedaPApellido(txtPrimerApellido.Text);
            }
            else
            {
                foreach (ListViewItem item in lvPersonas.Items)
                {
                    item.Selected = false;
                }
            }

        }

        private void TxtSegApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtSegApellido.Text != "")
            {
                this.BuquedaSApellido(txtSegApellido.Text);
            }
            else
            {
                foreach (ListViewItem item in lvPersonas.Items)
                {
                    item.Selected = false;
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                foreach (ListViewItem item in lvPersonas.Items)
                {
                    if (item.Text == txtNombre.Text)
                        item.Selected = true;
                    break;
                }
            }
            if (txtSegNombre.Text != "")
            {
                foreach (ListViewItem item in lvPersonas.Items)
                {
                    if (item.SubItems[1].Text == txtSegNombre.Text)
                        item.Selected = true;
                    break;
                }
            }
            if (txtPrimerApellido.Text != "")
            {
                foreach (ListViewItem item in lvPersonas.Items)
                {
                    if (item.SubItems[2].Text == txtPrimerApellido.Text)
                        item.Selected = true;
                    break;
                }
            }
            if (txtSegApellido.Text != "")
            {
                foreach (ListViewItem item in lvPersonas.Items)
                {
                    if (item.SubItems[1].Text == txtSegApellido.Text)
                        item.Selected = true;
                    break;
                }
            }
        }

        private void LvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Do_Save(object sender, EventArgs e)
        {
            ThrPeople people;
            listaPersonasSeleccionadas = new List<ThrPeople>();
            foreach (ListViewItem item in lvPersonas.Items)
            {
                if (item.Selected)
                {
                    people = new ThrPeople();
                    people.PrimerNombre = item.Text;
                    people.SegundoNombre = item.SubItems[1].Text; ;
                    people.PrimerApellido = item.SubItems[2].Text;
                    people.SegundoApellido = item.SubItems[3].Text;
                    people.CI = item.SubItems[4].Text;
                    people.AcumuladoVacations = Convert.ToInt32(item.SubItems[5].Text);
                    listaPersonasSeleccionadas.Add(people);
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            if (lvPersonas.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvPersonas.SelectedItems)
                {
                    lvPersonas.Items.Remove(item);
                }
            }
        }
    }
}
