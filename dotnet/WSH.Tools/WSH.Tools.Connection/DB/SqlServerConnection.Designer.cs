namespace WSH.Tools.Connection.DB
{
    partial class SqlServerConnection
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
            this.txtSqlString = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panelSql = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSqlDb = new System.Windows.Forms.ComboBox();
            this.txtSqlPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSqlUid = new System.Windows.Forms.ComboBox();
            this.cboSqlServer = new System.Windows.Forms.ComboBox();
            this.cboSqlType = new System.Windows.Forms.ComboBox();
            this.checkSql = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelSql.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSqlString
            // 
            this.txtSqlString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSqlString.Enabled = false;
            this.txtSqlString.Location = new System.Drawing.Point(3, 172);
            this.txtSqlString.Multiline = true;
            this.txtSqlString.Name = "txtSqlString";
            this.txtSqlString.Size = new System.Drawing.Size(459, 97);
            this.txtSqlString.TabIndex = 13;
            this.txtSqlString.Text = "server=.;user id=*;password=*;database=*;";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelSql
            // 
            this.panelSql.Controls.Add(this.label5);
            this.panelSql.Controls.Add(this.cboSqlDb);
            this.panelSql.Controls.Add(this.txtSqlPwd);
            this.panelSql.Controls.Add(this.label1);
            this.panelSql.Controls.Add(this.label2);
            this.panelSql.Controls.Add(this.label3);
            this.panelSql.Controls.Add(this.label4);
            this.panelSql.Controls.Add(this.cboSqlUid);
            this.panelSql.Controls.Add(this.cboSqlServer);
            this.panelSql.Controls.Add(this.cboSqlType);
            this.panelSql.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSql.Location = new System.Drawing.Point(0, 0);
            this.panelSql.Name = "panelSql";
            this.panelSql.Size = new System.Drawing.Size(487, 144);
            this.panelSql.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "数据库：";
            // 
            // cboSqlDb
            // 
            this.cboSqlDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSqlDb.FormattingEnabled = true;
            this.cboSqlDb.Location = new System.Drawing.Point(102, 115);
            this.cboSqlDb.Name = "cboSqlDb";
            this.cboSqlDb.Size = new System.Drawing.Size(360, 20);
            this.cboSqlDb.TabIndex = 10;
            this.cboSqlDb.Click += new System.EventHandler(this.cboSqlDb_Click);
            // 
            // txtSqlPwd
            // 
            this.txtSqlPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSqlPwd.Location = new System.Drawing.Point(102, 88);
            this.txtSqlPwd.Name = "txtSqlPwd";
            this.txtSqlPwd.PasswordChar = '*';
            this.txtSqlPwd.Size = new System.Drawing.Size(360, 21);
            this.txtSqlPwd.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "身份验证：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "登录名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "密码：";
            // 
            // cboSqlUid
            // 
            this.cboSqlUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSqlUid.FormattingEnabled = true;
            this.cboSqlUid.Location = new System.Drawing.Point(102, 62);
            this.cboSqlUid.Name = "cboSqlUid";
            this.cboSqlUid.Size = new System.Drawing.Size(360, 20);
            this.cboSqlUid.TabIndex = 7;
            // 
            // cboSqlServer
            // 
            this.cboSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSqlServer.FormattingEnabled = true;
            this.cboSqlServer.Location = new System.Drawing.Point(102, 10);
            this.cboSqlServer.Name = "cboSqlServer";
            this.cboSqlServer.Size = new System.Drawing.Size(360, 20);
            this.cboSqlServer.TabIndex = 5;
            this.cboSqlServer.TextChanged += new System.EventHandler(this.cboSqlServer_TextChanged);
            // 
            // cboSqlType
            // 
            this.cboSqlType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSqlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSqlType.FormattingEnabled = true;
            this.cboSqlType.Items.AddRange(new object[] {
            "Windows",
            "SqlServer"});
            this.cboSqlType.Location = new System.Drawing.Point(102, 36);
            this.cboSqlType.Name = "cboSqlType";
            this.cboSqlType.Size = new System.Drawing.Size(360, 20);
            this.cboSqlType.TabIndex = 6;
            this.cboSqlType.TextChanged += new System.EventHandler(this.cboSqlType_TextChanged);
            // 
            // checkSql
            // 
            this.checkSql.AutoSize = true;
            this.checkSql.Location = new System.Drawing.Point(3, 150);
            this.checkSql.Name = "checkSql";
            this.checkSql.Size = new System.Drawing.Size(84, 16);
            this.checkSql.TabIndex = 14;
            this.checkSql.Text = "连接字符串";
            this.checkSql.UseVisualStyleBackColor = true;
            this.checkSql.CheckedChanged += new System.EventHandler(this.checkSql_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UCSqlServerConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSqlString);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelSql);
            this.Controls.Add(this.checkSql);
            this.Controls.Add(this.button1);
            this.Name = "UCSqlServerConnection";
            this.Size = new System.Drawing.Size(487, 325);
            this.panelSql.ResumeLayout(false);
            this.panelSql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSqlString;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelSql;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSqlDb;
        private System.Windows.Forms.TextBox txtSqlPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSqlUid;
        private System.Windows.Forms.ComboBox cboSqlServer;
        private System.Windows.Forms.ComboBox cboSqlType;
        private System.Windows.Forms.CheckBox checkSql;
        private System.Windows.Forms.Button button1;
    }
}
