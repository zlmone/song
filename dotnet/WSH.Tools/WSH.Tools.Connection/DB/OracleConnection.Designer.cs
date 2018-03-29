namespace WSH.Tools.Connection.DB
{
    partial class OracleConnection
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtMySqlPwd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnMySqlCancel = new System.Windows.Forms.Button();
            this.btnMySqlConnection = new System.Windows.Forms.Button();
            this.txtMySqlString = new System.Windows.Forms.TextBox();
            this.checkMySql = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panelMySql.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMySql
            // 
            this.panelMySql.Controls.Add(this.textBox2);
            this.panelMySql.Controls.Add(this.textBox1);
            this.panelMySql.Controls.Add(this.label8);
            this.panelMySql.Controls.Add(this.txtMySqlPwd);
            this.panelMySql.Controls.Add(this.label12);
            this.panelMySql.Controls.Add(this.label13);
            this.panelMySql.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMySql.Location = new System.Drawing.Point(0, 0);
            this.panelMySql.Name = "panelMySql";
            this.panelMySql.Size = new System.Drawing.Size(490, 97);
            this.panelMySql.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "服务：";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtMySqlPwd
            // 
            this.txtMySqlPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMySqlPwd.Location = new System.Drawing.Point(102, 35);
            this.txtMySqlPwd.Name = "txtMySqlPwd";
            this.txtMySqlPwd.PasswordChar = '*';
            this.txtMySqlPwd.Size = new System.Drawing.Size(363, 21);
            this.txtMySqlPwd.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "登录名：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "密码：";
            // 
            // btnMySqlCancel
            // 
            this.btnMySqlCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMySqlCancel.Location = new System.Drawing.Point(245, 239);
            this.btnMySqlCancel.Name = "btnMySqlCancel";
            this.btnMySqlCancel.Size = new System.Drawing.Size(72, 23);
            this.btnMySqlCancel.TabIndex = 25;
            this.btnMySqlCancel.Text = "取消";
            this.btnMySqlCancel.UseVisualStyleBackColor = true;
            // 
            // btnMySqlConnection
            // 
            this.btnMySqlConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMySqlConnection.Location = new System.Drawing.Point(149, 239);
            this.btnMySqlConnection.Name = "btnMySqlConnection";
            this.btnMySqlConnection.Size = new System.Drawing.Size(71, 23);
            this.btnMySqlConnection.TabIndex = 24;
            this.btnMySqlConnection.Text = "连接";
            this.btnMySqlConnection.UseVisualStyleBackColor = true;
            // 
            // txtMySqlString
            // 
            this.txtMySqlString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMySqlString.Enabled = false;
            this.txtMySqlString.Location = new System.Drawing.Point(0, 125);
            this.txtMySqlString.Multiline = true;
            this.txtMySqlString.Name = "txtMySqlString";
            this.txtMySqlString.Size = new System.Drawing.Size(465, 96);
            this.txtMySqlString.TabIndex = 23;
            this.txtMySqlString.Text = "server=.;user id=*;password=*;database=*;";
            // 
            // checkMySql
            // 
            this.checkMySql.AutoSize = true;
            this.checkMySql.Location = new System.Drawing.Point(3, 103);
            this.checkMySql.Name = "checkMySql";
            this.checkMySql.Size = new System.Drawing.Size(84, 16);
            this.checkMySql.TabIndex = 22;
            this.checkMySql.Text = "连接字符串";
            this.checkMySql.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(102, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(363, 21);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(101, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(363, 21);
            this.textBox2.TabIndex = 11;
            // 
            // OracleConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMySql);
            this.Controls.Add(this.btnMySqlCancel);
            this.Controls.Add(this.btnMySqlConnection);
            this.Controls.Add(this.txtMySqlString);
            this.Controls.Add(this.checkMySql);
            this.Name = "OracleConnection";
            this.Size = new System.Drawing.Size(490, 279);
            this.panelMySql.ResumeLayout(false);
            this.panelMySql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMySql;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMySqlPwd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnMySqlCancel;
        private System.Windows.Forms.Button btnMySqlConnection;
        private System.Windows.Forms.TextBox txtMySqlString;
        private System.Windows.Forms.CheckBox checkMySql;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
