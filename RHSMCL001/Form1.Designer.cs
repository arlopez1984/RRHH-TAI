namespace RHSMCL001
{
    partial class frmCondicionesLaborales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondicionesLaborales));
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.strBar = new Net4Sage.Controls.StatusBar();
            this.gbxSelecCompetencias = new System.Windows.Forms.GroupBox();
            this.lvCondiciones = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbtipoCondicion = new System.Windows.Forms.ComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.grbcompetencias = new System.Windows.Forms.GroupBox();
            this.lblCondicionDescrip = new System.Windows.Forms.Label();
            this.txtDescrpCondicion = new System.Windows.Forms.TextBox();
            this.txtCondicionName = new System.Windows.Forms.Label();
            this.txtNombreCondicion = new System.Windows.Forms.TextBox();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.btnSelecc = new System.Windows.Forms.Button();
            this.gbxSelecCompetencias.SuspendLayout();
            this.grbcompetencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
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
            this.menuBar1.Size = new System.Drawing.Size(800, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 0;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            // 
            // strBar
            // 
            this.strBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strBar.Location = new System.Drawing.Point(0, 562);
            this.strBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strBar.Name = "strBar";
            this.strBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strBar.Size = new System.Drawing.Size(800, 38);
            this.strBar.SysSession = this.sageSession1;
            this.strBar.TabIndex = 1;
            // 
            // gbxSelecCompetencias
            // 
            this.gbxSelecCompetencias.Controls.Add(this.lvCondiciones);
            this.gbxSelecCompetencias.Location = new System.Drawing.Point(18, 249);
            this.gbxSelecCompetencias.Name = "gbxSelecCompetencias";
            this.gbxSelecCompetencias.Size = new System.Drawing.Size(767, 306);
            this.gbxSelecCompetencias.TabIndex = 32;
            this.gbxSelecCompetencias.TabStop = false;
            this.gbxSelecCompetencias.Text = "Cond. Laborales Seleccionadas";
            // 
            // lvCondiciones
            // 
            this.lvCondiciones.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lvCondiciones.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvCondiciones.AllowColumnReorder = true;
            this.lvCondiciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvCondiciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvCondiciones.FullRowSelect = true;
            this.lvCondiciones.GridLines = true;
            this.lvCondiciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCondiciones.HideSelection = false;
            this.lvCondiciones.HoverSelection = true;
            this.lvCondiciones.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvCondiciones.Location = new System.Drawing.Point(9, 27);
            this.lvCondiciones.MultiSelect = false;
            this.lvCondiciones.Name = "lvCondiciones";
            this.lvCondiciones.Size = new System.Drawing.Size(751, 273);
            this.lvCondiciones.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCondiciones.TabIndex = 28;
            this.lvCondiciones.UseCompatibleStateImageBehavior = false;
            this.lvCondiciones.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Condición Laboral";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripción";
            this.columnHeader2.Width = 270;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tipo";
            this.columnHeader3.Width = 120;
            // 
            // cmbtipoCondicion
            // 
            this.cmbtipoCondicion.FormattingEnabled = true;
            this.cmbtipoCondicion.Location = new System.Drawing.Point(29, 66);
            this.cmbtipoCondicion.Name = "cmbtipoCondicion";
            this.cmbtipoCondicion.Size = new System.Drawing.Size(169, 24);
            this.cmbtipoCondicion.TabIndex = 31;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(27, 43);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(122, 17);
            this.lblCodigo.TabIndex = 30;
            this.lblCodigo.Text = "Tipo de Condición";
            // 
            // grbcompetencias
            // 
            this.grbcompetencias.Controls.Add(this.btnSelecc);
            this.grbcompetencias.Controls.Add(this.lblCondicionDescrip);
            this.grbcompetencias.Controls.Add(this.txtDescrpCondicion);
            this.grbcompetencias.Controls.Add(this.txtCondicionName);
            this.grbcompetencias.Controls.Add(this.txtNombreCondicion);
            this.grbcompetencias.Location = new System.Drawing.Point(18, 91);
            this.grbcompetencias.Name = "grbcompetencias";
            this.grbcompetencias.Size = new System.Drawing.Size(767, 156);
            this.grbcompetencias.TabIndex = 29;
            this.grbcompetencias.TabStop = false;
            // 
            // lblCondicionDescrip
            // 
            this.lblCondicionDescrip.AutoSize = true;
            this.lblCondicionDescrip.Location = new System.Drawing.Point(9, 71);
            this.lblCondicionDescrip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCondicionDescrip.Name = "lblCondicionDescrip";
            this.lblCondicionDescrip.Size = new System.Drawing.Size(82, 17);
            this.lblCondicionDescrip.TabIndex = 14;
            this.lblCondicionDescrip.Text = "Descripción";
            // 
            // txtDescrpCondicion
            // 
            this.txtDescrpCondicion.Location = new System.Drawing.Point(12, 89);
            this.txtDescrpCondicion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescrpCondicion.MaxLength = 50;
            this.txtDescrpCondicion.Name = "txtDescrpCondicion";
            this.txtDescrpCondicion.Size = new System.Drawing.Size(748, 22);
            this.txtDescrpCondicion.TabIndex = 13;
            this.txtDescrpCondicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescrpCondicion_KeyPress);
            // 
            // txtCondicionName
            // 
            this.txtCondicionName.AutoSize = true;
            this.txtCondicionName.Location = new System.Drawing.Point(9, 16);
            this.txtCondicionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtCondicionName.Name = "txtCondicionName";
            this.txtCondicionName.Size = new System.Drawing.Size(79, 17);
            this.txtCondicionName.TabIndex = 8;
            this.txtCondicionName.Text = "Condición *";
            // 
            // txtNombreCondicion
            // 
            this.txtNombreCondicion.Location = new System.Drawing.Point(11, 36);
            this.txtNombreCondicion.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCondicion.MaxLength = 50;
            this.txtNombreCondicion.Name = "txtNombreCondicion";
            this.txtNombreCondicion.Size = new System.Drawing.Size(749, 22);
            this.txtNombreCondicion.TabIndex = 7;
            this.txtNombreCondicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombreCondicion_KeyPress);
            // 
            // btnSelecc
            // 
            this.btnSelecc.Location = new System.Drawing.Point(655, 118);
            this.btnSelecc.Name = "btnSelecc";
            this.btnSelecc.Size = new System.Drawing.Size(105, 31);
            this.btnSelecc.TabIndex = 16;
            this.btnSelecc.Text = "Seleccionar";
            this.btnSelecc.UseVisualStyleBackColor = true;
            this.btnSelecc.Click += new System.EventHandler(this.BtnSelecc_Click);
            // 
            // frmCondicionesLaborales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.gbxSelecCompetencias);
            this.Controls.Add(this.cmbtipoCondicion);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.grbcompetencias);
            this.Controls.Add(this.strBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmCondicionesLaborales";
            this.Text = "Gestión a Condiciones Laborales";
            this.gbxSelecCompetencias.ResumeLayout(false);
            this.grbcompetencias.ResumeLayout(false);
            this.grbcompetencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar strBar;
        private System.Windows.Forms.GroupBox gbxSelecCompetencias;
        private System.Windows.Forms.ListView lvCondiciones;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox cmbtipoCondicion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox grbcompetencias;
        private System.Windows.Forms.Label lblCondicionDescrip;
        private System.Windows.Forms.TextBox txtDescrpCondicion;
        private System.Windows.Forms.Label txtCondicionName;
        private System.Windows.Forms.TextBox txtNombreCondicion;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSelecc;
    }
}

