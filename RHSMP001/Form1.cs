using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls;
using Net4Sage.Controls.Lookup;
using Net4Sage.DataAccessModel;
using System;
using Sage500AppModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using RHSMP001.Object;
using Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Entidades.General;

namespace RHSMP001
{
    public partial class frmEmpleados : Form
    {
        //bool existe = false;
        
        ControlllerRHSMP001 controler;      
        ControllerRHSMUO001 control;
        ControllerRHSMC001 controlad;
        public frmEmpleados()
        {
            InitializeComponent();
        }
        public frmEmpleados(ref SageSession session) : this()
        {
            this.sageSession1.InitializeSession(session);           
            LoadContext();
            CargarDatosIniciales();
            controler = new ControlllerRHSMP001();
            controlad = new ControllerRHSMC001();
            control = new ControllerRHSMUO001();
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
            Conection.connectionString = connectionString.ToString();
        }
        public void CargarDatosIniciales()
        {
            ControlllerRHSMP001 controler = new ControlllerRHSMP001();
            //ControllerRHSMH001 controlador = new ControllerRHSMH001();
            ControllerRHSMUO001 control = new ControllerRHSMUO001();

           /* cmbPosition.DataSource = controler.GetaAllsPositions();
            cmbPosition.DisplayMember = "PositionID";
            cmbPosition.ValueMember = "Positionkey";*/

            cmbProvince.DataSource = controler.GetaAllsStates();
            cmbProvince.DisplayMember = "StateID";
            cmbProvince.ValueMember = "Statekey";

            cmbNivelCultural.DataSource = controler.GetaAllsNivelesCulturales();
            cmbNivelCultural.DisplayMember = "CulturalID";
            cmbNivelCultural.ValueMember = "CulturalLevelKey";

            cmbScientificCateg.DataSource = controler.GetaAllsScientifCategories();
            cmbScientificCateg.DisplayMember = "ScientificCategoryID";
            cmbScientificCateg.ValueMember = "ScientificCategorykey";

            cmbWorkertype.DataSource = controler.GetaAllsWrokerTypes();
            cmbWorkertype.DisplayMember = "WorkerTypeID";
            cmbWorkertype.ValueMember = "WorkerTypekey";

            cmbClasifOcupational.DataSource = controler.GetaAllsOcupationClasi();
            cmbClasifOcupational.DisplayMember = "SpecialtyID";
            cmbClasifOcupational.ValueMember = "OcupationClasificationkey";

           /* cmbUnidadOrganizativa.DataSource = controler.GetaAllsOrganizativeUnit();
            cmbUnidadOrganizativa.DisplayMember = "Name";
            cmbUnidadOrganizativa.ValueMember = "OrgUnitKey";
                    
            cmbTurnos.DataSource = control.BuscarTurnos(); 
            cmbTurnos.DisplayMember = "TurnoName";
            cmbTurnos.ValueMember = "Turnokey";*/
           

            //Cargar datos iniciales relacionados al Color de la Piel
            cmbcolorpiel.DataSource = Enum.GetValues(typeof(ColorPiel));
            cmbcolorpiel.SelectedItem = ColorPiel.Blanco;

            //Cargar datos iniciales relacionados al Color Ojos
            cmbColorOjos.DataSource = Enum.GetValues(typeof(ColorOjos));
            cmbColorOjos.SelectedItem = ColorOjos.Pardos;

            //Cargar datos iniciales relacionados al estado de la persona
            cmbEstadopersona.DataSource = Enum.GetValues(typeof(EstadoPersona));
            cmbEstadopersona.SelectedItem = EstadoPersona.Solicitud;

            //Cargar datos iniciales relacionados al Nacionalidad
            cmbNacionality.DataSource = Enum.GetValues(typeof(Nacionalidad));
            cmbNacionality.SelectedItem = Nacionalidad.CUBANA;

            //Cargar datos iniciales relacionados al Sexo
            cmbSexo.DataSource = Enum.GetValues(typeof(Sexo));
            cmbcolorpiel.SelectedItem = Sexo.Masculino;

            //Cargar datos iniciales relacionados al Sexo
            cmbEstadoCivil.DataSource = Enum.GetValues(typeof(CivilState));
            cmbEstadoCivil.SelectedItem = CivilState.Soltero;

            //Cargar datos iniciales relacionados a la Situacion Laboral
            cmbSitLaboral.DataSource = Enum.GetValues(typeof(SituacionLaboral));
            cmbSitLaboral.SelectedItem = SituacionLaboral.Activa;

            dtpFechaNac.Text = DateTime.Now.ToShortDateString();

        }
        public bool VerificarNomencladores()
        {
            //CargarDatosIniciales();                
            if (cmbScientificCateg.Items.Count == 0)
            {
                MessageBox.Show("Verifique. En el sistema no han sido cargado las Categorias Scientíficas.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbClasifOcupational.Items.Count == 0)
            {
                MessageBox.Show("Verifique. En el sistema no han sido cargado las Clasificaciones Ocupacionales.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbWorkertype.Items.Count == 0)
            {
                MessageBox.Show("Verifique. En el sistema no han sido cargado los Tipos de Trabajadores.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }           
            return true;
        }
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            DisableControls();
        }    
        private void UpdateLookup()
        {
            int tipoPersona = 0;
            ControlllerRHSMP001 controler = new ControlllerRHSMP001();
            ControllerRHSMC001 control = new ControllerRHSMC001();
            ControllerRHSMUO001 controlador = new ControllerRHSMUO001();
            if (rdbCubano.Checked)
            {
                tipoPersona = 1;                
                lkuNav.SetData(controler.ActualizarLista(tipoPersona));
                lkuUnidades.SetData(controlador.ActualizarLista());
                var unidad = controlador.GetUnidadOrganizativaName(txtUnidad.Text);
                lkuCargo.SetData(control.ActualizarLista(unidad.OrgUnitKey));                 
                lkuturnos.SetData(controlador.BuscarTurnosXUnidad(unidad.OrgUnitKey));
            }
            else
            {
                tipoPersona = 2;
                lkuNav.SetData(controler.ActualizarLista(tipoPersona));
                lkuUnidades.SetData(controlador.ActualizarLista());
                var unidad = controlador.GetUnidadOrganizativaName(txtUnidad.Text);
                lkuCargo.SetData(control.ActualizarLista(unidad.OrgUnitKey));
                lkuturnos.SetData(controlador.BuscarTurnosXUnidad(unidad.OrgUnitKey));
            }
        }
        private void EnableControls()
        {
            txtCI.Enabled = false;
            txtName.Enabled = true;
            txtSegundoNombre.Enabled = true;
            txtPrimerApellido.Enabled = true;
            txtSegApellido.Enabled = true;
            tabControl1.Enabled = true;
        }
        private void DisableControls()
        {
            txtCI.Enabled = true;
            txtSegundoNombre.Enabled = false;
            txtName.Enabled = false;
            txtPrimerApellido.Enabled = false;
            txtSegApellido.Enabled = false;
            tabControl1.Enabled = false;
        }
        private void DisableControlsGeneral()
        {            
            txtSegundoNombre.Enabled = false;
            txtName.Enabled = false;
            txtPrimerApellido.Enabled = false;
            txtSegApellido.Enabled = false;
            tabControl1.Enabled = false;
        }        
        public void MostrarDatosRegistro(ThrPeople dato)
        {            
            var data = new ThrPeople();
            data = dato;
            var unidad = control.GetUnidadOrganizativaKey(data.OrgUnitKey);
            txtUnidad.Text = unidad.Name;
            var cargo = controlad.GetCargoXKey(data.PositionKey);
            txtCargo.Text = cargo.PositionID;
            txtCI.Text = data.CI;
            txtName.Text = data.PrimerNombre;
            txtSegundoNombre.Text = data.SegundoNombre;
            txtPrimerApellido.Text = data.PrimerApellido;
            txtSegApellido.Text = data.SegundoApellido;
            var sex = (Sexo)data.Sex;
            cmbSexo.Text = sex.ToString();
            dtpFechaNac.Text = data.BirthDate.ToString();
            var state = (CivilState)data.CivilStatuskey;
            cmbEstadoCivil.Text = state.ToString();
            var color = (ColorPiel)data.SkinColor;
            cmbcolorpiel.Text = color.ToString();           
            var Nacionality = (Nacionalidad)data.Nacionalitykey;
            cmbNacionality.Text = Nacionality.ToString();
            var situaLaboral = (SituacionLaboral)data.SituacionLaboral;
            cmbSitLaboral.Text = situaLaboral.ToString();
            var estadoPers = (EstadoPersona)data.Estato;
            cmbEstadopersona.Text = estadoPers.ToString();
            txtTelefono.Text = data.Phone;
            txtmovil.Text = data.Movil;
            txtemail.Text = data.Email;
            txtAve.Text = data.AddressAve;
            txtbulding.Text = data.AddressBulding;
            txtNumberhome.Text = data.AddressNo;
            txtRpto.Text = data.AddressRpto;
            txtEntre.Text = data.AddressBetween;
            txtEntre1.Text = data.AddressBetweenLast;
            if(dato.Estato ==6)
            { 
                txtUnidad.Enabled = false;
                lkuUnidades.Enabled = false;
                txtCargo.Enabled = false;
                lkuCargo.Enabled = false;
            }
            else
            {
                txtUnidad.Enabled = true;
                lkuUnidades.Enabled = true;
                txtCargo.Enabled = true;
                lkuCargo.Enabled = true;              
            }
            if (dato.TurnoKey != null)
            {
                var turnotrabajo = control.BuscarTurno(Convert.ToInt32(dato.TurnoKey));
                txtturno.Text = turnotrabajo.TurnoName;
            }            
            cmbProvince.Text = controler.GetProvince(data.AddressStateKey);
            cmbMunicipality.Text = controler.GetMunicipality(Convert.ToInt16(data.AddressMunicipalitykey));    
            cmbNivelCultural.Text = controler.GetCulturalLevel(Convert.ToInt16(data.CultureKey));
            cmbScientificCateg.Text = controler.GetCategoriaScientifica(Convert.ToInt16(data.CientificCategorykey));
            cmbClasifOcupational.Text = controler.GetClasifOcupacional(Convert.ToInt16(data.OcupationalClasificacionKey));
            txtNoExpedLaboral.Text = data.EmploymentRecord;
            cmbWorkertype.Text = controler.GetWorkerType(Convert.ToInt16(data.WorkerTypekey));
            masktxtCuentaMN.Text = data.NoCuentaMN;
            txtExpempleadora.Text = data.EmployRecEmpleadora;
            rchObservTrabajador.Text = data.Observaciones;
            rchRasgos.Text = data.RasgosDistintivos;
            txtProfesion.Text = data.Profesion;
            txtAlias.Text = data.Alias;
            txtpeso.Text = data.Peso.ToString();
            txtestatura.Text = data.Estatura.ToString();
            txtCodTecnosime.Text = data.CodWorkerTecnosime.ToString();
            txtCodTrabajador.Text = data.CodWorker.ToString();
            string path = data.UrlPhoto;
            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    ptbFoto.Image = Image.FromStream(stream);
                }
            }
        }
        private void On_IDChange(object sender, EventArgs e)
        {
            if (txtCI.Tag != null && txtCI.Tag.ToString() == txtCI.Text) return;
            MainBS.Clear();

            if (txtCI.Text.Length > 0)
            {   
               // int estado = 6;
                ControlllerRHSMP001 controler = new ControlllerRHSMP001();
                var data = controler.GetPersona(txtCI.Text);
                if (data != null)
                {
                    MainBS.Add(data);
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
            txtCI.Tag = txtCI.Text;

        }
        private void Do_Cancel(object sender, EventArgs e)
        {
            if (rdbCubano.Enabled == true)
            {
                txtCI.Text = "";
                txtSegundoNombre.Text = "";
                txtName.Text = "";
                txtPrimerApellido.Text = "";
                txtSegApellido.Text = "";
                txtName.Text = "";
                txtTelefono.Text = "";
                txtAve.Text = "";
                txtRpto.Text = "";
                txtturno.Text = "";
                txtUnidad.Text = "";
                txtCargo.Text = "";
                txtEntre.Text = "";
                txtExpempleadora.Text = "";
                txtEntre1.Text = "";
                txtemail.Text = "";
                txtmovil.Text = "";
                txtbulding.Text = "";
                txtNoExpedLaboral.Text = "";
                txtNumberhome.Text = "";
                rchObservTrabajador.Text = "";
                txtCodTrabajador.Text = "";
                txtCodTecnosime.Text = "";
                txtAlias.Text = "";
                txtestatura.Text = "";
                txtpeso.Text = "";
                txtProfesion.Text = "";
                rchRasgos.Text = "";
                tabControl1.SelectedIndex = 0;
                ptbFoto.Image = null;
                if (cmbSexo.Items.Count > 0)
                {
                    cmbSexo.SelectedItem = cmbSexo.Items[0].ToString();
                }
                if (cmbEstadoCivil.Items.Count > 0)
                {
                    cmbEstadoCivil.SelectedItem = cmbEstadoCivil.Items[0].ToString();
                }
                if (cmbcolorpiel.Items.Count > 0)
                {
                    cmbcolorpiel.SelectedItem = cmbcolorpiel.Items[0].ToString();
                }
                if (cmbNacionality.Items.Count > 0)
                {
                    cmbNacionality.SelectedItem = cmbNacionality.Items[0].ToString();
                }
                if (cmbProvince.Items.Count > 0)
                {
                    cmbProvince.SelectedItem = cmbProvince.Items[0].ToString();
                }
                if (cmbMunicipality.Items.Count > 0)
                {
                    cmbMunicipality.SelectedItem = cmbMunicipality.Items[1].ToString();
                }
                if (cmbNivelCultural.Items.Count > 0)
                {
                    cmbNivelCultural.SelectedItem = cmbNivelCultural.Items[0].ToString();
                }               
               
                if (cmbClasifOcupational.Items.Count > 0)
                {
                    cmbClasifOcupational.SelectedItem = cmbClasifOcupational.Items[0].ToString();
                }
                if (cmbWorkertype.Items.Count > 0)
                {
                    cmbWorkertype.SelectedItem = cmbWorkertype.Items[0].ToString();
                }if (cmbScientificCateg.Items.Count > 0)
                {
                    cmbScientificCateg.SelectedItem = cmbScientificCateg.Items[0].ToString();
                }                
                txtCI.Focus();
                DisableControls();
                LoadContext();
            }
        }
        private void Do_Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCI.Text != "")
                {
                    ThrPeople objData = new ThrPeople();
                    objData.CI = txtCI.Text;
                    objData.PrimerNombre = txtName.Text;
                    objData.SegundoNombre = txtSegundoNombre.Text;
                    objData.PrimerApellido = txtPrimerApellido.Text;
                    objData.SegundoApellido = txtSegApellido.Text;
                    Sexo selectSex = (Sexo)cmbSexo.SelectedItem;
                    objData.Sex = ((SByte)selectSex);
                    objData.BirthDate = dtpFechaNac.Value.Date;
                    CivilState state = (CivilState)cmbEstadoCivil.SelectedItem;
                    objData.CivilStatuskey = ((SByte)state);
                    ColorPiel selectColor = (ColorPiel)cmbcolorpiel.SelectedItem;
                    objData.SkinColor = ((SByte)selectColor);
                    Nacionalidad selectNac = (Nacionalidad)cmbNacionality.SelectedItem;
                    objData.Nacionalitykey = ((SByte)selectNac);
                    SituacionLaboral selectSitulab = (SituacionLaboral)cmbSitLaboral.SelectedItem;
                    objData.SituacionLaboral = ((SByte)selectSitulab);
                    EstadoPersona estadopers = (EstadoPersona)cmbEstadopersona.SelectedItem;
                    objData.Estato = ((SByte)estadopers);
                    ColorOjos selectojos = (ColorOjos)cmbColorOjos.SelectedItem;
                    objData.Alias = txtAlias.Text;
                    objData.AcumuladoVacations = 0;
                    objData.EyesColor = ((SByte)selectojos);
                    objData.CodWorker = txtCodTrabajador.Text;
                    objData.CodWorkerTecnosime = txtCodTecnosime.Text;

                    ControllerRHSMUO001 control = new ControllerRHSMUO001();
                    var unidadAdmin = control.GetUnidadOrganizativaName(txtUnidad.Text);
                    objData.OrgUnitKey = unidadAdmin.OrgUnitKey;
                    
                    //objData.SheduleKey = unidadAdmin.Horariokey;
                    ControllerRHSMC001 controler = new ControllerRHSMC001();
                    var cargo = controler.GetCargoName(txtCargo.Text);
                    objData.PositionKey = cargo.PositionKey;

                    // Analizar el tema de los turnos para si es jornalero
                    if (cmbWorkertype.Text == "Jornalero")
                    {
                        var turno = control.BuscarTurnoName(txtturno.Text);
                        objData.TurnoKey = turno.TurnoKey;
                    }
                   // objData.PositionKey = cargo.PositionKey;

                    if (txtestatura.Text != "")
                    {
                        objData.Estatura = Convert.ToDecimal(txtestatura.Text);
                    }
                    if (txtpeso.Text != "")
                    {
                        objData.Peso = Convert.ToDecimal(txtpeso.Text);
                    }
                    if (txtedad.Text != "")
                    {
                        objData.Edad = Convert.ToInt32(txtedad.Text);
                    }
                    objData.Phone = txtTelefono.Text;
                    objData.Profesion = txtProfesion.Text;
                    objData.RasgosDistintivos = rchRasgos.Text;
                    objData.Movil = txtmovil.Text;
                    objData.Email = txtemail.Text;
                    objData.AddressAve = txtAve.Text;
                    objData.AddressBulding = txtbulding.Text;
                    objData.AddressNo = txtNumberhome.Text;
                    objData.AddressRpto = txtRpto.Text;
                    objData.AddressBetween = txtEntre.Text;
                    objData.AddressBetweenLast = txtEntre1.Text;  
                    objData.AddressStateKey = Convert.ToInt16(cmbProvince.SelectedValue.ToString());
                   
                    objData.AddressMunicipalitykey = Convert.ToInt16(cmbMunicipality.SelectedValue.ToString());
                    objData.CultureKey = Convert.ToInt16(cmbNivelCultural.SelectedValue.ToString());
                    objData.CientificCategorykey = Convert.ToInt16(cmbScientificCateg.SelectedValue.ToString());
                    objData.OcupationalClasificacionKey = Convert.ToInt16(cmbClasifOcupational.SelectedValue.ToString());
                    objData.EmploymentRecord = txtNoExpedLaboral.Text;
                    objData.EmployRecEmpleadora = txtExpempleadora.Text;
                    objData.WorkerTypekey = Convert.ToInt16(cmbWorkertype.SelectedValue.ToString());
                    objData.RegistrerDate = DateTime.Now;
                    objData.CreateUserID = sageSession1.UserID;
                    objData.CompanyID = sageSession1.CompanyID;
                    if (masktxtCuentaMN.Text == "    -    -    -")
                    {
                        objData.NoCuentaMN = null;
                    }
                    else
                    { objData.NoCuentaMN = masktxtCuentaMN.Text; }                   
                    objData.Observaciones = rchObservTrabajador.Text;
                    string path = "";
                    if (ptbFoto.Image != null)
                    {
                        path = Path.Combine("C:\\Program Files(x86)\\Sage Software\\Sage Mas 500 Client\\ImagenesPersonas", txtCI.Text + ".jpeg");
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        Bitmap bm = new Bitmap(ptbFoto.Image);
                        bm.Save(path, ImageFormat.Bmp);
                        objData.UrlPhoto = path;
                    }
                    ControlllerRHSMP001 controlerr = new ControlllerRHSMP001();
                    controlerr.AddPerson(objData);
                    UpdateLookup();
                    tabControl1.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al salvar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OnNavChange(object sender, LookupReturnEventArgs eventArgs)
        {
            ThrPeople data = eventArgs.ReturnValue as ThrPeople;
            try
            {
                var resultado = VerificarNomencladores();
                if (resultado)
                {
                    if (data != null)
                    {    
                        MostrarDatosRegistro(data);
                        On_IDChange(null, null);
                        EnableControls();
                        UpdateLookup();
                    }
                }
                else
                { DisableControls(); }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Do_Delete(object sender, EventArgs e)
        {
            try
            {
                if (txtCI.Text != "")
                {
                    ControlllerRHSMP001 controler = new ControlllerRHSMP001();
                    controler.DeletePerson(txtCI.Text);
                    string path = Path.Combine("C:\\Program Files(x86)\\Sage Software\\Sage Mas 500 Client\\ImagenesPersonas", txtCI.Text + ".jpeg");
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
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
                MessageBox.Show("Error al eliminar la persona.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private bool ValidateForm(object sender, EventArgs e)
        {
            if (MainBS.Current == null) return false;
            ValidateChildren();
            Validate();

            if (this.txtName.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Nombre válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                txtName.Focus();
                return false;
            }
            if (this.txtCodTecnosime.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un código de tecnosime válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 1;
                txtCodTecnosime.Focus();
                return false;
            }
            if (this.txtCodTrabajador.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un código de trabajador válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 1;
                txtCodTrabajador.Focus();
                return false;
            }
            if (txtUnidad.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir una Unidad Organizativa válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                txtUnidad.Focus();
                return false;
            }
            if (txtCargo.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Cargo válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                txtCargo.Focus();
                return false;
            }
            if (this.txtPrimerApellido.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Apellido válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                txtPrimerApellido.Focus();
                return false;
            }
            if (this.txtSegApellido.Text.Length == 0)
            {
                MessageBox.Show("Debe introducir un Apellido válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                txtSegApellido.Focus();
                return false;
            }
            if (this.txtemail.Text.Length > 0)
            {
                bool result = ValidarEmail(txtemail.Text);
                if (!result)
                {
                    MessageBox.Show("Debe introducir una dirección de correo electrónico válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedIndex = 0;
                    txtemail.Focus();
                    return false;
                }
            }
            if (this.txtestatura.Text == ".")
            {
                MessageBox.Show("Debe introducir una estatura válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                txtestatura.Focus();
                return false;
            }
            if (this.txtpeso.Text == ".")
            {
                MessageBox.Show("Debe introducir un peso válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                txtpeso.Focus();
                return false;
            }
            if (this.cmbProvince.Text == "")
            {
                MessageBox.Show("Debe introducir una Provincia válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                cmbProvince.Focus();
                return false;
            }
            if (this.cmbMunicipality.Text == "")
            {
                MessageBox.Show("Debe introducir un Municipio válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                cmbMunicipality.Focus();
                return false;
            }
            if (txtTelefono.Text.Length > 0)
            {
                if (!IDHandler.IsNumeric(txtTelefono.Text))
                {
                    MessageBox.Show("El número de teléfono no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefono.Focus();
                    return false;
                }
            }
            if (txtmovil.Text.Length > 0)
            {
                if (!IDHandler.IsNumeric(txtmovil.Text))
                {
                    MessageBox.Show("El número de móvil no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmovil.Focus();
                    return false;
                }
            }
            if (txtedad.Text == "0")
            {
                MessageBox.Show("La edad no es valida", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaNac.Focus();
                return false;
                
            }
            if (this.txtNoExpedLaboral.Text == "")
            {
                MessageBox.Show("El número de expediente es un campo obligatorio.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 1;
                txtNoExpedLaboral.Focus();
                return false;
            }
            if (txtExpempleadora.Text == "")
            {               
                MessageBox.Show("El número de expediente de la Empleadora no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 1;
                txtExpempleadora.Focus();
                return false;                
            }
            if (masktxtCuentaMN.Text != "    -    -    -")
            {
                if (!this.masktxtCuentaMN.MaskFull)
                {
                    MessageBox.Show("El número de cuenta en MN no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedIndex = 1;
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
            }
            if (rdbCubano.Checked)
            {
                if (cmbNacionality.Text == "EXTRANJERA")
                {
                    MessageBox.Show("La Nacionalidad no es válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedIndex = 0;
                    cmbNacionality.Focus();
                    return false;
                }
            }
            if (rdbextranjero.Checked)
            {
                if (cmbNacionality.Text == "CUBANA")
                {
                    MessageBox.Show("La Nacionalidad no es válida.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedIndex = 0;
                    cmbNacionality.Focus();
                    return false;
                }
            }

            return true;
        }
        private bool ValidarEmail(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }

        }
        public int ObtenerEdad()
        {
            DateTime fechaBirth = dtpFechaNac.Value;
            DateTime fechaActual = DateTime.Now;
            var yearsOld = fechaActual - fechaBirth;
            int years = (int)(yearsOld.TotalDays / 365.25);
            return years;
        }
        private void IDValidate(object sender, CancelEventArgs e)
        {
            if (IDHandler.IsAlphaNumeric(txtCI.Text) || IDHandler.IsNumeric(txtCI.Text))
            {
                if (lblCI.Text != "No. Pasaporte")
                {
                    if ((txtCI.Text.Length > 0 && txtCI.Text.Length < 11))
                    {
                        MessageBox.Show("El Carnet de Indentidad no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("El Carnet de Indentidad no es válido.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }
        private void TxtCI_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCI.Text != "")
                {
                    var resultado = VerificarNomencladores();
                    if (lblCI.Text == "Carnet de Identidad *")
                    {
                        if (IDHandler.IsNumeric(txtCI.Text) && txtCI.Text.Length == 11)
                        {
                            if (resultado)
                            {
                                var data = controler.GetPersona(txtCI.Text);
                                if (data != null)
                                {
                                    MainBS.Add(data);                                    
                                    MostrarDatosRegistro(data);
                                    strBar.SetFormStatus(FormBindingStatus.Editing);
                                }
                                EnableControls();
                                cmbNacionality.Text = "CUBANA";
                                string codTaibin = controler.GetCodWorker();
                                if (codTaibin == "")
                                {
                                    txtCodTrabajador.Text = "TBG001";
                                }
                                else
                                { txtCodTrabajador.Text = codTaibin.ToString(); }
                            }
                            else
                            { DisableControls(); }
                        }
                        else { MessageBox.Show("El Carnet de Indentidad no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        if (resultado)
                        {
                            var data = controler.GetPersona(txtCI.Text);
                            if (data != null)
                            {
                                MainBS.Add(data);
                                MostrarDatosRegistro(data);
                                strBar.SetFormStatus(FormBindingStatus.Editing);
                            }
                            EnableControls();
                            cmbNacionality.Text = "EXTRANJERA";
                            string codTaibin = controler.GetCodWorker();
                            if (codTaibin == "")
                            {
                                txtCodTrabajador.Text = "TBG001";
                            }
                            else
                            { txtCodTrabajador.Text = codTaibin.ToString(); }
                        }
                        else
                        { DisableControls(); }
                    }
                    UpdateLookup();
                }
                else 
                { 
                    MessageBox.Show("El Carnet de Indentidad no es válido", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThrState estado = (cmbProvince.SelectedItem) as ThrState;
            System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
            {
                Metadata = "res://*/DataModel1.csdl|res://*/DataModel1.ssdl|res://*/DataModel1.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sageSession1.GetConnectionString()
            };
            using (var mycontext = new Sage500AppEntities(connectionString.ToString()))
            {
                try
                {
                    if (cmbProvince.Text != "")
                    {
                        ControlllerRHSMP001 controler = new ControlllerRHSMP001();
                        cmbMunicipality.DataSource = controler.GetaAllsMunicipalyties(estado.Statekey);
                        cmbMunicipality.DisplayMember = "MunicipalityID";
                        cmbMunicipality.ValueMember = "Municipalitykey";
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cargar municipios por provincias", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void CubanoChecked(object sender, EventArgs e)
        {
            UpdateLookup();
            // DisableControls();
            lblCI.Text = "Carnet de Identidad *";
            Do_Cancel(null, null);
        }
        private void BuscarImagen(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string image = openFileDialog1.FileName;
                    ptbFoto.Image = Image.FromFile(image);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la imagen, no cuple con el formato", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void BtnScan_Click(object sender, EventArgs e)
        {

        }
        private void DtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            txtedad.Text = this.ObtenerEdad().ToString();
        }
        private void Cmbcolorpiel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            ptbFoto.Image = null;
            string path = @"C:\Program Files(x86)\Sage Software\Sage Mas 500 Client\ImagenesPersonas\" + txtCI.Text + "." + "jpeg";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private void Txtestatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }

        private void Txtpeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }
        }

        private void Rdbextranjero_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLookup();
            lblCI.Text = "No. Pasaporte";
            Do_Cancel(null, null);
            cmbNacionality.SelectedItem = Nacionalidad.EXTRANJERA;

        }

        private void CmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (cmbWorkertype.Text == "Sueldista")
                {
                    txtturno.Enabled = false;
                    lkuturnos.Enabled = false;
                }
                else
                {
                    txtturno.Enabled = true;
                    lkuturnos.Enabled = true;
                }
            }
        }     

        private void CmbPosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
           /* ControlllerRHSMP001 controler = new ControlllerRHSMP001();
            int cargo = Convert.ToInt16(cmbPosition.SelectedValue);
            cmbUnidadOrganizativa.DataSource = controler.GetaAllsOrganizativeUnit(cargo);
            cmbUnidadOrganizativa.DisplayMember = "Name";
            cmbUnidadOrganizativa.ValueMember = "OrgUnitKey";*/
        }    
        private void cmbUnidadOrganizativa_SelectionChangeCommitted(object sender, EventArgs e)
        {
           /* ControllerRHSMUO001 control = new ControllerRHSMUO001();
            var unidad = control.GetUnidadOrganizativaName(cmbUnidadOrganizativa.Text);
            var turnos = control.BuscarTurnosXUnidad(unidad.OrgUnitKey);
            if (turnos != null)
            {
                cmbTurnos.DataSource = turnos;
                cmbTurnos.DisplayMember = "TurnoName";
                cmbTurnos.ValueMember = "Turnokey";
            }
            else { cmbTurnos.Enabled = false; }*/
        }

        private void OnCargChange(object sender, LookupReturnEventArgs eventArgs)
        {
            ThrPosition data = eventArgs.ReturnValue as ThrPosition;
            try
            {
                if (data != null)
                {
                    txtCargo.Text = data.PositionID;
                    //txtCargo.tag = data.tag==
                }             

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OnUnitChange(object sender, LookupReturnEventArgs eventArgs)
        {
            ThrOrganizativeUnit data = eventArgs.ReturnValue as ThrOrganizativeUnit;
            try
            {
                if (data != null)
                {
                    txtUnidad.Text = data.Name;
                    UpdateLookup();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OnTurnoChange(object sender, LookupReturnEventArgs eventArgs)
        {
            ThrUnitTurno data = eventArgs.ReturnValue as ThrUnitTurno;
            try
            {
                if (data != null)
                {
                    txtturno.Text = data.TurnoName;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos.", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbWorkertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWorkertype.Text == "Sueldista")
            {
                txtturno.Enabled = false;
                lkuturnos.Enabled = false;
            }
            else
            {
                txtturno.Enabled = true;
                lkuturnos.Enabled = true;
            }
        }
    }
}
