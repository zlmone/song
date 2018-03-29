using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Web.Mvc.Common
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// 分页扩展
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        public static IQueryable<T> TakePage<T>(this IQueryable<T> queryable, int pageIndex = 1, int pageSize = 10)
        {
            var countSkip = (pageIndex - 1) * pageSize - 1;
            if (countSkip < 0)
            {
                countSkip = 0;
            }
            return queryable.Skip(countSkip).Take(pageSize);
        }
    }
}
