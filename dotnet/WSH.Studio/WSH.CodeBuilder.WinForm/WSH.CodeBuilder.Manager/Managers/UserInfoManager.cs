using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using System.Data;
using WSH.CodeBuilder.Entity;

namespace WSH.CodeBuilder.Manager
{
    public class UserInfoManager : BaseManager
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        public UserInfoEntity GetUserInfo(UserInfoEntity userInfo)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(userInfo.IPAddress) && !string.IsNullOrEmpty(userInfo.MacAddress))
            {
                string sql = "select * from [UserInfo] where [IPAddress]=@IPAddress and [MacAddress]=@MacAddress";
                dt = db.GetDataTable(sql, new List<Paramter>()
                { 
                    new Paramter(){ ParamterName="@IPAddress",Value=userInfo.IPAddress,DbType= DbType.String},
                    new Paramter(){ ParamterName="@MacAddress",Value=userInfo.MacAddress,DbType= DbType.String}
                });
            }
            else if (!string.IsNullOrEmpty(userInfo.UserName) && !string.IsNullOrEmpty(userInfo.Password))
            {
                string sql = "select * from [UserInfo] where [UserName]=@UserName and [Password]=@Password";
                dt = db.GetDataTable(sql, new List<Paramter>()
                { 
                    new Paramter(){ ParamterName="@UserName",Value=userInfo.UserName,DbType= DbType.String},
                    new Paramter(){ ParamterName="@Password",Value=userInfo.Password,DbType= DbType.String}
                });
            }
            List<UserInfoEntity> list = ConvertHelper.ToList<UserInfoEntity>(dt);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (item.Enabled)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public string GetSelectSql()
        {
            return string.Format("select * from [UserInfo]");
        }
        public DataTable GetDataTable()
        {
            return db.GetDataTable(GetSelectSql());
        }
        public bool UpdateList(DataTable dt)
        {
            return db.UpdateDataTable(dt, GetSelectSql());
        }
        public bool Update(UserInfoEntity entity)
        {
            return true;
        }
        public bool ExitisUser(UserInfoEntity entity)
        {
            string sql = "select count(1) from [UserInfo] where [UserName]=@UserName";
            return db.Exists(sql, new List<Paramter>() { 
                new Paramter(){ ParamterName="@UserName",DbType= DbType.String, Value=entity.UserName}
            });
        }
        public int Add(UserInfoEntity entity)
        {
            string sql = @"INSERT dbo.UserInfo
        ( UserName ,
          RealName ,
          [Password] ,
          IsAdmin ,
          IPAddress ,
          MacAddress ,
          [Enabled],
          [Email]
        )
VALUES  ( @UserName ,  
          @RealName ,  
          @Password , 
          @IsAdmin ,  
          @IPAddress ,  
          @MacAddress , 
          @Enabled,
          @Email
        )";
            return db.ExecuteAdd(sql, new List<Paramter>() { 
                new Paramter(){ ParamterName="@UserName",DbType= DbType.String, Value=entity.UserName},
                new Paramter(){ ParamterName="@RealName",DbType= DbType.String, Value=entity.RealName},
                new Paramter(){ ParamterName="@Password",DbType= DbType.String, Value=entity.Password},
                new Paramter(){ ParamterName="@IsAdmin",DbType= DbType.Boolean, Value=entity.IsAdmin},
                new Paramter(){ ParamterName="@IPAddress",DbType= DbType.String, Value=entity.IPAddress},
                new Paramter(){ ParamterName="@MacAddress",DbType= DbType.String, Value=entity.MacAddress},
                new Paramter(){ ParamterName="@Enabled",DbType= DbType.Boolean, Value=entity.Enabled},
                new Paramter(){ ParamterName="@Email",DbType= DbType.String, Value=entity.Email}
            });
        }
    }
}
