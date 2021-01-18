namespace RHSMCP001
{
    partial class frmCompetencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompetencias));
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.strBar = new Net4Sage.Controls.StatusBar();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.grbcompetencias = new System.Windows.Forms.GroupBox();
            this.btnSelecc = new System.Windows.Forms.Button();
            this.lbltarifamonto = new System.Windows.Forms.Label();
            this.txtDescrpCompet = new System.Windows.Forms.TextBox();
            this.lblSalarioEscala = new System.Windows.Forms.Label();
            this.txtNombreCompet = new System.Windows.Forms.TextBox();
            this.cmbtipoCompetencia = new System.Windows.Forms.ComboBox();
            this.gbxSelecCompetencias = new System.Windows.Forms.GroupBox();
            this.lvBasicas = new System.Windows.Forms.ListView();
            this.Competencias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripción = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.grbcompetencias.SuspendLayout();
            this.gbxSelecCompetencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(786, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 0;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // strBar
            // 
            this.strBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strBar.Location = new System.Drawing.Point(0, 567);
            this.strBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strBar.Name = "strBar";
            this.strBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strBar.Size = new System.Drawing.Size(786, 38);
            this.strBar.SysSession = this.sageSession1;
            this.strBar.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 45);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(149, 17);
            this.lblCodigo.TabIndex = 24;
            this.lblCodigo.Text = "Tipo de Competencias";
            // 
            // grbcompetencias
            // 
            this.grbcompetencias.Controls.Add(this.btnSelecc);
            this.grbcompetencias.Controls.Add(this.lbltarifamonto);
            this.grbcompetencias.Controls.Add(this.txtDescrpCompet);
            this.grbcompetencias.Controls.Add(this.lblSalarioEscala);
            this.grbcompetencias.Controls.Add(this.txtNombreCompet);
            this.grbcompetencias.Location = new System.Drawing.Point(9, 110);
            this.grbcompetencias.Name = "grbcompetencias";
            this.grbcompetencias.Size = new System.Drawing.Size(767, 107);
            this.grbcompetencias.TabIndex = 22;
            this.grbcompetencias.TabStop = false;
            // 
            // btnSelecc
            // 
            this.btnSelecc.Location = new System.Drawing.Point(655, 68);
            this.btnSelecc.Name = "btnSelecc";
            this.btnSelecc.Size = new System.Drawing.Size(105, 31);
            this.btnSelecc.TabIndex = 15;
            this.btnSelecc.Text = "Seleccionar";
            this.btnSelecc.UseVisualStyleBackColor = true;
            this.btnSelecc.Click += new System.EventHandler(this.BtnSelecc_Click);
            // 
            // lbltarifamonto
            // 
            this.lbltarifamonto.AutoSize = true;
            this.lbltarifamonto.Location = new System.Drawing.Point(332, 15);
            this.lbltarifamonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarifamonto.Name = "lbltarifamonto";
            this.lbltarifamonto.Size = new System.Drawing.Size(82, 17);
            this.lbltarifamonto.TabIndex = 14;
            this.lbltarifamonto.Text = "Descripción";
            // 
            // txtDescrpCompet
            // 
            this.txtDescrpCompet.Location = new System.Drawing.Point(335, 36);
            this.txtDescrpCompet.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescrpCompet.MaxLength = 250;
            this.txtDescrpCompet.Name = "txtDescrpCompet";
            this.txtDescrpCompet.Size = new System.Drawing.Size(425, 22);
            this.txtDescrpCompet.TabIndex = 13;
            this.txtDescrpCompet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescrpCompet_KeyPress);
            // 
            // lblSalarioEscala
            // 
            this.lblSalarioEscala.AutoSize = true;
            this.lblSalarioEscala.Location = new System.Drawing.Point(9, 16);
            this.lblSalarioEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioEscala.Name = "lblSalarioEscala";
            this.lblSalarioEscala.Size = new System.Drawing.Size(99, 17);
            this.lblSalarioEscala.TabIndex = 8;
            this.lblSalarioEscala.Text = "Competencia *";
            // 
            // txtNombreCompet
            // 
            this.txtNombreCompet.Location = new System.Drawing.Point(11, 36);
            this.txtNombreCompet.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCompet.MaxLength = 250;
            this.txtNombreCompet.Name = "txtNombreCompet";
            this.txtNombreCompet.Size = new System.Drawing.Size(316, 22);
            this.txtNombreCompet.TabIndex = 7;
            this.txtNombreCompet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescrpCompet_KeyPress);
            // 
            // cmbtipoCompetencia
            // 
            this.cmbtipoCompetencia.FormattingEnabled = true;
            this.cmbtipoCompetencia.Location = new System.Drawing.Point(22, 68);
            this.cmbtipoCompetencia.Name = "cmbtipoCompetencia";
            this.cmbtipoCompetencia.Size = new System.Drawing.Size(169, 24);
            this.cmbtipoCompetencia.TabIndex = 25;
            // 
            // gbxSelecCompetencias
            // 
            this.gbxSelecCompetencias.Controls.Add(this.lvBasicas);
            this.gbxSelecCompetencias.Location = new System.Drawing.Point(9, 211);
            this.gbxSelecCompetencias.Name = "gbxSelecCompetencias";
            this.gbxSelecCompetencias.Size = new System.Drawing.Size(767, 349);
            this.gbxSelecCompetencias.TabIndex = 28;
            this.gbxSelecCompetencias.TabStop = false;
            this.gbxSelecCompetencias.Text = "Competencias Seleccionadas";
            // 
            // lvBasicas
            // 
            this.lvBasicas.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lvBasicas.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvBasicas.AllowColumnReorder = true;
            this.lvBasicas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvBasicas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Competencias,
            this.Descripción,
            this.Tipo});
            this.lvBasicas.FullRowSelect = true;
            this.lvBasicas.GridLines = true;
            this.lvBasicas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBasicas.HideSelection = false;
            this.lvBasicas.HoverSelection = true;
            this.lvBasicas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvBasicas.Location = new System.Drawing.Point(10, 21);
            this.lvBasicas.MultiSelect = false;
            this.lvBasicas.Name = "lvBasicas";
            this.lvBasicas.Size = new System.Drawing.Size(750, 322);
            this.lvBasicas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvBasicas.TabIndex = 28;
            this.lvBasicas.UseCompatibleStateImageBehavior = false;
            this.lvBasicas.View = System.Windows.Forms.View.Details;
            // 
            // Competencias
            // 
            this.Competencias.Text = "Competencias";
            this.Competencias.Width = 200;
            // 
            // Descripción
            // 
            this.Descripción.Text = "Descripción";
            this.Descripción.Width = 300;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 130;
            // 
            // frmCompetencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 605);
            this.Controls.Add(this.gbxSelecCompetencias);
            this.Controls.Add(this.cmbtipoCompetencia);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.grbcompetencias);
            this.Controls.Add(this.strBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmCompetencias";
            this.Text = "Gestión a Competencias";
            this.grbcompetencias.ResumeLayout(false);
            this.grbcompetencias.PerformLayout();
            this.gbxSelecCompetencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.StatusBar strBar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox grbcompetencias;
        private System.Windows.Forms.Label lbltarifamonto;
        private System.Windows.Forms.TextBox txtDescrpCompet;
        private System.Windows.Forms.Label lblSalarioEscala;
        private System.Windows.Forms.TextBox txtNombreCompet;
        private System.Windows.Forms.ComboBox cmbtipoCompetencia;
        private System.Windows.Forms.GroupBox gbxSelecCompetencias;
        private System.Windows.Forms.ListView lvBasicas;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.ColumnHeader Competencias;
        private System.Windows.Forms.ColumnHeader Descripción;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.Button btnSelecc;
    }
}

