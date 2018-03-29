namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    partial class CodeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeView));
            this.txtCode = new ICSharpCode.TextEditor.TextEditorControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.ContextMenuStrip = this.contextMenuStrip;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Encoding = ((System.Text.Encoding)(resources.GetObject("txtCode.Encoding")));
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.ShowEOLMarkers = true;
            this.txtCode.ShowSpaces = true;
            this.txtCode.ShowTabs = true;
            this.txtCode.ShowVRuler = true;
            this.txtCode.Size = new System.Drawing.Size(628, 400);
            this.txtCode.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSave,
            this.menuCopy,
            this.menuCopyAll,
            this.menuPaste});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 92);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(124, 22);
            this.menuSave.Text = "保存";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(124, 22);
            this.menuCopy.Text = "复制";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuCopyAll
            // 
            this.menuCopyAll.Name = "menuCopyAll";
            this.menuCopyAll.Size = new System.Drawing.Size(124, 22);
            this.menuCopyAll.Text = "全部复制";
            this.menuCopyAll.Click += new System.EventHandler(this.menuCopyAll_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.Size = new System.Drawing.Size(124, 22);
            this.menuPaste.Text = "粘贴";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // CodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 400);
            this.Controls.Add(this.txtCode);
            this.Name = "CodeView";
            this.Text = "代码";
            this.Load += new System.EventHandler(this.CodeView_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl txtCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripMenuItem menuCopyAll;

    }
}