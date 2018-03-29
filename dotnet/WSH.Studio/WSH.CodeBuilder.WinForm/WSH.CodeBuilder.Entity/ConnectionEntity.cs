using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Entity
{
    [Serializable]
    public class ConnectionEntity : WSH.CodeBuilder.Entity.Entity
    {
        private string connectionName;
        /// <summary>
        /// ConnectionName
        /// </summary>
        public string ConnectionName
        {
            get { return connectionName; }
            set { connectionName = value; }
        }
        private DataBaseType connectionType;
        /// <summary>
        /// ConnectionType
        /// </summary>
        public DataBaseType ConnectionType
        {
            get { return connectionType; }
            set { connectionType = value; }
        }
        private string connectionString;
        /// <summary>
        /// ConnectionString
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

    }
}
