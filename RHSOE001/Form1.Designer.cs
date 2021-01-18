namespace RHSOE001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Empresa");
            this.sageSession1 = new Net4Sage.SageSession();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.treeViewEmpresa = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // sageSession1
            // 
            this.sageSession1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("sageSession1.Parameters")));
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 584);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 38);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 4, 7, 4);
            this.statusBar1.Size = new System.Drawing.Size(350, 38);
            this.statusBar1.SysSession = this.sageSession1;
            this.statusBar1.TabIndex = 0;
            // 
            // treeViewEmpresa
            // 
            this.treeViewEmpresa.Location = new System.Drawing.Point(24, 30);
            this.treeViewEmpresa.Name = "treeViewEmpresa";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Empresa";
            this.treeViewEmpresa.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewEmpresa.Size = new System.Drawing.Size(296, 531);
            this.treeViewEmpresa.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 622);
            this.Controls.Add(this.treeViewEmpresa);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Organigrama de la Empresa";
            this.ResumeLayout(false);

        }

        #endregion

        private Net4Sage.SageSession sageSession1;
        private Net4Sage.Controls.StatusBar statusBar1;
        private System.Windows.Forms.TreeView treeViewEmpresa;
    }
}

