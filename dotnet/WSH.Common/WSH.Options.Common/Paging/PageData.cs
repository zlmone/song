using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace WSH.Options.Common
{
    public class PageData
    {
        private DataTable table;
        /// <summary>
        /// 分页的数据
        /// </summary>
        public DataTable Table
        {
            get { return table; }
            set { table = value; }
        }
        private int totalRecord;
        /// <summary>
        /// 总记录条数
        /// </summary>
        public int TotalRecord
        {
            get { return totalRecord; }
            set { totalRecord = value; }
        }
        private int pageCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }
    }
}