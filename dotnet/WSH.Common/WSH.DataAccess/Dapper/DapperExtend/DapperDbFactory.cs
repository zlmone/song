using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.DataAccess.Dapper
{
    public class DapperDbFactory
    {
        public static DapperDb CreateDb(string connectionStringName="DbConnectionString")
        {
            return new DapperDb(connectionStringName);
        }
    }
}
