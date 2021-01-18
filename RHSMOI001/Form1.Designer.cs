namespace RHSMOI001
{
    partial class frmOtrasIncidencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtrasIncidencias));
            this.starBar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.txtNombreIncidencia = new System.Windows.Forms.TextBox();
            this.txtPorcientoaPagar = new System.Windows.Forms.TextBox();
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
            this.starBar.Size = new System.Drawing.Size(480, 38);
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
            this.menuBar1.Size = new System.Drawing.Size(480, 28);
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
            this.lkuNav.Location = new System.Drawing.Point(173, 57);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(33, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 21;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.lblnombre);
            this.grbCategoriaOcup.Controls.Add(this.label1);
            this.grbCategoriaOcup.Controls.Add(this.txtResolucion);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Controls.Add(this.txtNombreIncidencia);
            this.grbCategoriaOcup.Controls.Add(this.txtPorcientoaPagar);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(13, 92);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(456, 309);
            this.grbCategoriaOcup.TabIndex = 18;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(10, 16);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(67, 17);
            this.lblnombre.TabIndex = 24;
            this.lblnombre.Text = "Nombre *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "% Pagar *";
            // 
            // txtResolucion
            // 
            this.txtResolucion.Enabled = false;
            this.txtResolucion.Location = new System.Drawing.Point(11, 150);
            this.txtResolucion.Margin = new System.Windows.Forms.Padding(4);
            this.txtResolucion.MaxLength = 50;
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.Size = new System.Drawing.Size(434, 22);
            this.txtResolucion.TabIndex = 12;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(12, 129);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(87, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Resolución *";
            // 
            // txtNombreIncidencia
            // 
            this.txtNombreIncidencia.Location = new System.Drawing.Point(11, 37);
            this.txtNombreIncidencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreIncidencia.MaxLength = 30;
            this.txtNombreIncidencia.Name = "txtNombreIncidencia";
            this.txtNombreIncidencia.Size = new System.Drawing.Size(185, 22);
            this.txtNombreIncidencia.TabIndex = 23;
            // 
            // txtPorcientoaPagar
            // 
            this.txtPorcientoaPagar.Enabled = false;
            this.txtPorcientoaPagar.Location = new System.Drawing.Point(11, 90);
            this.txtPorcientoaPagar.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorcientoaPagar.MaxLength = 50;
            this.txtPorcientoaPagar.Name = "txtPorcientoaPagar";
            this.txtPorcientoaPagar.Size = new System.Drawing.Size(185, 22);
            this.txtPorcientoaPagar.TabIndex = 7;
            this.txtPorcientoaPagar.Text = "0";
            this.txtPorcientoaPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPorcientoaPagar_KeyPress);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(24, 57);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.MaxLength = 30;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(139, 22);
            this.txtCodigo.TabIndex = 24;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Código *";
            // 
            // frmOtrasIncidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.starBar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmOtrasIncidencias";
            this.Text = "Gestion Otras Incidencias";
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
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.TextBox txtPorcientoaPagar;
      
        private System.Windows.Forms.TextBox txtNombreIncidencia;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
    }
}

