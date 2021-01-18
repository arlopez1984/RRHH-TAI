namespace RHSMCLO001
{
    partial class frmClasificacionOcupacional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClasificacionOcupacional));
            this.sageSession1 = new Net4Sage.SageSession();
            this.label3 = new System.Windows.Forms.Label();
            this.strBar = new Net4Sage.Controls.StatusBar();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.menuBar2 = new Net4Sage.Controls.MenuBar();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.lbldescripcion = new System.Windows.Forms.Label();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.grbCategoriaOcup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Especialidad *";
            // 
            // strBar
            // 
            this.strBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strBar.Location = new System.Drawing.Point(0, 412);
            this.strBar.Margin = new System.Windows.Forms.Padding(5);
            this.strBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strBar.Name = "strBar";
            this.strBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strBar.Size = new System.Drawing.Size(487, 38);
            this.strBar.SysSession = this.sageSession1;
            this.strBar.TabIndex = 8;
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(16, 93);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(454, 288);
            this.grbCategoriaOcup.TabIndex = 10;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(12, 21);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(82, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Descripción";
            // 
            // menuBar2
            // 
            this.menuBar2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar2.Location = new System.Drawing.Point(0, 0);
            this.menuBar2.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar2.Name = "menuBar2";
            this.menuBar2.ShowItemToolTips = true;
            this.menuBar2.Size = new System.Drawing.Size(464, 28);
            this.menuBar2.SysSession = null;
            this.menuBar2.TabIndex = 0;
            this.menuBar2.Text = "menuBar2";
            this.menuBar2.OnSave += new System.EventHandler(this.On_Save);
            this.menuBar2.OnCancel += new System.EventHandler(this.On_Cancel);
            this.menuBar2.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.On_Delete);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 376);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(464, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtdescripcion);
            this.groupBox1.Controls.Add(this.lbldescripcion);
            this.groupBox1.Location = new System.Drawing.Point(14, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 269);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Location = new System.Drawing.Point(8, 35);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescripcion.MaxLength = 8000;
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(418, 89);
            this.txtdescripcion.TabIndex = 12;
            // 
            // lbldescripcion
            // 
            this.lbldescripcion.AutoSize = true;
            this.lbldescripcion.Location = new System.Drawing.Point(9, 14);
            this.lbldescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldescripcion.Name = "lbldescripcion";
            this.lbldescripcion.Size = new System.Drawing.Size(82, 17);
            this.lbldescripcion.TabIndex = 11;
            this.lbldescripcion.Text = "Descripción";
            // 
            // lkuNav
            // 
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(176, 64);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 19;
            this.lkuNav.Tag = "";
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LookupButton1_OnLookupReturn);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(11, 47);
            this.lblEspecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(97, 17);
            this.lblEspecialidad.TabIndex = 18;
            this.lblEspecialidad.Text = "Especialidad *";
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(14, 68);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(154, 22);
            this.txt.TabIndex = 20;
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // frmClasificacionOcupacional
            // 
            this.ClientSize = new System.Drawing.Size(464, 414);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuBar2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar2;
            this.Name = "frmClasificacionOcupacional";
            this.Text = "Gestión Clasificación Ocupacional";
            this.Shown += new System.EventHandler(this.Form_Show);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.Label label3;
        private Net4Sage.Controls.StatusBar strBar;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.Label lblDescripción;
        private Net4Sage.Controls.MenuBar menuBar2;
        private Net4Sage.Controls.StatusBar statusBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label lbldescripcion;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txt;
    }
}

