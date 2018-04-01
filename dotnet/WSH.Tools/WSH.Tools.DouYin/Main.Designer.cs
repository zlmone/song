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
            this.btnDownload = new WSH.WinForm.Controls.ButtonImage();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMsg = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.txtNumber = new WSH.WinForm.Controls.NumberBox();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.Transparent;
            this.btnDownload.Location = new System.Drawing.Point(101, 39);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(70, 30);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "批量下载";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "抖音ID：";
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(14, 84);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(0, 12);
            this.lbMsg.TabIndex = 3;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(15, 105);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(257, 23);
            this.progress.TabIndex = 4;
            // 
            // txtNumber
            // 
            this.txtNumber.AllowDecimal = false;
            this.txtNumber.AllowNegative = false;
            this.txtNumber.Location = new System.Drawing.Point(49, 10);
            this.txtNumber.MaxValue = ((long)(9223372036854775807));
            this.txtNumber.MinValue = ((long)(-9223372036854775808));
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.RegexMessage = null;
            this.txtNumber.RegexType = WSH.Common.RegexType.None;
            this.txtNumber.Required = true;
            this.txtNumber.RequiredMessage = "此项必填";
            this.txtNumber.Size = new System.Drawing.Size(223, 21);
            this.txtNumber.TabIndex = 5;
            this.txtNumber.Text = "45112660";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 145);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownload);
            this.Name = "Main";
            this.Text = "批量下载抖音视频";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinForm.Controls.ButtonImage btnDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.ProgressBar progress;
        private WinForm.Controls.NumberBox txtNumber;
    }
}