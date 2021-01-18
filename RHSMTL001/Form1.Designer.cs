namespace RHSMTL001
{
    partial class frmLicencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicencia));
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.starBar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.lblNombreTipo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodLicence = new System.Windows.Forms.Label();
            this.txtlicenceCod = new System.Windows.Forms.TextBox();
            this.chkAcumulaVacac = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.grbCategoriaOcup.SuspendLayout();
            this.SuspendLayout();
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
            this.menuBar1.TabIndex = 0;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // starBar
            // 
            this.starBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.starBar.Location = new System.Drawing.Point(0, 412);
            this.starBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.starBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.starBar.Name = "starBar";
            this.starBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.starBar.Size = new System.Drawing.Size(480, 38);
            this.starBar.SysSession = this.sageSession1;
            this.starBar.TabIndex = 1;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // lkuNav
            // 
            this.lkuNav.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(176, 60);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(33, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 21;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.chkAcumulaVacac);
            this.grbCategoriaOcup.Controls.Add(this.txtResolucion);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Controls.Add(this.lblNombreTipo);
            this.grbCategoriaOcup.Controls.Add(this.txtNombre);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(13, 95);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(456, 309);
            this.grbCategoriaOcup.TabIndex = 18;
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
            // lblCodLicence
            // 
            this.lblCodLicence.AutoSize = true;
            this.lblCodLicence.Location = new System.Drawing.Point(13, 42);
            this.lblCodLicence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodLicence.Name = "lblCodLicence";
            this.lblCodLicence.Size = new System.Drawing.Size(128, 17);
            this.lblCodLicence.TabIndex = 20;
            this.lblCodLicence.Text = "Código de Licencia";
            // 
            // txtlicenceCod
            // 
            this.txtlicenceCod.Location = new System.Drawing.Point(13, 62);
            this.txtlicenceCod.Margin = new System.Windows.Forms.Padding(4);
            this.txtlicenceCod.MaxLength = 30;
            this.txtlicenceCod.Name = "txtlicenceCod";
            this.txtlicenceCod.Size = new System.Drawing.Size(158, 22);
            this.txtlicenceCod.TabIndex = 19;
            this.txtlicenceCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtlicenceCod_KeyPress);
            // 
            // chkAcumulaVacac
            // 
            this.chkAcumulaVacac.AutoSize = true;
            this.chkAcumulaVacac.Location = new System.Drawing.Point(16, 150);
            this.chkAcumulaVacac.Name = "chkAcumulaVacac";
            this.chkAcumulaVacac.Size = new System.Drawing.Size(161, 21);
            this.chkAcumulaVacac.TabIndex = 13;
            this.chkAcumulaVacac.Text = "Acumula Vacaciones";
            this.chkAcumulaVacac.UseVisualStyleBackColor = true;
            // 
            // frmLicencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.lblCodLicence);
            this.Controls.Add(this.txtlicenceCod);
            this.Controls.Add(this.starBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmLicencia";
            this.Text = "Gestión Licencia";
            this.Shown += new System.EventHandler(this.Form_Show);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar starBar;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.BindingSource MainBS;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.CheckBox chkAcumulaVacac;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblNombreTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodLicence;
        private System.Windows.Forms.TextBox txtlicenceCod;
    }
}

