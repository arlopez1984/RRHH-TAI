namespace RHSMTS001
{
    partial class frmTipoSubsidio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoSubsidio));
            this.sageSession1 = new Net4Sage.SageSession();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.txtPorCientoPagar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.lblNombreTipo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodSubsidio = new System.Windows.Forms.Label();
            this.txtSubsidioCod = new System.Windows.Forms.TextBox();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.grbCategoriaOcup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
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
            this.strbar.Size = new System.Drawing.Size(482, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 1;
            // 
            // lkuNav
            // 
            this.lkuNav.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(175, 60);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(33, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 14;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.txtPorCientoPagar);
            this.grbCategoriaOcup.Controls.Add(this.label1);
            this.grbCategoriaOcup.Controls.Add(this.txtResolucion);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Controls.Add(this.lblNombreTipo);
            this.grbCategoriaOcup.Controls.Add(this.txtNombre);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(13, 96);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(456, 309);
            this.grbCategoriaOcup.TabIndex = 11;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // txtPorCientoPagar
            // 
            this.txtPorCientoPagar.Enabled = false;
            this.txtPorCientoPagar.Location = new System.Drawing.Point(15, 99);
            this.txtPorCientoPagar.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorCientoPagar.MaxLength = 8000;
            this.txtPorCientoPagar.Name = "txtPorCientoPagar";
            this.txtPorCientoPagar.Size = new System.Drawing.Size(268, 22);
            this.txtPorCientoPagar.TabIndex = 14;
            this.txtPorCientoPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPorCientoPagar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Por Ciento a Pagar *";
            // 
            // txtResolucion
            // 
            this.txtResolucion.Enabled = false;
            this.txtResolucion.Location = new System.Drawing.Point(15, 163);
            this.txtResolucion.Margin = new System.Windows.Forms.Padding(4);
            this.txtResolucion.MaxLength = 50;
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.Size = new System.Drawing.Size(418, 22);
            this.txtResolucion.TabIndex = 12;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(16, 142);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(87, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Resolución *";
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
            // lblCodSubsidio
            // 
            this.lblCodSubsidio.AutoSize = true;
            this.lblCodSubsidio.Location = new System.Drawing.Point(13, 43);
            this.lblCodSubsidio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodSubsidio.Name = "lblCodSubsidio";
            this.lblCodSubsidio.Size = new System.Drawing.Size(139, 17);
            this.lblCodSubsidio.TabIndex = 13;
            this.lblCodSubsidio.Text = "Código de Subsidio *";
            // 
            // txtSubsidioCod
            // 
            this.txtSubsidioCod.Location = new System.Drawing.Point(13, 63);
            this.txtSubsidioCod.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubsidioCod.MaxLength = 30;
            this.txtSubsidioCod.Name = "txtSubsidioCod";
            this.txtSubsidioCod.Size = new System.Drawing.Size(158, 22);
            this.txtSubsidioCod.TabIndex = 12;
            this.txtSubsidioCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSubsidioCod_KeyPress);
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(482, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 15;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // frmTipoSubsidio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 450);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.lblCodSubsidio);
            this.Controls.Add(this.txtSubsidioCod);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmTipoSubsidio";
            this.Text = "Gestión Tipo Subsudio";
            this.Shown += new System.EventHandler(this.Form_Show);
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.StatusBar strbar;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.TextBox txtPorCientoPagar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblNombreTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodSubsidio;
        private System.Windows.Forms.TextBox txtSubsidioCod;
        private System.Windows.Forms.BindingSource MainBS;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

