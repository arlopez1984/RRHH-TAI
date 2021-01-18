namespace RHSGPN001
{
    partial class frmGestionarPrenomina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionarPrenomina));
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.datagridResult = new System.Windows.Forms.DataGridView();
            this.cmbUnidadOrganizativas = new System.Windows.Forms.ComboBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblPeriodoActivo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportEngine = new ReportEngine.CrystalReportEngine(this.components);
            this.ReportWorker = new System.ComponentModel.BackgroundWorker();
            this.DataLoaderWorker = new System.ComponentModel.BackgroundWorker();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbUnidad = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbperiodos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridResult)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 498);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(1060, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 0;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // datagridResult
            // 
            this.datagridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridResult.Location = new System.Drawing.Point(13, 131);
            this.datagridResult.Margin = new System.Windows.Forms.Padding(4);
            this.datagridResult.Name = "datagridResult";
            this.datagridResult.ReadOnly = true;
            this.datagridResult.Size = new System.Drawing.Size(1034, 342);
            this.datagridResult.TabIndex = 50;
            // 
            // cmbUnidadOrganizativas
            // 
            this.cmbUnidadOrganizativas.FormattingEnabled = true;
            this.cmbUnidadOrganizativas.Location = new System.Drawing.Point(291, 99);
            this.cmbUnidadOrganizativas.Name = "cmbUnidadOrganizativas";
            this.cmbUnidadOrganizativas.Size = new System.Drawing.Size(228, 24);
            this.cmbUnidadOrganizativas.TabIndex = 117;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(10, 477);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(112, 17);
            this.lblRegistros.TabIndex = 119;
            this.lblRegistros.Text = "Total Registros: ";
            this.lblRegistros.Visible = false;
            // 
            // lblPeriodoActivo
            // 
            this.lblPeriodoActivo.AutoSize = true;
            this.lblPeriodoActivo.Location = new System.Drawing.Point(149, 53);
            this.lblPeriodoActivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodoActivo.Name = "lblPeriodoActivo";
            this.lblPeriodoActivo.Size = new System.Drawing.Size(0, 17);
            this.lblPeriodoActivo.TabIndex = 123;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 122;
            this.label5.Text = "Período Activo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(746, 97);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 27);
            this.btnBuscar.TabIndex = 124;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem,
            this.toolStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1060, 28);
            this.menuStrip1.TabIndex = 125;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelToolStripMenuItem.Image")));
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(32, 24);
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItem5_Click_1);
            // 
            // ReportEngine
            // 
            this.ReportEngine.LogoSize = new System.Drawing.Size(0, 0);
            this.ReportEngine.Report = null;
            this.ReportEngine.SysSession = null;
            this.ReportEngine.Title = null;
            // 
            // ReportWorker
            // 
            this.ReportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadData);
            this.ReportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ShowData);
            // 
            // DataLoaderWorker
            // 
            this.DataLoaderWorker.WorkerReportsProgress = true;
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Checked = true;
            this.rdbTodos.Location = new System.Drawing.Point(17, 97);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(69, 21);
            this.rdbTodos.TabIndex = 126;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.RdbTodos_CheckedChanged);
            // 
            // rdbUnidad
            // 
            this.rdbUnidad.AutoSize = true;
            this.rdbUnidad.Location = new System.Drawing.Point(126, 99);
            this.rdbUnidad.Name = "rdbUnidad";
            this.rdbUnidad.Size = new System.Drawing.Size(158, 21);
            this.rdbUnidad.TabIndex = 127;
            this.rdbUnidad.Text = "Unidad Organizativa";
            this.rdbUnidad.UseVisualStyleBackColor = true;
            this.rdbUnidad.CheckedChanged += new System.EventHandler(this.RdbUnidad_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(526, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 129;
            this.label2.Text = "Períodos";
            // 
            // cmbperiodos
            // 
            this.cmbperiodos.FormattingEnabled = true;
            this.cmbperiodos.Items.AddRange(new object[] {
            "Todos",
            "Reporte de Ausencias",
            "Reporte de Licencias",
            "Reporte de Subsidios",
            "Reporte de Vacaciones",
            "Reporte de Certificados y Accidentes "});
            this.cmbperiodos.Location = new System.Drawing.Point(529, 99);
            this.cmbperiodos.Name = "cmbperiodos";
            this.cmbperiodos.Size = new System.Drawing.Size(211, 24);
            this.cmbperiodos.TabIndex = 128;
            // 
            // frmGestionarPrenomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 536);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbperiodos);
            this.Controls.Add(this.rdbUnidad);
            this.Controls.Add(this.rdbTodos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblPeriodoActivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.cmbUnidadOrganizativas);
            this.Controls.Add(this.datagridResult);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGestionarPrenomina";
            this.Text = "Generar Modelo SC-4-05 Pre-Nómina";
            ((System.ComponentModel.ISupportInitialize)(this.datagridResult)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.DataGridView datagridResult;
        private System.Windows.Forms.ComboBox cmbUnidadOrganizativas;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblPeriodoActivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private ReportEngine.CrystalReportEngine ReportEngine;
        private System.ComponentModel.BackgroundWorker ReportWorker;
        private System.ComponentModel.BackgroundWorker DataLoaderWorker;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbUnidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbperiodos;
    }
}

