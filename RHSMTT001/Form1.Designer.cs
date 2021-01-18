namespace RHSMTT001
{
    partial class frmTipoTrabajador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoTrabajador));
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.lblNombreTipo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodtrabaj = new System.Windows.Forms.Label();
            this.txtCodTrabaj = new System.Windows.Forms.TextBox();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.sageSession1 = new Net4Sage.SageSession();
            this.strBar = new Net4Sage.Controls.StatusBar();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.grbCategoriaOcup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.txtdescripcion);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Controls.Add(this.lblNombreTipo);
            this.grbCategoriaOcup.Controls.Add(this.txtNombre);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(25, 98);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(454, 293);
            this.grbCategoriaOcup.TabIndex = 6;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Location = new System.Drawing.Point(19, 103);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescripcion.MaxLength = 8000;
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(418, 89);
            this.txtdescripcion.TabIndex = 12;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(20, 82);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(82, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Descripción";
            // 
            // lblNombreTipo
            // 
            this.lblNombreTipo.AutoSize = true;
            this.lblNombreTipo.Location = new System.Drawing.Point(17, 22);
            this.lblNombreTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreTipo.Name = "lblNombreTipo";
            this.lblNombreTipo.Size = new System.Drawing.Size(67, 17);
            this.lblNombreTipo.TabIndex = 8;
            this.lblNombreTipo.Text = "Nombre *";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(19, 43);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(156, 22);
            this.txtNombre.TabIndex = 7;
            // 
            // lblCodtrabaj
            // 
            this.lblCodtrabaj.AutoSize = true;
            this.lblCodtrabaj.Location = new System.Drawing.Point(25, 48);
            this.lblCodtrabaj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodtrabaj.Name = "lblCodtrabaj";
            this.lblCodtrabaj.Size = new System.Drawing.Size(146, 17);
            this.lblCodtrabaj.TabIndex = 8;
            this.lblCodtrabaj.Text = "Código de Trabajador";
            // 
            // txtCodTrabaj
            // 
            this.txtCodTrabaj.Location = new System.Drawing.Point(25, 68);
            this.txtCodTrabaj.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodTrabaj.MaxLength = 30;
            this.txtCodTrabaj.Name = "txtCodTrabaj";
            this.txtCodTrabaj.Size = new System.Drawing.Size(156, 22);
            this.txtCodTrabaj.TabIndex = 7;
            this.txtCodTrabaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodTrabaj_KeyPress);
            this.txtCodTrabaj.Validating += new System.ComponentModel.CancelEventHandler(this.IDValidate);
            this.txtCodTrabaj.Validated += new System.EventHandler(this.On_IDChange);
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(497, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 9;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // lkuNav
            // 
            this.lkuNav.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(187, 65);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 10;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // strBar
            // 
            this.strBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strBar.Location = new System.Drawing.Point(0, 412);
            this.strBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strBar.Name = "strBar";
            this.strBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strBar.Size = new System.Drawing.Size(497, 38);
            this.strBar.SysSession = this.sageSession1;
            this.strBar.TabIndex = 11;
            // 
            // frmTipoTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 450);
            this.Controls.Add(this.strBar);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.lblCodtrabaj);
            this.Controls.Add(this.txtCodTrabaj);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmTipoTrabajador";
            this.Text = "Gestión a Tipo de Trabajador";
            this.Shown += new System.EventHandler(this.Form_Show);
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblNombreTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodtrabaj;
        private System.Windows.Forms.TextBox txtCodTrabaj;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private Net4Sage.Controls.StatusBar strBar;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.BindingSource MainBS;
    }
}

