using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public enum SqlVerifyType
    {
        SqlServer, Windows
    }
    public class SqlConnectionOptions : DbConnectionOptions
    {
        private SqlVerifyType _type;
        private string _server;

        public SqlConnectionOptions()
        {
        }

        public SqlVerifyType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }
    }
}
