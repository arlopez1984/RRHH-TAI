namespace RHSMCO001
{
    partial class frmCategoriaCientifica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoriaCientifica));
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.lblCategoriaName = new System.Windows.Forms.Label();
            this.txtCategoriaName = new System.Windows.Forms.TextBox();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.grbCategoriaOcup.SuspendLayout();
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
            this.menuBar1.Size = new System.Drawing.Size(487, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 0;
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
            this.grbCategoriaOcup.Controls.Add(this.txtdescripcion);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(13, 94);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(454, 293);
            this.grbCategoriaOcup.TabIndex = 1;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Location = new System.Drawing.Point(15, 40);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescripcion.MaxLength = 1000;
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(432, 89);
            this.txtdescripcion.TabIndex = 12;
            // 
            // lkuNav
            // 
            this.lkuNav.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(173, 61);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 3;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // lblCategoriaName
            // 
            this.lblCategoriaName.AutoSize = true;
            this.lblCategoriaName.Location = new System.Drawing.Point(13, 44);
            this.lblCategoriaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoriaName.Name = "lblCategoriaName";
            this.lblCategoriaName.Size = new System.Drawing.Size(132, 17);
            this.lblCategoriaName.TabIndex = 5;
            this.lblCategoriaName.Text = "Nombre Categoría *";
            // 
            // txtCategoriaName
            // 
            this.txtCategoriaName.Location = new System.Drawing.Point(13, 64);
            this.txtCategoriaName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategoriaName.MaxLength = 30;
            this.txtCategoriaName.Name = "txtCategoriaName";
            this.txtCategoriaName.Size = new System.Drawing.Size(156, 22);
            this.txtCategoriaName.TabIndex = 4;
            this.txtCategoriaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCategoriaName_KeyPress);
            this.txtCategoriaName.Validating += new System.ComponentModel.CancelEventHandler(this.IDValidate);
            this.txtCategoriaName.Validated += new System.EventHandler(this.On_IDChange);
            // 
            // strbar
            // 
            this.strbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strbar.Location = new System.Drawing.Point(0, 412);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(487, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 2;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(16, 19);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(82, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Descripción";
            // 
            // frmCategoriaCientifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 450);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.menuBar1);
            this.Controls.Add(this.lblCategoriaName);
            this.Controls.Add(this.txtCategoriaName);
            this.Controls.Add(this.lkuNav);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmCategoriaCientifica";
            this.Text = "Gestión a Categoría Científica";
            this.Shown += new System.EventHandler(this.Form_Show);
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.Label lblCategoriaName;
        private System.Windows.Forms.TextBox txtCategoriaName;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.BindingSource MainBS;
        private Net4Sage.Controls.StatusBar strbar;
        private System.Windows.Forms.Label lblDescripción;
    }
}

