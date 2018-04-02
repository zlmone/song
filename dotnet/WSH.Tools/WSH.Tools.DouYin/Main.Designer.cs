namespace WSH.Tools.DouYin
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbMsg = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.selectDialog1 = new WSH.WinForm.Controls.SelectDialog();
            this.txtNumber = new WSH.WinForm.Controls.NumberBox();
            this.selectFolder = new WSH.WinForm.Controls.SelectDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "抖音ID：";
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(19, 105);
            this.lbMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(0, 15);
            this.lbMsg.TabIndex = 3;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(6, 139);
            this.progress.Margin = new System.Windows.Forms.Padding(4);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(405, 29);
            this.progress.TabIndex = 4;
            // 
            // selectDialog1
            // 
            this.selectDialog1.BackColor = System.Drawing.Color.Transparent;
            this.selectDialog1.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectDialog1.Location = new System.Drawing.Point(6, 49);
            this.selectDialog1.Margin = new System.Windows.Forms.Padding(4);
            this.selectDialog1.Name = "selectDialog1";
            this.selectDialog1.ReadOnly = false;
            this.selectDialog1.Size = new System.Drawing.Size(329, 26);
            this.selectDialog1.TabIndex = 6;
            this.selectDialog1.Title = null;
            this.selectDialog1.Type = WSH.Windows.Common.DialogType.Folder;
            // 
            // txtNumber
            // 
            this.txtNumber.AllowDecimal = false;
            this.txtNumber.AllowNegative = false;
            this.txtNumber.Location = new System.Drawing.Point(65, 12);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumber.MaxValue = ((long)(9223372036854775807));
            this.txtNumber.MinValue = ((long)(-9223372036854775808));
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.RegexMessage = null;
            this.txtNumber.RegexType = WSH.Common.RegexType.None;
            this.txtNumber.Required = true;
            this.txtNumber.RequiredMessage = "此项必填";
            this.txtNumber.Size = new System.Drawing.Size(346, 25);
            this.txtNumber.TabIndex = 5;
            this.txtNumber.Text = "45112660";
            // 
            // selectFolder
            // 
            this.selectFolder.BackColor = System.Drawing.Color.Transparent;
            this.selectFolder.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectFolder.Location = new System.Drawing.Point(6, 49);
            this.selectFolder.Margin = new System.Windows.Forms.Padding(4);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.ReadOnly = false;
            this.selectFolder.Size = new System.Drawing.Size(326, 26);
            this.selectFolder.TabIndex = 6;
            this.selectFolder.Title = null;
            this.selectFolder.Type = WSH.Windows.Common.DialogType.File;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 181);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectDialog1);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "批量下载抖音视频";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.ProgressBar progress;
        private WinForm.Controls.NumberBox txtNumber;
        private WinForm.Controls.SelectDialog selectFolder;
        private WinForm.Controls.SelectDialog selectDialog1;
        private System.Windows.Forms.Button button1;
    }
}