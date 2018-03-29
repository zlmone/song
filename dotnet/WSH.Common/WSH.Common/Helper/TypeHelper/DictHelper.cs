using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common.Helper
{
    public class DictHelper
    {
        /// <summary>
        /// 生成url参数字符串
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string ToParamterString(Dictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    string value = parameters[key];
                    // 忽略参数名或参数值为空的参数
                    if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                    {
                        if (hasParam)
                        {
                            postData.Append("&");
                        }
                        postData.Append(key);
                        postData.Append("=");
                        postData.Append(value);
                        hasParam = true;
                    }
                }
            }
            return postData.ToString();
        }
        /// <summary>
        /// 转换成Json字符串
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static string ToJson(IDictionary<string, object> dict)
        {
            if (dict != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                int i = 0;
                foreach (string key in dict.Keys)
                {
                    string last = StringHelper.GetLast(dict.Count, i);
                    if (DataTypeHelper.IsBool(dict[key]) || DataTypeHelper.IsInt(dict[key]))
                    {
                        sb.AppendFormat("\"{0}\":{1}{2}", key, dict[key], last);
                    }
                    else
                    {
                        sb.AppendFormat("\"{0}\":\"{1}\"{2}", key, dict[key], last);
                    }
                    i++;
                }
                sb.Append("}");
                return sb.ToString();
            }
            return "{}";
        }
        public static string ToJsonItem(IDictionary<string, object> dict)
        {
            if (dict != null)
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                foreach (string key in dict.Keys)
                {
                    string last = StringHelper.GetLast(dict.Count, i);
                    bool isBool = DataTypeHelper.IsBool(dict[key]);
                    if (isBool || DataTypeHelper.IsInt(dict[key]))
                    {
                        sb.AppendFormat("{0}:{1}{2}", key, isBool ? dict[key].ToString().ToLower() : dict[key], last);
                    }
                    else
                    {
                        sb.AppendFormat("{0}:'{1}'{2}", key, dict[key], last);
                    }
                    i++;
                }
                return sb.ToString();
            }
            return "";
        }
    }
}
