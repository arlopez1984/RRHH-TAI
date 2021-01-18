namespace RHSMNC001
{
    partial class frmNivelEscolar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNivelEscolar));
            this.sageSession1 = new Net4Sage.SageSession();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.lblnivelcultural = new System.Windows.Forms.Label();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.lblResolución = new System.Windows.Forms.Label();
            this.txtCulturalLevID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.grbCategoriaOcup.SuspendLayout();
            this.SuspendLayout();
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // strbar
            // 
            this.strbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strbar.Location = new System.Drawing.Point(0, 412);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(514, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 0;
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(514, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
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
            this.lkuNav.Location = new System.Drawing.Point(173, 58);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 26;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // lblnivelcultural
            // 
            this.lblnivelcultural.AutoSize = true;
            this.lblnivelcultural.Location = new System.Drawing.Point(11, 39);
            this.lblnivelcultural.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnivelcultural.Name = "lblnivelcultural";
            this.lblnivelcultural.Size = new System.Drawing.Size(146, 17);
            this.lblnivelcultural.TabIndex = 24;
            this.lblnivelcultural.Text = "Nivel de Escolaridad *";
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.txtdescripcion);
            this.grbCategoriaOcup.Controls.Add(this.lblResolución);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(12, 92);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(492, 313);
            this.grbCategoriaOcup.TabIndex = 22;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Location = new System.Drawing.Point(5, 41);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescripcion.MaxLength = 8000;
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(474, 69);
            this.txtdescripcion.TabIndex = 12;
            // 
            // lblResolución
            // 
            this.lblResolución.AutoSize = true;
            this.lblResolución.Location = new System.Drawing.Point(7, 18);
            this.lblResolución.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResolución.Name = "lblResolución";
            this.lblResolución.Size = new System.Drawing.Size(82, 17);
            this.lblResolución.TabIndex = 11;
            this.lblResolución.Text = "Descripción";
            // 
            // txtCulturalLevID
            // 
            this.txtCulturalLevID.Location = new System.Drawing.Point(13, 60);
            this.txtCulturalLevID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCulturalLevID.MaxLength = 30;
            this.txtCulturalLevID.Name = "txtCulturalLevID";
            this.txtCulturalLevID.Size = new System.Drawing.Size(156, 22);
            this.txtCulturalLevID.TabIndex = 23;
            this.txtCulturalLevID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCulturalLevID_KeyPress);
            this.txtCulturalLevID.Validating += new System.ComponentModel.CancelEventHandler(this.IDValidate);
            this.txtCulturalLevID.Validated += new System.EventHandler(this.On_IDChange);
            // 
            // frmNivelEscolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 450);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.lblnivelcultural);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.txtCulturalLevID);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmNivelEscolar";
            this.Text = "Gestión a Nivel de Escolaridad";
            this.Shown += new System.EventHandler(this.Form_Show);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.StatusBar strbar;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.BindingSource MainBS;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.Label lblnivelcultural;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label lblResolución;
        private System.Windows.Forms.TextBox txtCulturalLevID;
    }
}

