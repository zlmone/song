using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;

namespace WSH.Web.Common.Response
{
    public class AjaxResult : Result
    {
        private string code;
        /// <summary>
        /// 返回结果编码
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public string ToJsonString(bool isReplace = false)
        {
            return GetJsonString(isReplace);
        }
        /// <summary>
        /// 获取ajax返回的json字符串
        /// </summary>
        /// <returns></returns>
        public string GetJsonString(bool isReplace = false)
        {
            string json = "{";
            json += "\"isSuccess\":" + IsSuccess.ToString().ToLower() + ",\"msg\":\"" + Msg + "\"";
            if (!string.IsNullOrEmpty(code))
            {
                json += ",\"code\":\"" + code + "\"";
            }
            foreach (string key in Attrs.Keys)
            {
                string val = Attrs[key];
                if (val.ToLower() != "true" && val.ToLower() != "false" && !val.StartsWith("[") && !val.StartsWith("{"))
                {
                    val = "\"" + val + "\"";
                }
                json += ",\"" + key + "\":" + val + "";
            }
            json += "}";
            if (isReplace)
            {
                return json.Replace("\\", "\\\\");
            }
            return json;
        }
    }
}
