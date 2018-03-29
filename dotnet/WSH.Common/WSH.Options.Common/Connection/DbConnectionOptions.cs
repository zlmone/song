using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class DbConnectionOptions
    {
        private string _connectionString;
        private string _uid;
        private string _pwd;
        private string _dbName;

        public DbConnectionOptions()
        {
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        public string Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        public string DbName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }
    }
}
