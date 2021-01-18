namespace RHSMDE001
{
    partial class frmDatosEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatosEmpresa));
            this.sageSession1 = new Net4Sage.SageSession();
            this.starBar = new Net4Sage.Controls.StatusBar();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSector = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cmbMunicipality = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.cmbsegmento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbldireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.masktxtCuenta = new System.Windows.Forms.MaskedTextBox();
            this.txtContravalorPagoAdicional = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContravalorPagoCuC = new System.Windows.Forms.TextBox();
            this.lblContravalorpagoCUC = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfax = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.lblNombreTipo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodEmpresa = new System.Windows.Forms.Label();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.txtCodEmpresa = new System.Windows.Forms.TextBox();
            this.grbCategoriaOcup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // starBar
            // 
            this.starBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.starBar.Location = new System.Drawing.Point(0, 436);
            this.starBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.starBar.MinimumSize = new System.Drawing.Size(0, 38);
            this.starBar.Name = "starBar";
            this.starBar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.starBar.Size = new System.Drawing.Size(832, 38);
            this.starBar.SysSession = this.sageSession1;
            this.starBar.TabIndex = 0;
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(832, 28);
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
            this.lkuNav.Location = new System.Drawing.Point(175, 60);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = this.sageSession1;
            this.lkuNav.TabIndex = 14;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.label5);
            this.grbCategoriaOcup.Controls.Add(this.txtSector);
            this.grbCategoriaOcup.Controls.Add(this.label4);
            this.grbCategoriaOcup.Controls.Add(this.lblMunicipio);
            this.grbCategoriaOcup.Controls.Add(this.txtCodigo);
            this.grbCategoriaOcup.Controls.Add(this.cmbMunicipality);
            this.grbCategoriaOcup.Controls.Add(this.lblProvincia);
            this.grbCategoriaOcup.Controls.Add(this.cmbProvince);
            this.grbCategoriaOcup.Controls.Add(this.cmbsegmento);
            this.grbCategoriaOcup.Controls.Add(this.label3);
            this.grbCategoriaOcup.Controls.Add(this.lbldireccion);
            this.grbCategoriaOcup.Controls.Add(this.txtDireccion);
            this.grbCategoriaOcup.Controls.Add(this.masktxtCuenta);
            this.grbCategoriaOcup.Controls.Add(this.txtContravalorPagoAdicional);
            this.grbCategoriaOcup.Controls.Add(this.label2);
            this.grbCategoriaOcup.Controls.Add(this.txtContravalorPagoCuC);
            this.grbCategoriaOcup.Controls.Add(this.lblContravalorpagoCUC);
            this.grbCategoriaOcup.Controls.Add(this.lblCuenta);
            this.grbCategoriaOcup.Controls.Add(this.txtcorreo);
            this.grbCategoriaOcup.Controls.Add(this.label1);
            this.grbCategoriaOcup.Controls.Add(this.txtfax);
            this.grbCategoriaOcup.Controls.Add(this.lblTelefono);
            this.grbCategoriaOcup.Controls.Add(this.txttelefono);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Controls.Add(this.lblNombreTipo);
            this.grbCategoriaOcup.Controls.Add(this.txtNombre);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(11, 92);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Size = new System.Drawing.Size(809, 342);
            this.grbCategoriaOcup.TabIndex = 11;
            this.grbCategoriaOcup.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(544, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Sector";
            // 
            // txtSector
            // 
            this.txtSector.Enabled = false;
            this.txtSector.Location = new System.Drawing.Point(547, 38);
            this.txtSector.Margin = new System.Windows.Forms.Padding(4);
            this.txtSector.MaxLength = 50;
            this.txtSector.Name = "txtSector";
            this.txtSector.Size = new System.Drawing.Size(247, 22);
            this.txtSector.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Codigo *";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(281, 192);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(67, 17);
            this.lblMunicipio.TabIndex = 53;
            this.lblMunicipio.Text = "Municipio";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(281, 38);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.MaxLength = 30;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(247, 22);
            this.txtCodigo.TabIndex = 12;
            this.txtCodigo.Validated += new System.EventHandler(this.On_IDChange);
            // 
            // cmbMunicipality
            // 
            this.cmbMunicipality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMunicipality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMunicipality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipality.FormattingEnabled = true;
            this.cmbMunicipality.Location = new System.Drawing.Point(280, 212);
            this.cmbMunicipality.Name = "cmbMunicipality";
            this.cmbMunicipality.Size = new System.Drawing.Size(247, 24);
            this.cmbMunicipality.TabIndex = 54;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(14, 192);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(70, 17);
            this.lblProvincia.TabIndex = 51;
            this.lblProvincia.Text = "Provincia ";
            // 
            // cmbProvince
            // 
            this.cmbProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Location = new System.Drawing.Point(17, 212);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(247, 24);
            this.cmbProvince.TabIndex = 52;
            this.cmbProvince.SelectedIndexChanged += new System.EventHandler(this.CmbProvince_SelectedIndexChanged_1);
            // 
            // cmbsegmento
            // 
            this.cmbsegmento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsegmento.FormattingEnabled = true;
            this.cmbsegmento.Location = new System.Drawing.Point(547, 211);
            this.cmbsegmento.Name = "cmbsegmento";
            this.cmbsegmento.Size = new System.Drawing.Size(247, 24);
            this.cmbsegmento.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(545, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "Segmento Cuenta de Centro Costo *";
            // 
            // lbldireccion
            // 
            this.lbldireccion.AutoSize = true;
            this.lbldireccion.Location = new System.Drawing.Point(14, 252);
            this.lbldireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldireccion.Name = "lbldireccion";
            this.lbldireccion.Size = new System.Drawing.Size(76, 17);
            this.lbldireccion.TabIndex = 48;
            this.lbldireccion.Text = "Dirección *";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(15, 272);
            this.txtDireccion.MaxLength = 8000;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(779, 55);
            this.txtDireccion.TabIndex = 21;
            // 
            // masktxtCuenta
            // 
            this.masktxtCuenta.Location = new System.Drawing.Point(17, 150);
            this.masktxtCuenta.Mask = "####-####-####-####";
            this.masktxtCuenta.Name = "masktxtCuenta";
            this.masktxtCuenta.Size = new System.Drawing.Size(247, 22);
            this.masktxtCuenta.TabIndex = 47;
            // 
            // txtContravalorPagoAdicional
            // 
            this.txtContravalorPagoAdicional.Enabled = false;
            this.txtContravalorPagoAdicional.Location = new System.Drawing.Point(281, 151);
            this.txtContravalorPagoAdicional.Margin = new System.Windows.Forms.Padding(4);
            this.txtContravalorPagoAdicional.MaxLength = 50;
            this.txtContravalorPagoAdicional.Name = "txtContravalorPagoAdicional";
            this.txtContravalorPagoAdicional.Size = new System.Drawing.Size(247, 22);
            this.txtContravalorPagoAdicional.TabIndex = 46;
            this.txtContravalorPagoAdicional.Text = "0";
            this.txtContravalorPagoAdicional.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContravalorEstimpendio_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Contravalor Pago Adicional *";
            // 
            // txtContravalorPagoCuC
            // 
            this.txtContravalorPagoCuC.Enabled = false;
            this.txtContravalorPagoCuC.Location = new System.Drawing.Point(547, 151);
            this.txtContravalorPagoCuC.Margin = new System.Windows.Forms.Padding(4);
            this.txtContravalorPagoCuC.MaxLength = 50;
            this.txtContravalorPagoCuC.Name = "txtContravalorPagoCuC";
            this.txtContravalorPagoCuC.Size = new System.Drawing.Size(247, 22);
            this.txtContravalorPagoCuC.TabIndex = 44;
            this.txtContravalorPagoCuC.Text = "0";
            this.txtContravalorPagoCuC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContravalorPagoCuC_KeyPress);
            // 
            // lblContravalorpagoCUC
            // 
            this.lblContravalorpagoCUC.AutoSize = true;
            this.lblContravalorpagoCUC.Location = new System.Drawing.Point(545, 130);
            this.lblContravalorpagoCUC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContravalorpagoCUC.Name = "lblContravalorpagoCUC";
            this.lblContravalorpagoCUC.Size = new System.Drawing.Size(198, 17);
            this.lblContravalorpagoCUC.TabIndex = 43;
            this.lblContravalorpagoCUC.Text = "Contravalor Pago Alimenticio *";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(14, 130);
            this.lblCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(122, 17);
            this.lblCuenta.TabIndex = 18;
            this.lblCuenta.Text = "Cuenta Bancaria *";
            // 
            // txtcorreo
            // 
            this.txtcorreo.Enabled = false;
            this.txtcorreo.Location = new System.Drawing.Point(548, 93);
            this.txtcorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtcorreo.MaxLength = 50;
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(247, 22);
            this.txtcorreo.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fax";
            // 
            // txtfax
            // 
            this.txtfax.Enabled = false;
            this.txtfax.Location = new System.Drawing.Point(281, 93);
            this.txtfax.Margin = new System.Windows.Forms.Padding(4);
            this.txtfax.MaxLength = 50;
            this.txtfax.Name = "txtfax";
            this.txtfax.Size = new System.Drawing.Size(247, 22);
            this.txtfax.TabIndex = 15;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(14, 72);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(64, 17);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txttelefono
            // 
            this.txttelefono.Enabled = false;
            this.txttelefono.Location = new System.Drawing.Point(17, 93);
            this.txttelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txttelefono.MaxLength = 50;
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(247, 22);
            this.txttelefono.TabIndex = 13;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(545, 74);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(125, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Correo Electrónico";
            // 
            // lblNombreTipo
            // 
            this.lblNombreTipo.AutoSize = true;
            this.lblNombreTipo.Location = new System.Drawing.Point(13, 18);
            this.lblNombreTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreTipo.Name = "lblNombreTipo";
            this.lblNombreTipo.Size = new System.Drawing.Size(67, 17);
            this.lblNombreTipo.TabIndex = 8;
            this.lblNombreTipo.Text = "Nombre *";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(15, 38);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(247, 22);
            this.txtNombre.TabIndex = 7;
            // 
            // lblCodEmpresa
            // 
            this.lblCodEmpresa.AutoSize = true;
            this.lblCodEmpresa.Location = new System.Drawing.Point(11, 42);
            this.lblCodEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodEmpresa.Name = "lblCodEmpresa";
            this.lblCodEmpresa.Size = new System.Drawing.Size(73, 17);
            this.lblCodEmpresa.TabIndex = 13;
            this.lblCodEmpresa.Text = "Empresa *";
            // 
            // txtCodEmpresa
            // 
            this.txtCodEmpresa.Enabled = false;
            this.txtCodEmpresa.Location = new System.Drawing.Point(13, 63);
            this.txtCodEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodEmpresa.MaxLength = 50;
            this.txtCodEmpresa.Name = "txtCodEmpresa";
            this.txtCodEmpresa.Size = new System.Drawing.Size(159, 22);
            this.txtCodEmpresa.TabIndex = 55;
            this.txtCodEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodEmpresa_KeyPress_1);
            // 
            // frmDatosEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 474);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.txtCodEmpresa);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.lblCodEmpresa);
            this.Controls.Add(this.starBar);
            this.Controls.Add(this.menuBar1);
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmDatosEmpresa";
            this.Text = "Gestión Datos Empresa";
            this.Shown += new System.EventHandler(this.Form_Show);
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.StatusBar starBar;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfax;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblNombreTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodEmpresa;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtContravalorPagoAdicional;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContravalorPagoCuC;
        private System.Windows.Forms.Label lblContravalorpagoCUC;
        private System.Windows.Forms.MaskedTextBox masktxtCuenta;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.Label lbldireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbsegmento;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.ComboBox cmbMunicipality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSector;
    }
}

