namespace WSH.CodeBuilder.WinForm.Common
{
    partial class DocumentForm
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
            this.dockContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCloseCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.dockContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockContextMenu
            // 
            this.dockContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCloseCurrent,
            this.menuCloseOther,
            this.menuCloseAll});
            this.dockContextMenu.Name = "dockContextMenu";
            this.dockContextMenu.Size = new System.Drawing.Size(173, 92);
            // 
            // menuCloseCurrent
            // 
            this.menuCloseCurrent.Name = "menuCloseCurrent";
            this.menuCloseCurrent.Size = new System.Drawing.Size(172, 22);
            this.menuCloseCurrent.Text = "关闭";
            this.menuCloseCurrent.Click += new System.EventHandler(this.menuCloseCurrent_Click);
            // 
            // menuCloseOther
            // 
            this.menuCloseOther.Name = "menuCloseOther";
            this.menuCloseOther.Size = new System.Drawing.Size(172, 22);
            this.menuCloseOther.Text = "除此之外全部关闭";
            this.menuCloseOther.Click += new System.EventHandler(this.menuCloseOther_Click);
            // 
            // menuCloseAll
            // 
            this.menuCloseAll.Name = "menuCloseAll";
            this.menuCloseAll.Size = new System.Drawing.Size(172, 22);
            this.menuCloseAll.Text = "全部关闭";
            this.menuCloseAll.Click += new System.EventHandler(this.menuCloseAll_Click);
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "DocumentForm";
            this.TabPageContextMenuStrip = this.dockContextMenu;
            this.TabText = "DocumentForm";
            this.Text = "DocumentForm";
            this.dockContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip dockContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuCloseCurrent;
        private System.Windows.Forms.ToolStripMenuItem menuCloseOther;
        private System.Windows.Forms.ToolStripMenuItem menuCloseAll;
    }
}