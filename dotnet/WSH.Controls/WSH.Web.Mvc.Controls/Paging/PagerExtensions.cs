using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WSH.Web.Mvc.Controls
{
    public static class PagerExtensions
    {
        private static int[] PageList = new int[] { 5, 10, 15, 20, 30, 40, 50 };
        private static string GetSelectItem(int text)
        {
            return string.Format("<option value='{0}'>{1}</option>", text, text);
        }
        public static MvcHtmlString Pager(this HtmlHelper helper, PagerOptions options)
        {
            int pageSize = options.PageSize;
            string fn = options.OnMovePage;
            //int about=options.AboutCount;
            int pageCount = PageUtils.GetPageCount(options);
            int pageIndex = options.PageIndex;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div>");
            sb.AppendLine("<div class=\"song-paging\">");
            sb.AppendFormat("<select value=\"{0}\" onchange=\"" + PageUtils.GetMovePageFn("this.value",1,fn)+ "\">", pageSize);
            //动态生成pageSize
            sb.Append(GetSelectItem(pageSize));
            for (int i = 0; i < PageList.Length; i++)
            {
                if(PageList[i]!=pageSize){
                    sb.Append(GetSelectItem(PageList[i]));
                }
            }
            sb.AppendLine("</select>");
            //上一页
            if(pageIndex>1){
                sb.AppendLine("<a href=\"javascript:" + PageUtils.GetMovePageFn(pageSize, (pageIndex - 1), fn) + "\">上一页</a>");
            }
            //动态生成页码
            //只有一页,直接显示1
            //if (pageCount <= 1)
            //{
                //this.pageIndex = 1; 
                //this.pageCount = 1;
                //return this.pHtml2(1);
                
            //}
          // if (pageCount < pageIndex) { pageIndex = pageCount; };
            //var re = "";
          //  第一页
            //if (pageIndex <= 1)
            //{
            //    pageIndex = 1;
            //}
            //else
            //{
            //    //非第一页
            //    //re += this.pHtml(pageIndex - 1, pageCount, "上一页");
            //    //总是显示第一页页码
            if(pageIndex>1){
                sb.AppendLine(GetPageLink(1, options));
            }
            //}
            //校正页码
          // pageIndex = options.PageIndex;  

            //开始页码
           
                var start = 2;
                var end = (pageCount < 7) ? pageCount : 7;
                //是否显示前置省略号,即大于10的开始页码
                if (pageIndex >= 6)
                {
                    sb.AppendLine(GetPageDot());
                    start = pageIndex - 3;
                    var e = pageIndex + 3;
                    end = (pageCount < e) ? pageCount : e;
                }
                for (var i = start; i < pageIndex; i++)
                {
                    sb.AppendLine(GetPageLink(i, options));
                };
                sb.AppendLine(GetPageLink(pageIndex, options));
                for (var i = pageIndex + 1; i <= end; i++)
                {
                    sb.AppendLine(GetPageLink(i, options));
                };
                if (end < pageCount)
                {
                    sb.AppendLine(GetPageDot());
                    //显示最后一页页码,如不需要则去掉下面这一句
                    sb.AppendLine(GetPageLink(pageCount, options));
                };
          
            //下一页
            if(pageIndex<pageCount){
                sb.AppendLine("<a href=\"javascript:" + PageUtils.GetMovePageFn(pageSize, (pageIndex + 1), fn) + "\">下一页</a>");
            }
            sb.AppendLine("&nbsp;<label>跳转到</label>");
            
            //输出跳转数字框
            sb.AppendLine(helper.GotoPageBox(pageCount,options));

            sb.AppendLine("</div>");
            sb.AppendLine("<div class=\"song-clear\"></div>");
            sb.AppendLine("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }
        private static string GetPageLink(int pageNumber,PagerOptions options)
        {
            if (pageNumber == options.PageIndex)
            {
                return string.Format("<span class=\"active\">{0}</span>",pageNumber);
            }
            return string.Format("<a href=\"javascript:" + PageUtils.GetMovePageFn(options.PageSize, pageNumber, options.OnMovePage) + "\">{0}</a>", pageNumber);
        }
        private static string GetPageDot()
        {
            return string.Format("<span class=\"dot\">...</span>");
        }
    }
    
}
