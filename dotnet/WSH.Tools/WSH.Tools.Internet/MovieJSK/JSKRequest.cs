using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using WSH.Common.Helper;
using WSH.Common.Http;
using WSH.Options.Common;
using WSH.WinForm.Common;

namespace WSH.Tools.Internet.MovieJSK
{
    class JSKRequest : HttpSimpleRequest
    {
        public DataTable DataSource;
        public JSKRequest(DataTable dt)
        {
            this.DataSource = dt;
        }
        public string BasePath
        {
            get
            {
                return "http://www.jiusk1.com";
            }
        }
        public string PageUrl(object index)
        {
            return string.Format(this.BasePath + "/vod-type-id-1-pg-{0}.html", index);
        }
        public string LoginUrl()
        {
            return BasePath + "index.php?m=user-index.html";
        }
        public string CheckUrl()
        {   
            return BasePath + "/index.php?m=user-check.html";
        }
        public void SetParamter()
        {
            this.ClearParamters();
            this.Paramters.Add("u_name", "18664636176");
            this.Paramters.Add("u_password", "012011");
        }
        public bool Login()
        {
           
            this.SetParamter();
            this.Method = Common.RequestMethod.POST;
            this.IsSaveCookie = true;
            string msg = base.Request(this.CheckUrl()).Msg;
            return msg.Contains("成功");
        }

        /// <summary>
        /// 请求主页面
        /// </summary>
        /// <param name="urlAddress"></param>
        /// <returns></returns>
        public override Result Request(string index)
        {
            Result result = base.Request(this.PageUrl(index));
            if (result.IsSuccess && !string.IsNullOrWhiteSpace(result.Msg))
            {
                NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(result.Msg);
                var els = doc.Select("div.well-sm");
                if (els != null && els.Count > 0)
                {
                    foreach (var el in els)
                    {
                        var link = Utils.GetElementFirst(el.GetElementsByTag("a"));
                        if (link != null)
                        {
                            var subUrl = Utils.GetAttr(link, "href");
                            var title = Utils.GetText(Utils.GetElementFirst(link.GetElementsByTag("span")));
                            var img = Utils.GetAttr(Utils.GetElementFirst(link.GetElementsByTag("img")), "src");
                            var number = Utils.GetText(Utils.GetElementFirst(el.GetElementsByTag("font"))).Split(' ')[0];
                            var rating = Utils.GetText(Utils.GetElementFirst(el.GetElementsByTag("b")));
                            DataTableHelper.AddRow(this.DataSource, title, subUrl, "","", img, number, rating, null);
                        }

                    }
                }

            }
            return result;
        }
        public void RequestSubPage(ProgressHandler handler)
        {
            var lastColumn = this.DataSource.Columns.Count - 1;
            if (this.DataSource != null && this.DataSource.Rows.Count > 0)
            {
                int i = 1;
                if (!this.Login())
                {
                    MsgBox.Alert("登陆失败");
                    return;
                }
                foreach (DataRow row in DataSource.Rows)
                {
                    handler(row, new ProgressEventArgs()
                    {
                        Value = i
                    });
                    i++;
                    //防止网络慢，登录过期
                    if (i%500==0) {
                        this.Login();
                    }
                    var urlAddress = BasePath + row[1];
                    Result result = base.Request(urlAddress);
                    if (result.IsSuccess && !string.IsNullOrWhiteSpace(result.Msg))
                    {
                        try
                        {
                            NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(result.Msg);
                            var links = doc.GetElementsByTag("a");
                            foreach (var item in links)
                            {
                                var text = item.Text();
                                if (text.Contains("下载视频") && text.Contains("鼠标右键另存为"))
                                {
                                    var downloadUrl = Utils.GetAttr(item, "href");
                                    row[2] = downloadUrl;
                                    row[3] = Path.GetFileName(downloadUrl);
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            row[lastColumn] = ex.Message;
                        }
                    }
                }
            }
        }
    }
}
