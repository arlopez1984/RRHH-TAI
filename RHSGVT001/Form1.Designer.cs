namespace RHSGVT001
{
    partial class frmVacaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVacaciones));
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.grbSeleccionarTRabajador = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUnidadesOrganizativas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbTrabajadores = new System.Windows.Forms.GroupBox();
            this.lbldatosPersona = new System.Windows.Forms.Label();
            this.lblPeriodoActivo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbDatosvac = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpfechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpfechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdicionrVacaciones = new System.Windows.Forms.Button();
            this.grbDatosVacaciones = new System.Windows.Forms.GroupBox();
            this.lvVacaciones = new System.Windows.Forms.ListView();
            this.ColCondicion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCantidadHoras = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColHorasDisfrutadas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblVacacionesAcum = new System.Windows.Forms.Label();
            this.txtaumuladoVacaciones = new System.Windows.Forms.TextBox();
            this.grbSeleccionarTRabajador.SuspendLayout();
            this.grbTrabajadores.SuspendLayout();
            this.grbDatosvac.SuspendLayout();
            this.grbDatosVacaciones.SuspendLayout();
            this.SuspendLayout();
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
            this.menuBar1.Size = new System.Drawing.Size(760, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 0;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            // 
            // strbar
            // 
            this.strbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strbar.Location = new System.Drawing.Point(0, 507);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(760, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 1;
            // 
            // grbSeleccionarTRabajador
            // 
            this.grbSeleccionarTRabajador.Controls.Add(this.btnBuscar);
            this.grbSeleccionarTRabajador.Controls.Add(this.txtCi);
            this.grbSeleccionarTRabajador.Controls.Add(this.label2);
            this.grbSeleccionarTRabajador.Controls.Add(this.cmbUnidadesOrganizativas);
            this.grbSeleccionarTRabajador.Controls.Add(this.label1);
            this.grbSeleccionarTRabajador.Location = new System.Drawing.Point(15, 40);
            this.grbSeleccionarTRabajador.Name = "grbSeleccionarTRabajador";
            this.grbSeleccionarTRabajador.Size = new System.Drawing.Size(729, 68);
            this.grbSeleccionarTRabajador.TabIndex = 20;
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
            this.txtCi.MaxLength = 50;
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
            this.grbTrabajadores.Location = new System.Drawing.Point(16, 111);
            this.grbTrabajadores.Name = "grbTrabajadores";
            this.grbTrabajadores.Size = new System.Drawing.Size(729, 61);
            this.grbTrabajadores.TabIndex = 21;
            this.grbTrabajadores.TabStop = false;
            this.grbTrabajadores.Text = "Trabajador";
            // 
            // lbldatosPersona
            // 
            this.lbldatosPersona.AutoSize = true;
            this.lbldatosPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatosPersona.Location = new System.Drawing.Point(24, 25);
            this.lbldatosPersona.Name = "lbldatosPersona";
            this.lbldatosPersona.Size = new System.Drawing.Size(0, 20);
            this.lbldatosPersona.TabIndex = 81;
            // 
            // lblPeriodoActivo
            // 
            this.lblPeriodoActivo.AutoSize = true;
            this.lblPeriodoActivo.Location = new System.Drawing.Point(150, 185);
            this.lblPeriodoActivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodoActivo.Name = "lblPeriodoActivo";
            this.lblPeriodoActivo.Size = new System.Drawing.Size(0, 17);
            this.lblPeriodoActivo.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 184);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 96;
            this.label5.Text = "Período Activo:";
            // 
            // grbDatosvac
            // 
            this.grbDatosvac.Controls.Add(this.label3);
            this.grbDatosvac.Controls.Add(this.dtpfechaFin);
            this.grbDatosvac.Controls.Add(this.dtpfechaInicio);
            this.grbDatosvac.Controls.Add(this.label4);
            this.grbDatosvac.Controls.Add(this.btnAdicionrVacaciones);
            this.grbDatosvac.Location = new System.Drawing.Point(14, 218);
            this.grbDatosvac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDatosvac.Name = "grbDatosvac";
            this.grbDatosvac.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDatosvac.Size = new System.Drawing.Size(730, 92);
            this.grbDatosvac.TabIndex = 102;
            this.grbDatosvac.TabStop = false;
            this.grbDatosvac.Text = "Datos Vacaciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Fecha Inicio *";
            // 
            // dtpfechaFin
            // 
            this.dtpfechaFin.CustomFormat = "MM/dd/yyyy HH:mm";
            this.dtpfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfechaFin.Location = new System.Drawing.Point(218, 52);
            this.dtpfechaFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfechaFin.Name = "dtpfechaFin";
            this.dtpfechaFin.Size = new System.Drawing.Size(190, 22);
            this.dtpfechaFin.TabIndex = 18;
            // 
            // dtpfechaInicio
            // 
            this.dtpfechaInicio.CustomFormat = "MM/dd/yyyy HH:mm";
            this.dtpfechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfechaInicio.Location = new System.Drawing.Point(14, 52);
            this.dtpfechaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfechaInicio.Name = "dtpfechaInicio";
            this.dtpfechaInicio.Size = new System.Drawing.Size(190, 22);
            this.dtpfechaInicio.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Fecha Fin *";
            // 
            // btnAdicionrVacaciones
            // 
            this.btnAdicionrVacaciones.Location = new System.Drawing.Point(418, 47);
            this.btnAdicionrVacaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionrVacaciones.Name = "btnAdicionrVacaciones";
            this.btnAdicionrVacaciones.Size = new System.Drawing.Size(81, 30);
            this.btnAdicionrVacaciones.TabIndex = 92;
            this.btnAdicionrVacaciones.Text = "Adicionar";
            this.btnAdicionrVacaciones.UseVisualStyleBackColor = true;
            this.btnAdicionrVacaciones.Click += new System.EventHandler(this.BtnAdicionrVacaciones_Click);
            // 
            // grbDatosVacaciones
            // 
            this.grbDatosVacaciones.Controls.Add(this.lvVacaciones);
            this.grbDatosVacaciones.Location = new System.Drawing.Point(16, 316);
            this.grbDatosVacaciones.Name = "grbDatosVacaciones";
            this.grbDatosVacaciones.Size = new System.Drawing.Size(728, 187);
            this.grbDatosVacaciones.TabIndex = 103;
            this.grbDatosVacaciones.TabStop = false;
            this.grbDatosVacaciones.Text = "Vacaciones";
            // 
            // lvVacaciones
            // 
            this.lvVacaciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCondicion,
            this.ColCantidadHoras,
            this.ColHorasDisfrutadas});
            this.lvVacaciones.FullRowSelect = true;
            this.lvVacaciones.GridLines = true;
            this.lvVacaciones.HideSelection = false;
            this.lvVacaciones.Location = new System.Drawing.Point(5, 21);
            this.lvVacaciones.Name = "lvVacaciones";
            this.lvVacaciones.Size = new System.Drawing.Size(710, 145);
            this.lvVacaciones.TabIndex = 0;
            this.lvVacaciones.UseCompatibleStateImageBehavior = false;
            this.lvVacaciones.View = System.Windows.Forms.View.Details;
            // 
            // ColCondicion
            // 
            this.ColCondicion.Text = "Fecha Inicio";
            this.ColCondicion.Width = 150;
            // 
            // ColCantidadHoras
            // 
            this.ColCantidadHoras.Text = "Fecha Fin";
            this.ColCantidadHoras.Width = 150;
            // 
            // ColHorasDisfrutadas
            // 
            this.ColHorasDisfrutadas.Text = "Horas disfrutadas";
            this.ColHorasDisfrutadas.Width = 227;
            // 
            // lblVacacionesAcum
            // 
            this.lblVacacionesAcum.AutoSize = true;
            this.lblVacacionesAcum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVacacionesAcum.Location = new System.Drawing.Point(437, 185);
            this.lblVacacionesAcum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVacacionesAcum.Name = "lblVacacionesAcum";
            this.lblVacacionesAcum.Size = new System.Drawing.Size(180, 17);
            this.lblVacacionesAcum.TabIndex = 104;
            this.lblVacacionesAcum.Text = "Acumulado Vacaciones:";
            // 
            // txtaumuladoVacaciones
            // 
            this.txtaumuladoVacaciones.Location = new System.Drawing.Point(625, 182);
            this.txtaumuladoVacaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtaumuladoVacaciones.MaxLength = 50;
            this.txtaumuladoVacaciones.Name = "txtaumuladoVacaciones";
            this.txtaumuladoVacaciones.Size = new System.Drawing.Size(83, 22);
            this.txtaumuladoVacaciones.TabIndex = 105;
            // 
            // frmVacaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 545);
            this.Controls.Add(this.txtaumuladoVacaciones);
            this.Controls.Add(this.lblVacacionesAcum);
            this.Controls.Add(this.grbDatosVacaciones);
            this.Controls.Add(this.grbDatosvac);
            this.Controls.Add(this.lblPeriodoActivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grbTrabajadores);
            this.Controls.Add(this.grbSeleccionarTRabajador);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmVacaciones";
            this.Text = "Gestión Vacaciones";
            this.grbSeleccionarTRabajador.ResumeLayout(false);
            this.grbSeleccionarTRabajador.PerformLayout();
            this.grbTrabajadores.ResumeLayout(false);
            this.grbTrabajadores.PerformLayout();
            this.grbDatosvac.ResumeLayout(false);
            this.grbDatosvac.PerformLayout();
            this.grbDatosVacaciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar strbar;
        private System.Windows.Forms.GroupBox grbSeleccionarTRabajador;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUnidadesOrganizativas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbTrabajadores;
        private System.Windows.Forms.Label lbldatosPersona;
        private System.Windows.Forms.Label lblPeriodoActivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbDatosvac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpfechaFin;
        private System.Windows.Forms.DateTimePicker dtpfechaInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdicionrVacaciones;
        private System.Windows.Forms.GroupBox grbDatosVacaciones;
        private System.Windows.Forms.ListView lvVacaciones;
        private System.Windows.Forms.ColumnHeader ColCondicion;
        private System.Windows.Forms.ColumnHeader ColCantidadHoras;
        private System.Windows.Forms.ColumnHeader ColHorasDisfrutadas;
        private System.Windows.Forms.Label lblVacacionesAcum;
        private System.Windows.Forms.TextBox txtaumuladoVacaciones;
    }
}

