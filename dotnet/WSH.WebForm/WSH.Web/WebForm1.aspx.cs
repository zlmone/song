using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;

namespace WSH.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 以post方式提交数据到接口
        /// </summary>
        /// <param name="path">接口地址</param>
        /// <param name="param">接口参数串</param>
        /// <returns>调用结果</returns>
        private string PostData(string path, string param)
        {
            string responseStr = string.Empty;
            try
            {
                Encoding code = Encoding.GetEncoding("UTF-8");
                string postData = param; //这是要post的数据
                byte[] data = code.GetBytes(postData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded"; //这里的ContentType很重要!
                request.ContentLength = data.Length;

                using (Stream stream = request.GetRequestStream()) //获取数据流,该流是可写入的
                {
                    stream.Write(data, 0, data.Length);//发送数据流
                    stream.Close();
                }

                HttpWebResponse res;

                try
                {

                    res = (HttpWebResponse)request.GetResponse();

                }

                catch (WebException ex)
                {

                    res = (HttpWebResponse)ex.Response;

                }
                using (Stream sm = res.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(sm, System.Text.Encoding.UTF8);
                    responseStr = sr.ReadToEnd();
                }
            }
            catch (Exception ex0)
            {
                throw ex0;
            }
            return responseStr;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><user><name>wang</name><date>2010-10-01</date></user>";
            data = Server.HtmlEncode(data);
            PostData(this.TextBox1.Text.Trim(),data);
        }

    }
}