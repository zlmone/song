namespace WSH.Tools.Connection.FTP
{
    partial class FTPConnection
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.required1 = new WSH.WinForm.Controls.Required();
            this.btnConnection = new WSH.WinForm.Controls.ButtonImage();
            this.required2 = new WSH.WinForm.Controls.Required();
            this.required3 = new WSH.WinForm.Controls.Required();
            this.txtPort = new WSH.WinForm.Controls.NumberBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "端口：";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(77, 19);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(169, 21);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(77, 90);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(169, 21);
            this.txtUid.TabIndex = 8;
            this.txtUid.TextChanged += new System.EventHandler(this.txtUid_TextChanged);
            // 
            // required1
            // 
            this.required1.AutoSize = true;
            this.required1.ForeColor = System.Drawing.Color.Red;
            this.required1.Location = new System.Drawing.Point(19, 22);
            this.required1.Name = "required1";
            this.required1.Size = new System.Drawing.Size(11, 12);
            this.required1.TabIndex = 9;
            this.required1.Text = "*";
            // 
            // btnConnection
            // 
            this.btnConnection.BackColor = System.Drawing.Color.Transparent;
            this.btnConnection.Location = new System.Drawing.Point(105, 172);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(70, 30);
            this.btnConnection.TabIndex = 4;
            this.btnConnection.Text = "连接";
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // required2
            // 
            this.required2.AutoSize = true;
            this.required2.ForeColor = System.Drawing.Color.Red;
            this.required2.Location = new System.Drawing.Point(19, 129);
            this.required2.Name = "required2";
            this.required2.Size = new System.Drawing.Size(11, 12);
            this.required2.TabIndex = 10;
            this.required2.Text = "*";
            // 
            // required3
            // 
            this.required3.AutoSize = true;
            this.required3.ForeColor = System.Drawing.Color.Red;
            this.required3.Location = new System.Drawing.Point(8, 93);
            this.required3.Name = "required3";
            this.required3.Size = new System.Drawing.Size(11, 12);
            this.required3.TabIndex = 11;
            this.required3.Text = "*";
            // 
            // txtPort
            // 
            this.txtPort.AllowNegative = true;
            this.txtPort.CustomMessage = null;
            this.txtPort.Location = new System.Drawing.Point(78, 56);
            this.txtPort.MaxValue = ((long)(9223372036854775807));
            this.txtPort.MinValue = ((long)(-9223372036854775808));
            this.txtPort.Name = "txtPort";
            this.txtPort.RegexType = WSH.Common.RegexType.None;
            this.txtPort.Required = false;
            this.txtPort.RequiredMessage = "此项必填";
            this.txtPort.Size = new System.Drawing.Size(168, 21);
            this.txtPort.TabIndex = 5;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(78, 126);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(169, 21);
            this.txtPwd.TabIndex = 7;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            // 
            // FTPConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 229);
            this.Controls.Add(this.required3);
            this.Controls.Add(this.required2);
            this.Controls.Add(this.required1);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FTPConnection";
            this.Text = "FTP连接";
            this.Load += new System.EventHandler(this.FTPConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private WinForm.Controls.ButtonImage btnConnection;
        private WinForm.Controls.NumberBox txtPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtUid;
        private WinForm.Controls.Required required1;
        private WinForm.Controls.Required required2;
        private WinForm.Controls.Required required3;
        private System.Windows.Forms.TextBox txtPwd;
    }
}