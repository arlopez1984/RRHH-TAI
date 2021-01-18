namespace RHSMTD001
{
    partial class frmtipoDeduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtipoDeduccion));
            this.starBar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtNombrededuccion = new System.Windows.Forms.TextBox();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.grbCategoriaOcup.SuspendLayout();
            this.SuspendLayout();
            // 
            // starBar
            // 
            this.starBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.starBar.Location = new System.Drawing.Point(0, 412);
            this.starBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.starBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.starBar.Name = "starBar";
            this.starBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.starBar.Size = new System.Drawing.Size(483, 38);
            this.starBar.SysSession = this.sageSession1;
            this.starBar.TabIndex = 0;
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
            this.menuBar1.Size = new System.Drawing.Size(483, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(6, 20);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(67, 17);
            this.lblnombre.TabIndex = 28;
            this.lblnombre.Text = "Nombre *";
            // 
            // txtNombrededuccion
            // 
            this.txtNombrededuccion.Location = new System.Drawing.Point(8, 41);
            this.txtNombrededuccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombrededuccion.MaxLength = 30;
            this.txtNombrededuccion.Name = "txtNombrededuccion";
            this.txtNombrededuccion.Size = new System.Drawing.Size(193, 22);
            this.txtNombrededuccion.TabIndex = 27;
            // 
            // lkuNav
            // 
            this.lkuNav.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(178, 61);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(33, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 26;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.lblnombre);
            this.grbCategoriaOcup.Controls.Add(this.txtNombrededuccion);
            this.grbCategoriaOcup.Controls.Add(this.label1);
            this.grbCategoriaOcup.Controls.Add(this.txtDescripcion);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(13, 94);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(456, 309);
            this.grbCategoriaOcup.TabIndex = 25;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(11, 97);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(438, 87);
            this.txtDescripcion.TabIndex = 7;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(20, 65);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.MaxLength = 30;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(152, 22);
            this.txtCodigo.TabIndex = 28;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Código *";
            // 
            // frmtipoDeduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.starBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmtipoDeduccion";
            this.Text = "Gestión Tipo Deducciones";
            this.Shown += new System.EventHandler(this.Form_Show);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar starBar;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtNombrededuccion;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
    }
}

