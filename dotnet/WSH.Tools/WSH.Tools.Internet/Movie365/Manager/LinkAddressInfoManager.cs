using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.DataAccess.Dapper;
using System.Data;
using WSH.Tools.Internet.Movie.Model;

namespace WSH.Tools.Internet.Movie.Manager
{
    public class LinkAddressInfoManager
    {
        public static IList<LinkAddressInfo> GetLinkList(LinkAddressType type)
        {
            using (DapperDb db = DapperDbFactory.CreateDb())
            {
                SqlQuery filter = SqlQuery<LinkAddressInfo>.Builder(db).AndWhere(o => o.LinkType, FilterExpression.Equal, (int)type);
                return db.Query<LinkAddressInfo>(filter);
            }
        }
        public static LinkAddressInfo GetLinkInfo(string linkAddress)
        {
            using (DapperDb db = DapperDbFactory.CreateDb())
            {
                SqlQuery filter = SqlQuery<LinkAddressInfo>.Builder(db).AndWhere(o => o.LinkAddress, FilterExpression.Equal, linkAddress);
                return db.SingleOrDefault<LinkAddressInfo>(filter);
            }
        }
        public static bool SaveOrUpdateUser(LinkAddressInfo linkAddress)
        {
            if (linkAddress.LinkAddressId > 0)
            {
                return UpdateUser(linkAddress);
            }
            else
            {
                return AddUser(linkAddress);
            }
        }
        public static bool AddUser(LinkAddressInfo linkAddress)
        {
            using (DapperDb db = DapperDbFactory.CreateDb())
            {
                return db.Insert<LinkAddressInfo>(linkAddress);
            }
        }

        public static bool UpdateUser(LinkAddressInfo linkAddress)
        {
            using (DapperDb db = DapperDbFactory.CreateDb())
            {
                return db.Update<LinkAddressInfo>(linkAddress);
            }
        }
    }
}
