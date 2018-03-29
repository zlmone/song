//using System;
//using System.Collections.Generic;
//using System.Web;
//using System.Text;
//using WSH.Common;

//namespace Song.WebSite.View.admin
//{
//    public class BasePage : System.Web.UI.Page
//    {
//        //权限集合
//        private IDictionary<string, bool> Auth = new Dictionary<string, bool>();
//        //验证页面权限
//        protected override void OnSaveStateComplete(EventArgs e)
//        {
//            base.OnSaveStateComplete(e);
//            Auth.Add("edit",true);
//            Auth.Add("add", true);
//            Auth.Add("remove", true);
//        }

//        protected void ResponseWrite(string content)
//        {
//            Response.Write(content);
//            Response.End();
//        }
//        /// <summary>
//        /// 绑定客户端权限 
//        /// </summary>
//        /// <returns></returns>
//        public string BindClientAuth() {
//            StringBuilder sb = new StringBuilder();
//            sb.Append("{");
//            sb.Append("query:true");
//            foreach (string  key in Auth.Keys)
//            {
//                sb.AppendFormat(",{0}:{1}",StringUtils.Capitalize(key,CaseType.Lower),Auth[key].ToString().ToLower());
//            }
//            sb.Append("}");
//            return sb.ToString();
//        }
//    }
//}