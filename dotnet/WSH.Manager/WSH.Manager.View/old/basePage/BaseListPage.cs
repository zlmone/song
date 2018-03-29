//using System;
//using System.Collections.Generic;
//using System.Web;
//using System.Data;
//using WSH.Web.Common;
//using WSH.Options.Common;

//namespace Song.WebSite.View.admin
//{
//    public class BaseListPage : BasePage
//    {
//        public virtual PageData GetGridData(PageOptions options){
//            return null;
//        }
//        public virtual bool DeleteGridRows(string[] id, Result result) {
//            return true;
//        }
//        public int TotalRecord = 0;
        
//        protected override void OnLoad(EventArgs e)
//        {
//            if (Param.IsAsync("getGridSource"))
//            {
//                PageOptions options = new PageOptions();
//                options.PageIndex = Param.GetParamAsInt("pageIndex",1);
//                options.PageSize = Param.GetParamAsInt("pageSize",20);
//                options.SortMode = Param.Get("sortMode");
//                options.SortName = Param.Get("sortName");

//                PageData dt = this.GetGridData(options);
//                this.TotalRecord = dt.TotalRecord;
//                string json = Client.ToGridData(dt.Table, TotalRecord);
//                ResponseWrite(json);
//            }
//            if (Param.IsAsync("deleteBatch"))
//            {
//                string ids = Param.Get("deleteIDs");
//                Result result = new Result();
//                result.Msg = "删除成功";
//                try
//                {
//                    result.IsSuccess = this.DeleteGridRows(ids.Split(','), result);
//                    if(!result.IsSuccess){
//                        result.Msg = "删除失败";
//                    }
//                }
//                catch (Exception ex) {
//                    result.Msg = "删除失败,错误信息：<br>" + Client.ToHtml(ex.Message);
//                    result.IsSuccess = false;
//                }
//                string json = result.GetJsonString();
//                ResponseWrite(json);
//            }
//        }

//    }
//}