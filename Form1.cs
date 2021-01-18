using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Negocio;
using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls;
using Sage500AppModel;
using Entidades.RHSMC001;

namespace RHSMC001
{
    public partial class Form1 : Form
    {
        private Sage500AppEntities mycontext;
        string conection;
        ArrayList listaSeleccion;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            LoadContext();
            tabControl1.SelectedIndex = 0;

        }
        public void LoadContext()
        {
            System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
            {
                Metadata = "res://*/DataModel1.csdl|res://*/DataModel1.ssdl|res://*/DataModel1.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sageSession1.GetConnectionString()
            };
            conection = connectionString.ToString();
            mycontext = new Sage500AppEntities(connectionString.ToString());
            CargarDatosIniciales(conection);
        }
        public void CargarDatosIniciales(string connection)
        {

            ControllerRHSMGE001 controler = new ControllerRHSMGE001();
            cmbGrupoEscala.DataSource = controler.ActualizarLista(conection);
            cmbGrupoEscala.DisplayMember = "EscalaGroupID";
            cmbGrupoEscala.ValueMember = "EscalaGroupkey";

            ControllerRHSMCO001 catocupacional = new ControllerRHSMCO001();
            cmbCategoriaOcup.DataSource = catocupacional.ActualizarLista(conection);
            cmbCategoriaOcup.DisplayMember = "CategoryID";
            cmbCategoriaOcup.ValueMember = "OcupationCategoryKey";


            ControllerRHSMUO001 areasorg = new ControllerRHSMUO001();
            List<ThrOrganizativeUnit> lista = new List<ThrOrganizativeUnit>();
            lista = areasorg.ActualizarLista(conection);
            if (lista.Count > 0)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Checked = true;
                    item.Text = lista[i].Name.ToString();
                    item.Tag = lista[i];
                    lvareasDisponibles.Items.Add(item);
                }
            }
            //lbxAreasDisponibles.DataSource = areasorg.ActualizarLista(conection);
            //lbxAreasDisponibles.DisplayMember = "Name";
            //lbxAreasDisponibles.ValueMember = "OrgUnitKey";

            ControllerRHSMCA001 condanormales = new ControllerRHSMCA001();
            List<ThrAnormalCondition> listaCondiciones = new List<ThrAnormalCondition>();
            listaCondiciones = condanormales.ActualizarLista(conection);
            if (listaCondiciones.Count > 0)
            {
                for (int i = 0; i < listaCondiciones.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Checked = true;
                    item.Text = lista[i].OrgUnitID.ToString();
                    item.Tag = lista[i];
                    lvcondDisponibles.Items.Add(item);
                }
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (lvareasDisponibles.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvareasDisponibles.SelectedItems)
                {
                    lvareasDisponibles.Items.Remove(item);
                    lvareasSeleccion.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvareasSeleccion.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvareasSeleccion.SelectedItems)
                {
                    lvareasSeleccion.Items.Remove(item);
                    lvareasDisponibles.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void LvareasDisponibles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvareasDisponibles.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvareasDisponibles.SelectedItems)
                {
                    lvareasDisponibles.Items.Remove(item);
                    lvareasSeleccion.Items.Add(item);
                }
            }

        }
        private void LvareasSeleccion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvareasSeleccion.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvareasSeleccion.SelectedItems)
                {
                    lvareasSeleccion.Items.Remove(item);
                    lvareasDisponibles.Items.Add(item);
                }
            }

        }
        private void BtnAddCond_Click(object sender, EventArgs e)
        {
            if (lvcondDisponibles.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvcondDisponibles.SelectedItems)
                {
                    lvcondDisponibles.Items.Remove(item);
                    lvCondselecc.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnDeleteCond_Click(object sender, EventArgs e)
        {
            if (lvCondselecc.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvCondselecc.SelectedItems)
                {
                    lvCondselecc.Items.Remove(item);
                    lvcondDisponibles.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void LvcondDisponibles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvcondDisponibles.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvcondDisponibles.SelectedItems)
                {
                    lvcondDisponibles.Items.Remove(item);
                    lvCondselecc.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void LvCondselecc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvCondselecc.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvCondselecc.SelectedItems)
                {
                    lvCondselecc.Items.Remove(item);
                    lvcondDisponibles.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }
        private void EnableControls()
        {
            txtCargo.Enabled = false;
            tabControl1.Enabled = true;
        }
        private void DisableControls()
        {
            txtCargo.Enabled = true;
            tabControl1.Enabled = false;
        }
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }
        private void UpdateLookup()
        {
            ControlllerRHSMP001 controler = new ControlllerRHSMP001();
            lkuNav.SetData(controler.ActualizarLista(conection));
        }
        public void MostrarDatosRegistro(ThrPosition dato)
        {

            ThrPosition data = dato;
            //txtCI.Text = data.CI;
            //txtName.Text = data.PrimerNombre;
            //txtSegundoNombre.Text = data.SegundoNombre;

        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCargo.Tag != null && txtCargo.Tag.ToString() == txtCargo.Text) return;
            MainBS.Clear();

            if (txtCargo.Text.Length > 0)
            {
                //ThrPoeple data = mycontext.ThrPoeples.Where(p => p.CI == txtCI.Text).FirstOrDefault();
                ControllerRHSMC001 controler = new ControllerRHSMC001(conection);
                // ThrPosition data = controler.get(txtCargo.Text, conection);
                /*if (data != null)
                {
                    MainBS.Add(data);
                    MostrarDatosRegistro(data);
                    strBar.SetFormStatus(FormBindingStatus.Editing);
                }
                else
                {
                    MainBS.AddNew();
                    strBar.SetFormStatus(FormBindingStatus.Adding);
                }
                EnableControls();

            }
            else
            {
                DisableControls();
                strBar.SetFormStatus(FormBindingStatus.Waiting);
            }
            txtCargo.Tag = txtCargo.Text;*/
            }
        }
        private void Do_Cancel(object sender, EventArgs e)
            {
                /*txtCI.Text = "";
                txtSegundoNombre.Text = "";
                txtName.Text = "";
                txtPrimerApellido.Text = "";

                DisableControls();
                LoadContext();
                //On_IDChange(null, null);*/
            }        
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCargo.Text != "")
                {
                    clsCargo objData = new clsCargo();                   
                    objData.cargo = txtCargo.Text;
                    objData.grupoescala = Convert.ToInt16(cmbGrupoEscala.SelectedValue.ToString());
                    objData.categoriaOcupacional = Convert.ToInt16(cmbCategoriaOcup.SelectedValue.ToString());
                    objData.horasExtraspagar = Convert.ToInt32(txtCantmaxHoras.Text);
                    objData.estimulacionCuc = Convert.ToInt32(txtEstimulcionCuc.Text);
                    objData.pagoxcargo = Convert.ToDecimal(txtPagoCargo.Text);
                    ControllerRHSMUO001 cont = new ControllerRHSMUO001();
                    foreach (ListViewItem item in lvareasSeleccion.Items)
                    {
                        ThrOrganizativeUnit nuevoObj = new ThrOrganizativeUnit();
                        nuevoObj = cont.GetUnidadOrganizativa(item.ToString(), conection);
                        objData.ListAreasOrganizativas.Add(nuevoObj);
                    }
                    ControllerRHSMC001 conti = new ControllerRHSMC001();
                    conti.AddCargo(objData, conection);
                    //ThrEscalaGroup nuevo = new ThrEscalaGroup();
                    UpdateLookup();
                    tabControl1.SelectedIndex = 0;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al salvar, los datos seleccionables no pueden ser modificados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            /*try
            {

                if (txtCI.Text != "")
                {
                    ControlllerRHSMP001 controler = new ControlllerRHSMP001();
                    controler.DeletePerson(txtCI.Text, conection);
                    UpdateLookup();
                    Do_Cancel(null, null);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la persona", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }*/
            return false;

        }
        private bool ValidateForm(object sender, EventArgs e)
            {
                /*  if (MainBS.Current == null) return false;
                  ValidateChildren();
                  Validate();

                  if (masktxtCuentaMN.Text != "    -    -    -")
                  {
                      if (!this.masktxtCuentaMN.MaskFull)
                      {
                          MessageBox.Show("El número de cuenta en MN no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          tabControl1.SelectedIndex = 2;
                          masktxtCuentaMN.Focus();
                          return false;
                      }
                  }

                  if (!IDHandler.IsNumeric(txtNoExpedLaboral.Text))
                  {
                      MessageBox.Show("El número de Expediente solo puede estar compuesto por números.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      tabControl1.SelectedIndex = 1;
                      txtNoExpedLaboral.Focus();
                      return false;
                  }*/
                return true;
            }
        private void IDValidate(object sender, CancelEventArgs e)
            {
                if (!IDHandler.IsAlphaNumeric(txtCargo.Text))
                {
                    if (txtCargo.Text == "")
                    {
                        MessageBox.Show("El Cargo no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("El Carnet de Indentidad no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

            }
        private void TxtCargo_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                { e.Handled = true; }
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                { e.Handled = true; }

            }
        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {

            /*  ThrPosition data = eventArgs.ReturnValue as ThrPoeple;
              try
              {
                  if (data != null)
                  {
                      MostrarDatosRegistro(data);
                      On_IDChange(null, null);
                  }
                  else
                  {
                      ControlllerRHSMP001 controler = new ControlllerRHSMP001();
                      ThrPoeple person = controler.GetPersona(txtCI.Text, conection);
                      MostrarDatosRegistro(person);
                      On_IDChange(null, null);
                  }
                  EnableControls();

              }
              catch (Exception)
              {
                  MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }

          }   */
        }
    }
}

        

        
        
        
       
        
