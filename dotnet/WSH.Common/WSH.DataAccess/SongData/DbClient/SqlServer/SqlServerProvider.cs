using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common;

namespace WSH.DataAccess.SongData
{
    public class SqlServerProvider : BaseDbProvider
    {
        private System.Data.Common.DbProviderFactory dbFactory;
        public override System.Data.Common.DbProviderFactory GetDbProviderFactory
        {
            get
            {
                if (dbFactory == null)
                {
                    dbFactory = DbFactory.CreateDbProviderFactory(DataBaseType.SqlServer);
                }
                return dbFactory;
            }
        }
    }
}
