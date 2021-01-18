using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Negocio.Objetos;
using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls;
using Sage500AppModel;
using Entidades.General;
using Negocio;

namespace RHSMC001
{
    public partial class frmCargo : Form
    {
        ControllerRHSMC001 controler;
        int TipoCompetencia = 0;       
        List<clsCompetencias> listaCompetenciaXCargo; 
        List<clsRiesgo> listaRiesgosXCargo;        
        List<ThrLaboralCondition> listaCondicionesBD; 
        public frmCargo()
        {
            InitializeComponent();
            controler = new ControllerRHSMC001();
        }
        public frmCargo(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);
            LoadContext();
            tabControl1.SelectedIndex = 0;
            listaCondicionesBD = new List<ThrLaboralCondition>();
            
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
            UpdateLookup();
        }
        public void CargarDatosIniciales()
        {
            try
            {
                ControllerRHSMGE001 controler = new ControllerRHSMGE001();
                cmbgrupoEscala.DataSource = controler.ActualizarLista();
                cmbgrupoEscala.DisplayMember = "EscalaGroupID";
                cmbgrupoEscala.ValueMember = "EscalaGroupkey";

                ControllerRHSMCO001 catocupacional = new ControllerRHSMCO001();
                cmbOcupationCategory.DataSource = catocupacional.ActualizarLista();
                cmbOcupationCategory.DisplayMember = "CategoryID";
                cmbOcupationCategory.ValueMember = "OcupationCategoryKey";

                dtpfechaCreacionCargo.Value = DateTime.Now;
                //Cargar datos iniciales relacionados al estado del cargo
                cmbestadoCargo.DataSource = Enum.GetValues(typeof(EstadoCargo));
                cmbestadoCargo.SelectedItem = EstadoCargo.Activo;

                cmbClasifTrabajdor.DataSource = Enum.GetValues(typeof(ClasificTrabajador));
                cmbClasifTrabajdor.SelectedItem = ClasificTrabajador.Tarifa;

            }
            catch (Exception)
            {
                MessageBox.Show("Error en la carga de datos iniciales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void EnableControls()
        {
            txtCodigo.Enabled = false;
            tabControl1.Enabled = true;
        }        
        private void DisableControls()
        {
            txtCodigo.Enabled = true;
            tabControl1.Enabled = false;
        }
        private void Form_Show(object sender, EventArgs e)
        {
            CargarDatosIniciales();
            UpdateLookup();
            DisableControls();
        }
        private void UpdateLookup()
        {           
            //lkuNav.SetData(controler.ActualizarLista());
        }
        public void MostrarDatosRegistro(clsCargo dato)
        {            
            if (dato != null)
            {
                ControlllerRHSMP001 controler = new ControlllerRHSMP001();
                txtCodigo.Text = dato.codigo;
                txtNombre.Text = dato.nombrecargo;
                txtdescrip.Text = dato.descripcion;
                var estadoCarg = (EstadoCargo)dato.estado;
                cmbestadoCargo.Text = estadoCarg.ToString();
                var clasifcTrabajador = (ClasificTrabajador)dato.clasficacionTrabajador;
                cmbClasifTrabajdor.Text = clasifcTrabajador.ToString();
                txtHoursExtra.Text = dato.horasExtraspagar.ToString();
                txtpagoxcargo.Text = dato.pagoxcargo.ToString();
                dtpfechaCreacionCargo.Value = dato.fechaCreacion;
                txtMision.Text = dato.mision;
                txtFuncionesRespons.Text = dato.funcionesRespons;
                ControllerRHSMC001 controller = new ControllerRHSMC001();
                cmbgrupoEscala.Text = controller.GetGroupEscala(Convert.ToInt16(dato.grupoescala));
                cmbOcupationCategory.Text = controler.GetCategoriaOcupacional(Convert.ToInt16(dato.categoriaOcupacional));
                if (dato.ListAreasOrganizativas.Count > 0)
                {
                    lvareasseleccion.Items.Clear();
                    for (int j = 0; j < lvareasdisponibles.Items.Count; j++)
                    {
                        for (int i = 0; i < dato.ListAreasOrganizativas.Count; i++)
                        {
                            if (lvareasdisponibles.Items[j].Text == dato.ListAreasOrganizativas[i].name)
                            {
                                ListViewItem item = new ListViewItem();
                                item.Checked = true;
                                item.Text = dato.ListAreasOrganizativas[i].name.ToString();
                                lvareasseleccion.Items.Add(item);                                
                                lvareasdisponibles.Items[j].Remove();
                                lvareasdisponibles.Refresh();
                            }

                        }
                    }
                }
                if (dato.ListCondicionesAnormales.Count > 0)
                {
                    lvcondicionesSelecc.Items.Clear();
                    for (int j = 0; j < lvcondDispon.Items.Count; j++)
                    {
                        for (int i = 0; i < dato.ListCondicionesAnormales.Count; i++)
                        {
                            if (lvcondDispon.Items[j].Text == dato.ListCondicionesAnormales[i].amormalname)
                            {
                                ListViewItem item = new ListViewItem();
                                item.Checked = true;
                                item.Text = dato.ListCondicionesAnormales[i].amormalname.ToString();
                                lvcondicionesSelecc.Items.Add(item);                              
                                lvcondDispon.Items[j].Remove();
                            }
                        }
                    }
                }
                if (dato.ListCompetencias.Count > 0)
                {
                    ListViewItem nuevoitem;
                    lvcompetencias.Items.Clear();
                    foreach (clsCompetencias item in dato.ListCompetencias)
                    {
                        nuevoitem = new ListViewItem(item.nombre.ToString());
                        nuevoitem.SubItems.Add(item.descripcion.ToString());
                        if (item.requerido == true) { nuevoitem.SubItems.Add("Si"); }
                        else
                        {
                            nuevoitem.SubItems.Add("No");
                        }
                        if (item.niveles == 1)
                        {
                            nuevoitem.SubItems.Add("Alto");
                        }
                        else if (item.niveles == 2)
                        {
                            nuevoitem.SubItems.Add("Medio");
                        }
                        else nuevoitem.SubItems.Add("Bajo");

                        if (item.tipo == 1)
                        { nuevoitem.SubItems.Add("Básicas"); }
                        if (item.tipo == 2)
                        { nuevoitem.SubItems.Add("Generales"); }
                        if (item.tipo == 3)
                        { nuevoitem.SubItems.Add("Específicas"); }
                        lvcompetencias.Items.Add(nuevoitem);
                    }                   
                }
                if (dato.ListaCondicionesLaborales.Count > 0)
                {                   
                    ControllerRHSMCL001 controlador = new ControllerRHSMCL001();
                    foreach (DataGridViewRow row in datagridviewCond.Rows)
                    {
                        var obj = controlador.BuscarConditionlaboralKey(row.Cells[1].Value.ToString());
                        foreach (clsCondicionLaboral item in dato.ListaCondicionesLaborales)
                        {
                            ThrLaboralCondition cond = controlador.BuscarConditionlaboralKey(item.codicionLaboralID);
                            if (obj.TipoConditionLab == cond.TipoConditionLab)
                            {
                                if (obj.ConditionlabID == cond.ConditionlabID)
                                {
                                    row.Cells[0].Value = true;                                  
                                    row.Visible = true;
                                }
                                else { row.Visible = true; }
                            }
                            else { row.Visible = false; }
                        }

                    }
                    cmbTipoCondicion.DataSource = Enum.GetValues(typeof(TipoCondicion));
                    cmbTipoCondicion.SelectedItem = TipoCondicion.Básicas;
                }
                if (dato.ListaRiesgosLaborales.Count > 0)
                {
                    lvRiesgos.Items.Clear();
                    ListViewItem nuevoitem;
                    foreach (clsRiesgo item in dato.ListaRiesgosLaborales)
                    {
                        nuevoitem = new ListViewItem(item.nombreRiesgo.ToString());
                        nuevoitem.SubItems.Add(item.descripcionRiesgo.ToString());                       
                        if (item.nivel == 1)
                        {
                            nuevoitem.SubItems.Add("Alto");
                        }
                        else if (item.nivel == 2)
                        {
                            nuevoitem.SubItems.Add("Medio");
                        }
                        else nuevoitem.SubItems.Add("Bajo");

                        if (item.tipo == 1)
                        {
                            nuevoitem.SubItems.Add("Mecánicos");
                        }
                        else if (item.tipo == 2)
                        { nuevoitem.SubItems.Add("Físicos"); }
                        else if (item.tipo == 3)
                        { nuevoitem.SubItems.Add("Locativos"); }
                        else if (item.tipo == 4)
                        { nuevoitem.SubItems.Add("Psicosociales"); }
                        else if (item.tipo == 5)
                        { nuevoitem.SubItems.Add("Información"); }
                        else { nuevoitem.SubItems.Add("Meteorológico"); }
                        lvRiesgos.Items.Add(nuevoitem);
                    }
                }               

            }
            
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCodigo.Tag != null && txtCodigo.Tag.ToString() == txtCodigo.Text) return;
            MainBS.Clear();
           
            if (txtCodigo.Text.Length > 0)
            {               
                ThrPosition cargo = controler.GetCargo(txtCodigo.Text);
                if (cargo != null)
                {
                    clsCargo data = controler.CargarDatosObjCargo(cargo.Codigo);
                    if (data != null)
                    {
                        MainBS.Add(data); 
                        strBar.SetFormStatus(FormBindingStatus.Editing);
                    }
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
            txtCodigo.Tag = txtCodigo.Text;
        }
        public bool VerificarNomencladores()
        {            
            CargarDatosIniciales();
            if (cmbgrupoEscala.Items.Count == 0)
            {
                MessageBox.Show("Verifique, no han sido configurados los Grupos de Escala.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbOcupationCategory.Items.Count == 0)
            {
                MessageBox.Show("Verifique, no han sido configuradas las Categorías Ocupacionales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            ControllerRHSMUO001 areasorg = new ControllerRHSMUO001();
            var listaUnidades = areasorg.ActualizarLista();
            if (listaUnidades.Count > 0)
            {
                lvareasdisponibles.Items.Clear();
                for (int i = 0; i < listaUnidades.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Checked = true;
                    item.Text = listaUnidades[i].Name.ToString();
                    lvareasdisponibles.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Verifique, no han sido configuradas las Unidades Administrativas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            ControllerRHSMCA001 condanormales = new ControllerRHSMCA001();
            var listaCondiciones = condanormales.ActualizarLista();
            if (listaCondiciones.Count > 0)
            {
                lvcondDispon.Items.Clear();
                for (int i = 0; i < listaCondiciones.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Checked = true;
                    item.Text = listaCondiciones[i].AnormalName.ToString();
                    lvcondDispon.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Verifique, no han sido configuradas las Condiciones Anormales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            ControllerRHSMCL001 controlador = new ControllerRHSMCL001();
            var listaCondicionesBD = controlador.GetCondicionesLaborales();
            if (listaCondicionesBD.Count > 0)
            {
                datagridviewCond.Rows.Clear();
                clsCondicionLaboral condicion;
                for (int i = 0; i < listaCondicionesBD.Count; i++)
                {
                    condicion = new clsCondicionLaboral();
                    condicion.codicionLaboralID = listaCondicionesBD[i].ConditionlabID;
                    condicion.codicionLaboralDescrip = listaCondicionesBD[i].ConditionLabDescription;
                    condicion.tipo = listaCondicionesBD[i].TipoConditionLab;
                    datagridviewCond.Rows.Add(false, listaCondicionesBD[i].ConditionlabID, listaCondicionesBD[i].ConditionLabDescription);
                    datagridviewCond.Rows[i].Visible = false;
                }
                datagridviewCond.AllowUserToAddRows = false;
                cmbTipoCondicion.DataSource = Enum.GetValues(typeof(TipoCondicion));
                cmbTipoCondicion.SelectedItem = TipoCondicion.Básicas;
            }
            else
            {
                MessageBox.Show("Verifique, no han sido configuradas las Condiciones Laborales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            ControllerRHSMR001 controlRiesgo = new ControllerRHSMR001();
            var listaRiesgo = controlRiesgo.GetRiesgos();
            if (listaRiesgo.Count == 0)
            {
                MessageBox.Show("Verifique, no han sido configurados las Riesgos Laborales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            ControllerRHSMCP001 controlComp = new ControllerRHSMCP001();
            var listaComp = controlComp.GetCompetencias();
            if (listaComp.Count == 0)
            {
                MessageBox.Show("Verifique, no han sido configuradas las Competencias.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;                    
        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtMision.Text = "";
            txtFuncionesRespons.Text = "";
            txtHoursExtra.Text = "0";
            txtpagoxcargo.Text = "0";
            txtNombre.Text = "";
            txtdescrip.Text = "";
            cmbgrupoEscala.Text = cmbgrupoEscala.Items[0].ToString();
            cmbOcupationCategory.Text = cmbOcupationCategory.Items[0].ToString();
            listaCondicionesBD.Clear();            
            lvcompetencias.Items.Clear();
            lvcondicionesSelecc.Items.Clear();
            lvareasseleccion.Items.Clear();
            lvRiesgos.Items.Clear();
            datagridviewCond.Rows.Clear();
            tabControl1.SelectedIndex = 0;
            DisableControls();
            LoadContext();
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    clsCargo objCargo = new clsCargo();
                    objCargo.codigo = txtCodigo.Text;
                    objCargo.nombrecargo = txtNombre.Text;
                    EstadoCargo estadoCarg = (EstadoCargo)cmbestadoCargo.SelectedItem;
                    objCargo.estado = ((SByte)estadoCarg);
                    ClasificTrabajador clasifTrabajador = (ClasificTrabajador)cmbClasifTrabajdor.SelectedItem;
                    objCargo.clasficacionTrabajador = ((SByte)clasifTrabajador);
                    objCargo.descripcion = txtdescrip.Text;
                    objCargo.fechaCreacion = dtpfechaCreacionCargo.Value;
                    objCargo.grupoescala = Convert.ToInt16(cmbgrupoEscala.SelectedValue.ToString());
                    objCargo.categoriaOcupacional = Convert.ToInt16(cmbOcupationCategory.SelectedValue.ToString());
                    objCargo.horasExtraspagar = Convert.ToDecimal(txtHoursExtra.Text);
                    objCargo.pagoxcargo = Convert.ToDecimal(txtpagoxcargo.Text);
                    objCargo.mision = txtMision.Text;
                    objCargo.funcionesRespons = txtFuncionesRespons.Text;
                    objCargo.ListAreasOrganizativas = this.UnidadesAdministrativas();
                    objCargo.ListCondicionesAnormales = this.CondicionesAnormales();
                    objCargo.ListCompetencias = this.Competencias();
                    objCargo.ListaCondicionesLaborales = this.CondicionesLaborales();
                    objCargo.ListaRiesgosLaborales = this.RiesgosLaborales();
                    controler.AddCargo(objCargo);
                    tabControl1.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar, los datos seleccionables no pueden ser modificados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<clsUnidadesOrganizativas> UnidadesAdministrativas()
        {
            var listaunidades = new List<clsUnidadesOrganizativas>();
            ControllerRHSMUO001 controler = new ControllerRHSMUO001();
            clsUnidadesOrganizativas unidadOrg;

            foreach (ListViewItem item in lvareasseleccion.Items)
            {
                unidadOrg = new clsUnidadesOrganizativas();
                unidadOrg = controler.GetUnidadOrganizativaName(item.Text.ToString());
                listaunidades.Add(unidadOrg);
            }
            return listaunidades;
        }
        private List<clsCondicionLaboral> CondicionesLaborales()
        {
            List<clsCondicionLaboral> listaCondicionesLab = new List<clsCondicionLaboral>();
            ControllerRHSMCL001 controler = new ControllerRHSMCL001();
            clsCondicionLaboral condlaboral;

            foreach (DataGridViewRow item in datagridviewCond.Rows)
            {
                condlaboral = new clsCondicionLaboral();
                bool isChecked = Convert.ToBoolean(item.Cells[0].Value);
                if (isChecked)
                {
                    condlaboral = controler.GetUnidadOrganizativ(item.Cells[1].Value.ToString());
                    listaCondicionesLab.Add(condlaboral);
                }
            }
            return listaCondicionesLab;
        }
        private List<clsCompetencias> Competencias()
        {  
            var listCompetencias = new List<clsCompetencias>();
            var controler = new ControllerRHSMCP001();
            clsCompetencias competencia;
            foreach (ListViewItem item in lvcompetencias.Items)
            {
                var comp = controler.BuscarCompetenciaKey(item.Text.ToString());
                competencia = new clsCompetencias();
                competencia.competenciakey = comp.CompetenciaKey;               
                competencia.nombre = item.ToString();   
                competencia.descripcion = item.SubItems[1].ToString();
                if(item.SubItems[2].Text == "Si")
                {competencia.requerido = true;}
                else { competencia.requerido = false; }
                if (item.SubItems[3].Text == "Alto")
                { competencia.niveles = 1; }
                else if (item.SubItems[3].Text == "Medio")
                { competencia.niveles = 2; }
                else { competencia.niveles = 3; }
                listCompetencias.Add(competencia);
            }
            return listCompetencias;
        }
        private List<clsCondicionesAnormales> CondicionesAnormales()
        {
            var listaCondiciones = new List<clsCondicionesAnormales>();
            var controler = new ControllerRHSMCA001();
            foreach (ListViewItem item in lvcondicionesSelecc.Items)
            {
                var condition = controler.GetAnormalCondi(item.Text.ToString());
                listaCondiciones.Add(condition);
            }
            return listaCondiciones;

        }
        private List<clsRiesgo> RiesgosLaborales()
        {
            var listaRiesgos = new List<clsRiesgo>();
            var controler = new ControllerRHSMR001();
            foreach (ListViewItem item in lvRiesgos.Items)
            {
                var riesgo = controler.GetRiesg(item.Text.ToString());
                if (item.SubItems[2].Text == "Alto")
                {
                    riesgo.nivel = 1;
                }
                else if (item.SubItems[2].Text == "Medio")
                {
                    riesgo.nivel = 2;
                }
                else { riesgo.nivel = 3; }

                listaRiesgos.Add(riesgo);
            }
            return listaRiesgos;
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    ThrPosition cargo = controler.GetCargo(txtCodigo.Text);
                    bool resultado = controler.BuscarDependenciasCargo(cargo.PositionKey);
                    if (!resultado)
                    {
                        controler.DeleteCargo(cargo); 
                        UpdateLookup();
                        Do_Cancel(null, null);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el cargo, existen personas que tienen asignadas este cargo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Verifique, Error al eliminar el cargo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }
        private bool ValidateForm(object sender, EventArgs e)
        {
            if (MainBS.Current == null) return false;
            ValidateChildren();
            Validate();

            if (txtHoursExtra.Text == "")
            {
                MessageBox.Show("El campo Horas extras no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoursExtra.Focus();
                return false;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre Cargo no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            
            if (txtpagoxcargo.Text == "")
            {
                MessageBox.Show("El campo Pago por Cargo no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpagoxcargo.Focus();
                return false;
            }           
            if (lvareasseleccion.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar las Unidades Organizativas a las que pertenece el Cargo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 1;
                txtpagoxcargo.Focus();
                return false;
            }
            if (lvcompetencias.Items.Count  == 0)
            {
                MessageBox.Show("Debe seleccionar las competencias para el Cargo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 4;
                return false;
            }
            return true;
        }
        private void IDValidate(object sender, CancelEventArgs e)
        {

        }
        private void BtnAdd_Click_1(object sender, EventArgs e)
        {
            if (lvareasdisponibles.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvareasdisponibles.SelectedItems)
                {
                    lvareasdisponibles.Items.Remove(item);
                    lvareasseleccion.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnDelete_Click_1(object sender, EventArgs e)
        {
            if (lvareasseleccion.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvareasseleccion.SelectedItems)
                {
                    lvareasseleccion.Items.Remove(item);
                    lvareasdisponibles.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void LvcondDispon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvcondDispon.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvcondDispon.SelectedItems)
                {
                    lvcondDispon.Items.Remove(item);
                    lvcondicionesSelecc.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void LvcondicionesSelecc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvcondicionesSelecc.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvcondicionesSelecc.SelectedItems)
                {
                    lvcondicionesSelecc.Items.Remove(item);
                    lvcondDispon.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void Lvareasdisponibles_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (lvareasdisponibles.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvareasdisponibles.SelectedItems)
                {
                    lvareasdisponibles.Items.Remove(item);
                    lvareasseleccion.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void Lvareasseleccion_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (lvareasseleccion.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvareasseleccion.SelectedItems)
                {
                    lvareasseleccion.Items.Remove(item);
                    lvareasdisponibles.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar un área.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void BtnDeleteCond_Click_1(object sender, EventArgs e)
        {
            if (lvcondicionesSelecc.SelectedItems.Count > 0)
            {
              
                foreach (ListViewItem item in lvcondicionesSelecc.SelectedItems)
                {   
                    lvcondicionesSelecc.Items.Remove(item);
                    lvcondDispon.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar una Condición Anormal.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnAddCon_Click(object sender, EventArgs e)
        {
            if (lvcondDispon.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvcondDispon.SelectedItems)
                {
                    lvcondDispon.Items.Remove(item);
                    lvcondicionesSelecc.Items.Add(item);
                }
            }
            else { MessageBox.Show("Debe seleccionar una Condición Anormal.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void OnNavChange(object sender, Net4Sage.Controls.Lookup.LookupReturnEventArgs eventArgs)
        {
            try
            {
                ThrPosition cargo = eventArgs.ReturnValue as ThrPosition;
                if (cargo != null)
                {
                    bool resultado = VerificarNomencladores();
                    if (resultado)
                    {
                        clsCargo data = controler.CargarDatosObjCargo(cargo.Codigo);
                        MostrarDatosRegistro(data);
                        On_IDChange(null, null);
                    }
                    EnableControls();
                }
            }            
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
        private void TxtHoursExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void Txtestimulacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void Txtpagoxcargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }
        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodigo.Text != "")
                {
                    bool resultado = VerificarNomencladores();
                    if (resultado)
                    {
                        if (!IDHandler.IsAlphaNumeric(txtCodigo.Text))
                        {
                            MessageBox.Show("El código no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            ThrPosition cargo = controler.GetCargo(txtCodigo.Text);
                            if (cargo != null)
                            {
                                clsCargo data = controler.CargarDatosObjCargo(cargo.Codigo);
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
                    }
                }
            }
        }  
        public void MostrarCompetenciasSeleccionadas(List<clsCompetencias> listaCompetencias)
        {
            try
            {
                lvcompetencias.Items.Clear();
                ListViewItem nuevoitem;
                foreach (clsCompetencias item in listaCompetencias)
                {
                    nuevoitem = new ListViewItem(item.nombre.ToString());
                    nuevoitem.SubItems.Add(item.descripcion.ToString());
                    if (item.requerido == true) { nuevoitem.SubItems.Add("Si"); }
                    else
                    {
                        nuevoitem.SubItems.Add("No");
                    }
                    if (item.niveles == 1)
                    {
                        nuevoitem.SubItems.Add("Alto");
                    }
                    else if (item.niveles == 2)
                    {
                        nuevoitem.SubItems.Add("Medio");
                    }
                    else nuevoitem.SubItems.Add("Bajo");
                    if (item.tipo == 1)
                    { nuevoitem.SubItems.Add("Básicas"); }
                    if (item.tipo == 2)
                    { nuevoitem.SubItems.Add("Generales"); }
                    else
                    { nuevoitem.SubItems.Add("Específicas"); }
                    lvcompetencias.Items.Add(nuevoitem);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar las competencias seleccionadas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void MostrarRiesgosSeleccionados(List<clsRiesgo> listaRiesgos)
        {
            try
            {
                lvRiesgos.Items.Clear();
                ListViewItem nuevoitem;
                foreach (clsRiesgo item in listaRiesgos)
                {
                    nuevoitem = new ListViewItem(item.nombreRiesgo.ToString());
                    nuevoitem.SubItems.Add(item.descripcionRiesgo.ToString());                   
                    if (item.nivel == 1)
                    {
                        nuevoitem.SubItems.Add("Alto");
                    }
                    else if (item.nivel == 2)
                    {
                        nuevoitem.SubItems.Add("Medio");
                    }
                    else nuevoitem.SubItems.Add("Bajo");
                    if (item.tipo == 1)
                    {
                        nuevoitem.SubItems.Add("Mecánicos");
                    }
                    else if (item.tipo == 2)
                    { nuevoitem.SubItems.Add("Físicos"); }
                    else if (item.tipo == 3)
                    { nuevoitem.SubItems.Add("Locativos"); }
                    else if (item.tipo == 4)
                    { nuevoitem.SubItems.Add("Psicosociales"); }
                    else if (item.tipo == 5)
                    { nuevoitem.SubItems.Add("Información"); }
                    else { nuevoitem.SubItems.Add("Meteorológico"); }
                    lvRiesgos.Items.Add(nuevoitem);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los riesgos seleccionados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnBuscarCompet_Click(object sender, EventArgs e)
        {          
            clsCompetencias competencias;
            List<clsCompetencias> list = new List<clsCompetencias>();
            for (int i = 0; i < lvcompetencias.Items.Count; i++)
            {
                competencias = new clsCompetencias();
                competencias.nombre = lvcompetencias.Items[i].Text;
                competencias.descripcion = lvcompetencias.Items[i].SubItems[1].Text;
                if (lvcompetencias.Items[i].SubItems[2].Text == "Si")
                {
                    competencias.requerido = true;
                }
                else { competencias.requerido = false; }

                if (lvcompetencias.Items[i].SubItems[3].Text == "Alto")
                {
                    competencias.niveles = 1;
                }
                else if (lvcompetencias.Items[i].SubItems[3].Text == "Medio")
                {
                    competencias.niveles = 2;
                }
                else { competencias.niveles = 3; }

                list.Add(competencias);
            }
            frmCompetencia formBuscarCompetencias = new frmCompetencia(list, txtCodigo.Text);
            if (formBuscarCompetencias.ShowDialog() == DialogResult.OK)
            {
                listaCompetenciaXCargo = formBuscarCompetencias.listCompeteSelecionadas;
                if (listaCompetenciaXCargo.Count > 0)
                {
                    MostrarCompetenciasSeleccionadas(listaCompetenciaXCargo);
                }
                else
                { lvcompetencias.Items.Clear(); }
            } 
        }        
        private void CmbTipoCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoCondicion selectipo = (TipoCondicion)cmbTipoCondicion.SelectedItem;
            TipoCompetencia = ((SByte)selectipo);

            var controlador = new ControllerRHSMCL001();
            List<ThrPositionConditionLab> condicionesXCargo = new List<ThrPositionConditionLab>();

            ThrPosition cargo = controler.GetCargo(txtCodigo.Text);
            if (cargo != null)
            {
                condicionesXCargo = controlador.GetCondocionesLaboralesXCargo(cargo.PositionKey);               
            }
            MostrarCondicionesCargo(condicionesXCargo, TipoCompetencia);

        }
        public void MostrarCondicionesCargo(List<ThrPositionConditionLab> CondicionesXCargo, int tipo)
        {
            try
            {
                ControllerRHSMCL001 controlador = new ControllerRHSMCL001();
                string tipoCompetencia = "";                
                if (tipo == 1)
                {
                    tipoCompetencia = "Básicas";
                }
                else if (tipo == 2)
                {
                    tipoCompetencia = "Generales";
                }
                else { tipoCompetencia = "Específicas"; }                   
                
                if (CondicionesXCargo.Count > 0)
                {
                    datagridviewCond.DataSource = null;
                    foreach (DataGridViewRow row in datagridviewCond.Rows)
                    {
                        var obj = controlador.BuscarConditionlaboralKey(row.Cells[1].Value.ToString());
                        foreach (ThrPositionConditionLab item in CondicionesXCargo)
                        {
                            ThrLaboralCondition cond = controlador.BuscarConditionLab(item.ConditionLabKey);
                            if (obj.TipoConditionLab == tipo)
                            {
                                if (row.Cells[1].Value.ToString() == cond.ConditionlabID)
                                {
                                    row.Cells[0].Value = true;                                    
                                    row.Visible = true;
                                }
                                else { row.Visible = true; }
                            }
                            else { row.Visible = false; }
                        }
                    }
                }
                else
                {
                    TipoCondicion selectipo = (TipoCondicion)cmbTipoCondicion.SelectedItem;
                    int tipoCond = (SByte)selectipo;

                    for (int i = 0; i < datagridviewCond.Rows.Count; i++)
                    {
                        var condition= controlador.BuscarConditionlaboralKey(datagridviewCond.Rows[i].Cells[1].Value.ToString());                        
                        if (tipoCond ==  condition.TipoConditionLab)
                        {
                            datagridviewCond.Rows[i].Visible = true;
                        }
                        else { datagridviewCond.Rows[i].Visible = false; }
                    }
                }
                datagridviewCond.AllowUserToAddRows = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar las condiciones laborales por cargo.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DatagridviewCond_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //bool estado = (bool)datagridviewCond.Rows[e.RowIndex].Cells[0].Value;
            //datagridviewCond.Rows[e.RowIndex].Cells[0].Value = estado;
            //if (!estado)
            //    datagridviewCond.Rows[e.RowIndex].Cells[3].Value = false;
        }
        private void DatagridviewCond_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (datagridviewCond.IsCurrentCellDirty)
            //{
            //    datagridviewCond.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }
        private void BtnAsociarRiesgos_Click(object sender, EventArgs e)
        {            
            try
            {    
                clsRiesgo riesgo;
                var list = new List<clsRiesgo>();
                for (int i = 0; i < lvRiesgos.Items.Count; i++)
                {
                    riesgo = new clsRiesgo();
                    riesgo.nombreRiesgo = lvRiesgos.Items[i].Text;
                    riesgo.descripcionRiesgo = lvRiesgos.Items[i].SubItems[1].Text;
                    if (lvRiesgos.Items[i].SubItems[2].Text == "Alto")
                    {
                        riesgo.nivel = 1;
                    }
                    else if (lvRiesgos.Items[i].SubItems[2].Text == "Medio")
                    {
                        riesgo.nivel = 2;
                    }
                    else { riesgo.nivel = 3; }

                    list.Add(riesgo);
                }
                frmRiesgos formBuscarRiesgos = new frmRiesgos(list, txtCodigo.Text);
                if (formBuscarRiesgos.ShowDialog() == DialogResult.OK)
                {
                    listaRiesgosXCargo = new List<clsRiesgo>(); 
                    listaRiesgosXCargo = formBuscarRiesgos.listaRiesgoSeleccionadas;
                    if (listaRiesgosXCargo.Count > 0)
                    {
                        MostrarRiesgosSeleccionados(listaRiesgosXCargo);
                    }
                    else { lvRiesgos.Items.Clear(); }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al adicionar los riesgos seleccionados.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            

        }
    }
 }

