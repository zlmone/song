namespace WSH.WinForm.Controls
{
    partial class SelectDialog
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFile = new System.Windows.Forms.TextBox();
            this.dialogFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.dialogFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonImage1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.AllowDrop = true;
            this.txtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtFile.Location = new System.Drawing.Point(0, 0);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(343, 26);
            this.txtFile.TabIndex = 0;
            this.txtFile.WordWrap = false;
            this.txtFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPath_DragDrop);
            this.txtFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPath_DragEnter);
            // 
            // dialogFile
            // 
            this.dialogFile.FileName = "openFileDialog1";
            // 
            // buttonImage1
            // 
            this.buttonImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImage1.Location = new System.Drawing.Point(0, 0);
            this.buttonImage1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonImage1.Name = "buttonImage1";
            this.buttonImage1.Size = new System.Drawing.Size(69, 26);
            this.buttonImage1.TabIndex = 1;
            this.buttonImage1.Text = "浏览...";
            this.buttonImage1.UseVisualStyleBackColor = true;
            this.buttonImage1.Click += new System.EventHandler(this.buttonImage1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonImage1);
            this.splitContainer1.Size = new System.Drawing.Size(413, 26);
            this.splitContainer1.SplitterDistance = 343;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // SelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectDialog";
            this.Size = new System.Drawing.Size(413, 26);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.OpenFileDialog dialogFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.FolderBrowserDialog dialogFolder;
        private System.Windows.Forms.Button buttonImage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
