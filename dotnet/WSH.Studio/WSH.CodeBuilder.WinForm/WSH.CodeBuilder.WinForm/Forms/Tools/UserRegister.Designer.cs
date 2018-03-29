namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    partial class UserRegister
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtRePwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.required6 = new WSH.WinForm.Controls.Required();
            this.required5 = new WSH.WinForm.Controls.Required();
            this.buttonImage1 = new WSH.WinForm.Controls.ButtonImage();
            this.required4 = new WSH.WinForm.Controls.Required();
            this.required3 = new WSH.WinForm.Controls.Required();
            this.required2 = new WSH.WinForm.Controls.Required();
            this.required1 = new WSH.WinForm.Controls.Required();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "真实姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "验证码：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(91, 15);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(195, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 83);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(195, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // txtRealName
            // 
            this.txtRealName.Location = new System.Drawing.Point(91, 49);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(195, 21);
            this.txtRealName.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(91, 182);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(80, 28);
            this.pictureBox.TabIndex = 12;
            this.pictureBox.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(89, 218);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 12);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "看不清，换一张";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(188, 186);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(97, 21);
            this.txtCode.TabIndex = 6;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtRePwd
            // 
            this.txtRePwd.Location = new System.Drawing.Point(90, 116);
            this.txtRePwd.Name = "txtRePwd";
            this.txtRePwd.PasswordChar = '*';
            this.txtRePwd.Size = new System.Drawing.Size(195, 21);
            this.txtRePwd.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "确认密码：";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(91, 150);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 21);
            this.txtEmail.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "邮箱：";
            // 
            // required6
            // 
            this.required6.AutoSize = true;
            this.required6.ForeColor = System.Drawing.Color.Red;
            this.required6.Location = new System.Drawing.Point(31, 153);
            this.required6.Name = "required6";
            this.required6.Size = new System.Drawing.Size(11, 12);
            this.required6.TabIndex = 19;
            this.required6.Text = "*";
            // 
            // required5
            // 
            this.required5.AutoSize = true;
            this.required5.ForeColor = System.Drawing.Color.Red;
            this.required5.Location = new System.Drawing.Point(6, 119);
            this.required5.Name = "required5";
            this.required5.Size = new System.Drawing.Size(11, 12);
            this.required5.TabIndex = 16;
            this.required5.Text = "*";
            // 
            // buttonImage1
            // 
            this.buttonImage1.BackColor = System.Drawing.Color.Transparent;
            this.buttonImage1.Location = new System.Drawing.Point(130, 246);
            this.buttonImage1.Name = "buttonImage1";
            this.buttonImage1.Size = new System.Drawing.Size(70, 30);
            this.buttonImage1.TabIndex = 14;
            this.buttonImage1.Text = "注册";
            this.buttonImage1.Click += new System.EventHandler(this.buttonImage1_Click);
            // 
            // required4
            // 
            this.required4.AutoSize = true;
            this.required4.ForeColor = System.Drawing.Color.Red;
            this.required4.Location = new System.Drawing.Point(19, 189);
            this.required4.Name = "required4";
            this.required4.Size = new System.Drawing.Size(11, 12);
            this.required4.TabIndex = 6;
            this.required4.Text = "*";
            // 
            // required3
            // 
            this.required3.AutoSize = true;
            this.required3.ForeColor = System.Drawing.Color.Red;
            this.required3.Location = new System.Drawing.Point(26, 86);
            this.required3.Name = "required3";
            this.required3.Size = new System.Drawing.Size(11, 12);
            this.required3.TabIndex = 4;
            this.required3.Text = "*";
            // 
            // required2
            // 
            this.required2.AutoSize = true;
            this.required2.ForeColor = System.Drawing.Color.Red;
            this.required2.Location = new System.Drawing.Point(6, 51);
            this.required2.Name = "required2";
            this.required2.Size = new System.Drawing.Size(11, 12);
            this.required2.TabIndex = 2;
            this.required2.Text = "*";
            // 
            // required1
            // 
            this.required1.AutoSize = true;
            this.required1.ForeColor = System.Drawing.Color.Red;
            this.required1.Location = new System.Drawing.Point(18, 18);
            this.required1.Name = "required1";
            this.required1.Size = new System.Drawing.Size(11, 12);
            this.required1.TabIndex = 0;
            this.required1.Text = "*";
            // 
            // UserRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 287);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.required6);
            this.Controls.Add(this.txtRePwd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.required5);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.buttonImage1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.txtRealName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.required4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.required3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.required2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.required1);
            this.Name = "UserRegister";
            this.Text = "用户注册";
            this.Load += new System.EventHandler(this.UserRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WSH.WinForm.Controls.Required required1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WSH.WinForm.Controls.Required required2;
        private System.Windows.Forms.Label label3;
        private WSH.WinForm.Controls.Required required3;
        private System.Windows.Forms.Label label4;
        private WSH.WinForm.Controls.Required required4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private WSH.WinForm.Controls.ButtonImage buttonImage1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtRePwd;
        private System.Windows.Forms.Label label5;
        private WSH.WinForm.Controls.Required required5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private WSH.WinForm.Controls.Required required6;
    }
}