using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.DataAccess.Dapper;

namespace WSH.Tools.Internet.InternetFate.Model
{
    public class FateUserInfo
    {
        [Id(true)]
        public int FateUserId { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string HeadFileName { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }

        public int Height { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Marriage { get; set; }

        public string ShortNote { get; set; }

        public string Comment { get; set; }
    }
}

