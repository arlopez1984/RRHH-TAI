namespace RHSST001
{
    partial class frmIncidenciasTrabajador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIncidenciasTrabajador));
            this.starBar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.grbSeleccionarTRabajador = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUnidadesOrganizativas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbTrabajadores = new System.Windows.Forms.GroupBox();
            this.lbldatosPersona = new System.Windows.Forms.Label();
            this.btnAusencia = new System.Windows.Forms.Button();
            this.btnOtrasIncidencias = new System.Windows.Forms.Button();
            this.btnLicencia = new System.Windows.Forms.Button();
            this.btnSubsidios = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvResumenLicencias = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvResumenOtrasIncidencias = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.lvResumenSubsidios = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lvResumenAusencias = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblPeriodoActivo = new System.Windows.Forms.Label();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbSeleccionarTRabajador.SuspendLayout();
            this.grbTrabajadores.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // starBar
            // 
            this.starBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.starBar.Location = new System.Drawing.Point(0, 700);
            this.starBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.starBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.starBar.Name = "starBar";
            this.starBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.starBar.Size = new System.Drawing.Size(957, 38);
            this.starBar.SysSession = this.sageSession1;
            this.starBar.TabIndex = 0;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(957, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            // 
            // grbSeleccionarTRabajador
            // 
            this.grbSeleccionarTRabajador.Controls.Add(this.btnBuscar);
            this.grbSeleccionarTRabajador.Controls.Add(this.txtCi);
            this.grbSeleccionarTRabajador.Controls.Add(this.label2);
            this.grbSeleccionarTRabajador.Controls.Add(this.cmbUnidadesOrganizativas);
            this.grbSeleccionarTRabajador.Controls.Add(this.label1);
            this.grbSeleccionarTRabajador.Location = new System.Drawing.Point(12, 42);
            this.grbSeleccionarTRabajador.Name = "grbSeleccionarTRabajador";
            this.grbSeleccionarTRabajador.Size = new System.Drawing.Size(933, 68);
            this.grbSeleccionarTRabajador.TabIndex = 18;
            this.grbSeleccionarTRabajador.TabStop = false;
            this.grbSeleccionarTRabajador.Text = "Seleccionar Trabajador";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(623, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 29);
            this.btnBuscar.TabIndex = 94;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // txtCi
            // 
            this.txtCi.Location = new System.Drawing.Point(415, 33);
            this.txtCi.Margin = new System.Windows.Forms.Padding(4);
            this.txtCi.MaxLength = 11;
            this.txtCi.Name = "txtCi";
            this.txtCi.Size = new System.Drawing.Size(195, 22);
            this.txtCi.TabIndex = 80;
            this.txtCi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCi_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 92;
            this.label2.Text = "Unidad organizativa";
            // 
            // cmbUnidadesOrganizativas
            // 
            this.cmbUnidadesOrganizativas.FormattingEnabled = true;
            this.cmbUnidadesOrganizativas.Location = new System.Drawing.Point(162, 33);
            this.cmbUnidadesOrganizativas.Name = "cmbUnidadesOrganizativas";
            this.cmbUnidadesOrganizativas.Size = new System.Drawing.Size(195, 24);
            this.cmbUnidadesOrganizativas.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 79;
            this.label1.Text = "CI";
            // 
            // grbTrabajadores
            // 
            this.grbTrabajadores.Controls.Add(this.lbldatosPersona);
            this.grbTrabajadores.Location = new System.Drawing.Point(12, 113);
            this.grbTrabajadores.Name = "grbTrabajadores";
            this.grbTrabajadores.Size = new System.Drawing.Size(933, 71);
            this.grbTrabajadores.TabIndex = 19;
            this.grbTrabajadores.TabStop = false;
            this.grbTrabajadores.Text = "Trabajador";
            // 
            // lbldatosPersona
            // 
            this.lbldatosPersona.AutoSize = true;
            this.lbldatosPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatosPersona.Location = new System.Drawing.Point(24, 33);
            this.lbldatosPersona.Name = "lbldatosPersona";
            this.lbldatosPersona.Size = new System.Drawing.Size(0, 20);
            this.lbldatosPersona.TabIndex = 81;
            // 
            // btnAusencia
            // 
            this.btnAusencia.Location = new System.Drawing.Point(833, 40);
            this.btnAusencia.Name = "btnAusencia";
            this.btnAusencia.Size = new System.Drawing.Size(93, 29);
            this.btnAusencia.TabIndex = 96;
            this.btnAusencia.Text = "Ausencias";
            this.btnAusencia.UseVisualStyleBackColor = true;
            this.btnAusencia.Click += new System.EventHandler(this.BtnAusencia_Click);
            // 
            // btnOtrasIncidencias
            // 
            this.btnOtrasIncidencias.Location = new System.Drawing.Point(833, 172);
            this.btnOtrasIncidencias.Name = "btnOtrasIncidencias";
            this.btnOtrasIncidencias.Size = new System.Drawing.Size(93, 59);
            this.btnOtrasIncidencias.TabIndex = 95;
            this.btnOtrasIncidencias.Text = "Otras Incidencias";
            this.btnOtrasIncidencias.UseVisualStyleBackColor = true;
            this.btnOtrasIncidencias.Click += new System.EventHandler(this.BtnOtrasIncidencias_Click);
            // 
            // btnLicencia
            // 
            this.btnLicencia.Location = new System.Drawing.Point(833, 84);
            this.btnLicencia.Name = "btnLicencia";
            this.btnLicencia.Size = new System.Drawing.Size(93, 29);
            this.btnLicencia.TabIndex = 94;
            this.btnLicencia.Text = "Licencias";
            this.btnLicencia.UseVisualStyleBackColor = true;
            this.btnLicencia.Click += new System.EventHandler(this.BtnLicencia_Click);
            // 
            // btnSubsidios
            // 
            this.btnSubsidios.Location = new System.Drawing.Point(833, 130);
            this.btnSubsidios.Name = "btnSubsidios";
            this.btnSubsidios.Size = new System.Drawing.Size(93, 29);
            this.btnSubsidios.TabIndex = 93;
            this.btnSubsidios.Text = "Subsidios";
            this.btnSubsidios.UseVisualStyleBackColor = true;
            this.btnSubsidios.Click += new System.EventHandler(this.BtnSubsidios_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvResumenLicencias);
            this.groupBox1.Controls.Add(this.btnOtrasIncidencias);
            this.groupBox1.Controls.Add(this.btnSubsidios);
            this.groupBox1.Controls.Add(this.lvResumenOtrasIncidencias);
            this.groupBox1.Controls.Add(this.btnAusencia);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lvResumenSubsidios);
            this.groupBox1.Controls.Add(this.btnLicencia);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lvResumenAusencias);
            this.groupBox1.Location = new System.Drawing.Point(11, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(935, 458);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // lvResumenLicencias
            // 
            this.lvResumenLicencias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader13,
            this.columnHeader16});
            this.lvResumenLicencias.FullRowSelect = true;
            this.lvResumenLicencias.GridLines = true;
            this.lvResumenLicencias.HideSelection = false;
            this.lvResumenLicencias.Location = new System.Drawing.Point(427, 40);
            this.lvResumenLicencias.Name = "lvResumenLicencias";
            this.lvResumenLicencias.Size = new System.Drawing.Size(400, 191);
            this.lvResumenLicencias.TabIndex = 87;
            this.lvResumenLicencias.UseCompatibleStateImageBehavior = false;
            this.lvResumenLicencias.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tipo de Licencia";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Fecha Inicio";
            this.columnHeader8.Width = 85;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Fecha Fin";
            this.columnHeader13.Width = 80;
            // 
            // lvResumenOtrasIncidencias
            // 
            this.lvResumenOtrasIncidencias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader14,
            this.columnHeader18});
            this.lvResumenOtrasIncidencias.FullRowSelect = true;
            this.lvResumenOtrasIncidencias.GridLines = true;
            this.lvResumenOtrasIncidencias.HideSelection = false;
            this.lvResumenOtrasIncidencias.Location = new System.Drawing.Point(428, 257);
            this.lvResumenOtrasIncidencias.Name = "lvResumenOtrasIncidencias";
            this.lvResumenOtrasIncidencias.Size = new System.Drawing.Size(400, 191);
            this.lvResumenOtrasIncidencias.TabIndex = 85;
            this.lvResumenOtrasIncidencias.UseCompatibleStateImageBehavior = false;
            this.lvResumenOtrasIncidencias.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tipo Otra Incidencia";
            this.columnHeader5.Width = 134;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Fecha Inicio";
            this.columnHeader6.Width = 86;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Fech Fin";
            this.columnHeader14.Width = 69;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(425, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 88;
            this.label10.Text = "Licencias";
            // 
            // lvResumenSubsidios
            // 
            this.lvResumenSubsidios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader17});
            this.lvResumenSubsidios.FullRowSelect = true;
            this.lvResumenSubsidios.GridLines = true;
            this.lvResumenSubsidios.HideSelection = false;
            this.lvResumenSubsidios.Location = new System.Drawing.Point(13, 257);
            this.lvResumenSubsidios.Name = "lvResumenSubsidios";
            this.lvResumenSubsidios.Size = new System.Drawing.Size(400, 191);
            this.lvResumenSubsidios.TabIndex = 83;
            this.lvResumenSubsidios.UseCompatibleStateImageBehavior = false;
            this.lvResumenSubsidios.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tipo Subsidio";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fecha Inicio";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Fecha Fin";
            this.columnHeader4.Width = 102;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Subsidio Inicio";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Hospitalizado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(425, 234);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 17);
            this.label9.TabIndex = 86;
            this.label9.Text = "Otras Incidencias";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 234);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 84;
            this.label8.Text = "Subsidios";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 82;
            this.label7.Text = "Ausencias";
            // 
            // lvResumenAusencias
            // 
            this.lvResumenAusencias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader15});
            this.lvResumenAusencias.FullRowSelect = true;
            this.lvResumenAusencias.GridLines = true;
            this.lvResumenAusencias.HideSelection = false;
            this.lvResumenAusencias.Location = new System.Drawing.Point(13, 38);
            this.lvResumenAusencias.Name = "lvResumenAusencias";
            this.lvResumenAusencias.Size = new System.Drawing.Size(400, 191);
            this.lvResumenAusencias.TabIndex = 80;
            this.lvResumenAusencias.UseCompatibleStateImageBehavior = false;
            this.lvResumenAusencias.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tipo Ausencia";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fecha Inicio";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fecha Fin";
            this.columnHeader2.Width = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 95;
            this.label5.Text = "Período Activo:";
            // 
            // lblPeriodoActivo
            // 
            this.lblPeriodoActivo.AutoSize = true;
            this.lblPeriodoActivo.Location = new System.Drawing.Point(139, 200);
            this.lblPeriodoActivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodoActivo.Name = "lblPeriodoActivo";
            this.lblPeriodoActivo.Size = new System.Drawing.Size(0, 17);
            this.lblPeriodoActivo.TabIndex = 96;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Horas";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Días";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Días";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Días";
            // 
            // frmIncidenciasTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 738);
            this.Controls.Add(this.lblPeriodoActivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbTrabajadores);
            this.Controls.Add(this.grbSeleccionarTRabajador);
            this.Controls.Add(this.starBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmIncidenciasTrabajador";
            this.Text = "Gestionar Incidencias por Trabajador";
            this.grbSeleccionarTRabajador.ResumeLayout(false);
            this.grbSeleccionarTRabajador.PerformLayout();
            this.grbTrabajadores.ResumeLayout(false);
            this.grbTrabajadores.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar starBar;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.GroupBox grbSeleccionarTRabajador;
        private System.Windows.Forms.GroupBox grbTrabajadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.Button btnOtrasIncidencias;
        private System.Windows.Forms.Button btnLicencia;
        private System.Windows.Forms.Button btnSubsidios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvResumenLicencias;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView lvResumenOtrasIncidencias;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvResumenSubsidios;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvResumenAusencias;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUnidadesOrganizativas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAusencia;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbldatosPersona;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPeriodoActivo;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader15;
    }
}

