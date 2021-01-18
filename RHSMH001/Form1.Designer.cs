namespace RHSMH001
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlDatosJornada = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lvciclos = new System.Windows.Forms.ListView();
            this.ColConsecutivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColInicio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColFin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColTiempoTrabajo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDuracion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDescanso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.nmDia = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTiempoTrabajo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lbldescripcion = new System.Windows.Forms.Label();
            this.lblnombreHorario = new System.Windows.Forms.Label();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.txtnombreHorario = new System.Windows.Forms.TextBox();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDatosJornada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatosJornada
            // 
            this.pnlDatosJornada.Controls.Add(this.btnAdd);
            this.pnlDatosJornada.Controls.Add(this.btnEliminar);
            this.pnlDatosJornada.Controls.Add(this.lvciclos);
            this.pnlDatosJornada.Controls.Add(this.label8);
            this.pnlDatosJornada.Controls.Add(this.label40);
            this.pnlDatosJornada.Controls.Add(this.nmDia);
            this.pnlDatosJornada.Controls.Add(this.label10);
            this.pnlDatosJornada.Controls.Add(this.label9);
            this.pnlDatosJornada.Controls.Add(this.dtpInicio);
            this.pnlDatosJornada.Controls.Add(this.dtpFin);
            this.pnlDatosJornada.Controls.Add(this.label1);
            this.pnlDatosJornada.Controls.Add(this.dtpTiempoTrabajo);
            this.pnlDatosJornada.Controls.Add(this.dateTimePicker1);
            this.pnlDatosJornada.Enabled = false;
            this.pnlDatosJornada.Location = new System.Drawing.Point(12, 97);
            this.pnlDatosJornada.Name = "pnlDatosJornada";
            this.pnlDatosJornada.Size = new System.Drawing.Size(808, 394);
            this.pnlDatosJornada.TabIndex = 70;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(698, 46);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 29);
            this.btnAdd.TabIndex = 79;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(701, 362);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(93, 29);
            this.btnEliminar.TabIndex = 77;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // lvciclos
            // 
            this.lvciclos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColConsecutivo,
            this.ColInicio,
            this.ColFin,
            this.ColTiempoTrabajo,
            this.ColDuracion,
            this.ColDescanso});
            this.lvciclos.FullRowSelect = true;
            this.lvciclos.GridLines = true;
            this.lvciclos.HideSelection = false;
            this.lvciclos.Location = new System.Drawing.Point(9, 93);
            this.lvciclos.Name = "lvciclos";
            this.lvciclos.Size = new System.Drawing.Size(785, 263);
            this.lvciclos.TabIndex = 77;
            this.lvciclos.UseCompatibleStateImageBehavior = false;
            this.lvciclos.View = System.Windows.Forms.View.Details;
            // 
            // ColConsecutivo
            // 
            this.ColConsecutivo.Text = "Día";
            this.ColConsecutivo.Width = 40;
            // 
            // ColInicio
            // 
            this.ColInicio.Text = "Hora Inicio";
            this.ColInicio.Width = 105;
            // 
            // ColFin
            // 
            this.ColFin.Text = "Hora Fin";
            this.ColFin.Width = 105;
            // 
            // ColTiempoTrabajo
            // 
            this.ColTiempoTrabajo.Text = "Tiempo de Trabajo";
            this.ColTiempoTrabajo.Width = 110;
            // 
            // ColDuracion
            // 
            this.ColDuracion.Text = "Duración Jornada";
            this.ColDuracion.Width = 110;
            // 
            // ColDescanso
            // 
            this.ColDescanso.Text = "Tiempo Descanso";
            this.ColDescanso.Width = 110;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 75;
            this.label8.Text = "Hora Fin";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(105, 56);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(75, 17);
            this.label40.TabIndex = 45;
            this.label40.Text = "Hora Inicio";
            // 
            // nmDia
            // 
            this.nmDia.Enabled = false;
            this.nmDia.Location = new System.Drawing.Point(36, 51);
            this.nmDia.Name = "nmDia";
            this.nmDia.Size = new System.Drawing.Size(50, 22);
            this.nmDia.TabIndex = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 55);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 17);
            this.label10.TabIndex = 70;
            this.label10.Text = "Día";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 17);
            this.label9.TabIndex = 69;
            this.label9.Text = "Datos Jornada";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpInicio.Location = new System.Drawing.Point(182, 51);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.ShowUpDown = true;
            this.dtpInicio.Size = new System.Drawing.Size(94, 22);
            this.dtpInicio.TabIndex = 47;
            this.dtpInicio.Value = new System.DateTime(2020, 9, 15, 0, 0, 0, 0);
            this.dtpInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtpInicio_KeyPress);
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFin.Location = new System.Drawing.Point(360, 51);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.ShowUpDown = true;
            this.dtpFin.Size = new System.Drawing.Size(93, 22);
            this.dtpFin.TabIndex = 52;
            this.dtpFin.Value = new System.DateTime(2020, 9, 15, 0, 0, 0, 0);
            this.dtpFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtpFin_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(467, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Tiempo de trabajo";
            // 
            // dtpTiempoTrabajo
            // 
            this.dtpTiempoTrabajo.CustomFormat = "";
            this.dtpTiempoTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTiempoTrabajo.Location = new System.Drawing.Point(594, 51);
            this.dtpTiempoTrabajo.Name = "dtpTiempoTrabajo";
            this.dtpTiempoTrabajo.ShowUpDown = true;
            this.dtpTiempoTrabajo.Size = new System.Drawing.Size(93, 22);
            this.dtpTiempoTrabajo.TabIndex = 49;
            this.dtpTiempoTrabajo.Value = new System.DateTime(2020, 9, 15, 0, 0, 0, 0);
            this.dtpTiempoTrabajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtpTiempoTrabajo_KeyPress);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(187, 135);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(94, 22);
            this.dateTimePicker1.TabIndex = 78;
            this.dateTimePicker1.Value = new System.DateTime(2020, 9, 15, 0, 0, 0, 0);
            this.dateTimePicker1.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(214, 64);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.MaxLength = 250;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(592, 22);
            this.txtDescripcion.TabIndex = 23;
            // 
            // lbldescripcion
            // 
            this.lbldescripcion.AutoSize = true;
            this.lbldescripcion.Location = new System.Drawing.Point(211, 43);
            this.lbldescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldescripcion.Name = "lbldescripcion";
            this.lbldescripcion.Size = new System.Drawing.Size(82, 17);
            this.lbldescripcion.TabIndex = 24;
            this.lbldescripcion.Text = "Descripción";
            // 
            // lblnombreHorario
            // 
            this.lblnombreHorario.AutoSize = true;
            this.lblnombreHorario.Location = new System.Drawing.Point(8, 43);
            this.lblnombreHorario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombreHorario.Name = "lblnombreHorario";
            this.lblnombreHorario.Size = new System.Drawing.Size(55, 17);
            this.lblnombreHorario.TabIndex = 8;
            this.lblnombreHorario.Text = "Horario";
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
            this.menuBar1.TabIndex = 18;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.On_Save);
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
            this.strbar.Location = new System.Drawing.Point(0, 489);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(832, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 19;
            // 
            // txtnombreHorario
            // 
            this.txtnombreHorario.Location = new System.Drawing.Point(11, 64);
            this.txtnombreHorario.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombreHorario.MaxLength = 50;
            this.txtnombreHorario.Name = "txtnombreHorario";
            this.txtnombreHorario.Size = new System.Drawing.Size(158, 22);
            this.txtnombreHorario.TabIndex = 25;
            this.txtnombreHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtnombreHorario_KeyPress);
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
            this.lkuNav.TabIndex = 26;
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(832, 527);
            this.Controls.Add(this.pnlDatosJornada);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.txtnombreHorario);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblnombreHorario);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.lbldescripcion);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "Form1";
            this.Text = "Gestion Horario Empresa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form_Show);
            this.pnlDatosJornada.ResumeLayout(false);
            this.pnlDatosJornada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblnombreHorario;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.StatusBar strbar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lbldescripcion;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpTiempoTrabajo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnombreHorario;
        private System.Windows.Forms.Panel pnlDatosJornada;
        private System.Windows.Forms.Label label9;
        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nmDia;
        private System.Windows.Forms.ListView lvciclos;
        private System.Windows.Forms.ColumnHeader ColConsecutivo;
        private System.Windows.Forms.ColumnHeader ColInicio;
        private System.Windows.Forms.ColumnHeader ColFin;
        private System.Windows.Forms.ColumnHeader ColTiempoTrabajo;
        private System.Windows.Forms.ColumnHeader ColDuracion;
        private System.Windows.Forms.ColumnHeader ColDescanso;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAdd;
    }
}

