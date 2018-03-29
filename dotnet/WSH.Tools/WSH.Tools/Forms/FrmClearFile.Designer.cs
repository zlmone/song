namespace WSH.Tools
{
    partial class FrmClearFile
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
            this.btnCheck = new WSH.WinForm.Controls.ButtonImage();
            this.btnClear = new WSH.WinForm.Controls.ButtonImage();
            this.txtInfo = new WSH.WinForm.Controls.TextArea();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnCheck.Location = new System.Drawing.Point(191, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(70, 30);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "检测";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(267, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 30);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清理";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(0, 49);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(513, 192);
            this.txtInfo.TabIndex = 2;
            // 
            // FrmClearFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 242);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCheck);
            this.Name = "FrmClearFile";
            this.Text = "清理文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinForm.Controls.ButtonImage btnCheck;
        private WinForm.Controls.ButtonImage btnClear;
        private WinForm.Controls.TextArea txtInfo;
    }
}