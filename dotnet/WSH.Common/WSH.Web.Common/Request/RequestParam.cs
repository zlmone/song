using System;
using System.Collections.Generic;

using System.Text;
using System.Web;
using WSH.Common;
using WSH.Common.Helper;

namespace WSH.Web.Common.Request
{
    public class RequestParam
    {
        private Dictionary<string, object> param = new Dictionary<string, object>();
        //构造函数
        public RequestParam() { }
        public RequestParam(string ParamKey, object ParamVal)
        {
            param.Add(ParamKey,ParamVal);
        }
        //设置地址栏参数值
        public RequestParam Set(string key, object val)
        {
            if(param.ContainsKey(key)==false){
                param.Add(key, val);
            }
            return this;
        }
        //转换成地址栏参数字符串
        public string ToUrlParam()
        {
            string urlParam = "";
            if (param != null && param.Count > 0)
            {
                urlParam += "?";
                foreach (string k in param.Keys)
                {
                    urlParam += k + "=" + param[k].ToString() + "&";
                }
                urlParam = StringHelper.DeleteEnd(urlParam, "&");
            }
            return urlParam;
        }
        public string ToAndParam()
        {
            string urlParam = "";
            if (param != null && param.Count > 0)
            {
                foreach (string k in param.Keys)
                {
                    urlParam += k + "=" + param[k].ToString() + "&";
                }
                urlParam = StringHelper.DeleteEnd(urlParam, "&");
            }
            return urlParam;
        }
        /// <summary>
        /// 获取参数，如果为空则返回空字符串
        /// </summary>
        public static string Get(string name)
        {
            string p=HttpContext.Current.Request.Params[name] ;
            return p == null ? "" : p;
        }
        public static  bool Has(string key, string value)
        {
            string v = Get(key);
            if (string.IsNullOrEmpty(v))
            {
                return false;
            }
            return v == value;
        }
        public static  bool Has(string key)
        {
            return !string.IsNullOrEmpty(Get(key));
        }
        public static  bool IsAsync(string key)
        {
            return Has("isAsyncRequest", key);
        }
        /// <summary>
        /// 获取int类型参数，如果值不存在则返回默认值
        /// </summary>
        public static int GetParamAsInt(string name,int def) {
            string param = Get(name);
            return param == "" ? def : Convert.ToInt32(param);
        }
        /// <summary>
        /// 获取string类型参数，如果值不存在则返回默认值
        /// </summary>
        public static string GetParamAsString(string name, string def) {
            string param = Get(name);
            return param == "" ? def : param;
        }
    }
}
