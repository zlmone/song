using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WSH.Web.Mvc.Controls
{
  public static  class PaginationExtensions
    {
      public static MvcHtmlString Pagination(this HtmlHelper helper, PagerOptions options)
      {
          int pageIndex = options.PageIndex;
          int pageSize = options.PageSize;
          int pageCount = PageUtils.GetPageCount(options);
          StringBuilder sb = new StringBuilder();
          sb.AppendLine("<div style=\"text-align:center;padding:5px 0px;\" class=\"song-pagination\">");
          sb.AppendFormat("<span>共{0}项，本页显示{1}项，第{2}页/共{3}页</span>",options.TotalRecord,pageSize,pageIndex,pageCount);
          if (pageIndex <= 1)
          {
              sb.Append(GetPageText("首页"));
              sb.Append(GetPageText("上页"));
          }
          else {
              sb.Append(GetPageLink("首页",1,options));
              sb.Append(GetPageLink("上页",pageIndex-1,options));
          }
          if (pageIndex>=pageCount)
          {
              sb.Append(GetPageText("下页"));
              sb.Append(GetPageText("尾页"));
          }
          else
          {
              sb.Append(GetPageLink("下页",pageIndex+1, options));
              sb.Append(GetPageLink("尾页",pageCount, options));
          }
          sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;<span>跳转至：</span>&nbsp;&nbsp;");
          sb.Append(helper.GotoPageBox(pageCount,options));
          sb.AppendLine("</div>");
          return MvcHtmlString.Create(sb.ToString());
      }
      private static string GetPageLink(string text,int pageIndex,PagerOptions options) {
          return string.Format("&nbsp;&nbsp;<a href=\"javascript:{0}\">{1}</a>", PageUtils.GetMovePageFn(options.PageSize, pageIndex, options.OnMovePage), text);
      }
      private static string GetPageText(string text) {
          return string.Format("&nbsp;&nbsp;<span style=\"color:#cccccc\">{0}</span>", text);
      }

    }
}
