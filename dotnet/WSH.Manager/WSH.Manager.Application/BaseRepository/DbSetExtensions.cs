using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Options.Common;
using WSH.Web.Mvc.Common;

namespace WSH.Manager.Applications
{
    public static class DbSetExtensions
    {
        public static PageList<T> ToPagingList<T>(this IQueryable<T> query, int pageIndex = 1, int pageSize = 10)
        {
            var total = query.Count();
            PageList<T> paging = new PageList<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var list = query.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            if (list != null)
            {
                paging.AddRange(list);
            }
            paging.TotalRecord = total;
            return paging;
        }
    }
}
