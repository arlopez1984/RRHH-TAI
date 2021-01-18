namespace RHSMGE001
{
    partial class frmGrupoEscala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoEscala));
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.lblSalarioEscala = new System.Windows.Forms.Label();
            this.lblnombGrupo = new System.Windows.Forms.Label();
            this.txtnombreGrupo = new System.Windows.Forms.TextBox();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.lblDescripción = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.txtSalarioEscala = new System.Windows.Forms.TextBox();
            this.grbCategoriaOcup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.txtdescripcion);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Controls.Add(this.lblSalarioEscala);
            this.grbCategoriaOcup.Controls.Add(this.txtSalarioEscala);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(11, 93);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(436, 288);
            this.grbCategoriaOcup.TabIndex = 9;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // lblSalarioEscala
            // 
            this.lblSalarioEscala.AutoSize = true;
            this.lblSalarioEscala.Location = new System.Drawing.Point(9, 15);
            this.lblSalarioEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioEscala.Name = "lblSalarioEscala";
            this.lblSalarioEscala.Size = new System.Drawing.Size(107, 17);
            this.lblSalarioEscala.TabIndex = 8;
            this.lblSalarioEscala.Text = "Salario Escala *";
            // 
            // lblnombGrupo
            // 
            this.lblnombGrupo.AutoSize = true;
            this.lblnombGrupo.Location = new System.Drawing.Point(19, 41);
            this.lblnombGrupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombGrupo.Name = "lblnombGrupo";
            this.lblnombGrupo.Size = new System.Drawing.Size(123, 17);
            this.lblnombGrupo.TabIndex = 11;
            this.lblnombGrupo.Text = "Grupo de Escala *";
            // 
            // txtnombreGrupo
            // 
            this.txtnombreGrupo.Location = new System.Drawing.Point(19, 61);
            this.txtnombreGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombreGrupo.MaxLength = 30;
            this.txtnombreGrupo.Name = "txtnombreGrupo";
            this.txtnombreGrupo.Size = new System.Drawing.Size(156, 22);
            this.txtnombreGrupo.TabIndex = 10;
            this.txtnombreGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtnombreGrupo_KeyPress);
            this.txtnombreGrupo.Validated += new System.EventHandler(this.On_IDChange);
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(460, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 13;
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
            // strbar
            // 
            this.strbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strbar.Location = new System.Drawing.Point(0, 412);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(460, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 14;
            // 
            // lkuNav
            // 
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(184, 58);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 16;
            this.lkuNav.Tag = "";
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(12, 75);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(82, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Descripción";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Location = new System.Drawing.Point(11, 96);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescripcion.MaxLength = 8000;
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(418, 89);
            this.txtdescripcion.TabIndex = 12;
            // 
            // txtSalarioEscala
            // 
            this.txtSalarioEscala.AcceptsTab = true;
            this.txtSalarioEscala.Enabled = false;
            this.txtSalarioEscala.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSalarioEscala.Location = new System.Drawing.Point(11, 36);
            this.txtSalarioEscala.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalarioEscala.MaxLength = 50;
            this.txtSalarioEscala.Name = "txtSalarioEscala";
            this.txtSalarioEscala.Size = new System.Drawing.Size(132, 22);
            this.txtSalarioEscala.TabIndex = 7;
            this.txtSalarioEscala.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSalarioEscala_KeyPress);
            // 
            // frmGrupoEscala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 450);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.lblnombGrupo);
            this.Controls.Add(this.txtnombreGrupo);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmGrupoEscala";
            this.Text = "Gestión Grupo de Escala";
            this.Shown += new System.EventHandler(this.Form_Show);
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.Label lblSalarioEscala;
        private System.Windows.Forms.Label lblnombGrupo;
        private System.Windows.Forms.TextBox txtnombreGrupo;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.StatusBar strbar;
        private System.Windows.Forms.BindingSource MainBS;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.TextBox txtSalarioEscala;
    }
}

