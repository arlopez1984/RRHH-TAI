using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.General;
using Negocio;
using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls;
using Sage500AppModel;


namespace RHSMUO001
{
    public partial class frmUnidadAdministrativa : Form
    {
        
        ControllerRHSMUO001 controler;
        DataGridViewComboBoxColumn cmb;
        DataGridViewTextBoxColumn cmbTexto;
        public frmUnidadAdministrativa()
        {
            InitializeComponent();
            controler = new ControllerRHSMUO001();
        }
        public frmUnidadAdministrativa(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            cmb = new DataGridViewComboBoxColumn();
            cmbTexto= new DataGridViewTextBoxColumn();
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
        }
        private void UpdateLookup()
        {
            lkuNav.SetData(controler.ActualizarLista());
        }        
        public void MostrarDatosRegistro(ThrOrganizativeUnit dato)
        {
            try
            {
                cmb = new DataGridViewComboBoxColumn();
                txtCodigoArea.Text = dato.OrgUnitID;
                txtNombreArea.Text = dato.Name;
                int segmento = controler.BuscarNoSeg(sageSession1.CompanyID);
                var centro = controler.BuscarCentro(dato.CostCenter, segmento);
                cmbCentro.Text = centro.Description;
                txtdescripcion.Text = dato.Description;
                ControllerRHSMH001 controll = new ControllerRHSMH001();
                var horario = controll.GetHorarioKey(dato.Horariokey);
                cmbHorarios.Text = horario.HorarioID;
                var turnos = controler.BuscarTurnosXUnidad(dato.OrgUnitKey);
                if (turnos.Count > 0)
                {
                    ControllerRHSMH001 control = new ControllerRHSMH001();
                    cmb.DataSource = control.ActualizarLista();
                    cmbTexto.HeaderText = "Nombre Turno";
                    cmb.HeaderText = "Horario Turno";
                    cmb.DisplayMember = "HorarioID";
                    cmb.ValueMember = "HorarioKey";                   
                    gbxHorarioTurno.Visible = true;                   
                    dvTurnos.Visible = true;
                    cmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dvTurnos.Columns.Add(cmbTexto);
                    dvTurnos.Columns.Add(cmb);
                    foreach (ThrUnitTurno item in turnos)
                    {                       
                        var horarioturno = controll.GetHorarioKey(item.TurnoHorarioKey);
                        dvTurnos.Rows.Add(item.TurnoName, horarioturno.Horariokey);
                    }
                    chxTurnos.Checked = true;
                    dvTurnos.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }            
        }
        private void EnableControls()
        {
            txtCodigoArea.Enabled = false;
            txtNombreArea.Enabled = true;
            cmbCentro.Enabled = true;
            txtdescripcion.Enabled = true;
            cmbCentro.Enabled = true;
            cmbHorarios.Enabled = true;
        }
        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {            
            try
            {
                ThrOrganizativeUnit data = eventArgs.ReturnValue as ThrOrganizativeUnit;
                bool resultado = VerificarNomencladores();
                if (resultado)
                {
                    if (data != null)
                    {
                        MostrarDatosRegistro(data);
                        On_IDChange(null, null);
                        EnableControls();
                    }
                }             
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisableControls()
        {
            txtCodigoArea.Enabled = true;
            txtNombreArea.Enabled = false;
            cmbCentro.Enabled = false;
            txtdescripcion.Enabled = false;
            cmbCentro.DataSource = null;
            cmbHorarios.Enabled = false;
        }
        public bool VerificarNomencladores()
        {
            int segmento = controler.BuscarNoSeg(sageSession1.CompanyID);
            if (segmento != 0)
            {
                cmbCentro.DataSource = controler.GetCentroCosto(segmento);
                cmbCentro.DisplayMember = "Description";
                cmbCentro.ValueMember = "AcctSegValue";                
            }
            else
            {
                MessageBox.Show("Verifique. No han sido completados los datos relacionados a la Empresa.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            ControllerRHSMH001 controlador = new ControllerRHSMH001();
            cmbHorarios.DataSource = controlador.ActualizarLista();
            if (cmbHorarios.Items.Count > 0)
            {
                cmbHorarios.DisplayMember = "HorarioID";
                cmbHorarios.ValueMember = "Horariokey";
            }
            else 
            {
                MessageBox.Show("Verifique. No han sido cargados los horarios de las Unidades Organizativas de la Empresa.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }        
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCodigoArea.Tag != null && txtCodigoArea.Tag.ToString() == txtCodigoArea.Text) return;
            MainBS.Clear();

            if (txtCodigoArea.Text.Length > 0)
            {
                ThrOrganizativeUnit data = controler.GetUnidadOrganizativ(txtCodigoArea.Text);
                if (data != null)
                {
                    MainBS.Add(data);
                    strbar.SetFormStatus(FormBindingStatus.Editing);
                }
                else
                {
                    MainBS.AddNew();
                    strbar.SetFormStatus(FormBindingStatus.Adding);
                }
                EnableControls();
            }
            else
            {
                DisableControls();
                strbar.SetFormStatus(FormBindingStatus.Waiting);
            }
            
            txtCodigoArea.Tag = txtCodigoArea.Text;
        }
        private void On_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoArea.Text != "")
                {
                    List<clsTurnoHorario> lista = new List<clsTurnoHorario>();
                    ThrOrganizativeUnit objData = new ThrOrganizativeUnit();
                    ControllerRHSMH001 control = new ControllerRHSMH001();
                    objData.OrgUnitID = txtCodigoArea.Text;
                    objData.CompanyID = sageSession1.CompanyID;
                    objData.Name = txtNombreArea.Text;
                    objData.Description = txtdescripcion.Text;
                    objData.CostCenter = cmbCentro.SelectedValue.ToString();
                    objData.Horariokey = Convert.ToInt32(cmbHorarios.SelectedValue.ToString());
                    if (chxTurnos.Checked)
                    {
                        clsTurnoHorario turnoHorario;
                        if (dvTurnos.Rows.Count > 1)
                        {                           
                            for (int j = 0; j < dvTurnos.Rows.Count; j++)
                            {
                                for (int i = j + 1; i < dvTurnos.Rows.Count; i++)
                                {
                                    if ((dvTurnos.Rows[j].Cells[0].Value.ToString() != "") && (dvTurnos.Rows[j].Cells[1].Value != null) && (dvTurnos.Rows[i].Cells[0].Value.ToString() != "") && (dvTurnos.Rows[i].Cells[1].Value != null) )
                                    {
                                        if ((dvTurnos.Rows[j].Cells[0].Value.ToString() == dvTurnos.Rows[i].Cells[0].Value.ToString()) || (dvTurnos.Rows[j].Cells[1].Value.ToString() == dvTurnos.Rows[i].Cells[1].Value.ToString()))
                                        {
                                            MessageBox.Show("Verifique, no pueden ser definidos turnos con igual nombre o tipo de horario.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }                                        
                                    }
                                    else
                                    {
                                        MessageBox.Show("Verifique, el nombre del turno asi como al tipo de horario asignado no pueden estar en blanco.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }                                   
                                }
                                turnoHorario = new clsTurnoHorario();
                                turnoHorario.turnoName = dvTurnos.Rows[j].Cells[0].Value.ToString();
                                turnoHorario.horarioKey = Convert.ToInt16(dvTurnos.Rows[j].Cells[1].Value.ToString());
                                lista.Add(turnoHorario);
                            }                            
                        }
                        else
                        {
                            for (int j = 0; j < dvTurnos.Rows.Count; j++)
                            {
                                if ((dvTurnos.Rows[j].Cells[0].Value.ToString() != "") && ((dvTurnos.Rows[j].Cells[1].Value != null)))
                                {
                                    foreach (DataGridViewRow item in dvTurnos.Rows)
                                    {
                                        turnoHorario = new clsTurnoHorario();
                                        turnoHorario.turnoName = item.Cells[0].Value.ToString();
                                        turnoHorario.horarioKey = Convert.ToInt16(item.Cells[1].Value.ToString());
                                        lista.Add(turnoHorario);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Verifique, el nombre del turno asi como al tipo de horario asignado no pueden estar en blanco.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }                           
                        }
                    }
                    bool update = controler.BuscarDependencias(objData);
                    if (!update)
                    {
                        controler.AddUnidadOrganizativa(objData, lista);
                        UpdateLookup();
                    }
                    else { MessageBox.Show("La unidad organizativa que desea actualizar ya tiene persona asignadas en los turnos de trabajo definidos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al salvar los datos de la Unidad Organizativa.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }             
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
                if (txtCodigoArea.Text != "")
                {
                    bool result;
                    List<clsTurnoHorario> Listurnos = new List<clsTurnoHorario>();
                    clsTurnoHorario turnoHorario;
                    foreach (DataGridViewRow item in dvTurnos.Rows)
                    {
                        turnoHorario = new clsTurnoHorario();
                        turnoHorario.turnoName = item.Cells[0].Value.ToString();
                        turnoHorario.horarioKey = Convert.ToInt16(item.Cells[1].Value.ToString());
                        Listurnos.Add(turnoHorario);
                    }
                    result = controler.DeleteUnidadOrganizativa(txtCodigoArea.Text, Listurnos);
                    if (result)
                    {
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el registro, el área tiene dependenicas asociados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la Unidad Organizativa", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtCodigoArea.Text = "";            
            dvTurnos.Columns.Clear();
            dvTurnos.Rows.Clear();
            dvTurnos.Refresh();
            txtNombreArea.Text = "";
            chxTurnos.Checked = false;
            txtdescripcion.Text = "";           
            txtCodigoArea.Focus();
            if (cmbCentro.Items.Count > 0)
            {
                cmbCentro.SelectedIndex = 0;
            }
            On_IDChange(null, null);
            LoadContext();
        }        
        private bool ValidateForm(object sender, EventArgs e)
        {
            if (MainBS.Current == null) return false;
            ValidateChildren();
            Validate();                       
            
            if (txtCodigoArea.Text == "")
            {
                MessageBox.Show("Código no válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoArea.Focus();
                return false;
            }           
            if (txtCodigoArea.Text.Length > 0)
            {
                if (!IDHandler.IsAlphaNumeric(txtCodigoArea.Text))
                {
                    MessageBox.Show("Código no válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoArea.Focus();
                    return false;
                }
            }
            if (txtNombreArea.Text == "")
            {
                MessageBox.Show("Nombre no válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreArea.Focus();
                return false;
            }            
            return true;
        }      
        private void TxtCodigoArea_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                bool resultado = VerificarNomencladores();
                if (resultado)
                {
                    if (txtCodigoArea.Text != "")
                    {
                        if (!IDHandler.IsAlphaNumeric(txtCodigoArea.Text))
                        {
                            MessageBox.Show("El código no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            ControllerRHSMUO001 controler = new ControllerRHSMUO001();
                            ThrOrganizativeUnit data = controler.GetUnidadOrganizativ(txtCodigoArea.Text);
                            if (data != null)
                            {
                                MostrarDatosRegistro(data);                                
                            }
                            EnableControls();
                        }
                    }
                }
            }
        }
        private void IDValidate(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IDHandler.IsAlphaNumeric(txtCodigoArea.Text))
            {
                MessageBox.Show("El código no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }      
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            dvTurnos.Rows.Add("Turno #");
        }
        private void dvTurnos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void gbxHorarioTurno_Enter(object sender, EventArgs e)
        {

        }
        private void chxTurnos_CheckedChanged(object sender, EventArgs e)
        {
            if (chxTurnos.Checked)
            {                
                if (dvTurnos.Rows.Count == 0)
                {    

                    ControllerRHSMH001 control = new ControllerRHSMH001();
                    cmb.DataSource = control.ActualizarLista();
                    cmbTexto.HeaderText = "Nombre Turno";                   
                    cmb.HeaderText = "Horario Turno";
                    cmb.DisplayMember = "HorarioID";
                    cmb.ValueMember = "HorarioKey";
                    cmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    gbxHorarioTurno.Visible = true;
                    dvTurnos.Columns.Add(cmbTexto);
                    dvTurnos.Columns.Add(cmb);
                    var cant = dvTurnos.Rows.Count;
                    dvTurnos.Rows.Add("Turno #");
                    dvTurnos.AllowUserToAddRows = false;
                    gbxHorarioTurno.Visible = true;
                }
                else { gbxHorarioTurno.Visible = true; }               
            }
            else
            {
                gbxHorarioTurno.Visible = false;

            }
        }
        private void dvTurnos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;
            if(dgvCombo !=null)
            {
                //dgvCombo.SelectedIndexChanged += new EventHandler(dgvCombo_SelectedIndexChanged);


            }
        }
        private void cmbCentro_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
