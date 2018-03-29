using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.DataAccess.Dapper;
using System.Data;
using WSH.Tools.Internet.InternetFate.Model;

namespace WSH.Tools.Internet.InternetFate.Manager
{
    public class FateUserInfoManager
    {
        public static IList<FateUserInfo> GetUserList()
        {
            using (DapperDb db = DapperDbFactory.CreateDb())
            {
                return db.Query<FateUserInfo>();
            }
        }
        public static bool SaveOrUpdateUser(FateUserInfo user)
        {
            if (user.FateUserId > 0)
            {
                return UpdateUser(user);
            }
            else
            {
                return AddUser(user);
            }
        }
        public static bool AddUser(FateUserInfo user)
        {
            using (DapperDb db = DapperDbFactory.CreateDb())
            {
                return db.Insert<FateUserInfo>(user);
            }
        }
        public static FateUserInfo GetUser(string userCode)
        {
            using (DapperDb db = DapperDbFactory.CreateDb())
            {
                SqlQuery filter = SqlQuery<FateUserInfo>.Builder(db).AndWhere(o => o.UserCode, FilterExpression.Equal, userCode);
                return db.SingleOrDefault<FateUserInfo>(filter);
            }
        }
        public static bool UpdateUser(FateUserInfo user)
        {
            using (DapperDb db = DapperDbFactory.CreateDb())
            {
                return db.Update<FateUserInfo>(user);
            }
        }
    }
}
