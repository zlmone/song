namespace WSH.Tools.Connection.DB
{
    partial class DbConnection
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbConnection));
            this.tabDb = new System.Windows.Forms.TabControl();
            this.wrapSqlServer = new System.Windows.Forms.TabPage();
            this.ucSqlConnection = new WSH.Tools.Connection.DB.SqlServerConnection();
            this.tabPageOracle = new System.Windows.Forms.TabPage();
            this.wrapOracle = new System.Windows.Forms.Panel();
            this.oracleConnection1 = new WSH.Tools.Connection.DB.OracleConnection();
            this.tabPageMySql = new System.Windows.Forms.TabPage();
            this.wrapMySql = new System.Windows.Forms.Panel();
            this.mySqlConnection = new WSH.Tools.Connection.DB.MySqlConnection();
            this.tabPageAccess = new System.Windows.Forms.TabPage();
            this.wrapAccess = new System.Windows.Forms.Panel();
            this.ucAccessConnection1 = new WSH.Tools.Connection.DB.AccessConnection();
            this.tabDb.SuspendLayout();
            this.wrapSqlServer.SuspendLayout();
            this.tabPageOracle.SuspendLayout();
            this.wrapOracle.SuspendLayout();
            this.tabPageMySql.SuspendLayout();
            this.wrapMySql.SuspendLayout();
            this.tabPageAccess.SuspendLayout();
            this.wrapAccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDb
            // 
            this.tabDb.Controls.Add(this.wrapSqlServer);
            this.tabDb.Controls.Add(this.tabPageOracle);
            this.tabDb.Controls.Add(this.tabPageMySql);
            this.tabDb.Controls.Add(this.tabPageAccess);
            this.tabDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDb.Location = new System.Drawing.Point(0, 0);
            this.tabDb.Name = "tabDb";
            this.tabDb.SelectedIndex = 0;
            this.tabDb.Size = new System.Drawing.Size(505, 360);
            this.tabDb.TabIndex = 0;
            // 
            // wrapSqlServer
            // 
            this.wrapSqlServer.Controls.Add(this.ucSqlConnection);
            this.wrapSqlServer.Location = new System.Drawing.Point(4, 22);
            this.wrapSqlServer.Name = "wrapSqlServer";
            this.wrapSqlServer.Padding = new System.Windows.Forms.Padding(3);
            this.wrapSqlServer.Size = new System.Drawing.Size(497, 334);
            this.wrapSqlServer.TabIndex = 1;
            this.wrapSqlServer.Text = "SqlServer";
            this.wrapSqlServer.UseVisualStyleBackColor = true;
            // 
            // ucSqlConnection
            // 
            this.ucSqlConnection.Location = new System.Drawing.Point(3, 3);
            this.ucSqlConnection.Name = "ucSqlConnection";
            this.ucSqlConnection.Size = new System.Drawing.Size(487, 325);
            this.ucSqlConnection.TabIndex = 0;
            // 
            // tabPageOracle
            // 
            this.tabPageOracle.Controls.Add(this.wrapOracle);
            this.tabPageOracle.Location = new System.Drawing.Point(4, 22);
            this.tabPageOracle.Name = "tabPageOracle";
            this.tabPageOracle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOracle.Size = new System.Drawing.Size(497, 334);
            this.tabPageOracle.TabIndex = 2;
            this.tabPageOracle.Text = "Oracle";
            this.tabPageOracle.UseVisualStyleBackColor = true;
            // 
            // wrapOracle
            // 
            this.wrapOracle.Controls.Add(this.oracleConnection1);
            this.wrapOracle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wrapOracle.Location = new System.Drawing.Point(3, 3);
            this.wrapOracle.Name = "wrapOracle";
            this.wrapOracle.Size = new System.Drawing.Size(491, 328);
            this.wrapOracle.TabIndex = 0;
            // 
            // oracleConnection1
            // 
            this.oracleConnection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oracleConnection1.Location = new System.Drawing.Point(0, 0);
            this.oracleConnection1.Name = "oracleConnection1";
            this.oracleConnection1.Size = new System.Drawing.Size(491, 328);
            this.oracleConnection1.TabIndex = 0;
            // 
            // tabPageMySql
            // 
            this.tabPageMySql.Controls.Add(this.wrapMySql);
            this.tabPageMySql.Location = new System.Drawing.Point(4, 22);
            this.tabPageMySql.Name = "tabPageMySql";
            this.tabPageMySql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMySql.Size = new System.Drawing.Size(497, 334);
            this.tabPageMySql.TabIndex = 3;
            this.tabPageMySql.Text = "MySql";
            this.tabPageMySql.UseVisualStyleBackColor = true;
            // 
            // wrapMySql
            // 
            this.wrapMySql.Controls.Add(this.mySqlConnection);
            this.wrapMySql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wrapMySql.Location = new System.Drawing.Point(3, 3);
            this.wrapMySql.Name = "wrapMySql";
            this.wrapMySql.Size = new System.Drawing.Size(491, 328);
            this.wrapMySql.TabIndex = 0;
            // 
            // mySqlConnection
            // 
            this.mySqlConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlConnection.Location = new System.Drawing.Point(0, 0);
            this.mySqlConnection.Name = "mySqlConnection";
            this.mySqlConnection.Size = new System.Drawing.Size(491, 328);
            this.mySqlConnection.TabIndex = 0;
            // 
            // tabPageAccess
            // 
            this.tabPageAccess.Controls.Add(this.wrapAccess);
            this.tabPageAccess.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccess.Name = "tabPageAccess";
            this.tabPageAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccess.Size = new System.Drawing.Size(497, 334);
            this.tabPageAccess.TabIndex = 4;
            this.tabPageAccess.Text = "Access";
            this.tabPageAccess.UseVisualStyleBackColor = true;
            // 
            // wrapAccess
            // 
            this.wrapAccess.Controls.Add(this.ucAccessConnection1);
            this.wrapAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wrapAccess.Location = new System.Drawing.Point(3, 3);
            this.wrapAccess.Name = "wrapAccess";
            this.wrapAccess.Size = new System.Drawing.Size(491, 328);
            this.wrapAccess.TabIndex = 18;
            // 
            // ucAccessConnection1
            // 
            this.ucAccessConnection1.Location = new System.Drawing.Point(-1, 3);
            this.ucAccessConnection1.Name = "ucAccessConnection1";
            this.ucAccessConnection1.Size = new System.Drawing.Size(495, 313);
            this.ucAccessConnection1.TabIndex = 0;
            // 
            // DbConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 360);
            this.Controls.Add(this.tabDb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DbConnection";
            this.Text = "数据连接";
            this.Load += new System.EventHandler(this.DbConnection_Load);
            this.tabDb.ResumeLayout(false);
            this.wrapSqlServer.ResumeLayout(false);
            this.tabPageOracle.ResumeLayout(false);
            this.wrapOracle.ResumeLayout(false);
            this.tabPageMySql.ResumeLayout(false);
            this.wrapMySql.ResumeLayout(false);
            this.tabPageAccess.ResumeLayout(false);
            this.wrapAccess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDb;
        private System.Windows.Forms.TabPage wrapSqlServer;
        private System.Windows.Forms.TabPage tabPageOracle;
        private System.Windows.Forms.TabPage tabPageMySql;
        private System.Windows.Forms.TabPage tabPageAccess;
        private System.Windows.Forms.Panel wrapAccess;
        private System.Windows.Forms.Panel wrapOracle;
        private System.Windows.Forms.Panel wrapMySql;
        private SqlServerConnection ucSqlConnection;
        private AccessConnection ucAccessConnection1;
        private OracleConnection oracleConnection1;
        private MySqlConnection mySqlConnection;
    }
}

