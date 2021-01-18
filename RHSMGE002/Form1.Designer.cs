namespace RHSMUO001
{
    partial class frmUnidadAdministrativa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnidadAdministrativa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lkuNav = new Net4Sage.Controls.Lookup.LookupButton();
            this.strbar = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.grbArea = new System.Windows.Forms.GroupBox();
            this.gbxHorarioTurno = new System.Windows.Forms.GroupBox();
            this.dvTurnos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.chxTurnos = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbHorarios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCentro = new System.Windows.Forms.ComboBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.lblSalarioEscala = new System.Windows.Forms.Label();
            this.txtNombreArea = new System.Windows.Forms.TextBox();
            this.lblnombGrupo = new System.Windows.Forms.Label();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.MainBS = new System.Windows.Forms.BindingSource(this.components);
            this.txtCodigoArea = new System.Windows.Forms.TextBox();
            this.grbArea.SuspendLayout();
            this.gbxHorarioTurno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            this.SuspendLayout();
            // 
            // lkuNav
            // 
            this.lkuNav.BackColor = System.Drawing.Color.Transparent;
            this.lkuNav.Enable = true;
            this.lkuNav.Location = new System.Drawing.Point(244, 59);
            this.lkuNav.Margin = new System.Windows.Forms.Padding(5);
            this.lkuNav.Name = "lkuNav";
            this.lkuNav.Size = new System.Drawing.Size(31, 28);
            this.lkuNav.SysSession = null;
            this.lkuNav.TabIndex = 21;
            this.lkuNav.Tag = "";
            this.lkuNav.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.OnNavChange);
            // 
            // strbar
            // 
            this.strbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strbar.Location = new System.Drawing.Point(0, 680);
            this.strbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.strbar.MinimumSize = new System.Drawing.Size(0, 38);
            this.strbar.Name = "strbar";
            this.strbar.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.strbar.Size = new System.Drawing.Size(572, 38);
            this.strbar.SysSession = this.sageSession1;
            this.strbar.TabIndex = 20;
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // grbArea
            // 
            this.grbArea.Controls.Add(this.gbxHorarioTurno);
            this.grbArea.Controls.Add(this.chxTurnos);
            this.grbArea.Controls.Add(this.label2);
            this.grbArea.Controls.Add(this.cmbHorarios);
            this.grbArea.Controls.Add(this.label1);
            this.grbArea.Controls.Add(this.cmbCentro);
            this.grbArea.Controls.Add(this.txtdescripcion);
            this.grbArea.Controls.Add(this.lblDescripción);
            this.grbArea.Controls.Add(this.lblSalarioEscala);
            this.grbArea.Controls.Add(this.txtNombreArea);
            this.grbArea.Location = new System.Drawing.Point(11, 91);
            this.grbArea.Name = "grbArea";
            this.grbArea.Size = new System.Drawing.Size(546, 586);
            this.grbArea.TabIndex = 17;
            this.grbArea.TabStop = false;
            // 
            // gbxHorarioTurno
            // 
            this.gbxHorarioTurno.Controls.Add(this.dvTurnos);
            this.gbxHorarioTurno.Controls.Add(this.label3);
            this.gbxHorarioTurno.Controls.Add(this.btnAdicionar);
            this.gbxHorarioTurno.Location = new System.Drawing.Point(12, 317);
            this.gbxHorarioTurno.Name = "gbxHorarioTurno";
            this.gbxHorarioTurno.Size = new System.Drawing.Size(517, 254);
            this.gbxHorarioTurno.TabIndex = 49;
            this.gbxHorarioTurno.TabStop = false;
            this.gbxHorarioTurno.Visible = false;
            this.gbxHorarioTurno.Enter += new System.EventHandler(this.gbxHorarioTurno_Enter);
            // 
            // dvTurnos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvTurnos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvTurnos.Location = new System.Drawing.Point(9, 49);
            this.dvTurnos.Name = "dvTurnos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvTurnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvTurnos.RowHeadersWidth = 51;
            this.dvTurnos.RowTemplate.Height = 24;
            this.dvTurnos.Size = new System.Drawing.Size(498, 194);
            this.dvTurnos.TabIndex = 57;
            this.dvTurnos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dvTurnos_DataError);
            this.dvTurnos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dvTurnos_EditingControlShowing);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Turnos";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(469, 13);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(37, 28);
            this.btnAdicionar.TabIndex = 48;
            this.btnAdicionar.Text = "+";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // chxTurnos
            // 
            this.chxTurnos.AutoSize = true;
            this.chxTurnos.Location = new System.Drawing.Point(16, 299);
            this.chxTurnos.Name = "chxTurnos";
            this.chxTurnos.Size = new System.Drawing.Size(79, 21);
            this.chxTurnos.TabIndex = 50;
            this.chxTurnos.Text = "Turnos ";
            this.chxTurnos.UseVisualStyleBackColor = true;
            this.chxTurnos.CheckedChanged += new System.EventHandler(this.chxTurnos_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 48;
            this.label2.Text = "Horario de trabajo";
            // 
            // cmbHorarios
            // 
            this.cmbHorarios.FormattingEnabled = true;
            this.cmbHorarios.Location = new System.Drawing.Point(15, 253);
            this.cmbHorarios.Name = "cmbHorarios";
            this.cmbHorarios.Size = new System.Drawing.Size(257, 24);
            this.cmbHorarios.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Centro de Costo *";
            // 
            // cmbCentro
            // 
            this.cmbCentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCentro.FormattingEnabled = true;
            this.cmbCentro.Location = new System.Drawing.Point(11, 94);
            this.cmbCentro.Name = "cmbCentro";
            this.cmbCentro.Size = new System.Drawing.Size(264, 24);
            this.cmbCentro.TabIndex = 41;
            this.cmbCentro.SelectedValueChanged += new System.EventHandler(this.cmbCentro_SelectedValueChanged);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Location = new System.Drawing.Point(11, 160);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescripcion.MaxLength = 1000;
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(521, 58);
            this.txtdescripcion.TabIndex = 12;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(12, 139);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(82, 17);
            this.lblDescripción.TabIndex = 11;
            this.lblDescripción.Text = "Descripción";
            // 
            // lblSalarioEscala
            // 
            this.lblSalarioEscala.AutoSize = true;
            this.lblSalarioEscala.Location = new System.Drawing.Point(9, 15);
            this.lblSalarioEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioEscala.Name = "lblSalarioEscala";
            this.lblSalarioEscala.Size = new System.Drawing.Size(101, 17);
            this.lblSalarioEscala.TabIndex = 8;
            this.lblSalarioEscala.Text = "Nombre Área *";
            // 
            // txtNombreArea
            // 
            this.txtNombreArea.Enabled = false;
            this.txtNombreArea.Location = new System.Drawing.Point(11, 36);
            this.txtNombreArea.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreArea.MaxLength = 50;
            this.txtNombreArea.Name = "txtNombreArea";
            this.txtNombreArea.Size = new System.Drawing.Size(264, 22);
            this.txtNombreArea.TabIndex = 7;
            // 
            // lblnombGrupo
            // 
            this.lblnombGrupo.AutoSize = true;
            this.lblnombGrupo.Location = new System.Drawing.Point(13, 38);
            this.lblnombGrupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombGrupo.Name = "lblnombGrupo";
            this.lblnombGrupo.Size = new System.Drawing.Size(115, 17);
            this.lblnombGrupo.TabIndex = 19;
            this.lblnombGrupo.Text = "Código de Area *";
            // 
            // menuBar1
            // 
            this.menuBar1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(572, 30);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 22;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.On_Save);
            this.menuBar1.OnCancel += new System.EventHandler(this.Do_Cancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.Do_Delete);
            this.menuBar1.OnValidation += new Net4Sage.Controls.ValidationEvenHandler(this.ValidateForm);
            // 
            // txtCodigoArea
            // 
            this.txtCodigoArea.Location = new System.Drawing.Point(15, 61);
            this.txtCodigoArea.MaxLength = 5;
            this.txtCodigoArea.Name = "txtCodigoArea";
            this.txtCodigoArea.Size = new System.Drawing.Size(226, 22);
            this.txtCodigoArea.TabIndex = 23;
            this.txtCodigoArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigoArea_KeyPress_1);
            this.txtCodigoArea.Validating += new System.ComponentModel.CancelEventHandler(this.IDValidate);
            this.txtCodigoArea.Validated += new System.EventHandler(this.On_IDChange);
            // 
            // frmUnidadAdministrativa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 718);
            this.Controls.Add(this.txtCodigoArea);
            this.Controls.Add(this.lkuNav);
            this.Controls.Add(this.strbar);
            this.Controls.Add(this.grbArea);
            this.Controls.Add(this.lblnombGrupo);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmUnidadAdministrativa";
            this.Text = "Gestión a Unidad Organizativa";
            this.Shown += new System.EventHandler(this.Form_Show);
            this.grbArea.ResumeLayout(false);
            this.grbArea.PerformLayout();
            this.gbxHorarioTurno.ResumeLayout(false);
            this.gbxHorarioTurno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.Lookup.LookupButton lkuNav;
        private Net4Sage.Controls.StatusBar strbar;
        private System.Windows.Forms.GroupBox grbArea;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblSalarioEscala;
        private System.Windows.Forms.TextBox txtNombreArea;
        private System.Windows.Forms.Label lblnombGrupo;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.SageSession sageSession1;
        private System.Windows.Forms.BindingSource MainBS;
        private System.Windows.Forms.ComboBox cmbCentro;
        private System.Windows.Forms.TextBox txtCodigoArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dvTurnos;
        private System.Windows.Forms.GroupBox gbxHorarioTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbHorarios;
        private System.Windows.Forms.CheckBox chxTurnos;
    }
}

