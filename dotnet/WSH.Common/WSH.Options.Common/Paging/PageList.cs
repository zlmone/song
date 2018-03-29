using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class PageList<T> : List<T>
    {
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        private int pageIndex;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
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
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get { return TotalRecord == 0 ? 0 : (TotalRecord + PageSize - 1) / PageSize; }
        }
    }
}
