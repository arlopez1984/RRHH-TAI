namespace RHSST001
{
    partial class frmBuscarTrabajador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarTrabajador));
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.sageSession1 = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.grbTrabajadores = new System.Windows.Forms.GroupBox();
            this.lvPersonas = new System.Windows.Forms.ListView();
            this.ColNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSegundoNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColPrimerApellido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSegundoApellido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCIPasaporte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSegNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSegApellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbTrabajadores.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 526);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(1023, 38);
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
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(1023, 28);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 1;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.Do_Save);
            // 
            // grbTrabajadores
            // 
            this.grbTrabajadores.Controls.Add(this.lvPersonas);
            this.grbTrabajadores.Location = new System.Drawing.Point(18, 105);
            this.grbTrabajadores.Name = "grbTrabajadores";
            this.grbTrabajadores.Size = new System.Drawing.Size(994, 366);
            this.grbTrabajadores.TabIndex = 20;
            this.grbTrabajadores.TabStop = false;
            this.grbTrabajadores.Text = "Trabajador(es)";
            // 
            // lvPersonas
            // 
            this.lvPersonas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColNombre,
            this.ColSegundoNombre,
            this.ColPrimerApellido,
            this.ColSegundoApellido,
            this.ColCIPasaporte,
            this.columnHeader1});
            this.lvPersonas.FullRowSelect = true;
            this.lvPersonas.GridLines = true;
            this.lvPersonas.HideSelection = false;
            this.lvPersonas.Location = new System.Drawing.Point(13, 33);
            this.lvPersonas.MultiSelect = false;
            this.lvPersonas.Name = "lvPersonas";
            this.lvPersonas.Size = new System.Drawing.Size(961, 327);
            this.lvPersonas.TabIndex = 80;
            this.lvPersonas.UseCompatibleStateImageBehavior = false;
            this.lvPersonas.View = System.Windows.Forms.View.Details;
            this.lvPersonas.SelectedIndexChanged += new System.EventHandler(this.LvPersonas_SelectedIndexChanged);
            this.lvPersonas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvPersonas_MouseDoubleClick);
            // 
            // ColNombre
            // 
            this.ColNombre.Text = "Nombre";
            this.ColNombre.Width = 143;
            // 
            // ColSegundoNombre
            // 
            this.ColSegundoNombre.Text = "Segundo Nombre";
            this.ColSegundoNombre.Width = 157;
            // 
            // ColPrimerApellido
            // 
            this.ColPrimerApellido.Text = "Primer Apellido";
            this.ColPrimerApellido.Width = 147;
            // 
            // ColSegundoApellido
            // 
            this.ColSegundoApellido.Text = "Segundo Apellido";
            this.ColSegundoApellido.Width = 144;
            // 
            // ColCIPasaporte
            // 
            this.ColCIPasaporte.Text = "CI o Pasaporte";
            this.ColCIPasaporte.Width = 250;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(81, 50);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(123, 22);
            this.txtNombre.TabIndex = 82;
            this.txtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 81;
            this.label1.Text = "Nombre";
            // 
            // txtSegNombre
            // 
            this.txtSegNombre.Location = new System.Drawing.Point(331, 50);
            this.txtSegNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtSegNombre.MaxLength = 50;
            this.txtSegNombre.Name = "txtSegNombre";
            this.txtSegNombre.Size = new System.Drawing.Size(149, 22);
            this.txtSegNombre.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 83;
            this.label2.Text = "Segundo Nombre";
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Location = new System.Drawing.Point(590, 50);
            this.txtPrimerApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrimerApellido.MaxLength = 50;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(149, 22);
            this.txtPrimerApellido.TabIndex = 86;
            this.txtPrimerApellido.TextChanged += new System.EventHandler(this.TxtPrimerApellido_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 85;
            this.label3.Text = "Primer Apellido";
            // 
            // txtSegApellido
            // 
            this.txtSegApellido.Location = new System.Drawing.Point(864, 50);
            this.txtSegApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtSegApellido.MaxLength = 50;
            this.txtSegApellido.Name = "txtSegApellido";
            this.txtSegApellido.Size = new System.Drawing.Size(149, 22);
            this.txtSegApellido.TabIndex = 88;
            this.txtSegApellido.TextChanged += new System.EventHandler(this.TxtSegApellido_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(742, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 87;
            this.label4.Text = "Segundo Apellido";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(922, 79);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 29);
            this.btnBuscar.TabIndex = 95;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(920, 477);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(91, 29);
            this.btnEliminar.TabIndex = 96;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Acumulado de Vacaciones";
            this.columnHeader1.Width = 100;
            // 
            // frmBuscarTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 564);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtSegApellido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrimerApellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSegNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbTrabajadores);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuBar1);
            this.MainMenuStrip = this.menuBar1;
            this.Name = "frmBuscarTrabajador";
            this.Text = "Buscar Trabajador(es)";
            this.grbTrabajadores.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.GroupBox grbTrabajadores;
        private System.Windows.Forms.ListView lvPersonas;
        private System.Windows.Forms.ColumnHeader ColNombre;
        private System.Windows.Forms.ColumnHeader ColSegundoNombre;
        private System.Windows.Forms.ColumnHeader ColPrimerApellido;
        private System.Windows.Forms.ColumnHeader ColSegundoApellido;
        private System.Windows.Forms.ColumnHeader ColCIPasaporte;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSegNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSegApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}