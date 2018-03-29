namespace WSH.Tools
{
    partial class FrmFormatCode
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuFmt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNote = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHtmlNote = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuParams = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.AllowDrop = true;
            this.txtCode.ContextMenuStrip = this.contextMenuStrip1;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(752, 519);
            this.txtCode.TabIndex = 1;
            this.txtCode.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtCode_DragDrop);
            this.txtCode.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtCode_DragEnter);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFmt,
            this.menuNote,
            this.menuHtmlNote,
            this.menuParams,
            this.menuClear});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 136);
            // 
            // menuFmt
            // 
            this.menuFmt.Name = "menuFmt";
            this.menuFmt.Size = new System.Drawing.Size(160, 22);
            this.menuFmt.Text = "删除空行和行号";
            this.menuFmt.Click += new System.EventHandler(this.menuFmt_Click);
            // 
            // menuNote
            // 
            this.menuNote.Name = "menuNote";
            this.menuNote.Size = new System.Drawing.Size(158, 22);
            this.menuNote.Text = "删除C#注释";
            this.menuNote.Click += new System.EventHandler(this.menuNote_Click);
            // 
            // menuHtmlNote
            // 
            this.menuHtmlNote.Name = "menuHtmlNote";
            this.menuHtmlNote.Size = new System.Drawing.Size(158, 22);
            this.menuHtmlNote.Text = "删除HTML注释";
            this.menuHtmlNote.Click += new System.EventHandler(this.menuHtmlNote_Click);
            // 
            // menuClear
            // 
            this.menuClear.Name = "menuClear";
            this.menuClear.Size = new System.Drawing.Size(158, 22);
            this.menuClear.Text = "清空";
            this.menuClear.Click += new System.EventHandler(this.menuClear_Click);
            // 
            // menuParams
            // 
            this.menuParams.Name = "menuParams";
            this.menuParams.Size = new System.Drawing.Size(160, 22);
            this.menuParams.Text = "删除数据类型";
            this.menuParams.Click += new System.EventHandler(this.menuParams_Click);
            // 
            // FrmFormatCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 519);
            this.Controls.Add(this.txtCode);
            this.Name = "FrmFormatCode";
            this.Text = "格式化代码";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFmt;
        private System.Windows.Forms.ToolStripMenuItem menuNote;
        private System.Windows.Forms.ToolStripMenuItem menuHtmlNote;
        private System.Windows.Forms.ToolStripMenuItem menuClear;
        private System.Windows.Forms.ToolStripMenuItem menuParams;
    }
}