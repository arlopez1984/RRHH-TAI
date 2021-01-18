namespace RHSST001
{
    partial class frmOtrasIncidencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtrasIncidencias));
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarOtraIncidencia = new System.Windows.Forms.Button();
            this.lvOtraIncidencias = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbDatosAusencias = new System.Windows.Forms.GroupBox();
            this.lbltiposubsidio = new System.Windows.Forms.Label();
            this.cmbTipoOtraIncidencia = new System.Windows.Forms.ComboBox();
            this.llblfechainicio = new System.Windows.Forms.Label();
            this.dtpfechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpfehaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblfechafin = new System.Windows.Forms.Label();
            this.btnAdicionrOtraIncidencia = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.grbDatosAusencias.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(737, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 0;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 412);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(737, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 1;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarOtraIncidencia);
            this.groupBox2.Controls.Add(this.lvOtraIncidencias);
            this.groupBox2.Location = new System.Drawing.Point(13, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 279);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Otras Incidencias";
            // 
            // btnEliminarOtraIncidencia
            // 
            this.btnEliminarOtraIncidencia.Location = new System.Drawing.Point(617, 244);
            this.btnEliminarOtraIncidencia.Name = "btnEliminarOtraIncidencia";
            this.btnEliminarOtraIncidencia.Size = new System.Drawing.Size(81, 29);
            this.btnEliminarOtraIncidencia.TabIndex = 100;
            this.btnEliminarOtraIncidencia.Text = "Eliminar";
            this.btnEliminarOtraIncidencia.UseVisualStyleBackColor = true;
            this.btnEliminarOtraIncidencia.Click += new System.EventHandler(this.BtnEliminarOtraIncidencia_Click);
            // 
            // lvOtraIncidencias
            // 
            this.lvOtraIncidencias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvOtraIncidencias.FullRowSelect = true;
            this.lvOtraIncidencias.GridLines = true;
            this.lvOtraIncidencias.HideSelection = false;
            this.lvOtraIncidencias.Location = new System.Drawing.Point(11, 26);
            this.lvOtraIncidencias.Name = "lvOtraIncidencias";
            this.lvOtraIncidencias.Size = new System.Drawing.Size(685, 211);
            this.lvOtraIncidencias.TabIndex = 80;
            this.lvOtraIncidencias.UseCompatibleStateImageBehavior = false;
            this.lvOtraIncidencias.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tipo de Otra Incidencia";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fecha Inicio";
            this.columnHeader2.Width = 157;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fecha Fin";
            this.columnHeader3.Width = 147;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tiempo de la Incidencia (Días)";
            this.columnHeader4.Width = 202;
            // 
            // grbDatosAusencias
            // 
            this.grbDatosAusencias.Controls.Add(this.lbltiposubsidio);
            this.grbDatosAusencias.Controls.Add(this.cmbTipoOtraIncidencia);
            this.grbDatosAusencias.Controls.Add(this.llblfechainicio);
            this.grbDatosAusencias.Controls.Add(this.dtpfechaFin);
            this.grbDatosAusencias.Controls.Add(this.dtpfehaInicio);
            this.grbDatosAusencias.Controls.Add(this.lblfechafin);
            this.grbDatosAusencias.Controls.Add(this.btnAdicionrOtraIncidencia);
            this.grbDatosAusencias.Location = new System.Drawing.Point(13, 41);
            this.grbDatosAusencias.Name = "grbDatosAusencias";
            this.grbDatosAusencias.Size = new System.Drawing.Size(712, 87);
            this.grbDatosAusencias.TabIndex = 100;
            this.grbDatosAusencias.TabStop = false;
            this.grbDatosAusencias.Text = "Datos Otras Incidencias";
            // 
            // lbltiposubsidio
            // 
            this.lbltiposubsidio.AutoSize = true;
            this.lbltiposubsidio.Location = new System.Drawing.Point(11, 32);
            this.lbltiposubsidio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltiposubsidio.Name = "lbltiposubsidio";
            this.lbltiposubsidio.Size = new System.Drawing.Size(155, 17);
            this.lbltiposubsidio.TabIndex = 22;
            this.lbltiposubsidio.Text = "Tipo de Otra Incidencia";
            // 
            // cmbTipoOtraIncidencia
            // 
            this.cmbTipoOtraIncidencia.FormattingEnabled = true;
            this.cmbTipoOtraIncidencia.Location = new System.Drawing.Point(14, 52);
            this.cmbTipoOtraIncidencia.Name = "cmbTipoOtraIncidencia";
            this.cmbTipoOtraIncidencia.Size = new System.Drawing.Size(189, 24);
            this.cmbTipoOtraIncidencia.TabIndex = 21;
            // 
            // llblfechainicio
            // 
            this.llblfechainicio.AutoSize = true;
            this.llblfechainicio.Location = new System.Drawing.Point(213, 32);
            this.llblfechainicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblfechainicio.Name = "llblfechainicio";
            this.llblfechainicio.Size = new System.Drawing.Size(83, 17);
            this.llblfechainicio.TabIndex = 19;
            this.llblfechainicio.Text = "Fecha Inicio";
            // 
            // dtpfechaFin
            // 
            this.dtpfechaFin.CustomFormat = "";
            this.dtpfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaFin.Location = new System.Drawing.Point(418, 52);
            this.dtpfechaFin.Name = "dtpfechaFin";
            this.dtpfechaFin.Size = new System.Drawing.Size(190, 22);
            this.dtpfechaFin.TabIndex = 18;
            // 
            // dtpfehaInicio
            // 
            this.dtpfehaInicio.CustomFormat = "";
            this.dtpfehaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfehaInicio.Location = new System.Drawing.Point(216, 52);
            this.dtpfehaInicio.Name = "dtpfehaInicio";
            this.dtpfehaInicio.Size = new System.Drawing.Size(190, 22);
            this.dtpfehaInicio.TabIndex = 17;
            // 
            // lblfechafin
            // 
            this.lblfechafin.AutoSize = true;
            this.lblfechafin.Location = new System.Drawing.Point(415, 32);
            this.lblfechafin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfechafin.Name = "lblfechafin";
            this.lblfechafin.Size = new System.Drawing.Size(70, 17);
            this.lblfechafin.TabIndex = 20;
            this.lblfechafin.Text = "Fecha Fin";
            // 
            // btnAdicionrOtraIncidencia
            // 
            this.btnAdicionrOtraIncidencia.Location = new System.Drawing.Point(615, 49);
            this.btnAdicionrOtraIncidencia.Name = "btnAdicionrOtraIncidencia";
            this.btnAdicionrOtraIncidencia.Size = new System.Drawing.Size(81, 29);
            this.btnAdicionrOtraIncidencia.TabIndex = 92;
            this.btnAdicionrOtraIncidencia.Text = "Adicionar";
            this.btnAdicionrOtraIncidencia.UseVisualStyleBackColor = true;
            this.btnAdicionrOtraIncidencia.Click += new System.EventHandler(this.BtnAdicionrOtraIncidencia_Click);
            // 
            // frmOtrasIncidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbDatosAusencias);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmOtrasIncidencias";
            this.Text = "Gestión Otras Incidencias";
            this.groupBox2.ResumeLayout(false);
            this.grbDatosAusencias.ResumeLayout(false);
            this.grbDatosAusencias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminarOtraIncidencia;
        private System.Windows.Forms.ListView lvOtraIncidencias;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox grbDatosAusencias;
        private System.Windows.Forms.Label lbltiposubsidio;
        private System.Windows.Forms.ComboBox cmbTipoOtraIncidencia;
        private System.Windows.Forms.Label llblfechainicio;
        private System.Windows.Forms.DateTimePicker dtpfechaFin;
        private System.Windows.Forms.DateTimePicker dtpfehaInicio;
        private System.Windows.Forms.Label lblfechafin;
        private System.Windows.Forms.Button btnAdicionrOtraIncidencia;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}