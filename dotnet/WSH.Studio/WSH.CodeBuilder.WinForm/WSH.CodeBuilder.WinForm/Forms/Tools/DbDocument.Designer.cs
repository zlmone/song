namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    partial class DbDocument
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
            this.checkRequired = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnExport = new WSH.WinForm.Controls.ButtonImage();
            this.selectPath = new WSH.WinForm.Controls.SelectDialog();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // checkRequired
            // 
            this.checkRequired.AutoSize = true;
            this.checkRequired.Checked = true;
            this.checkRequired.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRequired.Location = new System.Drawing.Point(297, 14);
            this.checkRequired.Name = "checkRequired";
            this.checkRequired.Size = new System.Drawing.Size(108, 16);
            this.checkRequired.TabIndex = 1;
            this.checkRequired.Text = "导出是否为空列";
            this.checkRequired.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "导出类型：";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(78, 12);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(208, 20);
            this.cboType.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.Location = new System.Drawing.Point(164, 85);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 30);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // selectPath
            // 
            this.selectPath.BackColor = System.Drawing.Color.Transparent;
            this.selectPath.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectPath.Location = new System.Drawing.Point(10, 49);
            this.selectPath.MaximumSize = new System.Drawing.Size(3000, 30);
            this.selectPath.MinimumSize = new System.Drawing.Size(100, 30);
            this.selectPath.Name = "selectPath";
            this.selectPath.ReadOnly = false;
            this.selectPath.Size = new System.Drawing.Size(400, 30);
            this.selectPath.TabIndex = 5;
            this.selectPath.Title = null;
            this.selectPath.Type = WSH.Windows.Common.DialogType.Folder;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(0, 127);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(417, 23);
            this.progress.TabIndex = 6;
            // 
            // DbDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 150);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.selectPath);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkRequired);
            this.MaximizeBox = false;
            this.Name = "DbDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库文档";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DbDocument_FormClosing);
            this.Load += new System.EventHandler(this.DbDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkRequired;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboType;
        private WSH.WinForm.Controls.ButtonImage btnExport;
        private WSH.WinForm.Controls.SelectDialog selectPath;
        private System.Windows.Forms.ProgressBar progress;
    }
}