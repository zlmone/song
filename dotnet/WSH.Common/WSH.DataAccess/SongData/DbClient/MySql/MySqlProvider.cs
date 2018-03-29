using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.DataAccess.SongData
{
    public class MySqlProvider: BaseDbProvider
    {
        private System.Data.Common.DbProviderFactory dbFactory;
        public override System.Data.Common.DbProviderFactory GetDbProviderFactory
        {
            get
            {
                if (dbFactory == null)
                {
                    dbFactory = DbFactory.CreateDbProviderFactory(WSH.Common.DataBaseType.MySql);
                }
                return dbFactory;
            }
        }
    }
}
