using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WSH.Web.Mvc.Controls
{
    public static class PageUtils
    {
        public static int GetPageCount(PagerOptions options)
        {
            int pageSize = options.PageSize;
            return Math.Max((options.TotalRecord + pageSize - 1) / pageSize, 1);
        }
             
        public static string GetMovePageFn(object pageSize,int pageIndex,string fn) {
            //return string.Format("song.mvcPager.move({0},{1},{2});", pageSize, pageIndex, fn);
            return string.Format("{0}({1},{2});",fn,pageIndex,pageSize);
        }
        public static string GotoPageBox(this HtmlHelper helper, int pageCount,PagerOptions options)
        {
            string id = "WSHPAGER-" + Guid.NewGuid().ToString("N");
            return helper.NumberBox(id, null, new NumberOptions()
                 {
                     AllowDecimal = false,
                     AllowNegative = false,
                     MinValue = 1,
                     MaxValue = pageCount,
                     OnEnter = "function(e){song.pager.goto.call(this," + options.PageSize + "," + options.PageIndex + "," + options.OnMovePage + ");}"
                 }, new
                 {
                     @class = "num",
                     @style="width:40px;"
                 }).ToHtmlString();
        }
    }
    /// <summary>
    /// 分页配置
    /// </summary>
    public class PagerOptions
    {
        private int pageSize = 20;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        private int pageIndex = 1;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
        private int totalRecord = 0;

        public int TotalRecord
        {
            get { return totalRecord; }
            set { totalRecord = value; }
        }
        private string onMovePage = "song.pager.move";

        public string OnMovePage
        {
            get { return onMovePage; }
            set { onMovePage = value; }
        }
    }
}
