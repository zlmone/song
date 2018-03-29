using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.IO;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Net.Security;

namespace WSH.Common.Helper
{
    public static class DataMiningHelper
    {
        private static bool proxyEnable =string.IsNullOrEmpty(ConfigurationManager.AppSettings["ProxyEnable"]) ? false : bool.Parse(ConfigurationManager.AppSettings["ProxyEnable"]);//是否启用代理
        private static string proxyServer = ConfigurationManager.AppSettings["ProxyServer"];//代理服务器地址
        private static int proxyPort = Convert.ToInt32(ConfigurationManager.AppSettings["ProxyPort"]);//代理服务器端口
        public static string GrabberPath = @"C:\Grabber\";

        #region 通过get的方式请求得到页面信息，参数1：url ，参数2：编码格式
        public static string GetHtmlAutoEncode(string url, out string encoding)
        {
            WebClient myWebClient = new WebClient(); //创建WebClient实例myWebClient
            // 需要注意的：
            //有的网页可能下不下来，有种种原因比如需要cookie,编码问题等等
            //这是就要具体问题具体分析比如在头部加入cookie
            // webclient.Headers.Add("Cookie", cookie);
            //这样可能需要一些重载方法。根据需要写就可以了

            //获取或设置用于对向 Internet 资源的请求进行身份验证的网络凭据。
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            //如果服务器要验证用户名,密码
            //NetworkCredential mycred = new NetworkCredential(struser, strpassword);
            //myWebClient.Credentials = mycred;
            //从资源下载数据并返回字节数组。（加@是因为网址中间有"/"符号）
            byte[] myDataBuffer = myWebClient.DownloadData(url);
            string strWebData = Encoding.Default.GetString(myDataBuffer);

            //获取网页字符编码描述信息
            Match charSetMatch = Regex.Match(strWebData, "<meta([^<]*)charset=([^<]*)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string webCharSet="utf-8";
            if (charSetMatch.Groups.Count > 1)
            {
                string matchStr = charSetMatch.Groups[2].Value.Replace("\"","");
                webCharSet= Regex.Split(matchStr, @"\s+")[0];
            }
            encoding = webCharSet.ToLower();
            strWebData = Encoding.GetEncoding(webCharSet).GetString(myDataBuffer);
            return strWebData;
        }
        /// <summary>
        /// 以get方式请求
        /// </summary>
        /// <param name="tUrl">传入url</param>
        /// <param name="encodeType">传入 页面的编码格式</param>
        /// <returns></returns>
        public static string Get_Https(string tUrl, string encodeType)
        {
            string strResult;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
                HttpWebRequest hwr = CreateHttpWebRequest(tUrl);
                hwr.UserAgent = "Mozilla/4.0   (compatible;   MSIE   6.0;   Windows   NT   5.1;   SV1;   .NET   CLR  2.0.50727) "; //根据CLR版本和NT版本适当修改。
                hwr.Timeout = 19600;
                CookieContainer cc = new CookieContainer();
                hwr.CookieContainer = cc;
                HttpWebResponse hwrs = (HttpWebResponse)hwr.GetResponse();
                Stream myStream = hwrs.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding(encodeType);
                StreamReader sr = new StreamReader(myStream, encoding);
                strResult = sr.ReadToEnd();
                sr.Close();
                hwrs.Close();
            }
            catch (Exception ee)
            {
                strResult = ee.Message;
            }
            return strResult;
        }
        //----------针对太平船务的https调用中“基础连接已经关闭: 未能为 SSL/TLS 安全通道建立信任关系”的异常”而改进
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        { // 总是接受 
            return true;
        }
        //----------

        #endregion

        #region
        /// <summary>
        /// 以get方式请求  ***自2010-10-25 发现该方法抓取不到网页内容，就将所有调用Get_Http的类改掉用Get_HttpAll函数，后来判断为 “strResult=sr.ReadToEnd() ”行的错误。***
        /// </summary>
        /// <param name="tUrl">传入url</param>
        /// <param name="encodeType">传入 页面的编码格式</param>
        /// <returns></returns>
        public static string Get_Http(string tUrl, string encodeType)
        {
            string strResult;
            HttpWebRequest hwr = CreateHttpWebRequest(tUrl);
            hwr.Timeout = 19600;
            CookieContainer cc = new CookieContainer();
            hwr.CookieContainer = cc;
            HttpWebResponse hwrs = (HttpWebResponse)hwr.GetResponse();
            Stream myStream = hwrs.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding(encodeType);
            StreamReader sr = new StreamReader(myStream, encoding);
            StringBuilder sb = new StringBuilder();
            while (-1 != sr.Peek())
            {
                sb.Append(sr.ReadLine() + "\r\n");
            }
            strResult = sb.ToString();
            //strResult = sr.ReadToEnd();  错误行
            hwrs.Close();
            return strResult;
        }
        /// <summary>
        /// 传入get请求地址，和页面编码格式，返回该页面html源文件，返回wrong则出现异常。
        /// </summary>
        /// <param name="tUrl">传入url</param>
        /// <param name="encodeType">传入 页面的编码格式</param>
        /// <returns></returns>
        public static string Get_HttpAll(string tUrl, Encoding encoding)
        {
            string strResult;
            try
            {
                HttpWebRequest hwr = CreateHttpWebRequest(tUrl);
                hwr.Timeout = 19990;
                CookieContainer cc = new CookieContainer();
                hwr.CookieContainer = cc;
                HttpWebResponse hwrs = (HttpWebResponse)hwr.GetResponse();
                Stream myStream = hwrs.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, encoding);
                strResult = sr.ReadToEnd();
                hwrs.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return strResult;
        }
        #endregion

        #region 通过post的方式请求html信息
        /// <summary>
        /// 通过post的方式请求获取html信息
        /// </summary>
        /// <param name="url">要请求的地址</param>
        /// <param name="postData">post数据</param>
        /// <param name="encodeType">编码格式</param>
        /// <param name="err">返回错误信息</param>
        /// <returns></returns>
        public static string Post_Http(string url, string postData, string encodeType, out string err)
        {
            string uriString = url;
            byte[] byteArray;
            byte[] responseArray;
            Encoding encoding = Encoding.GetEncoding(encodeType);
            try
            {
                WebClient myWebClient = CreateWebClient();
                WebHeaderCollection myWebHeaderCollection;
                myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                myWebHeaderCollection = myWebClient.Headers;
                byteArray = encoding.GetBytes(postData);
                responseArray = myWebClient.UploadData(uriString, "POST", byteArray);
                err = string.Empty;
                return encoding.GetString(responseArray).ToString();
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return string.Empty;
            }
        }
        #endregion

        #region 通过正则表达式，获取要得到的字符串信息
        /// <summary>
        /// 通过正则表达式，获取要得到的信息。
        /// </summary>
        /// <param name="pattern">传入正则表达式</param>
        /// <param name="THtml">传入被正则的html页</param>
        /// <param name="Col">要被正则的Html有几列。</param>
        /// <returns></returns>
        public static string GetPatternHtml(string pattern, string THtml, int Col)
        {
            Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(THtml);
            string strTempContent = "";
            if (mc.Count > 0)
            {
                int num = 1;
                foreach (Match matI in mc)
                {
                    strTempContent += matI.Groups[0].Value + "$";
                    if (num % Col == 0)
                    {
                        strTempContent += "~";
                    }
                    num = num + 1;
                }
            }
            else
            {
                strTempContent = "wrong";
            }
            return strTempContent;
        }
        #endregion

        #region 对抓取到的网页进行分析并输出 ResolverAndOutput
        /// <summary>
        /// 对抓取到的网页进行分析并输出
        /// </summary>
        /// <param name="result">result：抓取后待分析的网页</param>
        /// <param name="regexStr">regexStr：对整个网页进行正则截取时，正则开始标签</param>
        /// <param name="regexEnd">regexEnd：对整个网页进行正则截取时，正则结束标签</param>
        /// <param name="regexTab">regexTab：确定抓取范围后匹配某列的正则</param>
        /// <param name="ColNum">共有几列</param>
        /// <returns></returns>
        /// 
        public static string ResolverAndOutput(string result, string regexStr, string regexEnd, string regexTab, int ColNum)
        {
            return ResolverAndOutput(result, regexStr, regexEnd, regexTab, ColNum, true);
        }
        #endregion

        #region 对抓取到的网页进行分析并输出 ResolverAndOutput
        /// <summary>
        /// 对抓取到的网页进行分析组合成有规律的数组，不过滤HTml
        /// </summary>
        /// <param name="result">result：抓取后待分析的网页</param>
        /// <param name="regexStr">regexStr：对整个网页进行正则截取时，正则开始标签</param>
        /// <param name="regexEnd">regexEnd：对整个网页进行正则截取时，正则结束标签</param>
        /// <param name="regexTab">regexTab：确定抓取范围后匹配某列的正则</param>
        /// <param name="ColNum">共有几列</param>
        /// <param name="IsRemoveHtml">是否移除Html</param>
        /// <returns></returns>
        /// 
        public static string ResolverAndOutput(string result, string regexStr, string regexEnd, string regexTab, int ColNum, bool IsRemoveHtml)
        {
            string strTempContent = "";
            string patternStart = regexStr;         //表达式开始标签,regexStr
            string patternEnd = regexEnd;           //表达式结束标签,regexEnd
            string regex = patternStart + @"([\s\S]*)" + patternEnd;          //组合后的表达式 
            //regex = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";           //匹配http:
            strTempContent = GetPatternHtml(regex, result, ColNum);        //通过正则表达式获得所需信息的大table
            if (strTempContent != "wrong")
            {
                strTempContent = strTempContent.Replace("\n", "");            //去掉\n符
                strTempContent = strTempContent.Replace("></td>", "> </td>");            //在<td></td>之间加入空字符，以便被正则
                //strTempContent = strTempContent.Replace("\r", "");          //去掉\r符
                string regex2 = regexTab;                                     //确定抓取范围后匹配某列的正则，regexTab
                strTempContent = GetPatternHtml(regex2, strTempContent, ColNum); //正则找到每列值
                if (IsRemoveHtml == true)
                {
                    strTempContent = RemoveHtml(strTempContent);         //正则移除html标签
                }
                if (strTempContent != "wrong")
                {
                    return strTempContent;
                }
                else
                {
                    string tmpNull = "";
                    for (int i = 0; i < ColNum; i++)
                    {
                        tmpNull = tmpNull + "Null$";
                    }
                    return tmpNull + "?";
                }
            }
            else
            {
                string retNull = "";
                for (int i = 0; i < ColNum; i++)
                {
                    retNull = retNull + "Null$";
                }
                return retNull + "?";
            }

        }
        #endregion

        public static List<string> GetItems(string useHtml)
        {
            string[] arr = useHtml.Replace("~", "").Split('$');
            List<string> list = new List<string>();
            foreach (string item in arr)
            {
                if (item.Trim() != string.Empty)
                {
                    list.Add(item.Trim());
                }
            }
            return list;
        }
        public static List<string> GetItemsByTab(string html,string beginTab, string endTab) {
            string str = GetHtmlByTab(html,beginTab,endTab);
            List<string> list = GetItems(str);
            List<string> newlist = new List<string>();
            list.ForEach(delegate(string name)
            {
                newlist.Add(name.Replace(beginTab, "").Replace(endTab, "").Trim());
            });
            return newlist;
        }
        public static string GetHtmlByTab(string html, string beginTab, string endTab) {
            string regex = beginTab + "(?<content>.+?)" + endTab;
            string str = ResolverAndOutput(html, "", "", regex, 1, false);
            return str;
        }
        public static string GetHtmlByWrap(string html, string wrapBegin, string wrapEnd, string tabBegin, string tabEnd)
        {
            string regex = tabBegin + "(?<content>.+?)" + tabEnd;
            return ResolverAndOutput(html, wrapBegin, wrapEnd, regex, 1, false);
        }
        /// <summary>
        /// 移除html标签
        /// </summary>
        /// <param name="html">传入html字符串</param>
        /// <returns>移除Html标签后的Html字符串</returns>
        public static string RemoveHtml(string html)
        {
            string m_outstr = "";
            m_outstr = html.Clone() as string;
            m_outstr = new Regex(@"(?m)<script[^>]*>(\w|\W)*?</script[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(m_outstr, "");
            m_outstr = new Regex(@"(?m)<style[^>]*>(\w|\W)*?</style[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(m_outstr, "");
            m_outstr = new Regex(@"(?m)<select[^>]*>(\w|\W)*?</select[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(m_outstr, "");
            Regex objReg = new System.Text.RegularExpressions.Regex("(<[^>]+?>)|&nbsp;", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            m_outstr = objReg.Replace(m_outstr, "");
            Regex objReg2 = new System.Text.RegularExpressions.Regex("(\\s)+", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            m_outstr = objReg2.Replace(m_outstr, " ");
            return m_outstr;
        }

        /// <summary>
        /// 返回截取html后的字符串
        /// </summary>
        /// <param name="pageHtml">要截取的字符串</param>
        /// <param name="starts">截取起点</param>
        /// <param name="ends">截取终点</param>
        /// <returns>截取后的字符串</returns>
        public static string GetString(string pageHtml, string starts, string ends)
        {
            string keyText = "";
            int StrLen = starts.Length;
            if (starts.Trim() != "" || ends.Trim() != "")
            {
                int m = pageHtml.IndexOf(starts.Trim());                        //找出starts的位置
                if (m == -1)
                {
                    return "没找到当前指定的START";                              //没有查找到数据，直接返回
                }
                string pageText = pageHtml.Remove(0, m + StrLen);                   //删除starts以上的html文本
                if (!string.IsNullOrEmpty(ends))
                {
                    int n = pageText.IndexOf(ends.Trim());                          //找出ends的位置
                    keyText = pageText.Remove(n - 0);//删除ends以下的html文本
                }
                else
                {
                    keyText = pageText;
                }
            }
            else
            {
                keyText = pageHtml;
            }
            keyText = keyText.Replace("\n", "");
            return keyText;
        }

        /// <summary>
        /// 根据是否使用代理配置，实例化一个WebClient对象
        /// </summary>
        /// <returns></returns>
        public static WebClient CreateWebClient()
        {
            WebClient wec = new WebClient();
            if (proxyEnable)
            {
                wec.Proxy = new WebProxy(proxyServer, proxyPort);
            }
            return wec;
        }

        /// <summary>
        /// 根据是否使用代理配置，创建一个HttpWebRequest对象
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpWebRequest CreateHttpWebRequest(string url)
        {
            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(url);
            if (proxyEnable)
            {
                hwr.Proxy = new WebProxy(proxyServer, proxyPort);
            }
            return hwr;
        }

        /// <summary>
        /// 抓取页面自定义段的HTML源码
        /// </summary>
        /// <param name="url">url入口</param>
        /// <param name="conditions">船期号码组合条件</param>
        /// <param name="encode">网站页面采取的编码格式</param>
        /// <param name="starts">抓取源码START</param>
        /// <param name="ends">抓取源码end</param>
        /// <returns>最终抓取到的HTML源码</returns>
        public static string Bind(string url, string conditions, string encodeType, string starts, string ends)
        {
            Encoding encode = Encoding.GetEncoding(encodeType);
            string firstPage = url + conditions;
            string keyText = "";
            try
            {
                WebClient astoWebClient = CreateWebClient();
                astoWebClient.Credentials = CredentialCache.DefaultCredentials;   //获取或设置用于对向Internet资源的请求进行身份验证的网络凭据。
                Byte[] pageData = astoWebClient.DownloadData(firstPage);          //从指定网站下载数据         
                string pageHtml = encode.GetString(pageData);                     //获取的网站页面采用的是什么编码格式如：UTF-8
                pageHtml = pageHtml.Trim();                                       //先去掉头部多余的空格
                if (starts.Trim() != "" && ends.Trim() != "")
                {
                    int m = pageHtml.IndexOf(starts.Trim());                        //找出starts的位置
                    if (m == -1)
                    {
                        return "没找到当前指定的START";                              //没有查找到数据，直接返回
                    }
                    string pageText = pageHtml.Remove(0, m);   //删除starts以上的html文本
                    int n = pageText.IndexOf(ends.Trim());                          //找出ends的位置  
                    keyText = pageText.Remove(n);   //删除ends以下的html文本
                }
                else
                {
                    keyText = pageHtml;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(webEx.Message);
            }
            keyText = keyText.Replace("\n", "");
            return keyText;
        }

        /// <summary>
        /// 抓取页面自定义段的HTML源码
        /// </summary>
        /// <param name="url">url入口</param>
        /// <param name="conditions">船期号码组合条件</param>
        /// <param name="encode">网站页面采取的编码格式</param>
        /// <returns>最终抓取到的HTML源码</returns>
        public static string Bind(string url, string conditions, string encode)
        {
            return Bind(url, conditions, encode, "", "");
        }

        /// <summary>
        /// 抓取页面自定义段的HTML源码
        /// </summary>
        /// <param name="url">url入口</param>
        /// <param name="conditions">船期号码组合条件</param>
        /// <returns>最终抓取到的HTML源码</returns>
        public static string Bind(string url, string conditions)
        {
            return Bind(url, conditions, "utf-8");
        }

        /// <summary>
        /// 抓取页面自定义段的HTML源码
        /// </summary>
        /// <param name="url">url入口</param>
        /// <returns>最终抓取到的HTML源码</returns>
        public static string Bind(string url)
        {
            return Bind(url, "");
        }

        /// <summary>
        /// 分析HTML 数据
        /// </summary>
        /// <param name="UrlHtml">最终抓取到的HTML源码</param>
        /// <param name="Columns">当前要抓取表格数据的列名数组</param>
        /// <param name="TbPattern">抓取单个td数据的正则表达式</param>
        /// <returns>解析HTML数据后的DataTable</returns>
        public static DataTable GetData(string UrlHtml, string[] Columns, string TbPattern)
        {
            System.Data.DataRow dr;
            DataTable dt = new DataTable();
            for (int i = 0; i < Columns.Length; i++)
            {
                dt.Columns.Add(new System.Data.DataColumn(Columns[i].Trim(), typeof(System.String)));
            }
            string fileConent = string.Empty;
            string tableContent = string.Empty;
            string rowContent = string.Empty;
            string columnConent = string.Empty;
            string rowPatterm = @"<tr[^>]*>[\s\S]*?<\/tr>";
            string columnPattern = TbPattern;
            MatchCollection rowCollection = Regex.Matches(UrlHtml, rowPatterm, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture); //对tr进行筛选
            for (int i = 0; i < rowCollection.Count; i++)
            {
                rowContent = rowCollection[i].Value;
                MatchCollection columnCollection = Regex.Matches(rowContent, columnPattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture); //对td进行筛选
                dr = dt.NewRow();
                for (int j = 0; j < columnCollection.Count; j++)
                {
                    string strWeb = DataMiningHelper.RemoveHtml(columnCollection[j].Value);
                    dr[Columns[j].ToString().Trim()] = strWeb;
                }
                if (columnCollection.Count >= 1)
                {
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }
            return dt;
        }

        public static DataTable GetData(string UrlHtml, string[] Columns, string TbPattern, bool bt)
        {
            System.Data.DataRow dr;
            DataTable dt = new DataTable();
            for (int i = 0; i < Columns.Length; i++)
            {
                dt.Columns.Add(new System.Data.DataColumn(Columns[i].Trim(), typeof(System.String)));
            }
            string fileConent = string.Empty;
            string tableContent = string.Empty;
            string rowContent = string.Empty;
            string columnConent = string.Empty;
            string rowPatterm = @"<tr[^>]*>[\s\S]*?<\/tr>";
            string columnPattern = TbPattern;
            MatchCollection rowCollection = Regex.Matches(UrlHtml, rowPatterm, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture); //对tr进行筛选
            for (int i = 1; i < rowCollection.Count; i++)
            {
                rowContent = rowCollection[i].Value;
                MatchCollection columnCollection = Regex.Matches(rowContent, columnPattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture); //对td进行筛选
                dr = dt.NewRow();
                for (int j = 0; j < columnCollection.Count; j++)
                {
                    string strWeb = DataMiningHelper.RemoveHtml(columnCollection[j].Value);
                    dr[Columns[j].ToString().Trim()] = strWeb;
                }
                if (columnCollection.Count >= 1)
                {
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }
            return dt;
        }

        ///// <summary>
        ///// 根据公司简称和下载日期生成文件夹，返回新创建的文件夹路径
        ///// </summary>
        ///// <param name="companyShortName">公司简称</param>
        ///// <param name="time">年月日时分秒</param>
        ///// <param name="directoryType">文件夹类型(PDF，Excel)</param>
        ///// <returns>新生成的文件夹的路径</returns>
        //public static string CreateDownLoadDirectory(string companyShortName, string time, DownLoadDirectoryType directoryType)
        //{
        //    string historyDirectory = GlobalCommon.GetLatestDownLoadDirectoryPath(companyShortName, directoryType);//获取上次创建的文件夹路径
        //    if (!string.IsNullOrEmpty(historyDirectory))
        //    {
        //        Directory.Delete(historyDirectory, true);//删除上次创建的文件夹及文件夹里面所有的文件
        //    }

        //    string parentDirectory = Application.StartupPath + (directoryType == DownLoadDirectoryType.PDF ? @"\PDF" : @"\EXCEL");//获取父文件夹路径
        //    StringBuilder sb = new StringBuilder(parentDirectory);
        //    string newDirectory = sb.Append(@"\").Append(companyShortName).Append(time).ToString();//所要创建的新文件夹
        //    Directory.CreateDirectory(newDirectory);
        //    return newDirectory;
        //}

        /// <summary>
        /// 转换成统一的时间格式
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        public static string FormatDateTime(string datetime)
        {
            return DateTime.Parse(datetime).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 通过post的方式请求获取html信息
        /// </summary>
        /// <param name="url">要请求的地址</param>
        /// <param name="postData">post数据</param>
        /// <param name="encodeType">编码格式</param>
        /// <param name="err">返回错误信息</param>
        /// <param name="starts">抓取源码START</param>
        /// <param name="ends">抓取源码end</param>
        /// <returns>最终抓取到的HTML源码</returns>
        public static string Post_Html(string url, string postData, string encodeType, out string err, string starts, string ends)
        {
            string uriString = url;
            string keyText = "";
            byte[] byteArray;
            byte[] responseArray;
            Encoding encoding = Encoding.GetEncoding(encodeType);
            try
            {
                WebClient myWebClient = new WebClient();
                WebHeaderCollection myWebHeaderCollection;
                myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                myWebHeaderCollection = myWebClient.Headers;
                byteArray = encoding.GetBytes(postData);
                responseArray = myWebClient.UploadData(uriString, "POST", byteArray);
                err = string.Empty;
                string pageHtml = encoding.GetString(responseArray).ToString();
                if (starts.Trim() != "" && ends.Trim() != "")
                {
                    int m = pageHtml.IndexOf(starts.Trim());                        //找出starts的位置
                    if (m == -1)
                    {
                        return "没找到当前指定的START";                              //没有查找到数据，直接返回
                    }
                    string pageText = pageHtml.Remove(0, m);                   //删除starts以上的html文本
                    int n = pageText.IndexOf(ends.Trim());                          //找出ends的位置
                    keyText = pageText.Remove(n);                              //删除ends以下的html文本
                }
                else
                {
                    keyText = pageHtml;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return string.Empty;
            }
            keyText = keyText.Replace("\n", "");
            return keyText;
        }

        /// <summary>
        /// 通过post的方式请求获取html信息 
        /// </summary>
        /// <param name="url">要请求的地址</param>
        /// <param name="postData">post数据</param>
        /// <param name="encodeType">编码格式</param>
        /// <param name="err">返回错误信息</param>
        /// <returns>最终抓取到的HTML源码</returns>
        public static string Post_Html(string url, string postData, string encodeType, out string err)
        {
            return Post_Html(url, postData, encodeType, out err, "", "");
        }

        #region 自动抓取船名实现方法
        /// <summary>
        ///  
        /// </summary>
        /// <param name="UrlHtml">源码</param>
        /// <param name="Columns">表行</param>
        /// <param name="TbPattern">正则</param>
        /// <param name="starts">截取开始为止</param>
        /// <param name="ends">截取结束为止</param>
        /// <param name="Leg">去掉的字符长度</param>
        /// <returns></returns>
        public static DataTable GetVesselData(string UrlHtml, string[] Columns, string TbPattern, string starts, string ends, int Leg)
        {
            System.Data.DataRow dr;
            DataTable dt = new DataTable();
            for (int i = 0; i < Columns.Length; i++)
            {
                dt.Columns.Add(new System.Data.DataColumn(Columns[i].Trim(), typeof(System.String)));
            }
            string columnPattern = TbPattern;
            MatchCollection rowCollection = Regex.Matches(UrlHtml, TbPattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture); //对tr进行筛选
            for (int i = 0; i < rowCollection.Count; i++)
            {
                dr = dt.NewRow();
                int m = rowCollection[i].Value.IndexOf(starts.Trim());   //找出starts的位置
                if (m == -1)
                {
                    return null;  //没有查找到数据，直接返回
                }
                string pageText = rowCollection[i].Value.Remove(0, m + Leg);   //删除starts以上的html文本
                int n = pageText.IndexOf(ends.Trim());                          //找出ends的位置
                dr["Vessel"] = pageText.Remove(n);                              //删除ends以下的html文本
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            return dt;
        }
        public static string Bind(string url, string conditions, Encoding encode, string starts, string ends)
        {
            string firstPage = url + conditions;
            string keyText = "";
            try
            {
                WebClient astoWebClient = DataMiningHelper.CreateWebClient();
                astoWebClient.Credentials = CredentialCache.DefaultCredentials;   //获取或设置用于对向Internet资源的请求进行身份验证的网络凭据。
                Byte[] pageData = astoWebClient.DownloadData(firstPage);          //从指定网站下载数据         
                string pageHtml = encode.GetString(pageData);                     //获取的网站页面采用的是什么编码格式如：UTF-8
                pageHtml = pageHtml.Trim();                                       //先去掉头部多余的空格
                if (starts.Trim() != "" && ends.Trim() != "")
                {
                    int m = pageHtml.IndexOf(starts.Trim());                        //找出starts的位置
                    if (m == -1)
                    {
                        return "没找到当前指定的START";                              //没有查找到数据，直接返回
                    }
                    string pageText = pageHtml.Remove(0, m);                   //删除starts以上的html文本
                    int n = pageText.IndexOf(ends.Trim());                          //找出ends的位置
                    keyText = pageText.Remove(n);                              //删除ends以下的html文本
                }
                else
                {
                    keyText = pageHtml;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(webEx.Message);
            }
            keyText = keyText.Replace("\n", "");
            return keyText;
        }
        #endregion

        /// <summary>
        /// 解析Excel到DataTable
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable GetDataTabelExcelContent(string filePath)
        {
            //excel2007,兼容2003   
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
            System.Data.OleDb.OleDbConnection myConn = new System.Data.OleDb.OleDbConnection(strCon);
            myConn.Open();
            //获取excel第一标签名   
            DataTable dt = new DataTable();
            DataTable schemaTable = myConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            string tableName = schemaTable.Rows[0][2].ToString().Trim();//标签名   
            string strCom = "SELECT *  FROM [" + tableName + "]";//查询语句   
            OleDbCommand ocmd = null;
            try
            {
                ocmd = new OleDbCommand(strCom, myConn);
                OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
                oda.Fill(dt);
            }
            catch (OleDbException oex)
            {
                dt = null;
                throw oex;
            }
            finally
            {
                myConn.Close();
                ocmd.Dispose();
            }
            return dt;
        }
        /// <summary>
        /// 解析Excel到DataTable 》》多表
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable GegDataTabelExcelContentAll(string filePath)
        {
            //excel2007,兼容2003   
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
            System.Data.OleDb.OleDbConnection myConn = new System.Data.OleDb.OleDbConnection(strCon);
            myConn.Open();
            //获取excel第一标签名   
            DataTable dt = new DataTable();
            DataTable schemaTable = myConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            int DataNum = schemaTable.Rows.Count;
            for (int i = 0; i < DataNum; i++)
            {
                string tableName = schemaTable.Rows[i][2].ToString().Trim();//标签名   
                string strCom = "SELECT *  FROM [" + tableName + "]";//查询语句   
                OleDbCommand ocmd = null;
                try
                {
                    ocmd = new OleDbCommand(strCom, myConn);
                    OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
                    oda.Fill(dt);
                }
                catch (OleDbException oex)
                {
                    dt = null;
                    throw oex;
                }
                finally
                {
                    myConn.Close();
                    ocmd.Dispose();
                }
            }
            return dt;
        }
        /// <summary>
        /// 自动下载.pdf
        /// </summary>
        /// <param name="pdfPath">下载地址</param>
        /// <param name="FileName">下载存储文件的名称</param>
        /// <param name="downloadpdfpath">文件存储路径</param>
        public static void DownloadFileTo(string pdfPath, string FileName, string downloadpdfpath)
        {
            WebClient client = new WebClient();
            client.DownloadFile(pdfPath.Trim(), downloadpdfpath + @"\" + FileName + ".pdf");
        }
        public static void DownLoadFile(string webFilePath, string savePath)
        {
            WebClient client = new WebClient();
            client.DownloadFile(webFilePath.Trim(), savePath);
        }

        #region 传入：一个正确时间格式的时间字符串 ChangeTime（）
        /// <summary>
        /// 对正确时间格式的时间字符串进行跨年处理
        /// </summary>
        /// <param name="Tm">传入正确格式的时间字符串，可以是2010-10-14、2010-10-14 11：11：11、可以是Sep-12-2010 </param>
        /// <returns>返回经FormatDateTime() 函数处理后的时间</returns>      
        public static string ChangeTime(string Tm)
        {
            string ETA = Tm;
            DateTime DtNow = DateTime.Now;
            DateTime DtETA = DateTime.Parse(ETA);
            if (DtNow.Month == 10 || DtNow.Month == 11 || DtNow.Month == 12) //当前时间的月为11、12、10时并且，当前的ETA所指的月为1、2、3时，ETA跨年+1
            {
                if (DtETA.Month == 1 || DtETA.Month == 2 || DtETA.Month == 3)
                {
                    ETA = DtETA.AddYears(1).ToString();
                }
            }
            else if (DtNow.Month == 1 || DtNow.Month == 2 || DtNow.Month == 3)//当前时间的月为1、2、3时并且，当前的ETA所指的月为10、11、12时，ETA跨年-1
            {
                if (DtETA.Month == 10 || DtETA.Month == 11 || DtETA.Month == 12)
                {
                    ETA = DtETA.AddYears(-1).ToString();
                }
            }
            return FormatDateTime(ETA);
        }
        #endregion


        private static object myLock = new object();
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="folderPath">文件夹路径</param>
        /// <param name="content">日志内容</param>
        /// <param name="errName">产生的日志文件名字</param>
        public static void Write(string folderPath, string content, string errName)
        {
            lock (myLock)
            {
                string date = errName;
                string logFolderPath = folderPath + "\\Log";
                string filePath = logFolderPath + "\\" + "抓取日志" + "_" + date + ".txt";
                //创建目录Log
                DirectoryInfo dir = new DirectoryInfo(logFolderPath);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                //创建日志文件
                FileInfo file = new FileInfo(filePath);
                if (!file.Exists)
                {
                    using (StreamWriter write = file.CreateText())
                    {
                        write.WriteLine("-------------------------抓取日志------------------------------");
                    }
                }
                //文件已存在追加内容
                using (StreamWriter write = file.AppendText())
                {
                    content = string.Format("[{0}]:" + content, System.DateTime.Now.ToLongTimeString());
                    write.WriteLine(content);
                    write.WriteLine("-----------------------------------------------------------------");
                }
            }
        }
    }
}
