using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WSH.Options.Common;
using WSH.Web.Common;
using WSH.Web.Mvc.Common;
using WSH.Web.Common.EasyUI;
using WSH.Web.Common.Response;
using WSH.Web.Common.Helper;

namespace WSH.Manager.Controllers
{
    public class BaseController : Controller
    {
        public delegate string SaveAction<T>(AjaxResult result);
        public delegate ContentResult GetListAction<T>(AjaxResult result);
        #region 通用的方法
        public ContentResult GridResult(int total, object list)
        {
            return Content(EasyGridMgr.GetGridData(total, JsonHelper.ToJson(list)));
        }
        public ContentResult GridResult<T>(PageList<T> list)
        {
            return GridResult(list.TotalRecord, list);
        }
        #endregion

        #region 重载的操作方法
        protected virtual void RemoveGridRows(string[] ids, Result result)
        {
        }
        #endregion

        #region 默认的操作action
        /// <summary>
        /// 删除通用的Action
        /// </summary>
        /// <param name="removeGridRows"></param>
        /// <returns></returns>
        public ContentResult RemoveGridRowsAction(string removeGridRows)
        {
            return TryAction(r =>
            {
                string[] ids = removeGridRows.Split(',');
                RemoveGridRows(ids, r);
            });
        }
        /// <summary>
        /// 保存时执行的action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public ContentResult TrySaveAction(SaveAction<AjaxResult> action, Action<AjaxResult> catchAction = null)
        {
            return TryAction(o =>
            {
                string id = action(o);
                o.Add("idFieldValue", id);
            }, "保存", catchAction);
        }
        /// <summary>
        /// 通用的执行命令
        /// </summary>
        /// <param name="action">业务逻辑方法</param>
        /// <param name="actionName">业务描述</param>
        /// <param name="catchAction">出错执行的方法</param>
        /// <returns>json结果集</returns>
        public ContentResult TryAction(Action<AjaxResult> action, string actionName = "操作", Action<AjaxResult> catchAction = null)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                result.IsSuccess = true;
                result.Msg = actionName + "成功";
                action(result);
            }
            catch (Exception ex)
            {
                //记录错误日志
                //。。。。。。。
                result.IsSuccess = false;
                result.Msg = actionName + "失败，错误信息：<br>" + ClientHelper.ToHtml(ex.Message);
                if (catchAction != null)
                {
                    catchAction(result);
                }
            }
            return Content(result.ToJsonString());
        }

        #endregion
    }
}
