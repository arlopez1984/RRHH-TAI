namespace RHSGTTT001
{
    partial class frmGestionTiempo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionTiempo));
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.grbSeleccionarTRabajador = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUnidadesOrganizativas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbTrabajadores = new System.Windows.Forms.GroupBox();
            this.lbldatosPersona = new System.Windows.Forms.Label();
            this.grbDatosJornalero = new System.Windows.Forms.GroupBox();
            this.lblhorasTrabajadas = new System.Windows.Forms.Label();
            this.txthorasTrabajadas = new System.Windows.Forms.TextBox();
            this.txtdiasFeriados = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHorasExtras = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grbCondicionesAnorm = new System.Windows.Forms.GroupBox();
            this.btnBuscarCondAnormales = new System.Windows.Forms.Button();
            this.lvCondiciones = new System.Windows.Forms.ListView();
            this.ColCondicion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCantidadHoras = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblPeriodoActivo = new System.Windows.Forms.Label();
            this.grbSeleccionarTRabajador.SuspendLayout();
            this.grbTrabajadores.SuspendLayout();
            this.grbDatosJornalero.SuspendLayout();
            this.grbCondicionesAnorm.SuspendLayout();
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
            this.menuBar1.Size = new System.Drawing.Size(752, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 0;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // strbar
            // 
            this.strbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strbar.Location = new System.Drawing.Point(0, 592);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(752, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 1;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // grbSeleccionarTRabajador
            // 
            this.grbSeleccionarTRabajador.Controls.Add(this.btnBuscar);
            this.grbSeleccionarTRabajador.Controls.Add(this.txtCi);
            this.grbSeleccionarTRabajador.Controls.Add(this.label2);
            this.grbSeleccionarTRabajador.Controls.Add(this.cmbUnidadesOrganizativas);
            this.grbSeleccionarTRabajador.Controls.Add(this.label1);
            this.grbSeleccionarTRabajador.Location = new System.Drawing.Point(12, 46);
            this.grbSeleccionarTRabajador.Name = "grbSeleccionarTRabajador";
            this.grbSeleccionarTRabajador.Size = new System.Drawing.Size(729, 68);
            this.grbSeleccionarTRabajador.TabIndex = 19;
            this.grbSeleccionarTRabajador.TabStop = false;
            this.grbSeleccionarTRabajador.Text = "Seleccionar Trabajador";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(623, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 29);
            this.btnBuscar.TabIndex = 94;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // txtCi
            // 
            this.txtCi.Location = new System.Drawing.Point(415, 33);
            this.txtCi.Margin = new System.Windows.Forms.Padding(4);
            this.txtCi.MaxLength = 50;
            this.txtCi.Name = "txtCi";
            this.txtCi.Size = new System.Drawing.Size(195, 22);
            this.txtCi.TabIndex = 80;
            this.txtCi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCi_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 92;
            this.label2.Text = "Unidad organizativa";
            // 
            // cmbUnidadesOrganizativas
            // 
            this.cmbUnidadesOrganizativas.FormattingEnabled = true;
            this.cmbUnidadesOrganizativas.Location = new System.Drawing.Point(162, 33);
            this.cmbUnidadesOrganizativas.Name = "cmbUnidadesOrganizativas";
            this.cmbUnidadesOrganizativas.Size = new System.Drawing.Size(195, 24);
            this.cmbUnidadesOrganizativas.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 79;
            this.label1.Text = "CI";
            // 
            // grbTrabajadores
            // 
            this.grbTrabajadores.Controls.Add(this.lbldatosPersona);
            this.grbTrabajadores.Location = new System.Drawing.Point(13, 126);
            this.grbTrabajadores.Name = "grbTrabajadores";
            this.grbTrabajadores.Size = new System.Drawing.Size(729, 61);
            this.grbTrabajadores.TabIndex = 20;
            this.grbTrabajadores.TabStop = false;
            this.grbTrabajadores.Text = "Trabajador";
            this.grbTrabajadores.Enter += new System.EventHandler(this.GrbTrabajadores_Enter);
            // 
            // lbldatosPersona
            // 
            this.lbldatosPersona.AutoSize = true;
            this.lbldatosPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatosPersona.Location = new System.Drawing.Point(24, 25);
            this.lbldatosPersona.Name = "lbldatosPersona";
            this.lbldatosPersona.Size = new System.Drawing.Size(0, 20);
            this.lbldatosPersona.TabIndex = 81;
            // 
            // grbDatosJornalero
            // 
            this.grbDatosJornalero.Controls.Add(this.lblhorasTrabajadas);
            this.grbDatosJornalero.Controls.Add(this.txthorasTrabajadas);
            this.grbDatosJornalero.Controls.Add(this.txtdiasFeriados);
            this.grbDatosJornalero.Controls.Add(this.label8);
            this.grbDatosJornalero.Controls.Add(this.label11);
            this.grbDatosJornalero.Controls.Add(this.txtHorasExtras);
            this.grbDatosJornalero.Controls.Add(this.label12);
            this.grbDatosJornalero.Location = new System.Drawing.Point(13, 254);
            this.grbDatosJornalero.Name = "grbDatosJornalero";
            this.grbDatosJornalero.Size = new System.Drawing.Size(728, 90);
            this.grbDatosJornalero.TabIndex = 24;
            this.grbDatosJornalero.TabStop = false;
            this.grbDatosJornalero.Text = "Datos del tiempo trabajado";
            this.grbDatosJornalero.Enter += new System.EventHandler(this.GrbDatosJornalero_Enter);
            // 
            // lblhorasTrabajadas
            // 
            this.lblhorasTrabajadas.AutoSize = true;
            this.lblhorasTrabajadas.Location = new System.Drawing.Point(7, 33);
            this.lblhorasTrabajadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhorasTrabajadas.Name = "lblhorasTrabajadas";
            this.lblhorasTrabajadas.Size = new System.Drawing.Size(131, 17);
            this.lblhorasTrabajadas.TabIndex = 101;
            this.lblhorasTrabajadas.Text = "Horas Trabajadas *";
            // 
            // txthorasTrabajadas
            // 
            this.txthorasTrabajadas.Location = new System.Drawing.Point(10, 53);
            this.txthorasTrabajadas.Margin = new System.Windows.Forms.Padding(4);
            this.txthorasTrabajadas.MaxLength = 50;
            this.txthorasTrabajadas.Name = "txthorasTrabajadas";
            this.txthorasTrabajadas.Size = new System.Drawing.Size(161, 22);
            this.txthorasTrabajadas.TabIndex = 100;
            this.txthorasTrabajadas.Text = "0";
            this.txthorasTrabajadas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxthorasTrabajadas_KeyPress);
            // 
            // txtdiasFeriados
            // 
            this.txtdiasFeriados.Location = new System.Drawing.Point(191, 53);
            this.txtdiasFeriados.Margin = new System.Windows.Forms.Padding(4);
            this.txtdiasFeriados.MaxLength = 50;
            this.txtdiasFeriados.Name = "txtdiasFeriados";
            this.txtdiasFeriados.Size = new System.Drawing.Size(161, 22);
            this.txtdiasFeriados.TabIndex = 99;
            this.txtdiasFeriados.Text = "0";
            this.txtdiasFeriados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtdiasFeriados_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(188, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 17);
            this.label8.TabIndex = 98;
            this.label8.Text = "Feriados Trabajados *";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(365, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 17);
            this.label11.TabIndex = 93;
            this.label11.Text = "Cantidad horas extras *";
            this.label11.Click += new System.EventHandler(this.Label11_Click);
            // 
            // txtHorasExtras
            // 
            this.txtHorasExtras.Location = new System.Drawing.Point(368, 53);
            this.txtHorasExtras.Margin = new System.Windows.Forms.Padding(4);
            this.txtHorasExtras.MaxLength = 50;
            this.txtHorasExtras.Name = "txtHorasExtras";
            this.txtHorasExtras.Size = new System.Drawing.Size(161, 22);
            this.txtHorasExtras.TabIndex = 82;
            this.txtHorasExtras.Text = "0";
            this.txtHorasExtras.TextChanged += new System.EventHandler(this.TxtHorasExtras_TextChanged);
            this.txtHorasExtras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHorasExtras_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(553, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 20);
            this.label12.TabIndex = 81;
            // 
            // grbCondicionesAnorm
            // 
            this.grbCondicionesAnorm.Controls.Add(this.btnBuscarCondAnormales);
            this.grbCondicionesAnorm.Controls.Add(this.lvCondiciones);
            this.grbCondicionesAnorm.Location = new System.Drawing.Point(12, 366);
            this.grbCondicionesAnorm.Name = "grbCondicionesAnorm";
            this.grbCondicionesAnorm.Size = new System.Drawing.Size(728, 187);
            this.grbCondicionesAnorm.TabIndex = 25;
            this.grbCondicionesAnorm.TabStop = false;
            this.grbCondicionesAnorm.Text = "Condiciones Anormales";
            this.grbCondicionesAnorm.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // btnBuscarCondAnormales
            // 
            this.btnBuscarCondAnormales.Location = new System.Drawing.Point(623, 137);
            this.btnBuscarCondAnormales.Name = "btnBuscarCondAnormales";
            this.btnBuscarCondAnormales.Size = new System.Drawing.Size(93, 29);
            this.btnBuscarCondAnormales.TabIndex = 95;
            this.btnBuscarCondAnormales.Text = "Buscar";
            this.btnBuscarCondAnormales.UseVisualStyleBackColor = true;
            this.btnBuscarCondAnormales.Click += new System.EventHandler(this.BtnBuscarCondAnormales_Click);
            // 
            // lvCondiciones
            // 
            this.lvCondiciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCondicion,
            this.ColCantidadHoras});
            this.lvCondiciones.GridLines = true;
            this.lvCondiciones.HideSelection = false;
            this.lvCondiciones.Location = new System.Drawing.Point(5, 21);
            this.lvCondiciones.Name = "lvCondiciones";
            this.lvCondiciones.Size = new System.Drawing.Size(612, 145);
            this.lvCondiciones.TabIndex = 0;
            this.lvCondiciones.UseCompatibleStateImageBehavior = false;
            this.lvCondiciones.View = System.Windows.Forms.View.Details;
            this.lvCondiciones.SelectedIndexChanged += new System.EventHandler(this.LvCondiciones_SelectedIndexChanged);
            // 
            // ColCondicion
            // 
            this.ColCondicion.Text = "Condición Anormal";
            this.ColCondicion.Width = 300;
            // 
            // ColCantidadHoras
            // 
            this.ColCantidadHoras.Text = "Cantidad de Horas";
            this.ColCantidadHoras.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 94;
            this.label5.Text = "Período Activo:";
            // 
            // lblPeriodoActivo
            // 
            this.lblPeriodoActivo.AutoSize = true;
            this.lblPeriodoActivo.Location = new System.Drawing.Point(144, 206);
            this.lblPeriodoActivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodoActivo.Name = "lblPeriodoActivo";
            this.lblPeriodoActivo.Size = new System.Drawing.Size(0, 17);
            this.lblPeriodoActivo.TabIndex = 95;
            // 
            // frmGestionTiempo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 630);
            this.Controls.Add(this.lblPeriodoActivo);
            this.Controls.Add(this.grbDatosJornalero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grbCondicionesAnorm);
            this.Controls.Add(this.grbTrabajadores);
            this.Controls.Add(this.grbSeleccionarTRabajador);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmGestionTiempo";
            this.Text = "Gestión Tiempo Total Trabajado";
            this.Load += new System.EventHandler(this.FrmGestionTiempo_Load);
            this.grbSeleccionarTRabajador.ResumeLayout(false);
            this.grbSeleccionarTRabajador.PerformLayout();
            this.grbTrabajadores.ResumeLayout(false);
            this.grbTrabajadores.PerformLayout();
            this.grbDatosJornalero.ResumeLayout(false);
            this.grbDatosJornalero.PerformLayout();
            this.grbCondicionesAnorm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar strbar;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.GroupBox grbSeleccionarTRabajador;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUnidadesOrganizativas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbTrabajadores;
        private System.Windows.Forms.Label lbldatosPersona;
        private System.Windows.Forms.GroupBox grbDatosJornalero;
        private System.Windows.Forms.Label lblhorasTrabajadas;
        private System.Windows.Forms.TextBox txthorasTrabajadas;
        private System.Windows.Forms.TextBox txtdiasFeriados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHorasExtras;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grbCondicionesAnorm;
        private System.Windows.Forms.ListView lvCondiciones;
        private System.Windows.Forms.Button btnBuscarCondAnormales;
        private System.Windows.Forms.ColumnHeader ColCondicion;
        private System.Windows.Forms.ColumnHeader ColCantidadHoras;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPeriodoActivo;
    }
}

