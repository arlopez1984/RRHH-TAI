namespace RHSST001
{
    partial class frmAusencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAusencias));
            this.lbltiposubsidio = new System.Windows.Forms.Label();
            this.cmbTipoAusencias = new System.Windows.Forms.ComboBox();
            this.lblfechafin = new System.Windows.Forms.Label();
            this.llblfechainicio = new System.Windows.Forms.Label();
            this.dtpfehaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpfechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnAdicionrAusencias = new System.Windows.Forms.Button();
            this.grbDatosAusencias = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarAusencias = new System.Windows.Forms.Button();
            this.lvAusencias = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.grbDatosAusencias.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltiposubsidio
            // 
            this.lbltiposubsidio.AutoSize = true;
            this.lbltiposubsidio.Location = new System.Drawing.Point(11, 32);
            this.lbltiposubsidio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltiposubsidio.Name = "lbltiposubsidio";
            this.lbltiposubsidio.Size = new System.Drawing.Size(118, 17);
            this.lbltiposubsidio.TabIndex = 22;
            this.lbltiposubsidio.Text = "Tipo de Ausencia";
            // 
            // cmbTipoAusencias
            // 
            this.cmbTipoAusencias.FormattingEnabled = true;
            this.cmbTipoAusencias.Location = new System.Drawing.Point(13, 52);
            this.cmbTipoAusencias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipoAusencias.Name = "cmbTipoAusencias";
            this.cmbTipoAusencias.Size = new System.Drawing.Size(189, 24);
            this.cmbTipoAusencias.TabIndex = 21;
            // 
            // lblfechafin
            // 
            this.lblfechafin.AutoSize = true;
            this.lblfechafin.Location = new System.Drawing.Point(417, 32);
            this.lblfechafin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfechafin.Name = "lblfechafin";
            this.lblfechafin.Size = new System.Drawing.Size(70, 17);
            this.lblfechafin.TabIndex = 20;
            this.lblfechafin.Text = "Fecha Fin";
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
            // dtpfehaInicio
            // 
            this.dtpfehaInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpfehaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfehaInicio.Location = new System.Drawing.Point(216, 52);
            this.dtpfehaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfehaInicio.Name = "dtpfehaInicio";
            this.dtpfehaInicio.Size = new System.Drawing.Size(190, 22);
            this.dtpfehaInicio.TabIndex = 17;
            // 
            // dtpfechaFin
            // 
            this.dtpfechaFin.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfechaFin.Location = new System.Drawing.Point(420, 52);
            this.dtpfechaFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfechaFin.Name = "dtpfechaFin";
            this.dtpfechaFin.Size = new System.Drawing.Size(190, 22);
            this.dtpfechaFin.TabIndex = 18;
            // 
            // btnAdicionrAusencias
            // 
            this.btnAdicionrAusencias.Location = new System.Drawing.Point(620, 46);
            this.btnAdicionrAusencias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionrAusencias.Name = "btnAdicionrAusencias";
            this.btnAdicionrAusencias.Size = new System.Drawing.Size(81, 30);
            this.btnAdicionrAusencias.TabIndex = 92;
            this.btnAdicionrAusencias.Text = "Adicionar";
            this.btnAdicionrAusencias.UseVisualStyleBackColor = true;
            this.btnAdicionrAusencias.Click += new System.EventHandler(this.BtnAdicionrAusencias_Click);
            // 
            // grbDatosAusencias
            // 
            this.grbDatosAusencias.Controls.Add(this.lbltiposubsidio);
            this.grbDatosAusencias.Controls.Add(this.cmbTipoAusencias);
            this.grbDatosAusencias.Controls.Add(this.llblfechainicio);
            this.grbDatosAusencias.Controls.Add(this.dtpfechaFin);
            this.grbDatosAusencias.Controls.Add(this.dtpfehaInicio);
            this.grbDatosAusencias.Controls.Add(this.lblfechafin);
            this.grbDatosAusencias.Controls.Add(this.btnAdicionrAusencias);
            this.grbDatosAusencias.Location = new System.Drawing.Point(12, 44);
            this.grbDatosAusencias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDatosAusencias.Name = "grbDatosAusencias";
            this.grbDatosAusencias.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDatosAusencias.Size = new System.Drawing.Size(712, 92);
            this.grbDatosAusencias.TabIndex = 96;
            this.grbDatosAusencias.TabStop = false;
            this.grbDatosAusencias.Text = "Datos Ausencias";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarAusencias);
            this.groupBox2.Controls.Add(this.lvAusencias);
            this.groupBox2.Location = new System.Drawing.Point(12, 138);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(712, 367);
            this.groupBox2.TabIndex = 97;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ausencias";
            // 
            // btnEliminarAusencias
            // 
            this.btnEliminarAusencias.Location = new System.Drawing.Point(619, 330);
            this.btnEliminarAusencias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarAusencias.Name = "btnEliminarAusencias";
            this.btnEliminarAusencias.Size = new System.Drawing.Size(81, 30);
            this.btnEliminarAusencias.TabIndex = 100;
            this.btnEliminarAusencias.Text = "Eliminar";
            this.btnEliminarAusencias.UseVisualStyleBackColor = true;
            this.btnEliminarAusencias.Click += new System.EventHandler(this.BtnEliminarAusencias_Click);
            // 
            // lvAusencias
            // 
            this.lvAusencias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvAusencias.FullRowSelect = true;
            this.lvAusencias.GridLines = true;
            this.lvAusencias.HideSelection = false;
            this.lvAusencias.Location = new System.Drawing.Point(12, 31);
            this.lvAusencias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvAusencias.Name = "lvAusencias";
            this.lvAusencias.Size = new System.Drawing.Size(690, 292);
            this.lvAusencias.TabIndex = 80;
            this.lvAusencias.UseCompatibleStateImageBehavior = false;
            this.lvAusencias.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tipo de Ausencia";
            this.columnHeader1.Width = 143;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fecha Inicio";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fecha Fin";
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tiempo Ausencia (Horas)";
            this.columnHeader4.Width = 200;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 510);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(5);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(734, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 98;
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
            this.menuBar1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(734, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 99;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            // 
            // frmAusencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 548);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbDatosAusencias);
            this.Controls.Add(this.menuBar1);
            this.MainMenuStrip = this.menuBar1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAusencias";
            this.Text = "Gestionar Ausencias";
            this.grbDatosAusencias.ResumeLayout(false);
            this.grbDatosAusencias.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbltiposubsidio;
        private System.Windows.Forms.ComboBox cmbTipoAusencias;
        private System.Windows.Forms.Label lblfechafin;
        private System.Windows.Forms.Label llblfechainicio;
        private System.Windows.Forms.DateTimePicker dtpfehaInicio;
        private System.Windows.Forms.DateTimePicker dtpfechaFin;
        private System.Windows.Forms.Button btnAdicionrAusencias;
        private System.Windows.Forms.GroupBox grbDatosAusencias;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvAusencias;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.Button btnEliminarAusencias;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}