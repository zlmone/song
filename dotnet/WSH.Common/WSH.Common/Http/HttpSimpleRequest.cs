using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using WSH.Options.Common;
using WSH.Common.Helper;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace WSH.Common.Http
{

    public class HttpSimpleRequest
    {
        public HttpSimpleRequest() { }
        public HttpSimpleRequest(string url)
        {
            this.url = url;
        }
        #region 公共属性
        private string url;
        /// <summary>
        /// 登录的Url
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private RequestMethod method= RequestMethod.POST;
        /// <summary>
        /// 请求的类型
        /// </summary>
        public RequestMethod Method
        {
            get { return method; }
            set { method = value; }
        }
        private Encoding encoding = Encoding.Default;

        public Encoding Encoding
        {
            get { return encoding; }
            set { 
                //如果设置了编码，则关闭自动编码
                encoding = value;
                this.AutoEncoding = false;
            }
        }
        private bool autoEncoding = true;
        /// <summary>
        /// 是否自动获取编码
        /// </summary>
        public bool AutoEncoding
        {
            get { return autoEncoding; }
            set { autoEncoding = value; }
        }
        private bool keepAlive = false;
        /// <summary>
        /// 是否表示建立长久连接
        /// </summary>
        public bool KeepAlive
        {
            get { return keepAlive; }
            set { keepAlive = value; }
        }
        private string userAgent="Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
        /// <summary>
        /// 用户信息
        /// </summary>
        public string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }
        private string contentType = "application/x-www-form-urlencoded";
        /// <summary>
        /// 指定请求头信息
        /// </summary>
        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }
        private CookieContainer cookieContainer;

        public CookieContainer CookieContainer
        {
            get { return cookieContainer; }
            set { cookieContainer = value; }
        }
        private CookieCollection _cookiecollection;

        public CookieCollection CookieCollection
        {
            get { return _cookiecollection; }
            set { _cookiecollection = value; }
        }
        private string cookiesString;

        public string CookiesString
        {
            get { return cookiesString; }
            set { cookiesString = value; }
        }
        private bool isSaveCookie = false;
        /// <summary>
        /// 请求成功之后是否保存Cookie
        /// </summary>
        public bool IsSaveCookie
        {
            get { return isSaveCookie; }
            set { isSaveCookie = value; }
        }
        protected Dictionary<string, string> Paramters = new Dictionary<string, string>();
        private string paramterContent;
        /// <summary>
        /// 参数内容
        /// </summary>
        public string ParamterContent
        {
            get { return paramterContent; }
            set { paramterContent = value; }
        }
        #endregion

        #region 受保护方法
        protected HttpWebRequest request = null;
        protected HttpWebResponse response = null;
        /// <summary>
        /// 创建请求对象
        /// </summary>
        protected void CreateRequest()
        {
            this.ExistsUrl();
            this.ExistsHttps();
            request = (HttpWebRequest)WebRequest.Create(Url);
            this.SetRequestInfo();
        }
        /// <summary>
        /// 获取响应对象
        /// </summary>
        protected void GetResponse()
        {
            if (request != null)
            {
                response = (HttpWebResponse)request.GetResponse();
                this.SaveCookie();
                this.SetAutoEncoding();
            }
        }
        /// <summary>
        /// 关闭请求
        /// </summary>
        protected void Close()
        {
            if (request != null)
            {
                request.Abort();
                request = null;
            }
            if (response != null)
            {
                response.Close();
                response = null;
            }
        }
        protected void SetUrl(string urlAddress)
        {
            if (!string.IsNullOrEmpty(urlAddress))
            {
                Url = urlAddress;
            }
        }
        /// <summary>
        /// 获取响应流内容
        /// </summary>
        /// <returns></returns>
        protected string GetResponseContent()
        {
            if (response != null)
            {
                return HttpHepler.GetResponseContent(response, this.Encoding);
            }
            return null;
        }
        /// <summary>
        /// 获取响应流字节
        /// </summary>
        /// <returns></returns>
        protected byte[] GetResponseBytes()
        {
            if (response != null)
            {
                return HttpHepler.GetResponseBytes(response);
            }
            return null;
        }
        /// <summary>
        /// 设置请求参数
        /// </summary>
        protected virtual void SetRequestParamter()
        {
            string paramString =string.IsNullOrEmpty(ParamterContent) ? DictHelper.ToParamterString(Paramters) : ParamterContent;
            //设置请求参数
            if (!string.IsNullOrEmpty(paramString) && request != null)
            {
                byte[] postdatabytes = Encoding.Default.GetBytes(paramString);
                request.ContentLength = postdatabytes.Length;
                using (Stream myStream = request.GetRequestStream())
                {
                    myStream.Write(postdatabytes, 0, postdatabytes.Length);
                }
            }
            else {
                request.ContentLength = 0;
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 对https的ssl加密处理
        /// </summary>
        private void ExistsHttps()
        {
            //对https的ssl加密处理
            System.Text.RegularExpressions.Regex _reg = new System.Text.RegularExpressions.Regex("^https://",
                                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (_reg.IsMatch(Url))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback =
                        new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) =>
                        {
                            return true;
                        });
            }
        }
        private void ExistsUrl()
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new Exception("Url地址为空");
            }
        }
        /// <summary>
        /// 设置自动编码
        /// </summary>
        private void SetAutoEncoding()
        {
            if (AutoEncoding && response != null)
            {
                string chartset = response.CharacterSet;
                if (chartset.ToLower() != "iso-8859-1")
                {
                    this.encoding = Encoding.GetEncoding(chartset);
                }
            }
        }
        /// <summary>
        /// 保存返回cookie 
        /// </summary>
        private void SaveCookie()
        {
            //保存返回cookie  
            if (IsSaveCookie && request != null && response != null)
            {
 
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                CookieCollection = response.Cookies;
                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);
                CookiesString = strcrook;
            }
        }
        /// <summary>
        /// 设置请求的信息
        /// </summary>
        private void SetRequestInfo()
        {
            if (request != null)
            {
                request.Method = Method.ToString();
                request.ContentType = ContentType;
                request.KeepAlive = KeepAlive;
                request.UserAgent = this.UserAgent;

                //必须设置CookieContainer存储请求返回的Cookies
                if (CookieContainer != null)
                {
                    request.CookieContainer = CookieContainer;
                }
                else
                {
                    request.CookieContainer = new CookieContainer();
                    CookieContainer = request.CookieContainer;
                }
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public virtual Result Request(string urlAddress = null)
        {
            Result r = new Result();
            r.IsSuccess = false;
            try
            {
                this.SetUrl(urlAddress);
                this.CreateRequest();
                this.SetRequestParamter();
                //接收响应  
                this.GetResponse();
                //获取响应流的字符串
                r.Msg = this.GetResponseContent();
                r.IsSuccess = true;
            }
            catch (Exception ex)
            {
                r.IsSuccess = false;
                r.Msg = ex.Message;
            }
            finally
            {
                this.Close();
            }
            return r;
        }
        /// <summary>
        /// 清空请求参数
        /// </summary>
        public void ClearParamters()
        {
            this.Paramters.Clear();
        }
        /// <summary>
        /// 添加请求参数
        /// </summary>
        public void AddParamter(string paramName, string paramValue)
        {
            if (Paramters.ContainsKey(paramName))
            {
                Paramters[paramName] = paramValue;
            }
            else
            {
                Paramters.Add(paramName, paramValue);
            }
        }
        #endregion
    }
}
