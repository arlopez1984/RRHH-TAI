namespace RHSGDT001
{
    partial class frmGestionDeducciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionDeducciones));
            this.starbar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.lblPeriodoActivo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbTrabajadores = new System.Windows.Forms.GroupBox();
            this.lbldatosPersona = new System.Windows.Forms.Label();
            this.grbSeleccionarTRabajador = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUnidadesOrganizativas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbDatosJornalero = new System.Windows.Forms.GroupBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpfechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbdeduccion = new System.Windows.Forms.ComboBox();
            this.txtSaldoTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCuotaMensual = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lvDeducciones = new System.Windows.Forms.ListView();
            this.ColDeduccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColFechaInicio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSaldoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCuotaMensual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSaldoPendiente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbTrabajadores.SuspendLayout();
            this.grbSeleccionarTRabajador.SuspendLayout();
            this.grbDatosJornalero.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // starbar
            // 
            this.starbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.starbar.Location = new System.Drawing.Point(0, 586);
            this.starbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.starbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.starbar.Name = "starbar";
            this.starbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.starbar.Size = new System.Drawing.Size(756, 38);
            this.starbar.SysSession = this.sageSession1;
            this.starbar.TabIndex = 0;
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
            this.menuBar1.Size = new System.Drawing.Size(756, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            // 
            // lblPeriodoActivo
            // 
            this.lblPeriodoActivo.AutoSize = true;
            this.lblPeriodoActivo.Location = new System.Drawing.Point(149, 191);
            this.lblPeriodoActivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodoActivo.Name = "lblPeriodoActivo";
            this.lblPeriodoActivo.Size = new System.Drawing.Size(0, 17);
            this.lblPeriodoActivo.TabIndex = 109;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 190);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 108;
            this.label5.Text = "Período Activo:";
            // 
            // grbTrabajadores
            // 
            this.grbTrabajadores.Controls.Add(this.lbldatosPersona);
            this.grbTrabajadores.Location = new System.Drawing.Point(15, 117);
            this.grbTrabajadores.Name = "grbTrabajadores";
            this.grbTrabajadores.Size = new System.Drawing.Size(729, 61);
            this.grbTrabajadores.TabIndex = 107;
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
            // grbSeleccionarTRabajador
            // 
            this.grbSeleccionarTRabajador.Controls.Add(this.btnBuscar);
            this.grbSeleccionarTRabajador.Controls.Add(this.txtCi);
            this.grbSeleccionarTRabajador.Controls.Add(this.label2);
            this.grbSeleccionarTRabajador.Controls.Add(this.cmbUnidadesOrganizativas);
            this.grbSeleccionarTRabajador.Controls.Add(this.label1);
            this.grbSeleccionarTRabajador.Location = new System.Drawing.Point(14, 46);
            this.grbSeleccionarTRabajador.Name = "grbSeleccionarTRabajador";
            this.grbSeleccionarTRabajador.Size = new System.Drawing.Size(729, 68);
            this.grbSeleccionarTRabajador.TabIndex = 106;
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
            // grbDatosJornalero
            // 
            this.grbDatosJornalero.Controls.Add(this.btnAdicionar);
            this.grbDatosJornalero.Controls.Add(this.label4);
            this.grbDatosJornalero.Controls.Add(this.dtpfechaInicio);
            this.grbDatosJornalero.Controls.Add(this.label3);
            this.grbDatosJornalero.Controls.Add(this.cmbdeduccion);
            this.grbDatosJornalero.Controls.Add(this.txtSaldoTotal);
            this.grbDatosJornalero.Controls.Add(this.label8);
            this.grbDatosJornalero.Controls.Add(this.label11);
            this.grbDatosJornalero.Controls.Add(this.txtCuotaMensual);
            this.grbDatosJornalero.Controls.Add(this.label12);
            this.grbDatosJornalero.Location = new System.Drawing.Point(17, 232);
            this.grbDatosJornalero.Name = "grbDatosJornalero";
            this.grbDatosJornalero.Size = new System.Drawing.Size(726, 118);
            this.grbDatosJornalero.TabIndex = 110;
            this.grbDatosJornalero.TabStop = false;
            this.grbDatosJornalero.Text = "Datos Deducción";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(616, 83);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(90, 29);
            this.btnAdicionar.TabIndex = 108;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 105;
            this.label4.Text = "Fecha Inicio";
            // 
            // dtpfechaInicio
            // 
            this.dtpfechaInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpfechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfechaInicio.Location = new System.Drawing.Point(280, 51);
            this.dtpfechaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfechaInicio.Name = "dtpfechaInicio";
            this.dtpfechaInicio.Size = new System.Drawing.Size(193, 22);
            this.dtpfechaInicio.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 103;
            this.label3.Text = "Deducción";
            // 
            // cmbdeduccion
            // 
            this.cmbdeduccion.FormattingEnabled = true;
            this.cmbdeduccion.Location = new System.Drawing.Point(11, 51);
            this.cmbdeduccion.Name = "cmbdeduccion";
            this.cmbdeduccion.Size = new System.Drawing.Size(263, 24);
            this.cmbdeduccion.TabIndex = 102;
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.Location = new System.Drawing.Point(486, 51);
            this.txtSaldoTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSaldoTotal.MaxLength = 50;
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.Size = new System.Drawing.Size(90, 22);
            this.txtSaldoTotal.TabIndex = 99;
            this.txtSaldoTotal.Text = "0";
            this.txtSaldoTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSaldoTotal_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(484, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 98;
            this.label8.Text = "Saldo Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(589, 31);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 17);
            this.label11.TabIndex = 93;
            this.label11.Text = "Cuota Mansual(%)";
            // 
            // txtCuotaMensual
            // 
            this.txtCuotaMensual.Location = new System.Drawing.Point(592, 50);
            this.txtCuotaMensual.Margin = new System.Windows.Forms.Padding(4);
            this.txtCuotaMensual.MaxLength = 50;
            this.txtCuotaMensual.Name = "txtCuotaMensual";
            this.txtCuotaMensual.Size = new System.Drawing.Size(114, 22);
            this.txtCuotaMensual.TabIndex = 82;
            this.txtCuotaMensual.Text = "0";
            this.txtCuotaMensual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCuotaMensual_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(564, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 20);
            this.label12.TabIndex = 81;
            // 
            // lvDeducciones
            // 
            this.lvDeducciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColDeduccion,
            this.ColFechaInicio,
            this.ColSaldoTotal,
            this.ColCuotaMensual,
            this.ColSaldoPendiente});
            this.lvDeducciones.FullRowSelect = true;
            this.lvDeducciones.GridLines = true;
            this.lvDeducciones.HideSelection = false;
            this.lvDeducciones.Location = new System.Drawing.Point(6, 21);
            this.lvDeducciones.Name = "lvDeducciones";
            this.lvDeducciones.Size = new System.Drawing.Size(710, 165);
            this.lvDeducciones.TabIndex = 111;
            this.lvDeducciones.UseCompatibleStateImageBehavior = false;
            this.lvDeducciones.View = System.Windows.Forms.View.Details;
            // 
            // ColDeduccion
            // 
            this.ColDeduccion.Text = "Deducción";
            this.ColDeduccion.Width = 158;
            // 
            // ColFechaInicio
            // 
            this.ColFechaInicio.Text = "Fecha Inicio";
            this.ColFechaInicio.Width = 140;
            // 
            // ColSaldoTotal
            // 
            this.ColSaldoTotal.Text = "Saldo Total";
            this.ColSaldoTotal.Width = 100;
            // 
            // ColCuotaMensual
            // 
            this.ColCuotaMensual.Text = "Cuota Mensual";
            this.ColCuotaMensual.Width = 100;
            // 
            // ColSaldoPendiente
            // 
            this.ColSaldoPendiente.Text = "Saldo Pendiente";
            this.ColSaldoPendiente.Width = 100;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(626, 196);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 29);
            this.btnEliminar.TabIndex = 112;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvDeducciones);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Location = new System.Drawing.Point(13, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 232);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deducciones Seleccionadas";
            // 
            // frmGestionDeducciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbDatosJornalero);
            this.Controls.Add(this.lblPeriodoActivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grbTrabajadores);
            this.Controls.Add(this.grbSeleccionarTRabajador);
            this.Controls.Add(this.starbar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmGestionDeducciones";
            this.Text = "Gestión Deducciones Trabajador";
            this.grbTrabajadores.ResumeLayout(false);
            this.grbTrabajadores.PerformLayout();
            this.grbSeleccionarTRabajador.ResumeLayout(false);
            this.grbSeleccionarTRabajador.PerformLayout();
            this.grbDatosJornalero.ResumeLayout(false);
            this.grbDatosJornalero.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar starbar;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.Label lblPeriodoActivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbTrabajadores;
        private System.Windows.Forms.Label lbldatosPersona;
        private System.Windows.Forms.GroupBox grbSeleccionarTRabajador;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUnidadesOrganizativas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbDatosJornalero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbdeduccion;
        private System.Windows.Forms.TextBox txtSaldoTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCuotaMensual;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpfechaInicio;
        private System.Windows.Forms.ListView lvDeducciones;
        private System.Windows.Forms.ColumnHeader ColDeduccion;
        private System.Windows.Forms.ColumnHeader ColFechaInicio;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ColumnHeader ColSaldoTotal;
        private System.Windows.Forms.ColumnHeader ColCuotaMensual;
        private System.Windows.Forms.ColumnHeader ColSaldoPendiente;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

