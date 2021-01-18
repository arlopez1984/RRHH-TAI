namespace RHSMR001
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRiesgos));
            this.strBar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.gbxSelecCompetencias = new System.Windows.Forms.GroupBox();
            this.lvRiesgos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbtipoRiesgos = new System.Windows.Forms.ComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.grbcompetencias = new System.Windows.Forms.GroupBox();
            this.lbltarifamonto = new System.Windows.Forms.Label();
            this.txtDescrpRiesgos = new System.Windows.Forms.TextBox();
            this.lblSalarioEscala = new System.Windows.Forms.Label();
            this.txtNombreRiesgo = new System.Windows.Forms.TextBox();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.btnSelecc = new System.Windows.Forms.Button();
            this.gbxSelecCompetencias.SuspendLayout();
            this.grbcompetencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // strBar
            // 
            this.strBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strBar.Location = new System.Drawing.Point(0, 436);
            this.strBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strBar.Name = "strBar";
            this.strBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strBar.Size = new System.Drawing.Size(789, 38);
            this.strBar.SysSession = this.sageSession1;
            this.strBar.TabIndex = 0;
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
            this.menuBar1.Size = new System.Drawing.Size(789, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            // 
            // gbxSelecCompetencias
            // 
            this.gbxSelecCompetencias.Controls.Add(this.lvRiesgos);
            this.gbxSelecCompetencias.Location = new System.Drawing.Point(11, 193);
            this.gbxSelecCompetencias.Name = "gbxSelecCompetencias";
            this.gbxSelecCompetencias.Size = new System.Drawing.Size(767, 236);
            this.gbxSelecCompetencias.TabIndex = 33;
            this.gbxSelecCompetencias.TabStop = false;
            this.gbxSelecCompetencias.Text = "Riesgos Seleccionados";
            // 
            // lvRiesgos
            // 
            this.lvRiesgos.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lvRiesgos.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvRiesgos.AllowColumnReorder = true;
            this.lvRiesgos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvRiesgos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvRiesgos.FullRowSelect = true;
            this.lvRiesgos.GridLines = true;
            this.lvRiesgos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvRiesgos.HideSelection = false;
            this.lvRiesgos.HoverSelection = true;
            this.lvRiesgos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvRiesgos.Location = new System.Drawing.Point(9, 30);
            this.lvRiesgos.MultiSelect = false;
            this.lvRiesgos.Name = "lvRiesgos";
            this.lvRiesgos.Size = new System.Drawing.Size(752, 200);
            this.lvRiesgos.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvRiesgos.TabIndex = 28;
            this.lvRiesgos.UseCompatibleStateImageBehavior = false;
            this.lvRiesgos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Riesgo";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripción";
            this.columnHeader2.Width = 280;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tipo";
            this.columnHeader3.Width = 120;
            // 
            // cmbtipoRiesgos
            // 
            this.cmbtipoRiesgos.FormattingEnabled = true;
            this.cmbtipoRiesgos.Location = new System.Drawing.Point(22, 64);
            this.cmbtipoRiesgos.Name = "cmbtipoRiesgos";
            this.cmbtipoRiesgos.Size = new System.Drawing.Size(169, 24);
            this.cmbtipoRiesgos.TabIndex = 32;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 41);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(104, 17);
            this.lblCodigo.TabIndex = 31;
            this.lblCodigo.Text = "Tipo de Riesgo";
            // 
            // grbcompetencias
            // 
            this.grbcompetencias.Controls.Add(this.btnSelecc);
            this.grbcompetencias.Controls.Add(this.lbltarifamonto);
            this.grbcompetencias.Controls.Add(this.txtDescrpRiesgos);
            this.grbcompetencias.Controls.Add(this.lblSalarioEscala);
            this.grbcompetencias.Controls.Add(this.txtNombreRiesgo);
            this.grbcompetencias.Location = new System.Drawing.Point(11, 89);
            this.grbcompetencias.Name = "grbcompetencias";
            this.grbcompetencias.Size = new System.Drawing.Size(767, 104);
            this.grbcompetencias.TabIndex = 30;
            this.grbcompetencias.TabStop = false;
            // 
            // lbltarifamonto
            // 
            this.lbltarifamonto.AutoSize = true;
            this.lbltarifamonto.Location = new System.Drawing.Point(338, 15);
            this.lbltarifamonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarifamonto.Name = "lbltarifamonto";
            this.lbltarifamonto.Size = new System.Drawing.Size(82, 17);
            this.lbltarifamonto.TabIndex = 14;
            this.lbltarifamonto.Text = "Descripción";
            // 
            // txtDescrpRiesgos
            // 
            this.txtDescrpRiesgos.Location = new System.Drawing.Point(341, 36);
            this.txtDescrpRiesgos.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescrpRiesgos.MaxLength = 250;
            this.txtDescrpRiesgos.Name = "txtDescrpRiesgos";
            this.txtDescrpRiesgos.Size = new System.Drawing.Size(419, 22);
            this.txtDescrpRiesgos.TabIndex = 13;
            this.txtDescrpRiesgos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescrpRiesgos_KeyPress);
            // 
            // lblSalarioEscala
            // 
            this.lblSalarioEscala.AutoSize = true;
            this.lblSalarioEscala.Location = new System.Drawing.Point(9, 16);
            this.lblSalarioEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioEscala.Name = "lblSalarioEscala";
            this.lblSalarioEscala.Size = new System.Drawing.Size(131, 17);
            this.lblSalarioEscala.TabIndex = 8;
            this.lblSalarioEscala.Text = "Nombre de Riesgo*";
            // 
            // txtNombreRiesgo
            // 
            this.txtNombreRiesgo.Location = new System.Drawing.Point(11, 36);
            this.txtNombreRiesgo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreRiesgo.MaxLength = 250;
            this.txtNombreRiesgo.Name = "txtNombreRiesgo";
            this.txtNombreRiesgo.Size = new System.Drawing.Size(316, 22);
            this.txtNombreRiesgo.TabIndex = 7;
            this.txtNombreRiesgo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombreRiesgo_KeyPress);
            // 
            // btnSelecc
            // 
            this.btnSelecc.Location = new System.Drawing.Point(655, 65);
            this.btnSelecc.Name = "btnSelecc";
            this.btnSelecc.Size = new System.Drawing.Size(105, 31);
            this.btnSelecc.TabIndex = 16;
            this.btnSelecc.Text = "Seleccionar";
            this.btnSelecc.UseVisualStyleBackColor = true;
            this.btnSelecc.Click += new System.EventHandler(this.BtnSelecc_Click);
            // 
            // frmRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 474);
            this.Controls.Add(this.gbxSelecCompetencias);
            this.Controls.Add(this.cmbtipoRiesgos);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.grbcompetencias);
            this.Controls.Add(this.strBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmRiesgos";
            this.Text = "Gestión a Riesgos";
            this.gbxSelecCompetencias.ResumeLayout(false);
            this.grbcompetencias.ResumeLayout(false);
            this.grbcompetencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar strBar;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.GroupBox gbxSelecCompetencias;
        private System.Windows.Forms.ListView lvRiesgos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox cmbtipoRiesgos;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox grbcompetencias;
        private System.Windows.Forms.Label lbltarifamonto;
        private System.Windows.Forms.TextBox txtDescrpRiesgos;
        private System.Windows.Forms.Label lblSalarioEscala;
        private System.Windows.Forms.TextBox txtNombreRiesgo;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSelecc;
    }
}

