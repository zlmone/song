using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using WSH.Common;
using System.Text.RegularExpressions;
using System.IO;
using WSH.Common.Helper;

namespace WSH.Web.Common.Helper
{
    public class ClientHelper
    {
        /// <summary>
        /// 对于资源文件内容（如：js，css）做简单压缩
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string SimpleMinify(string fileName) {
            string ext = Path.GetExtension(fileName).ToLower();
            string content = FileHelper.GetFileContent(fileName);
            if (ext == ".css")
            {
                return CSSMinify(content);
            }
            else {
                return JavaScriptMinify(content);
            }
        }
        private static string JavaScriptMinify(string Input)
        {
            string[] CodeLines = Input.Split(new string[] { System.Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder Builder = new StringBuilder();
            foreach (string Line in CodeLines)
            {
                string Temp = Line.Trim();
                if (Temp.Length > 0 && !Temp.StartsWith("//", StringComparison.InvariantCulture))
                    Builder.AppendLine(Temp);
            }

            Input = Builder.ToString();
            Input = Regex.Replace(Input, @"(/\*\*/)|(/\*[^!][\s\S]*?\*/)", string.Empty);
            Input = Regex.Replace(Input, @"^[\s]+|[ \f\r\t\v]+$", String.Empty);
            Input = Regex.Replace(Input, @"^[\s]+|[ \f\r\t\v]+$", String.Empty);
            Input = Regex.Replace(Input, @"([+-])\n\1", "$1 $1");
            Input = Regex.Replace(Input, @"([^+-][+-])\n", "$1");
            Input = Regex.Replace(Input, @"([^+]) ?(\+)", "$1$2");
            Input = Regex.Replace(Input, @"(\+) ?([^+])", "$1$2");
            Input = Regex.Replace(Input, @"([^-]) ?(\-)", "$1$2");
            Input = Regex.Replace(Input, @"(\-) ?([^-])", "$1$2");
            Input = Regex.Replace(Input, @"\n([{}()[\],<>/*%&|^!~?:=.;+-])", "$1");
            Input = Regex.Replace(Input, @"(\W(if|while|for)\([^{]*?\))\n", "$1");
            Input = Regex.Replace(Input, @"(\W(if|while|for)\([^{]*?\))((if|while|for)\([^{]*?\))\n", "$1$3");
            Input = Regex.Replace(Input, @"([;}]else)\n", "$1 ");
            Input = Regex.Replace(Input, @"(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,}(?=&nbsp;)|(?<=&nbsp;)\s{2,}(?=[<])", String.Empty);

            return Input;
        }
        private static string CSSMinify(string Input)
        {
            Input = Regex.Replace(Input, @"(/\*\*/)|(/\*[^!][\s\S]*?\*/)", string.Empty);
            Input = Regex.Replace(Input, @"\s+", " ");
            Input = Regex.Replace(Input, @"(\s([\{:,;\}\(\)]))", "$2");
            Input = Regex.Replace(Input, @"(([\{:,;\}\(\)])\s)", "$2");
            Input = Regex.Replace(Input, ":0 0 0 0;", ":0;");
            Input = Regex.Replace(Input, ":0 0 0;", ":0;");
            Input = Regex.Replace(Input, ":0 0;", ":0;");
            Input = Regex.Replace(Input, ";}", "}");
            Input = Regex.Replace(Input, @"(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,}(?=&nbsp;)|(?<=&nbsp;)\s{2,}(?=[<])", string.Empty);
            Input = Regex.Replace(Input, @"([!{}:;>+([,])\s+", "$1");
            Input = Regex.Replace(Input, @"([\s:])(0)(px|em|%|in|cm|mm|pc|pt|ex)", "$1$2");
            Input = Regex.Replace(Input, "background-position:0", "background-position:0 0");
            Input = Regex.Replace(Input, @"(:|\s)0+\.(\d+)", "$1.$2");
            Input = Regex.Replace(Input, @"[^\}]+\{;\}", "");
            return Input;
        }

        public static string GetStyle(IDictionary<string, string> styles)
        {
            string css = "";
            if (styles != null && styles.Count > 0)
            {
                foreach (string key in styles.Keys)
                {
                    css += string.Format("{0}:{1};", key, styles[key]);
                }
            }
            return css;
        }
        public static string ToHtml(string msg)
        {
            return msg.Replace("\r\n", "<br>").Replace("\"", "");
        }
        public static void AddAttr(IDictionary<string, object> attrs, string key, string value)
        {
            if (attrs.ContainsKey(key))
            {
                if (key.Equals("class"))
                {
                    attrs[key] = attrs[key] + " " + value;
                }
                else
                {
                    attrs[key] = value;
                }
            }
            else
            {
                attrs.Add(key, value);
            }
        }
        #region 数据类型转换
        public static string GetEnum(Enum value)
        {
            return value.ToString().ToLower();
        }
        public static string GetBool(bool value)
        {
            return value.ToString().ToLower();
        }
        public static string GetIcon(Icons icon)
        {
            return "icon-" + GetEnum(icon);
        }
        #endregion

        #region 转json数据
        public static string GetArray(string[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sb.Append("\"" + array[i] + "\"");
                    if (i < array.Length - 1)
                    {
                        sb.Append(",");
                    }
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
        public static string GetDictionary(Dictionary<string, string> dic)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            int count = 0;
            if (dic != null)
            {
                foreach (string key in dic.Keys)
                {
                    count++;
                    sb.Append(key + ":\"" + dic[key] + "\"");
                    if (count < dic.Keys.Count)
                    {
                        sb.Append(",");
                    }
                }
            }
            sb.Append("}");
            return sb.ToString();
        }
        #region 将datatable数据转成json字符串格式
        public static string ToGridData(DataTable dt, int count)
        {
            return "{\"totalRecord\":" + count + ",\"rows\":" + ToJsonString(dt) + "}";
        }
        public static string ToJsonString(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                sb.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string name = dt.Columns[j].ColumnName.ToString();
                        string value = dt.Rows[i][j].ToString();
                        if (value == "True" || value == "False")
                        {
                            value = value.ToLower();
                        }
                        sb.Append("\"" + name + "\":" + "\"" + value + "\"");
                        sb.Append(j == (dt.Columns.Count - 1) ? "" : ",");
                    }
                    sb.Append("}");
                    sb.Append(i == (dt.Rows.Count - 1) ? "" : ",");
                }
                sb.Append("]");
                return sb.ToString();
            }
            else
            {
                return "[]";
            }
        }
        #endregion

        #region 指定datatable某一列转化JSON字符串
        public static string ToJsonMap(DataTable dt, string keyField, string valField)
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append(row[keyField].ToString() + ":" + "'" + row[valField].ToString() + "'");
                count++;
                if (count < dt.Rows.Count) { sb.Append(","); }
            }
            sb.Append("}");
            return sb.ToString();
        }
        #endregion
        #endregion
  
    }
}
