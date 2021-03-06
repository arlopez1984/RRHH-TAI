﻿namespace RHSMC001
{
    partial class frmCompetencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompetencia));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoCompetencia = new System.Windows.Forms.ComboBox();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.ColSelecc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCompetencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRequerido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColNivel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TCompetencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1061, 528);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Competencias";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelecc,
            this.ColCompetencias,
            this.ColDescripcion,
            this.ColRequerido,
            this.ColNivel,
            this.TCompetencia});
            this.dataGridView1.Location = new System.Drawing.Point(11, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 497);
            this.dataGridView1.TabIndex = 56;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridView1_CurrentCellDirtyStateChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 645);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(1084, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 55;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 56;
            this.label1.Tag = "";
            this.label1.Text = "Tipo de Competencia";
            // 
            // cmbTipoCompetencia
            // 
            this.cmbTipoCompetencia.FormattingEnabled = true;
            this.cmbTipoCompetencia.Location = new System.Drawing.Point(15, 65);
            this.cmbTipoCompetencia.Name = "cmbTipoCompetencia";
            this.cmbTipoCompetencia.Size = new System.Drawing.Size(169, 24);
            this.cmbTipoCompetencia.TabIndex = 55;
            this.cmbTipoCompetencia.SelectedIndexChanged += new System.EventHandler(this.CmbTipoCompetencia_SelectedIndexChanged);
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(1084, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 57;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            // 
            // ColSelecc
            // 
            this.ColSelecc.HeaderText = "Selecc";
            this.ColSelecc.Name = "ColSelecc";
            this.ColSelecc.Width = 60;
            // 
            // ColCompetencias
            // 
            this.ColCompetencias.HeaderText = "Competencias";
            this.ColCompetencias.Name = "ColCompetencias";
            this.ColCompetencias.ReadOnly = true;
            this.ColCompetencias.Width = 200;
            // 
            // ColDescripcion
            // 
            this.ColDescripcion.HeaderText = "Descripción";
            this.ColDescripcion.Name = "ColDescripcion";
            this.ColDescripcion.ReadOnly = true;
            this.ColDescripcion.Width = 200;
            // 
            // ColRequerido
            // 
            this.ColRequerido.HeaderText = "Requerida";
            this.ColRequerido.Name = "ColRequerido";
            this.ColRequerido.Width = 50;
            // 
            // ColNivel
            // 
            this.ColNivel.HeaderText = "Nivel";
            this.ColNivel.Items.AddRange(new object[] {
            "Alto",
            "Medio",
            "Bajo"});
            this.ColNivel.Name = "ColNivel";
            this.ColNivel.Width = 80;
            // 
            // TCompetencia
            // 
            this.TCompetencia.HeaderText = "Tipo de Competencia";
            this.TCompetencia.Name = "TCompetencia";
            this.TCompetencia.ReadOnly = true;
            this.TCompetencia.Width = 150;
            // 
            // frmCompetencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 683);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoCompetencia);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmCompetencia";
            this.Text = "Buscar Competencias ";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoCompetencia;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelecc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCompetencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColRequerido;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCompetencia;
    }
}