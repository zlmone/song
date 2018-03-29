using System;

using System.Text;

namespace WSH.Common
{

    public class BusinessException : Exception
    {
        public BusinessException(string msg)
            : base(msg)
        {

        }
    }
    //数据库操作异常类
    public class DataBaseException : Exception
    {
        public DataBaseException(string msg)
            : base(msg)
        {
        }

    }
    //数据重复异常类
    public class DataExistException : Exception
    {
        public DataExistException(string msg)
            : base(msg)
        {

        }
    }
    //数据找不到异常类
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string msg)
            : base(msg)
        {

        }
    }
     
    //没有权限异常类
    public class NotRoleException : Exception
    {
        public NotRoleException(string msg)
            : base(msg)
        {

        }
    }
    //数据验证异常类
    public class DataValidException : Exception
    {
        public DataValidException(string msg)
            : base(msg)
        {

        }
    }
}