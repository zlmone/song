namespace WSH.Tools.Connection.DB
{
    partial class MySqlConnection
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
            this.panelMySql = new System.Windows.Forms.Panel();
            this.txtMySqlPort = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMySqlDb = new System.Windows.Forms.ComboBox();
            this.txtMySqlPwd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboMySqlUid = new System.Windows.Forms.ComboBox();
            this.cboMySqlServer = new System.Windows.Forms.ComboBox();
            this.checkMySql = new System.Windows.Forms.CheckBox();
            this.txtMySqlString = new System.Windows.Forms.TextBox();
            this.btnMySqlCancel = new System.Windows.Forms.Button();
            this.btnMySqlConnection = new System.Windows.Forms.Button();
            this.panelMySql.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMySql
            // 
            this.panelMySql.Controls.Add(this.txtMySqlPort);
            this.panelMySql.Controls.Add(this.label11);
            this.panelMySql.Controls.Add(this.label8);
            this.panelMySql.Controls.Add(this.cboMySqlDb);
            this.panelMySql.Controls.Add(this.txtMySqlPwd);
            this.panelMySql.Controls.Add(this.label9);
            this.panelMySql.Controls.Add(this.label12);
            this.panelMySql.Controls.Add(this.label13);
            this.panelMySql.Controls.Add(this.cboMySqlUid);
            this.panelMySql.Controls.Add(this.cboMySqlServer);
            this.panelMySql.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMySql.Location = new System.Drawing.Point(0, 0);
            this.panelMySql.Name = "panelMySql";
            this.panelMySql.Size = new System.Drawing.Size(491, 123);
            this.panelMySql.TabIndex = 16;
            // 
            // txtMySqlPort
            // 
            this.txtMySqlPort.Location = new System.Drawing.Point(387, 9);
            this.txtMySqlPort.Name = "txtMySqlPort";
            this.txtMySqlPort.Size = new System.Drawing.Size(79, 21);
            this.txtMySqlPort.TabIndex = 12;
            this.txtMySqlPort.Text = "3306";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "端口：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "数据库：";
            // 
            // cboMySqlDb
            // 
            this.cboMySqlDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMySqlDb.FormattingEnabled = true;
            this.cboMySqlDb.Location = new System.Drawing.Point(102, 90);
            this.cboMySqlDb.Name = "cboMySqlDb";
            this.cboMySqlDb.Size = new System.Drawing.Size(364, 20);
            this.cboMySqlDb.TabIndex = 10;
            // 
            // txtMySqlPwd
            // 
            this.txtMySqlPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMySqlPwd.Location = new System.Drawing.Point(102, 63);
            this.txtMySqlPwd.Name = "txtMySqlPwd";
            this.txtMySqlPwd.PasswordChar = '*';
            this.txtMySqlPwd.Size = new System.Drawing.Size(364, 21);
            this.txtMySqlPwd.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "主机名或IP：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "登录名：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "密码：";
            // 
            // cboMySqlUid
            // 
            this.cboMySqlUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMySqlUid.FormattingEnabled = true;
            this.cboMySqlUid.Location = new System.Drawing.Point(102, 37);
            this.cboMySqlUid.Name = "cboMySqlUid";
            this.cboMySqlUid.Size = new System.Drawing.Size(364, 20);
            this.cboMySqlUid.TabIndex = 7;
            this.cboMySqlUid.Text = "root";
            // 
            // cboMySqlServer
            // 
            this.cboMySqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMySqlServer.FormattingEnabled = true;
            this.cboMySqlServer.Location = new System.Drawing.Point(102, 10);
            this.cboMySqlServer.Name = "cboMySqlServer";
            this.cboMySqlServer.Size = new System.Drawing.Size(232, 20);
            this.cboMySqlServer.TabIndex = 5;
            this.cboMySqlServer.Text = "localhost";
            // 
            // checkMySql
            // 
            this.checkMySql.AutoSize = true;
            this.checkMySql.Location = new System.Drawing.Point(3, 129);
            this.checkMySql.Name = "checkMySql";
            this.checkMySql.Size = new System.Drawing.Size(84, 16);
            this.checkMySql.TabIndex = 17;
            this.checkMySql.Text = "连接字符串";
            this.checkMySql.UseVisualStyleBackColor = true;
            // 
            // txtMySqlString
            // 
            this.txtMySqlString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMySqlString.Enabled = false;
            this.txtMySqlString.Location = new System.Drawing.Point(0, 151);
            this.txtMySqlString.Multiline = true;
            this.txtMySqlString.Name = "txtMySqlString";
            this.txtMySqlString.Size = new System.Drawing.Size(465, 110);
            this.txtMySqlString.TabIndex = 18;
            this.txtMySqlString.Text = "server=.;user id=*;password=*;database=*;";
            // 
            // btnMySqlCancel
            // 
            this.btnMySqlCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMySqlCancel.Location = new System.Drawing.Point(230, 273);
            this.btnMySqlCancel.Name = "btnMySqlCancel";
            this.btnMySqlCancel.Size = new System.Drawing.Size(72, 23);
            this.btnMySqlCancel.TabIndex = 20;
            this.btnMySqlCancel.Text = "取消";
            this.btnMySqlCancel.UseVisualStyleBackColor = true;
            // 
            // btnMySqlConnection
            // 
            this.btnMySqlConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMySqlConnection.Location = new System.Drawing.Point(134, 273);
            this.btnMySqlConnection.Name = "btnMySqlConnection";
            this.btnMySqlConnection.Size = new System.Drawing.Size(71, 23);
            this.btnMySqlConnection.TabIndex = 19;
            this.btnMySqlConnection.Text = "连接";
            this.btnMySqlConnection.UseVisualStyleBackColor = true;
            this.btnMySqlConnection.Click += new System.EventHandler(this.btnMySqlConnection_Click);
            // 
            // MySqlConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMySqlCancel);
            this.Controls.Add(this.btnMySqlConnection);
            this.Controls.Add(this.txtMySqlString);
            this.Controls.Add(this.checkMySql);
            this.Controls.Add(this.panelMySql);
            this.Name = "MySqlConnection";
            this.Size = new System.Drawing.Size(491, 312);
            this.Load += new System.EventHandler(this.MySqlConnection_Load);
            this.panelMySql.ResumeLayout(false);
            this.panelMySql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMySql;
        private System.Windows.Forms.TextBox txtMySqlPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboMySqlDb;
        private System.Windows.Forms.TextBox txtMySqlPwd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboMySqlUid;
        private System.Windows.Forms.ComboBox cboMySqlServer;
        private System.Windows.Forms.CheckBox checkMySql;
        private System.Windows.Forms.TextBox txtMySqlString;
        private System.Windows.Forms.Button btnMySqlCancel;
        private System.Windows.Forms.Button btnMySqlConnection;
    }
}
