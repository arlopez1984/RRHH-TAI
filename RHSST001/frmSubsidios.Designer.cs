namespace RHSST001
{
    partial class frmSubsidios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubsidios));
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.grbDatosAusencias = new System.Windows.Forms.GroupBox();
            this.chkhospitalizado = new System.Windows.Forms.CheckBox();
            this.chkSubInicio = new System.Windows.Forms.CheckBox();
            this.lbltiposubsidio = new System.Windows.Forms.Label();
            this.cmbTipoSubsidios = new System.Windows.Forms.ComboBox();
            this.llblfechainicio = new System.Windows.Forms.Label();
            this.dtpfechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpfehaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblfechafin = new System.Windows.Forms.Label();
            this.btnAdicionrSubsidios = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarSubsidios = new System.Windows.Forms.Button();
            this.lvSubsidios = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbDatosAusencias.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 504);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(5);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(894, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 0;
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
            this.menuBar1.Size = new System.Drawing.Size(894, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            // 
            // grbDatosAusencias
            // 
            this.grbDatosAusencias.Controls.Add(this.chkhospitalizado);
            this.grbDatosAusencias.Controls.Add(this.chkSubInicio);
            this.grbDatosAusencias.Controls.Add(this.lbltiposubsidio);
            this.grbDatosAusencias.Controls.Add(this.cmbTipoSubsidios);
            this.grbDatosAusencias.Controls.Add(this.llblfechainicio);
            this.grbDatosAusencias.Controls.Add(this.dtpfechaFin);
            this.grbDatosAusencias.Controls.Add(this.dtpfehaInicio);
            this.grbDatosAusencias.Controls.Add(this.lblfechafin);
            this.grbDatosAusencias.Controls.Add(this.btnAdicionrSubsidios);
            this.grbDatosAusencias.Location = new System.Drawing.Point(12, 43);
            this.grbDatosAusencias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDatosAusencias.Name = "grbDatosAusencias";
            this.grbDatosAusencias.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDatosAusencias.Size = new System.Drawing.Size(869, 138);
            this.grbDatosAusencias.TabIndex = 97;
            this.grbDatosAusencias.TabStop = false;
            this.grbDatosAusencias.Text = "Datos Subsidio";
            // 
            // chkhospitalizado
            // 
            this.chkhospitalizado.AutoSize = true;
            this.chkhospitalizado.Location = new System.Drawing.Point(139, 89);
            this.chkhospitalizado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkhospitalizado.Name = "chkhospitalizado";
            this.chkhospitalizado.Size = new System.Drawing.Size(115, 21);
            this.chkhospitalizado.TabIndex = 94;
            this.chkhospitalizado.Text = "Hospitalizado";
            this.chkhospitalizado.UseVisualStyleBackColor = true;
            // 
            // chkSubInicio
            // 
            this.chkSubInicio.AutoSize = true;
            this.chkSubInicio.Location = new System.Drawing.Point(14, 89);
            this.chkSubInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSubInicio.Name = "chkSubInicio";
            this.chkSubInicio.Size = new System.Drawing.Size(120, 21);
            this.chkSubInicio.TabIndex = 93;
            this.chkSubInicio.Text = "Subsidio inicio";
            this.chkSubInicio.UseVisualStyleBackColor = true;
            // 
            // lbltiposubsidio
            // 
            this.lbltiposubsidio.AutoSize = true;
            this.lbltiposubsidio.Location = new System.Drawing.Point(11, 32);
            this.lbltiposubsidio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltiposubsidio.Name = "lbltiposubsidio";
            this.lbltiposubsidio.Size = new System.Drawing.Size(114, 17);
            this.lbltiposubsidio.TabIndex = 22;
            this.lbltiposubsidio.Text = "Tipo de Subsidio";
            // 
            // cmbTipoSubsidios
            // 
            this.cmbTipoSubsidios.FormattingEnabled = true;
            this.cmbTipoSubsidios.Location = new System.Drawing.Point(13, 52);
            this.cmbTipoSubsidios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipoSubsidios.Name = "cmbTipoSubsidios";
            this.cmbTipoSubsidios.Size = new System.Drawing.Size(435, 24);
            this.cmbTipoSubsidios.TabIndex = 21;
            // 
            // llblfechainicio
            // 
            this.llblfechainicio.AutoSize = true;
            this.llblfechainicio.Location = new System.Drawing.Point(457, 32);
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
            this.dtpfechaFin.Location = new System.Drawing.Point(664, 52);
            this.dtpfechaFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfechaFin.Name = "dtpfechaFin";
            this.dtpfechaFin.Size = new System.Drawing.Size(190, 22);
            this.dtpfechaFin.TabIndex = 18;
            // 
            // dtpfehaInicio
            // 
            this.dtpfehaInicio.CustomFormat = "";
            this.dtpfehaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfehaInicio.Location = new System.Drawing.Point(460, 52);
            this.dtpfehaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfehaInicio.Name = "dtpfehaInicio";
            this.dtpfehaInicio.Size = new System.Drawing.Size(190, 22);
            this.dtpfehaInicio.TabIndex = 17;
            // 
            // lblfechafin
            // 
            this.lblfechafin.AutoSize = true;
            this.lblfechafin.Location = new System.Drawing.Point(661, 32);
            this.lblfechafin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfechafin.Name = "lblfechafin";
            this.lblfechafin.Size = new System.Drawing.Size(70, 17);
            this.lblfechafin.TabIndex = 20;
            this.lblfechafin.Text = "Fecha Fin";
            // 
            // btnAdicionrSubsidios
            // 
            this.btnAdicionrSubsidios.Location = new System.Drawing.Point(779, 104);
            this.btnAdicionrSubsidios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionrSubsidios.Name = "btnAdicionrSubsidios";
            this.btnAdicionrSubsidios.Size = new System.Drawing.Size(81, 30);
            this.btnAdicionrSubsidios.TabIndex = 92;
            this.btnAdicionrSubsidios.Text = "Adicionar";
            this.btnAdicionrSubsidios.UseVisualStyleBackColor = true;
            this.btnAdicionrSubsidios.Click += new System.EventHandler(this.btnAdicionrSubsidios_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarSubsidios);
            this.groupBox2.Controls.Add(this.lvSubsidios);
            this.groupBox2.Location = new System.Drawing.Point(12, 185);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(869, 312);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subsidios";
            // 
            // btnEliminarSubsidios
            // 
            this.btnEliminarSubsidios.Location = new System.Drawing.Point(778, 279);
            this.btnEliminarSubsidios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarSubsidios.Name = "btnEliminarSubsidios";
            this.btnEliminarSubsidios.Size = new System.Drawing.Size(81, 30);
            this.btnEliminarSubsidios.TabIndex = 100;
            this.btnEliminarSubsidios.Text = "Eliminar";
            this.btnEliminarSubsidios.UseVisualStyleBackColor = true;
            this.btnEliminarSubsidios.Click += new System.EventHandler(this.btnEliminarSubsidios_Click);
            // 
            // lvSubsidios
            // 
            this.lvSubsidios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvSubsidios.FullRowSelect = true;
            this.lvSubsidios.GridLines = true;
            this.lvSubsidios.HideSelection = false;
            this.lvSubsidios.Location = new System.Drawing.Point(13, 28);
            this.lvSubsidios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvSubsidios.Name = "lvSubsidios";
            this.lvSubsidios.Size = new System.Drawing.Size(847, 244);
            this.lvSubsidios.TabIndex = 80;
            this.lvSubsidios.UseCompatibleStateImageBehavior = false;
            this.lvSubsidios.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tipo de Subsidio";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fecha Inicio";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fecha Fin";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Subsidio Inicio";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Hospitalizado";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tiempo de Subsidio (Días)";
            this.columnHeader6.Width = 230;
            // 
            // frmSubsidios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 542);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbDatosAusencias);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSubsidios";
            this.Text = "Gestionar Subsidios";
            this.grbDatosAusencias.ResumeLayout(false);
            this.grbDatosAusencias.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.GroupBox grbDatosAusencias;
        private System.Windows.Forms.CheckBox chkhospitalizado;
        private System.Windows.Forms.CheckBox chkSubInicio;
        private System.Windows.Forms.Label lbltiposubsidio;
        private System.Windows.Forms.ComboBox cmbTipoSubsidios;
        private System.Windows.Forms.Label llblfechainicio;
        private System.Windows.Forms.DateTimePicker dtpfechaFin;
        private System.Windows.Forms.DateTimePicker dtpfehaInicio;
        private System.Windows.Forms.Label lblfechafin;
        private System.Windows.Forms.Button btnAdicionrSubsidios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminarSubsidios;
        private System.Windows.Forms.ListView lvSubsidios;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}