namespace RHSGRT001
{
    partial class frmRetencionesTrabajador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetencionesTrabajador));
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.lblPeriodoActivo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbSeleccionarTRabajador = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUnidadesOrganizativas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dvtrabajadores = new System.Windows.Forms.DataGridView();
            this.chxMostrarTodos = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ColNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCompetencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHoras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFechaGestion = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.grbSeleccionarTRabajador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvtrabajadores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(927, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 0;
            this.menuBar1.Text = "menuBar1";
            // 
            // strbar
            // 
            this.strbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strbar.Location = new System.Drawing.Point(0, 645);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(927, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 1;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // lblPeriodoActivo
            // 
            this.lblPeriodoActivo.AutoSize = true;
            this.lblPeriodoActivo.Location = new System.Drawing.Point(152, 47);
            this.lblPeriodoActivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodoActivo.Name = "lblPeriodoActivo";
            this.lblPeriodoActivo.Size = new System.Drawing.Size(0, 17);
            this.lblPeriodoActivo.TabIndex = 117;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 116;
            this.label5.Text = "Período Activo:";
            // 
            // grbSeleccionarTRabajador
            // 
            this.grbSeleccionarTRabajador.Controls.Add(this.btnBuscar);
            this.grbSeleccionarTRabajador.Controls.Add(this.txtCi);
            this.grbSeleccionarTRabajador.Controls.Add(this.label2);
            this.grbSeleccionarTRabajador.Controls.Add(this.cmbUnidadesOrganizativas);
            this.grbSeleccionarTRabajador.Controls.Add(this.label1);
            this.grbSeleccionarTRabajador.Location = new System.Drawing.Point(15, 76);
            this.grbSeleccionarTRabajador.Name = "grbSeleccionarTRabajador";
            this.grbSeleccionarTRabajador.Size = new System.Drawing.Size(900, 66);
            this.grbSeleccionarTRabajador.TabIndex = 114;
            this.grbSeleccionarTRabajador.TabStop = false;
            this.grbSeleccionarTRabajador.Text = "Seleccionar Trabajador";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(582, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 29);
            this.btnBuscar.TabIndex = 94;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCi
            // 
            this.txtCi.Location = new System.Drawing.Point(380, 29);
            this.txtCi.Margin = new System.Windows.Forms.Padding(4);
            this.txtCi.MaxLength = 50;
            this.txtCi.Name = "txtCi";
            this.txtCi.Size = new System.Drawing.Size(195, 22);
            this.txtCi.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 92;
            this.label2.Text = "Unidad organizativa";
            // 
            // cmbUnidadesOrganizativas
            // 
            this.cmbUnidadesOrganizativas.FormattingEnabled = true;
            this.cmbUnidadesOrganizativas.Location = new System.Drawing.Point(152, 29);
            this.cmbUnidadesOrganizativas.Name = "cmbUnidadesOrganizativas";
            this.cmbUnidadesOrganizativas.Size = new System.Drawing.Size(195, 24);
            this.cmbUnidadesOrganizativas.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 79;
            this.label1.Text = "CI";
            // 
            // dvtrabajadores
            // 
            this.dvtrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvtrabajadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNombres,
            this.ColDescripcion,
            this.TCompetencia,
            this.ColHoras});
            this.dvtrabajadores.Location = new System.Drawing.Point(9, 22);
            this.dvtrabajadores.Name = "dvtrabajadores";
            this.dvtrabajadores.RowHeadersWidth = 51;
            this.dvtrabajadores.RowTemplate.Height = 24;
            this.dvtrabajadores.Size = new System.Drawing.Size(883, 410);
            this.dvtrabajadores.TabIndex = 120;
            // 
            // chxMostrarTodos
            // 
            this.chxMostrarTodos.AutoSize = true;
            this.chxMostrarTodos.Location = new System.Drawing.Point(10, 21);
            this.chxMostrarTodos.Name = "chxMostrarTodos";
            this.chxMostrarTodos.Size = new System.Drawing.Size(122, 21);
            this.chxMostrarTodos.TabIndex = 122;
            this.chxMostrarTodos.Text = "Mostrar Todos";
            this.chxMostrarTodos.UseVisualStyleBackColor = true;
            this.chxMostrarTodos.CheckedChanged += new System.EventHandler(this.chxMostrarTodos_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dvtrabajadores);
            this.groupBox1.Location = new System.Drawing.Point(15, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 438);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trabajador Seleccionados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chxMostrarTodos);
            this.groupBox2.Controls.Add(this.dtpFechaGestion);
            this.groupBox2.Location = new System.Drawing.Point(15, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 61);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            // 
            // ColNombres
            // 
            this.ColNombres.HeaderText = "Nombres y Apellidos";
            this.ColNombres.MinimumWidth = 6;
            this.ColNombres.Name = "ColNombres";
            this.ColNombres.ReadOnly = true;
            this.ColNombres.Width = 200;
            // 
            // ColDescripcion
            // 
            this.ColDescripcion.HeaderText = "Hora Inicio";
            this.ColDescripcion.MinimumWidth = 6;
            this.ColDescripcion.Name = "ColDescripcion";
            this.ColDescripcion.ReadOnly = true;
            this.ColDescripcion.Width = 120;
            // 
            // TCompetencia
            // 
            this.TCompetencia.HeaderText = "Hora fin ";
            this.TCompetencia.MinimumWidth = 6;
            this.TCompetencia.Name = "TCompetencia";
            this.TCompetencia.ReadOnly = true;
            this.TCompetencia.Width = 120;
            // 
            // ColHoras
            // 
            this.ColHoras.HeaderText = "Horas Extras";
            this.ColHoras.MinimumWidth = 6;
            this.ColHoras.Name = "ColHoras";
            this.ColHoras.Width = 120;
            // 
            // dtpFechaGestion
            // 
            this.dtpFechaGestion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaGestion.Location = new System.Drawing.Point(735, 32);
            this.dtpFechaGestion.Name = "dtpFechaGestion";
            this.dtpFechaGestion.Size = new System.Drawing.Size(159, 22);
            this.dtpFechaGestion.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(732, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 125;
            this.label3.Text = "Día a Procesar";
            // 
            // frmRetencionesTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 683);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblPeriodoActivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grbSeleccionarTRabajador);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmRetencionesTrabajador";
            this.Text = "Gestión Asistencias Trabajador";
            this.grbSeleccionarTRabajador.ResumeLayout(false);
            this.grbSeleccionarTRabajador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvtrabajadores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar strbar;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.Label lblPeriodoActivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbSeleccionarTRabajador;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUnidadesOrganizativas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dvtrabajadores;
        private System.Windows.Forms.CheckBox chxMostrarTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCompetencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHoras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaGestion;
    }
}

