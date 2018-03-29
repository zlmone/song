using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class QueryParamsBase
    {
        private int pageIndex=1;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
        private int pageSize=15;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        private string sortName;

        public string SortName
        {
            get { return sortName; }
            set { sortName = value; }
        }
        private string sortMode;

        public string SortMode
        {
            get { return sortMode; }
            set { sortMode = value; }
        }
    }
}
