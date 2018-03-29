namespace WSH.Tools.Connection.DB
{
    partial class AccessConnection
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
            this.txtAccessString = new System.Windows.Forms.TextBox();
            this.btnAccessCancel = new System.Windows.Forms.Button();
            this.checkAccess = new System.Windows.Forms.CheckBox();
            this.btnAccessConnection = new System.Windows.Forms.Button();
            this.panelAccess = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccessFile = new System.Windows.Forms.TextBox();
            this.txtAccessPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelAccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAccessString
            // 
            this.txtAccessString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccessString.Enabled = false;
            this.txtAccessString.Location = new System.Drawing.Point(2, 116);
            this.txtAccessString.Multiline = true;
            this.txtAccessString.Name = "txtAccessString";
            this.txtAccessString.Size = new System.Drawing.Size(472, 133);
            this.txtAccessString.TabIndex = 18;
            this.txtAccessString.Text = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Data Source=|DataDirectory|\\DataBase\\*" +
                "**.mdb;Database Password=***;Persist Security Info=True";
            // 
            // btnAccessCancel
            // 
            this.btnAccessCancel.Location = new System.Drawing.Point(264, 270);
            this.btnAccessCancel.Name = "btnAccessCancel";
            this.btnAccessCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAccessCancel.TabIndex = 22;
            this.btnAccessCancel.Text = "取消";
            this.btnAccessCancel.UseVisualStyleBackColor = true;
            this.btnAccessCancel.Click += new System.EventHandler(this.btnAccessCancel_Click);
            // 
            // checkAccess
            // 
            this.checkAccess.AutoSize = true;
            this.checkAccess.Location = new System.Drawing.Point(2, 91);
            this.checkAccess.Name = "checkAccess";
            this.checkAccess.Size = new System.Drawing.Size(84, 16);
            this.checkAccess.TabIndex = 19;
            this.checkAccess.Text = "连接字符串";
            this.checkAccess.UseVisualStyleBackColor = true;
            this.checkAccess.CheckedChanged += new System.EventHandler(this.checkAccess_CheckedChanged);
            // 
            // btnAccessConnection
            // 
            this.btnAccessConnection.Location = new System.Drawing.Point(140, 270);
            this.btnAccessConnection.Name = "btnAccessConnection";
            this.btnAccessConnection.Size = new System.Drawing.Size(75, 23);
            this.btnAccessConnection.TabIndex = 21;
            this.btnAccessConnection.Text = "连接";
            this.btnAccessConnection.UseVisualStyleBackColor = true;
            this.btnAccessConnection.Click += new System.EventHandler(this.btnAccessConnection_Click);
            // 
            // panelAccess
            // 
            this.panelAccess.Controls.Add(this.button5);
            this.panelAccess.Controls.Add(this.label6);
            this.panelAccess.Controls.Add(this.txtAccessFile);
            this.panelAccess.Controls.Add(this.txtAccessPwd);
            this.panelAccess.Controls.Add(this.label7);
            this.panelAccess.Controls.Add(this.label10);
            this.panelAccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAccess.Location = new System.Drawing.Point(0, 0);
            this.panelAccess.Name = "panelAccess";
            this.panelAccess.Size = new System.Drawing.Size(495, 85);
            this.panelAccess.TabIndex = 20;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(397, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "选择文件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(395, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "无密码可不填";
            // 
            // txtAccessFile
            // 
            this.txtAccessFile.Location = new System.Drawing.Point(101, 12);
            this.txtAccessFile.Name = "txtAccessFile";
            this.txtAccessFile.Size = new System.Drawing.Size(271, 21);
            this.txtAccessFile.TabIndex = 9;
            // 
            // txtAccessPwd
            // 
            this.txtAccessPwd.Location = new System.Drawing.Point(101, 50);
            this.txtAccessPwd.Name = "txtAccessPwd";
            this.txtAccessPwd.PasswordChar = '*';
            this.txtAccessPwd.Size = new System.Drawing.Size(271, 21);
            this.txtAccessPwd.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "文件地址：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "密码：";
            // 
            // UCAccessConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAccessString);
            this.Controls.Add(this.btnAccessCancel);
            this.Controls.Add(this.checkAccess);
            this.Controls.Add(this.btnAccessConnection);
            this.Controls.Add(this.panelAccess);
            this.Name = "UCAccessConnection";
            this.Size = new System.Drawing.Size(495, 313);
            this.panelAccess.ResumeLayout(false);
            this.panelAccess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccessString;
        private System.Windows.Forms.Button btnAccessCancel;
        private System.Windows.Forms.CheckBox checkAccess;
        private System.Windows.Forms.Button btnAccessConnection;
        private System.Windows.Forms.Panel panelAccess;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccessFile;
        private System.Windows.Forms.TextBox txtAccessPwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
    }
}
