namespace RHSMC001
{
    partial class frmRiesgos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRiesgos));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTipoRiesgo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datagridviewRiesgo = new System.Windows.Forms.DataGridView();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.ColSelecc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCondicionLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNivel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewRiesgo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 59;
            this.label1.Tag = "";
            this.label1.Text = "Tipo de Riesgo";
            // 
            // cbxTipoRiesgo
            // 
            this.cbxTipoRiesgo.FormattingEnabled = true;
            this.cbxTipoRiesgo.Location = new System.Drawing.Point(7, 56);
            this.cbxTipoRiesgo.Name = "cbxTipoRiesgo";
            this.cbxTipoRiesgo.Size = new System.Drawing.Size(169, 24);
            this.cbxTipoRiesgo.TabIndex = 58;
            this.cbxTipoRiesgo.SelectedIndexChanged += new System.EventHandler(this.CmbTipoRiesgo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datagridviewRiesgo);
            this.groupBox1.Location = new System.Drawing.Point(4, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1061, 528);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Competencias";
            // 
            // datagridviewRiesgo
            // 
            this.datagridviewRiesgo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewRiesgo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelecc,
            this.ColCondicionLaboral,
            this.ColDescripcion,
            this.ColNivel,
            this.Column1});
            this.datagridviewRiesgo.Location = new System.Drawing.Point(11, 25);
            this.datagridviewRiesgo.Name = "datagridviewRiesgo";
            this.datagridviewRiesgo.RowTemplate.Height = 24;
            this.datagridviewRiesgo.Size = new System.Drawing.Size(1040, 497);
            this.datagridviewRiesgo.TabIndex = 56;
            this.datagridviewRiesgo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagridviewRiesgo_CellContentClick);
            this.datagridviewRiesgo.CurrentCellDirtyStateChanged += new System.EventHandler(this.DatagridviewRiesgo_CurrentCellDirtyStateChanged);
            this.datagridviewRiesgo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DatagridviewRiesgo_DataError);
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(1069, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 60;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 632);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(1069, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 61;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // ColSelecc
            // 
            this.ColSelecc.HeaderText = "Selecc";
            this.ColSelecc.Name = "ColSelecc";
            this.ColSelecc.Width = 60;
            // 
            // ColCondicionLaboral
            // 
            this.ColCondicionLaboral.HeaderText = "Riesgo";
            this.ColCondicionLaboral.Name = "ColCondicionLaboral";
            this.ColCondicionLaboral.ReadOnly = true;
            this.ColCondicionLaboral.Width = 200;
            // 
            // ColDescripcion
            // 
            this.ColDescripcion.HeaderText = "Descripción";
            this.ColDescripcion.Name = "ColDescripcion";
            this.ColDescripcion.ReadOnly = true;
            this.ColDescripcion.Width = 250;
            // 
            // ColNivel
            // 
            this.ColNivel.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColNivel.HeaderText = "Nivel";
            this.ColNivel.Items.AddRange(new object[] {
            "Alto",
            "Medio",
            "Bajo"});
            this.ColNivel.Name = "ColNivel";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tipo de Riesgo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // frmRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 670);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTipoRiesgo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuBar1);
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmRiesgos";
            this.Text = "Búsqueda de Riesgos";
            this.Load += new System.EventHandler(this.frmRiesgos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewRiesgo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.SageSession sageSession1;
        public System.Windows.Forms.ComboBox cbxTipoRiesgo;
        public System.Windows.Forms.DataGridView datagridviewRiesgo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelecc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCondicionLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}