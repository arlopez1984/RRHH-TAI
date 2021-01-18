namespace RHSMTA001
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAusencias));
            this.strBar = new Net4Sage.Controls.StatusBar();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.lblNombreTipo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodAusencia = new System.Windows.Forms.Label();
            this.txtAusenciaCod = new System.Windows.Forms.TextBox();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.grbCategoriaOcup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // strBar
            // 
            this.strBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strBar.Location = new System.Drawing.Point(0, 412);
            this.strBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strBar.Name = "strBar";
            this.strBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strBar.Size = new System.Drawing.Size(480, 38);
            this.strBar.SysSession = this.sageSession1;
            this.strBar.TabIndex = 0;
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(480, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.txtResolucion);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Controls.Add(this.lblNombreTipo);
            this.grbCategoriaOcup.Controls.Add(this.txtNombre);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(13, 94);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(456, 309);
            this.grbCategoriaOcup.TabIndex = 14;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // txtResolucion
            // 
            this.txtResolucion.Enabled = false;
            this.txtResolucion.Location = new System.Drawing.Point(15, 103);
            this.txtResolucion.Margin = new System.Windows.Forms.Padding(4);
            this.txtResolucion.MaxLength = 50;
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.Size = new System.Drawing.Size(418, 22);
            this.txtResolucion.TabIndex = 12;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(16, 82);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(78, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Resolución";
            // 
            // lblNombreTipo
            // 
            this.lblNombreTipo.AutoSize = true;
            this.lblNombreTipo.Location = new System.Drawing.Point(13, 22);
            this.lblNombreTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreTipo.Name = "lblNombreTipo";
            this.lblNombreTipo.Size = new System.Drawing.Size(67, 17);
            this.lblNombreTipo.TabIndex = 8;
            this.lblNombreTipo.Text = "Nombre *";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(15, 43);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(268, 22);
            this.txtNombre.TabIndex = 7;
            // 
            // lblCodAusencia
            // 
            this.lblCodAusencia.AutoSize = true;
            this.lblCodAusencia.Location = new System.Drawing.Point(13, 41);
            this.lblCodAusencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodAusencia.Name = "lblCodAusencia";
            this.lblCodAusencia.Size = new System.Drawing.Size(134, 17);
            this.lblCodAusencia.TabIndex = 16;
            this.lblCodAusencia.Text = "Código de Ausencia";
            // 
            // txtAusenciaCod
            // 
            this.txtAusenciaCod.Location = new System.Drawing.Point(13, 61);
            this.txtAusenciaCod.Margin = new System.Windows.Forms.Padding(4);
            this.txtAusenciaCod.MaxLength = 30;
            this.txtAusenciaCod.Name = "txtAusenciaCod";
            this.txtAusenciaCod.Size = new System.Drawing.Size(158, 22);
            this.txtAusenciaCod.TabIndex = 15;
            this.txtAusenciaCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAusenciaCod_KeyPress);
            // 
            // lkuNav
            // 
            this.lkuNav.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(176, 59);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(33, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 17;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // frmAusencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.lblCodAusencia);
            this.Controls.Add(this.txtAusenciaCod);
            this.Controls.Add(this.strBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmAusencias";
            this.Text = "Gestión Aunsencias";
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar strBar;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblNombreTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodAusencia;
        private System.Windows.Forms.TextBox txtAusenciaCod;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.BindingSource MainBS;
    }
}

