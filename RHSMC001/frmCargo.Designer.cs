namespace RHSMC001
{
    partial class frmCargo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargo));
            this.sageSession1 = new Net4Sage.SageSession();
            this.strBar = new Net4Sage.Controls.StatusBar();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbClasifTrabajdor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdescrip = new System.Windows.Forms.TextBox();
            this.ldlDesc = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dtpfechaCreacionCargo = new System.Windows.Forms.DateTimePicker();
            this.lblfechaCreac = new System.Windows.Forms.Label();
            this.lblestadoCargo = new System.Windows.Forms.Label();
            this.cmbestadoCargo = new System.Windows.Forms.ComboBox();
            this.txtpagoxcargo = new System.Windows.Forms.TextBox();
            this.lblPagoxCargo = new System.Windows.Forms.Label();
            this.cmbgrupoEscala = new System.Windows.Forms.ComboBox();
            this.lnlGrupoEscala = new System.Windows.Forms.Label();
            this.cmbOcupationCategory = new System.Windows.Forms.ComboBox();
            this.lblClasifOcupacional = new System.Windows.Forms.Label();
            this.lblHorasExtraPAgar = new System.Windows.Forms.Label();
            this.txtHoursExtra = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblareasSeleccionada = new System.Windows.Forms.Label();
            this.lblareasDisponibles = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvareasseleccion = new System.Windows.Forms.ListView();
            this.lvareasdisponibles = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblCondSelec = new System.Windows.Forms.Label();
            this.lblCondDispo = new System.Windows.Forms.Label();
            this.btnDeleteCond = new System.Windows.Forms.Button();
            this.btnAddCon = new System.Windows.Forms.Button();
            this.lvcondicionesSelecc = new System.Windows.Forms.ListView();
            this.lvcondDispon = new System.Windows.Forms.ListView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFuncionesRespons = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lvcompetencias = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBuscarCompet = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.datagridviewCond = new System.Windows.Forms.DataGridView();
            this.ColSelecc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCondicionLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoCondicion = new System.Windows.Forms.ComboBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btnAsociarRiesgos = new System.Windows.Forms.Button();
            this.lvRiesgos = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.grbCategoriaOcup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewCond)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // strBar
            // 
            this.strBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strBar.Location = new System.Drawing.Point(0, 555);
            this.strBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strBar.Name = "strBar";
            this.strBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strBar.Size = new System.Drawing.Size(901, 38);
            this.strBar.SysSession = this.sageSession1;
            this.strBar.TabIndex = 0;
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(901, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // lkuNav
            // 
            this.lkuNav.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(175, 59);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 14;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.tabControl1);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(13, 89);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(874, 464);
            this.grbCategoriaOcup.TabIndex = 11;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(9, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(855, 432);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage1.Controls.Add(this.cmbClasifTrabajdor);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtMision);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtdescrip);
            this.tabPage1.Controls.Add(this.ldlDesc);
            this.tabPage1.Controls.Add(this.txtNombre);
            this.tabPage1.Controls.Add(this.lblNombre);
            this.tabPage1.Controls.Add(this.dtpfechaCreacionCargo);
            this.tabPage1.Controls.Add(this.lblfechaCreac);
            this.tabPage1.Controls.Add(this.lblestadoCargo);
            this.tabPage1.Controls.Add(this.cmbestadoCargo);
            this.tabPage1.Controls.Add(this.txtpagoxcargo);
            this.tabPage1.Controls.Add(this.lblPagoxCargo);
            this.tabPage1.Controls.Add(this.cmbgrupoEscala);
            this.tabPage1.Controls.Add(this.lnlGrupoEscala);
            this.tabPage1.Controls.Add(this.cmbOcupationCategory);
            this.tabPage1.Controls.Add(this.lblClasifOcupacional);
            this.tabPage1.Controls.Add(this.lblHorasExtraPAgar);
            this.tabPage1.Controls.Add(this.txtHoursExtra);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(847, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos";
            // 
            // cmbClasifTrabajdor
            // 
            this.cmbClasifTrabajdor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasifTrabajdor.FormattingEnabled = true;
            this.cmbClasifTrabajdor.Location = new System.Drawing.Point(380, 97);
            this.cmbClasifTrabajdor.Name = "cmbClasifTrabajdor";
            this.cmbClasifTrabajdor.Size = new System.Drawing.Size(158, 24);
            this.cmbClasifTrabajdor.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 17);
            this.label4.TabIndex = 58;
            this.label4.Text = "Clasificación Trabajador";
            // 
            // txtMision
            // 
            this.txtMision.Location = new System.Drawing.Point(14, 217);
            this.txtMision.Margin = new System.Windows.Forms.Padding(4);
            this.txtMision.MaxLength = 8000;
            this.txtMision.Multiline = true;
            this.txtMision.Name = "txtMision";
            this.txtMision.Size = new System.Drawing.Size(815, 179);
            this.txtMision.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "Misión";
            // 
            // txtdescrip
            // 
            this.txtdescrip.Location = new System.Drawing.Point(247, 41);
            this.txtdescrip.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescrip.MaxLength = 1000;
            this.txtdescrip.Name = "txtdescrip";
            this.txtdescrip.Size = new System.Drawing.Size(392, 22);
            this.txtdescrip.TabIndex = 55;
            // 
            // ldlDesc
            // 
            this.ldlDesc.AutoSize = true;
            this.ldlDesc.Location = new System.Drawing.Point(244, 20);
            this.ldlDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ldlDesc.Name = "ldlDesc";
            this.ldlDesc.Size = new System.Drawing.Size(82, 17);
            this.ldlDesc.TabIndex = 54;
            this.ldlDesc.Text = "Descripción";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(13, 41);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 1000;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(208, 22);
            this.txtNombre.TabIndex = 53;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(14, 21);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(109, 17);
            this.lblNombre.TabIndex = 52;
            this.lblNombre.Text = "Nombre Cargo *";
            // 
            // dtpfechaCreacionCargo
            // 
            this.dtpfechaCreacionCargo.Enabled = false;
            this.dtpfechaCreacionCargo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaCreacionCargo.Location = new System.Drawing.Point(666, 40);
            this.dtpfechaCreacionCargo.Name = "dtpfechaCreacionCargo";
            this.dtpfechaCreacionCargo.Size = new System.Drawing.Size(148, 22);
            this.dtpfechaCreacionCargo.TabIndex = 51;
            // 
            // lblfechaCreac
            // 
            this.lblfechaCreac.AutoSize = true;
            this.lblfechaCreac.Location = new System.Drawing.Point(663, 22);
            this.lblfechaCreac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfechaCreac.Name = "lblfechaCreac";
            this.lblfechaCreac.Size = new System.Drawing.Size(127, 17);
            this.lblfechaCreac.TabIndex = 50;
            this.lblfechaCreac.Text = "Fecha de Creación";
            // 
            // lblestadoCargo
            // 
            this.lblestadoCargo.AutoSize = true;
            this.lblestadoCargo.Location = new System.Drawing.Point(193, 76);
            this.lblestadoCargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblestadoCargo.Name = "lblestadoCargo";
            this.lblestadoCargo.Size = new System.Drawing.Size(52, 17);
            this.lblestadoCargo.TabIndex = 49;
            this.lblestadoCargo.Text = "Estado";
            // 
            // cmbestadoCargo
            // 
            this.cmbestadoCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbestadoCargo.FormattingEnabled = true;
            this.cmbestadoCargo.Location = new System.Drawing.Point(196, 96);
            this.cmbestadoCargo.Name = "cmbestadoCargo";
            this.cmbestadoCargo.Size = new System.Drawing.Size(158, 24);
            this.cmbestadoCargo.TabIndex = 48;
            // 
            // txtpagoxcargo
            // 
            this.txtpagoxcargo.Location = new System.Drawing.Point(19, 156);
            this.txtpagoxcargo.Margin = new System.Windows.Forms.Padding(4);
            this.txtpagoxcargo.MaxLength = 1000;
            this.txtpagoxcargo.Name = "txtpagoxcargo";
            this.txtpagoxcargo.Size = new System.Drawing.Size(160, 22);
            this.txtpagoxcargo.TabIndex = 45;
            this.txtpagoxcargo.Text = "0";
            this.txtpagoxcargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtpagoxcargo_KeyPress);
            // 
            // lblPagoxCargo
            // 
            this.lblPagoxCargo.AutoSize = true;
            this.lblPagoxCargo.Location = new System.Drawing.Point(16, 135);
            this.lblPagoxCargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPagoxCargo.Name = "lblPagoxCargo";
            this.lblPagoxCargo.Size = new System.Drawing.Size(119, 17);
            this.lblPagoxCargo.TabIndex = 44;
            this.lblPagoxCargo.Text = "Salario por Cargo";
            // 
            // cmbgrupoEscala
            // 
            this.cmbgrupoEscala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgrupoEscala.FormattingEnabled = true;
            this.cmbgrupoEscala.Location = new System.Drawing.Point(16, 96);
            this.cmbgrupoEscala.Name = "cmbgrupoEscala";
            this.cmbgrupoEscala.Size = new System.Drawing.Size(158, 24);
            this.cmbgrupoEscala.TabIndex = 43;
            // 
            // lnlGrupoEscala
            // 
            this.lnlGrupoEscala.AutoSize = true;
            this.lnlGrupoEscala.Location = new System.Drawing.Point(13, 76);
            this.lnlGrupoEscala.Name = "lnlGrupoEscala";
            this.lnlGrupoEscala.Size = new System.Drawing.Size(103, 17);
            this.lnlGrupoEscala.TabIndex = 42;
            this.lnlGrupoEscala.Tag = "";
            this.lnlGrupoEscala.Text = "Grupo Escala *";
            // 
            // cmbOcupationCategory
            // 
            this.cmbOcupationCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOcupationCategory.FormattingEnabled = true;
            this.cmbOcupationCategory.Location = new System.Drawing.Point(561, 97);
            this.cmbOcupationCategory.Name = "cmbOcupationCategory";
            this.cmbOcupationCategory.Size = new System.Drawing.Size(158, 24);
            this.cmbOcupationCategory.TabIndex = 41;
            // 
            // lblClasifOcupacional
            // 
            this.lblClasifOcupacional.AutoSize = true;
            this.lblClasifOcupacional.Location = new System.Drawing.Point(559, 76);
            this.lblClasifOcupacional.Name = "lblClasifOcupacional";
            this.lblClasifOcupacional.Size = new System.Drawing.Size(141, 17);
            this.lblClasifOcupacional.TabIndex = 40;
            this.lblClasifOcupacional.Tag = "";
            this.lblClasifOcupacional.Text = "Categ. Ocupacional *";
            // 
            // lblHorasExtraPAgar
            // 
            this.lblHorasExtraPAgar.AutoSize = true;
            this.lblHorasExtraPAgar.Location = new System.Drawing.Point(202, 136);
            this.lblHorasExtraPAgar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHorasExtraPAgar.Name = "lblHorasExtraPAgar";
            this.lblHorasExtraPAgar.Size = new System.Drawing.Size(143, 17);
            this.lblHorasExtraPAgar.TabIndex = 8;
            this.lblHorasExtraPAgar.Text = "Horas Extras a Pagar";
            // 
            // txtHoursExtra
            // 
            this.txtHoursExtra.Location = new System.Drawing.Point(203, 155);
            this.txtHoursExtra.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoursExtra.MaxLength = 50;
            this.txtHoursExtra.Name = "txtHoursExtra";
            this.txtHoursExtra.Size = new System.Drawing.Size(158, 22);
            this.txtHoursExtra.TabIndex = 7;
            this.txtHoursExtra.Text = "0";
            this.txtHoursExtra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHoursExtra_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage2.Controls.Add(this.lblareasSeleccionada);
            this.tabPage2.Controls.Add(this.lblareasDisponibles);
            this.tabPage2.Controls.Add(this.btnDelete);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.lvareasseleccion);
            this.tabPage2.Controls.Add(this.lvareasdisponibles);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(847, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Área ";
            // 
            // lblareasSeleccionada
            // 
            this.lblareasSeleccionada.AutoSize = true;
            this.lblareasSeleccionada.Location = new System.Drawing.Point(475, 14);
            this.lblareasSeleccionada.Name = "lblareasSeleccionada";
            this.lblareasSeleccionada.Size = new System.Drawing.Size(145, 17);
            this.lblareasSeleccionada.TabIndex = 44;
            this.lblareasSeleccionada.Tag = "";
            this.lblareasSeleccionada.Text = "Áreas Seleccionadas ";
            // 
            // lblareasDisponibles
            // 
            this.lblareasDisponibles.AutoSize = true;
            this.lblareasDisponibles.Location = new System.Drawing.Point(21, 15);
            this.lblareasDisponibles.Name = "lblareasDisponibles";
            this.lblareasDisponibles.Size = new System.Drawing.Size(126, 17);
            this.lblareasDisponibles.TabIndex = 43;
            this.lblareasDisponibles.Tag = "";
            this.lblareasDisponibles.Text = "Áreas Disponibles ";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(398, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 33);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "<<";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(398, 173);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 33);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Tag = "";
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click_1);
            // 
            // lvareasseleccion
            // 
            this.lvareasseleccion.HideSelection = false;
            this.lvareasseleccion.Location = new System.Drawing.Point(478, 36);
            this.lvareasseleccion.Name = "lvareasseleccion";
            this.lvareasseleccion.Size = new System.Drawing.Size(346, 352);
            this.lvareasseleccion.TabIndex = 1;
            this.lvareasseleccion.UseCompatibleStateImageBehavior = false;
            this.lvareasseleccion.View = System.Windows.Forms.View.List;
            this.lvareasseleccion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lvareasseleccion_MouseDoubleClick_1);
            // 
            // lvareasdisponibles
            // 
            this.lvareasdisponibles.HideSelection = false;
            this.lvareasdisponibles.Location = new System.Drawing.Point(24, 36);
            this.lvareasdisponibles.Name = "lvareasdisponibles";
            this.lvareasdisponibles.Size = new System.Drawing.Size(353, 352);
            this.lvareasdisponibles.TabIndex = 0;
            this.lvareasdisponibles.UseCompatibleStateImageBehavior = false;
            this.lvareasdisponibles.View = System.Windows.Forms.View.List;
            this.lvareasdisponibles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lvareasdisponibles_MouseDoubleClick_1);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage3.Controls.Add(this.lblCondSelec);
            this.tabPage3.Controls.Add(this.lblCondDispo);
            this.tabPage3.Controls.Add(this.btnDeleteCond);
            this.tabPage3.Controls.Add(this.btnAddCon);
            this.tabPage3.Controls.Add(this.lvcondicionesSelecc);
            this.tabPage3.Controls.Add(this.lvcondDispon);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(847, 403);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cond. Anormales";
            // 
            // lblCondSelec
            // 
            this.lblCondSelec.AutoSize = true;
            this.lblCondSelec.Location = new System.Drawing.Point(487, 15);
            this.lblCondSelec.Name = "lblCondSelec";
            this.lblCondSelec.Size = new System.Drawing.Size(185, 17);
            this.lblCondSelec.TabIndex = 46;
            this.lblCondSelec.Tag = "";
            this.lblCondSelec.Text = "Condiciones Seleccionadas ";
            // 
            // lblCondDispo
            // 
            this.lblCondDispo.AutoSize = true;
            this.lblCondDispo.Location = new System.Drawing.Point(20, 17);
            this.lblCondDispo.Name = "lblCondDispo";
            this.lblCondDispo.Size = new System.Drawing.Size(162, 17);
            this.lblCondDispo.TabIndex = 45;
            this.lblCondDispo.Tag = "";
            this.lblCondDispo.Text = "Condiciones Disponibles";
            // 
            // btnDeleteCond
            // 
            this.btnDeleteCond.Location = new System.Drawing.Point(405, 210);
            this.btnDeleteCond.Name = "btnDeleteCond";
            this.btnDeleteCond.Size = new System.Drawing.Size(58, 30);
            this.btnDeleteCond.TabIndex = 7;
            this.btnDeleteCond.Text = "<<";
            this.btnDeleteCond.UseVisualStyleBackColor = true;
            this.btnDeleteCond.Click += new System.EventHandler(this.BtnDeleteCond_Click_1);
            // 
            // btnAddCon
            // 
            this.btnAddCon.Location = new System.Drawing.Point(405, 171);
            this.btnAddCon.Name = "btnAddCon";
            this.btnAddCon.Size = new System.Drawing.Size(58, 33);
            this.btnAddCon.TabIndex = 6;
            this.btnAddCon.Tag = "";
            this.btnAddCon.Text = ">>";
            this.btnAddCon.UseVisualStyleBackColor = true;
            this.btnAddCon.Click += new System.EventHandler(this.BtnAddCon_Click);
            // 
            // lvcondicionesSelecc
            // 
            this.lvcondicionesSelecc.HideSelection = false;
            this.lvcondicionesSelecc.Location = new System.Drawing.Point(491, 36);
            this.lvcondicionesSelecc.Name = "lvcondicionesSelecc";
            this.lvcondicionesSelecc.Size = new System.Drawing.Size(334, 345);
            this.lvcondicionesSelecc.TabIndex = 5;
            this.lvcondicionesSelecc.UseCompatibleStateImageBehavior = false;
            this.lvcondicionesSelecc.View = System.Windows.Forms.View.List;
            this.lvcondicionesSelecc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvcondicionesSelecc_MouseDoubleClick);
            // 
            // lvcondDispon
            // 
            this.lvcondDispon.HideSelection = false;
            this.lvcondDispon.Location = new System.Drawing.Point(23, 38);
            this.lvcondDispon.Name = "lvcondDispon";
            this.lvcondDispon.Size = new System.Drawing.Size(350, 345);
            this.lvcondDispon.TabIndex = 4;
            this.lvcondDispon.UseCompatibleStateImageBehavior = false;
            this.lvcondDispon.View = System.Windows.Forms.View.List;
            this.lvcondDispon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvcondDispon_MouseDoubleClick);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.txtFuncionesRespons);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(847, 403);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Funciones y Resposabilidades";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 17);
            this.label3.TabIndex = 59;
            this.label3.Tag = "";
            this.label3.Text = "Funciones y Responsabilidades";
            // 
            // txtFuncionesRespons
            // 
            this.txtFuncionesRespons.Location = new System.Drawing.Point(14, 37);
            this.txtFuncionesRespons.Margin = new System.Windows.Forms.Padding(4);
            this.txtFuncionesRespons.MaxLength = 8000;
            this.txtFuncionesRespons.Multiline = true;
            this.txtFuncionesRespons.Name = "txtFuncionesRespons";
            this.txtFuncionesRespons.Size = new System.Drawing.Size(817, 345);
            this.txtFuncionesRespons.TabIndex = 58;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage4.Controls.Add(this.lvcompetencias);
            this.tabPage4.Controls.Add(this.btnBuscarCompet);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(847, 403);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Competencias";
            // 
            // lvcompetencias
            // 
            this.lvcompetencias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader9});
            this.lvcompetencias.GridLines = true;
            this.lvcompetencias.HideSelection = false;
            this.lvcompetencias.Location = new System.Drawing.Point(13, 15);
            this.lvcompetencias.Name = "lvcompetencias";
            this.lvcompetencias.Size = new System.Drawing.Size(816, 337);
            this.lvcompetencias.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvcompetencias.TabIndex = 54;
            this.lvcompetencias.UseCompatibleStateImageBehavior = false;
            this.lvcompetencias.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Competencia";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripción";
            this.columnHeader2.Width = 135;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Requerido";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nivel";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tipo de Competencia";
            this.columnHeader9.Width = 160;
            // 
            // btnBuscarCompet
            // 
            this.btnBuscarCompet.Location = new System.Drawing.Point(659, 358);
            this.btnBuscarCompet.Name = "btnBuscarCompet";
            this.btnBuscarCompet.Size = new System.Drawing.Size(170, 33);
            this.btnBuscarCompet.TabIndex = 53;
            this.btnBuscarCompet.Text = "Asociar Competencias";
            this.btnBuscarCompet.UseVisualStyleBackColor = true;
            this.btnBuscarCompet.Click += new System.EventHandler(this.BtnBuscarCompet_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage6.Controls.Add(this.datagridviewCond);
            this.tabPage6.Controls.Add(this.label1);
            this.tabPage6.Controls.Add(this.cmbTipoCondicion);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(847, 403);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Cond. Laborales";
            // 
            // datagridviewCond
            // 
            this.datagridviewCond.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewCond.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelecc,
            this.ColCondicionLaboral,
            this.ColDescripcion});
            this.datagridviewCond.Location = new System.Drawing.Point(11, 77);
            this.datagridviewCond.Name = "datagridviewCond";
            this.datagridviewCond.RowHeadersWidth = 51;
            this.datagridviewCond.RowTemplate.Height = 24;
            this.datagridviewCond.Size = new System.Drawing.Size(821, 305);
            this.datagridviewCond.TabIndex = 62;
            this.datagridviewCond.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagridviewCond_CellContentClick);
            this.datagridviewCond.CurrentCellDirtyStateChanged += new System.EventHandler(this.DatagridviewCond_CurrentCellDirtyStateChanged);
            // 
            // ColSelecc
            // 
            this.ColSelecc.HeaderText = "Seleccc";
            this.ColSelecc.MinimumWidth = 6;
            this.ColSelecc.Name = "ColSelecc";
            this.ColSelecc.Width = 60;
            // 
            // ColCondicionLaboral
            // 
            this.ColCondicionLaboral.HeaderText = "Condición Laboral";
            this.ColCondicionLaboral.MinimumWidth = 6;
            this.ColCondicionLaboral.Name = "ColCondicionLaboral";
            this.ColCondicionLaboral.Width = 250;
            // 
            // ColDescripcion
            // 
            this.ColDescripcion.HeaderText = "Descripción";
            this.ColDescripcion.MinimumWidth = 6;
            this.ColDescripcion.Name = "ColDescripcion";
            this.ColDescripcion.Width = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 61;
            this.label1.Tag = "";
            this.label1.Text = "Tipo de Condición";
            // 
            // cmbTipoCondicion
            // 
            this.cmbTipoCondicion.FormattingEnabled = true;
            this.cmbTipoCondicion.Location = new System.Drawing.Point(12, 37);
            this.cmbTipoCondicion.Name = "cmbTipoCondicion";
            this.cmbTipoCondicion.Size = new System.Drawing.Size(169, 24);
            this.cmbTipoCondicion.TabIndex = 60;
            this.cmbTipoCondicion.SelectedIndexChanged += new System.EventHandler(this.CmbTipoCondicion_SelectedIndexChanged);
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage7.Controls.Add(this.btnAsociarRiesgos);
            this.tabPage7.Controls.Add(this.lvRiesgos);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(847, 403);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Riesgos";
            // 
            // btnAsociarRiesgos
            // 
            this.btnAsociarRiesgos.Location = new System.Drawing.Point(662, 363);
            this.btnAsociarRiesgos.Name = "btnAsociarRiesgos";
            this.btnAsociarRiesgos.Size = new System.Drawing.Size(170, 33);
            this.btnAsociarRiesgos.TabIndex = 56;
            this.btnAsociarRiesgos.Text = "Asociar Riesgos";
            this.btnAsociarRiesgos.UseVisualStyleBackColor = true;
            this.btnAsociarRiesgos.Click += new System.EventHandler(this.BtnAsociarRiesgos_Click);
            // 
            // lvRiesgos
            // 
            this.lvRiesgos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader7});
            this.lvRiesgos.GridLines = true;
            this.lvRiesgos.HideSelection = false;
            this.lvRiesgos.Location = new System.Drawing.Point(15, 14);
            this.lvRiesgos.Name = "lvRiesgos";
            this.lvRiesgos.Size = new System.Drawing.Size(816, 344);
            this.lvRiesgos.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvRiesgos.TabIndex = 55;
            this.lvRiesgos.UseCompatibleStateImageBehavior = false;
            this.lvRiesgos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Riesgo";
            this.columnHeader5.Width = 170;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Descripción";
            this.columnHeader6.Width = 240;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nivel";
            this.columnHeader8.Width = 160;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tipo de Riesgo";
            this.columnHeader7.Width = 160;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(13, 41);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(52, 17);
            this.lblCargo.TabIndex = 13;
            this.lblCargo.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(13, 61);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.MaxLength = 30;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(156, 22);
            this.txtCodigo.TabIndex = 12;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            // 
            // frmCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 593);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.strBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmCargo";
            this.Text = "Gestión a Cargo";
            this.Shown += new System.EventHandler(this.Form_Show);
            this.grbCategoriaOcup.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewCond)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.StatusBar strBar;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblHorasExtraPAgar;
        private System.Windows.Forms.TextBox txtHoursExtra;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cmbgrupoEscala;
        private System.Windows.Forms.Label lnlGrupoEscala;
        private System.Windows.Forms.ComboBox cmbOcupationCategory;
        private System.Windows.Forms.Label lblClasifOcupacional;
        private System.Windows.Forms.TextBox txtpagoxcargo;
        private System.Windows.Forms.Label lblPagoxCargo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvareasseleccion;
        private System.Windows.Forms.ListView lvareasdisponibles;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.Label lblareasSeleccionada;
        private System.Windows.Forms.Label lblareasDisponibles;
        private System.Windows.Forms.Label lblCondSelec;
        private System.Windows.Forms.Label lblCondDispo;
        private System.Windows.Forms.Button btnDeleteCond;
        private System.Windows.Forms.Button btnAddCon;
        private System.Windows.Forms.ListView lvcondicionesSelecc;
        private System.Windows.Forms.ListView lvcondDispon;
        private System.Windows.Forms.TextBox txtdescrip;
        private System.Windows.Forms.Label ldlDesc;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DateTimePicker dtpfechaCreacionCargo;
        private System.Windows.Forms.Label lblfechaCreac;
        private System.Windows.Forms.Label lblestadoCargo;
        private System.Windows.Forms.ComboBox cmbestadoCargo;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtMision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFuncionesRespons;
        private System.Windows.Forms.Button btnBuscarCompet;
        private System.Windows.Forms.ListView lvcompetencias;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoCondicion;
        private System.Windows.Forms.DataGridView datagridviewCond;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelecc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCondicionLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
        private System.Windows.Forms.Button btnAsociarRiesgos;
        private System.Windows.Forms.ListView lvRiesgos;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ComboBox cmbClasifTrabajdor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}

