using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace WSH.Common.Helper
{
    public class TagHelper
    {
        #region 清除HTML标记
        ///<summary>   
        ///清除HTML标记   
        ///</summary>   
        ///<param name="NoHTML">包括HTML的源码</param>   
        ///<returns>已经去除后的文字</returns>   
        public static string RemoveHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML   
            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            Htmlstring = regex.Replace(Htmlstring, "");
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");

            return Htmlstring;
        }
        #endregion

        #region 匹配页面的链接
        /// <summary>
        /// 获取页面的链接正则
        /// </summary>
        public string GetHref(string HtmlCode)
        {
            string MatchVale = "";
            string Reg = @"(h|H)(r|R)(e|E)(f|F) *= *('|"")?((\w|\\|\/|\.|:|-|_)+)[\S]*";
            foreach (Match m in Regex.Matches(HtmlCode, Reg))
            {
                MatchVale += (m.Value).ToLower().Replace("href=", "").Trim() + "|";
            }
            return MatchVale;
        }
        #endregion

        #region 压缩HTML输出
        /// <summary>
        /// 压缩HTML输出
        /// </summary>
        public static string ZipHtml(string Html)
        {
            Html = Regex.Replace(Html, @">\s+?<", "><");//去除HTML中的空白字符
            Html = Regex.Replace(Html, @"\r\n\s*", "");
            Html = Regex.Replace(Html, @"<body([\s|\S]*?)>([\s|\S]*?)</body>", @"<body$1>$2</body>", RegexOptions.IgnoreCase);
            return Html;
        }
        #endregion

        #region 过滤指定HTML标签
        /// <summary>
        /// 过滤指定HTML标签
        /// </summary>
        /// <param name="s_TextStr">要过滤的字符</param>
        /// <param name="html_Str">a img p div</param>
        public static string RemoveHtml(string s_TextStr, string html_Str)
        {
            string rStr = "";
            if (!string.IsNullOrEmpty(s_TextStr))
            {
                rStr = Regex.Replace(s_TextStr, "<" + html_Str + "[^>]*>", "", RegexOptions.IgnoreCase);
                rStr = Regex.Replace(rStr, "</" + html_Str + ">", "", RegexOptions.IgnoreCase);
            }
            return rStr;
        }
        #endregion

        #region 解析标记和属性
        /// <summary>
        /// 解析同级别的html标签，不能解析子标签
        /// </summary>
        /// <param name="htmls">例如：<element>text</element></param>
        /// <returns></returns>
        public static IList<TagBuilder> ParseSiblingHmlt(string html)
        {
            IList<TagBuilder> tags = new List<TagBuilder>();
            html = "<ParseSiblingHmltRoot>" + html + "</ParseSiblingHmltRoot>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(html);
            XmlNodeList nodes = doc.DocumentElement.ChildNodes;
            if (nodes.Count > 0)
            {
                foreach (XmlNode node in nodes)
                {
                    TagBuilder tag = new TagBuilder()
                    {
                        InnerHtml = node.InnerText.Trim(),
                        TagName = node.Name
                    };
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        tag.AddAttribute(attr.Name, attr.Value);
                    }
                    tags.Add(tag);
                }
            }
            return tags;
        }
        /// <summary>
        /// 解析标签属性
        /// </summary>
        /// <param name="attrsHtml">例如：href="http://www.baidu.com" icon="a.png">百度</param>
        /// <returns></returns>
        public static IDictionary<string, string> ParseAttributes(string attrsHtml)
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            if (attrsHtml.Contains(">"))
            {
                string[] attrs = attrsHtml.Split('>');
                dic.Add("InnerText", attrs[1].Trim());
                attrsHtml = attrs[0];
            }
            string[] attrItems = Regex.Split(attrsHtml.Trim(), "\\s+");
            foreach (string item in attrItems)
            {
                string[] items = item.Split('=');
                string key = items[0].Trim();
                string value = items[1];
                //防止value里包含“=”
                if (items.Length > 2)
                {
                    for (int i = 2; i < items.Length; i++)
                    {
                        value = value + "=" + items[i];
                    }
                }
                dic.Add(key, value.Trim().Replace("\"", ""));
            }
            return dic;
        }
        #endregion
    }
}
