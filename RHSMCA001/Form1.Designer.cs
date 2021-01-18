namespace RHSMCA001
{
    partial class frmCondicionesAnormales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondicionesAnormales));
            this.lblCodigo = new System.Windows.Forms.Label();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.lbltarifamonto = new System.Windows.Forms.Label();
            this.txtTarifaMonto = new System.Windows.Forms.TextBox();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.lblResolución = new System.Windows.Forms.Label();
            this.lblSalarioEscala = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodAnorCond = new System.Windows.Forms.TextBox();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.grbCategoriaOcup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(17, 44);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(61, 17);
            this.lblCodigo.TabIndex = 18;
            this.lblCodigo.Text = "Código *";
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.lbltarifamonto);
            this.grbCategoriaOcup.Controls.Add(this.txtTarifaMonto);
            this.grbCategoriaOcup.Controls.Add(this.txtResolucion);
            this.grbCategoriaOcup.Controls.Add(this.lblResolución);
            this.grbCategoriaOcup.Controls.Add(this.lblSalarioEscala);
            this.grbCategoriaOcup.Controls.Add(this.txtNombre);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(18, 97);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(492, 308);
            this.grbCategoriaOcup.TabIndex = 16;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // lbltarifamonto
            // 
            this.lbltarifamonto.AutoSize = true;
            this.lbltarifamonto.Location = new System.Drawing.Point(12, 76);
            this.lbltarifamonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarifamonto.Name = "lbltarifamonto";
            this.lbltarifamonto.Size = new System.Drawing.Size(100, 17);
            this.lbltarifamonto.TabIndex = 14;
            this.lbltarifamonto.Text = "Tarifa o Monto";
            // 
            // txtTarifaMonto
            // 
            this.txtTarifaMonto.Enabled = false;
            this.txtTarifaMonto.Location = new System.Drawing.Point(13, 97);
            this.txtTarifaMonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtTarifaMonto.MaxLength = 50;
            this.txtTarifaMonto.Name = "txtTarifaMonto";
            this.txtTarifaMonto.Size = new System.Drawing.Size(153, 22);
            this.txtTarifaMonto.TabIndex = 13;
            this.txtTarifaMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTarifaMonto_KeyPress);
            // 
            // txtResolucion
            // 
            this.txtResolucion.Enabled = false;
            this.txtResolucion.Location = new System.Drawing.Point(10, 167);
            this.txtResolucion.Margin = new System.Windows.Forms.Padding(4);
            this.txtResolucion.MaxLength = 8800;
            this.txtResolucion.Multiline = true;
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.Size = new System.Drawing.Size(474, 134);
            this.txtResolucion.TabIndex = 12;
            // 
            // lblResolución
            // 
            this.lblResolución.AutoSize = true;
            this.lblResolución.Location = new System.Drawing.Point(12, 144);
            this.lblResolución.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResolución.Name = "lblResolución";
            this.lblResolución.Size = new System.Drawing.Size(78, 17);
            this.lblResolución.TabIndex = 11;
            this.lblResolución.Text = "Resolución";
            // 
            // lblSalarioEscala
            // 
            this.lblSalarioEscala.AutoSize = true;
            this.lblSalarioEscala.Location = new System.Drawing.Point(9, 15);
            this.lblSalarioEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioEscala.Name = "lblSalarioEscala";
            this.lblSalarioEscala.Size = new System.Drawing.Size(168, 17);
            this.lblSalarioEscala.TabIndex = 8;
            this.lblSalarioEscala.Text = "Nombre de la Condición *";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(11, 36);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(153, 22);
            this.txtNombre.TabIndex = 7;
            // 
            // txtCodAnorCond
            // 
            this.txtCodAnorCond.Location = new System.Drawing.Point(19, 65);
            this.txtCodAnorCond.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodAnorCond.MaxLength = 5;
            this.txtCodAnorCond.Name = "txtCodAnorCond";
            this.txtCodAnorCond.Size = new System.Drawing.Size(156, 22);
            this.txtCodAnorCond.TabIndex = 17;
            this.txtCodAnorCond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodAnorCond_KeyPress);
            this.txtCodAnorCond.Validating += new System.ComponentModel.CancelEventHandler(this.IDValidate);
            this.txtCodAnorCond.Validated += new System.EventHandler(this.On_IDChange);
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(522, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 19;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // strbar
            // 
            this.strbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strbar.Location = new System.Drawing.Point(0, 412);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(522, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 20;
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
            this.lkuNav.Location = new System.Drawing.Point(179, 63);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 21;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // frmCondicionesAnormales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 450);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.txtCodAnorCond);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.MaximizeBox = false;
            this.Name = "frmCondicionesAnormales";
            this.Text = "Gestión a Condiciones Anormales.";
            this.Shown += new System.EventHandler(this.Form_Show);
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.Label lblResolución;
        private System.Windows.Forms.Label lblSalarioEscala;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodAnorCond;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar strbar;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.Label lbltarifamonto;
        private System.Windows.Forms.TextBox txtTarifaMonto;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
    }
}

