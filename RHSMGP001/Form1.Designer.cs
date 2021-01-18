namespace RHSMGP001
{
    partial class frmPeriodo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeriodo));
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.rdbIniciarOperacion = new System.Windows.Forms.RadioButton();
            this.rdbCerrarOperacion = new System.Windows.Forms.RadioButton();
            this.grbCategoriaOcup = new System.Windows.Forms.GroupBox();
            this.lblTotalDias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.grbCategoriaOcup.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 412);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(513, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 0;
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
            this.menuBar1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(513, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Delete);
            // 
            // rdbIniciarOperacion
            // 
            this.rdbIniciarOperacion.AutoSize = true;
            this.rdbIniciarOperacion.Checked = true;
            this.rdbIniciarOperacion.Location = new System.Drawing.Point(15, 50);
            this.rdbIniciarOperacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbIniciarOperacion.Name = "rdbIniciarOperacion";
            this.rdbIniciarOperacion.Size = new System.Drawing.Size(136, 21);
            this.rdbIniciarOperacion.TabIndex = 2;
            this.rdbIniciarOperacion.TabStop = true;
            this.rdbIniciarOperacion.Text = "Iniciar Operación";
            this.rdbIniciarOperacion.UseVisualStyleBackColor = true;
            this.rdbIniciarOperacion.CheckedChanged += new System.EventHandler(this.RdbIniciarOperacion_CheckedChanged);
            // 
            // rdbCerrarOperacion
            // 
            this.rdbCerrarOperacion.AutoSize = true;
            this.rdbCerrarOperacion.Location = new System.Drawing.Point(165, 50);
            this.rdbCerrarOperacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbCerrarOperacion.Name = "rdbCerrarOperacion";
            this.rdbCerrarOperacion.Size = new System.Drawing.Size(139, 21);
            this.rdbCerrarOperacion.TabIndex = 3;
            this.rdbCerrarOperacion.TabStop = true;
            this.rdbCerrarOperacion.Text = "Cerrar Operación";
            this.rdbCerrarOperacion.UseVisualStyleBackColor = true;
            this.rdbCerrarOperacion.CheckedChanged += new System.EventHandler(this.RdbCerrarOperacion_CheckedChanged);
            // 
            // grbCategoriaOcup
            // 
            this.grbCategoriaOcup.Controls.Add(this.lblTotalDias);
            this.grbCategoriaOcup.Controls.Add(this.label1);
            this.grbCategoriaOcup.Controls.Add(this.dtpFechaFin);
            this.grbCategoriaOcup.Controls.Add(this.dtpFechaInicio);
            this.grbCategoriaOcup.Controls.Add(this.lblFechaFin);
            this.grbCategoriaOcup.Controls.Add(this.txtdescripcion);
            this.grbCategoriaOcup.Controls.Add(this.lblDescripción);
            this.grbCategoriaOcup.Controls.Add(this.lblFechaInicio);
            this.grbCategoriaOcup.Location = new System.Drawing.Point(19, 86);
            this.grbCategoriaOcup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCategoriaOcup.Name = "grbCategoriaOcup";
            this.grbCategoriaOcup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCategoriaOcup.Size = new System.Drawing.Size(483, 311);
            this.grbCategoriaOcup.TabIndex = 10;
            this.grbCategoriaOcup.TabStop = false;
            this.grbCategoriaOcup.Text = "Período";
            // 
            // lblTotalDias
            // 
            this.lblTotalDias.AutoSize = true;
            this.lblTotalDias.Location = new System.Drawing.Point(117, 212);
            this.lblTotalDias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDias.Name = "lblTotalDias";
            this.lblTotalDias.Size = new System.Drawing.Size(0, 17);
            this.lblTotalDias.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 212);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Total de días:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(181, 55);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(137, 22);
            this.dtpFechaFin.TabIndex = 15;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.DateTimePicker2_ValueChanged);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(11, 55);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(137, 22);
            this.dtpFechaInicio.TabIndex = 14;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.DtpFechaInicio_ValueChanged);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(177, 36);
            this.lblFechaFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(79, 17);
            this.lblFechaFin.TabIndex = 13;
            this.lblFechaFin.Text = "Fecha Fin *";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Location = new System.Drawing.Point(11, 112);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdescripcion.MaxLength = 8000;
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(460, 78);
            this.txtdescripcion.TabIndex = 12;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(12, 91);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(158, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Descripción del Período";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(8, 34);
            this.lblFechaInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(92, 17);
            this.lblFechaInicio.TabIndex = 8;
            this.lblFechaInicio.Text = "Fecha Inicio *";
            // 
            // frmPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 450);
            this.Controls.Add(this.grbCategoriaOcup);
            this.Controls.Add(this.rdbCerrarOperacion);
            this.Controls.Add(this.rdbIniciarOperacion);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPeriodo";
            this.Text = "Gestión Inicio/Cierre de Período";
            this.grbCategoriaOcup.ResumeLayout(false);
            this.grbCategoriaOcup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.RadioButton rdbIniciarOperacion;
        private System.Windows.Forms.RadioButton rdbCerrarOperacion;
        private System.Windows.Forms.GroupBox grbCategoriaOcup;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalDias;
    }
}

