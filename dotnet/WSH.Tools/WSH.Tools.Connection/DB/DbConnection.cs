using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;
using WSH.Windows.Common;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using WSH.WinForm.Common;
using WSH.Options.Common;
using WSH.Common;


namespace WSH.Tools.Connection.DB
{
    public partial class DbConnection : Form
    {
        #region 属性
        private DataBaseType defaultDataBase = DataBaseType.SqlServer;
        /// <summary>
        /// 默认数据库连接
        /// </summary>
        public DataBaseType DefaultDataBase
        {
            get { return defaultDataBase; }
            set { defaultDataBase = value; }
        }
        public string ConnectionString { get; set; }
        private bool canSqlServer = false;
        /// <summary>
        /// 是否开启SqlServer
        /// </summary>
        public bool CanSqlServer
        {
            get { return canSqlServer; }
            set { canSqlServer = value; }
        }
        private bool canOracle = false;
        /// <summary>
        /// 是否开启Oracle
        /// </summary>
        public bool CanOracle
        {
            get { return canOracle; }
            set { canOracle = value; }
        }
        private bool canMySql = false;
        /// <summary>
        /// 是否开启MySql
        /// </summary>
        public bool CanMySql
        {
            get { return canMySql; }
            set { canMySql = value; }
        }
        private bool canAccess = false;
        /// <summary>
        /// 是否开启Access
        /// </summary>
        public bool CanAccess
        {
            get { return canAccess; }
            set { canAccess = value; }
        }
        #endregion

        #region 加载设置
        public DbConnectionOptions DefaultConnection=null;
        public DbConnection()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion   

        private void DbConnection_Load(object sender, EventArgs e)
        {
            int idx = 0;
            switch (DefaultDataBase)
            {
                case DataBaseType.SqlServer:
                    {
                        idx = 0; canSqlServer = true;
                        if (DefaultConnection != null)
                        {
                            this.ucSqlConnection.SetConnectionString(DefaultConnection.ConnectionString);
                        }
                    }
                    break;
                case DataBaseType.Oracle: idx = 1; canOracle = true;
                    break;
                case DataBaseType.MySql:
                    {
                        idx = 2; canMySql = true;
                        this.mySqlConnection.SetConnectionString(DefaultConnection.ConnectionString);
                    }
                    break;
                case DataBaseType.Access: idx = 3; canAccess = true;
                    break;
            }
            this.tabDb.SelectedIndex = idx;
            if (!canSqlServer) { wrapSqlServer.Enabled = false; }
            if (!canOracle) { wrapOracle.Enabled = false; }
            if (!canMySql) { wrapMySql.Enabled = false; }
            if (!canAccess) { wrapAccess.Enabled = false; }
        }

      
    }
}
