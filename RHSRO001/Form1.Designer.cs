namespace RHSRO001
{
    partial class frmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportes));
            this.lblReportes = new System.Windows.Forms.Label();
            this.cmbSeleccReporte = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.datagridResult = new System.Windows.Forms.DataGridView();
            this.lblParosProd = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPeriodoActivo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ReportWorker = new System.ComponentModel.BackgroundWorker();
            this.DataLoaderWorker = new System.ComponentModel.BackgroundWorker();
            this.cmbperiodos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sageSession2 = new Net4Sage.SageSession();
            this.statusBar2 = new Net4Sage.Controls.StatusBar();
            this.ReportEngine = new ReportEngine.CrystalReportEngine(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReportes
            // 
            this.lblReportes.AutoSize = true;
            this.lblReportes.Location = new System.Drawing.Point(11, 78);
            this.lblReportes.Name = "lblReportes";
            this.lblReportes.Size = new System.Drawing.Size(179, 17);
            this.lblReportes.TabIndex = 39;
            this.lblReportes.Text = "Seleccione tipo de Reporte";
            // 
            // cmbSeleccReporte
            // 
            this.cmbSeleccReporte.FormattingEnabled = true;
            this.cmbSeleccReporte.Items.AddRange(new object[] {
            "Todos",
            "Reporte de Ausencias",
            "Reporte de Licencias",
            "Reporte de Subsidios",
            "Reporte de Vacaciones",
            "Reporte de Certificados y Accidentes"});
            this.cmbSeleccReporte.Location = new System.Drawing.Point(14, 100);
            this.cmbSeleccReporte.Name = "cmbSeleccReporte";
            this.cmbSeleccReporte.Size = new System.Drawing.Size(380, 24);
            this.cmbSeleccReporte.TabIndex = 38;
            this.cmbSeleccReporte.SelectedIndexChanged += new System.EventHandler(this.CmbSeleccReporte_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.cancelToolStripMenuItem,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1201, 28);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 24);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelToolStripMenuItem.Image")));
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.CancelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(32, 24);
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItem5_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(12, 24);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(12, 24);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 24);
            // 
            // datagridResult
            // 
            this.datagridResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridResult.Location = new System.Drawing.Point(15, 157);
            this.datagridResult.Margin = new System.Windows.Forms.Padding(4);
            this.datagridResult.Name = "datagridResult";
            this.datagridResult.ReadOnly = true;
            this.datagridResult.Size = new System.Drawing.Size(1173, 412);
            this.datagridResult.TabIndex = 52;
            // 
            // lblParosProd
            // 
            this.lblParosProd.AutoSize = true;
            this.lblParosProd.Location = new System.Drawing.Point(-193, 53);
            this.lblParosProd.Name = "lblParosProd";
            this.lblParosProd.Size = new System.Drawing.Size(72, 17);
            this.lblParosProd.TabIndex = 51;
            this.lblParosProd.Text = "Resultado";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(617, 96);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(114, 31);
            this.btnBuscar.TabIndex = 50;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Resultado";
            // 
            // lblPeriodoActivo
            // 
            this.lblPeriodoActivo.AutoSize = true;
            this.lblPeriodoActivo.Location = new System.Drawing.Point(143, 47);
            this.lblPeriodoActivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodoActivo.Name = "lblPeriodoActivo";
            this.lblPeriodoActivo.Size = new System.Drawing.Size(0, 17);
            this.lblPeriodoActivo.TabIndex = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 124;
            this.label5.Text = "Período Activo:";
            // 
            // ReportWorker
            // 
            this.ReportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadData);
            this.ReportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ShowData);
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
            this.cmbperiodos.Location = new System.Drawing.Point(400, 100);
            this.cmbperiodos.Name = "cmbperiodos";
            this.cmbperiodos.Size = new System.Drawing.Size(211, 24);
            this.cmbperiodos.TabIndex = 126;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(397, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 127;
            this.label2.Text = "Período";
            // 
            // sageSession2
            // 
            this.sageSession2.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession2.Parameters")));
            // 
            // statusBar2
            // 
            this.statusBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar2.Location = new System.Drawing.Point(0, 577);
            this.statusBar2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar2.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar2.Name = "statusBar2";
            this.statusBar2.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar2.Size = new System.Drawing.Size(1201, 38);
            this.statusBar2.SysSession = this.sageSession2;
            this.statusBar2.TabIndex = 128;
            // 
            // ReportEngine
            // 
            this.ReportEngine.LogoSize = new System.Drawing.Size(0, 0);
            this.ReportEngine.Report = null;
            this.ReportEngine.SysSession = null;
            this.ReportEngine.Title = null;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 615);
            this.Controls.Add(this.statusBar2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbperiodos);
            this.Controls.Add(this.lblPeriodoActivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridResult);
            this.Controls.Add(this.lblParosProd);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblReportes);
            this.Controls.Add(this.cmbSeleccReporte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportes";
            this.Text = "Reportes Asociados a Operaciones";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReportes;
        private System.Windows.Forms.ComboBox cmbSeleccReporte;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridView datagridResult;
        private System.Windows.Forms.Label lblParosProd;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        //private Net4Sage.Controls.StatusBar statusBar1;
        //private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.Label lblPeriodoActivo;
        private System.Windows.Forms.Label label5;
       // private ReportEngine.CrystalReportEngine ReportEngine;
        private System.ComponentModel.BackgroundWorker ReportWorker;
        private System.ComponentModel.BackgroundWorker DataLoaderWorker;
        private System.Windows.Forms.ComboBox cmbperiodos;
        private System.Windows.Forms.Label label2;
        private Net4Sage.SageSession sageSession2;
        private Net4Sage.Controls.StatusBar statusBar2;
        private ReportEngine.CrystalReportEngine ReportEngine;
    }
}

