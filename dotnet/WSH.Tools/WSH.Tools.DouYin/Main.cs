using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Http;
using WSH.Options.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WSH.Common.Extend;
using NSoup;
using NSoup.Nodes;
using System.Text.RegularExpressions;
using System.IO;
using WSH.Common.Helper;
using WSH.WinForm.Common;

namespace WSH.Tools.DouYin
{
    public partial class Main : Form
    {
        HttpSimpleRequest client;

        public Main()
        {
            InitializeComponent();
            this.selectDialog1.Text = "D:\\";
            client = getConnection();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            string id = this.txtNumber.Text.Trim();
            string userInfo = getUserInfo(id);
            string basePath=this.selectDialog1.Text.Trim();
            if (!string.IsNullOrEmpty(userInfo) && !string.IsNullOrEmpty(basePath))
            {
                try
                {
                    JObject obj = (JObject)JsonConvert.DeserializeObject(userInfo);
                    JObject objUser = (JObject)(((JObject)((JArray)obj["user_list"])[0])["user_info"]);
                    string uid = objUser["uid"].toString();
                    string awemeCount = objUser["aweme_count"].toString("100");
                    string nickname = objUser["nickname"].toString(id);
                    //string uniqueid = objUser["unique_id"].toString();
                    List<string> listUrls = getDownloadUrls(uid, awemeCount);
                    if (listUrls.Count > 0)
                    {
                        string path = Path.Combine(basePath, nickname);
                        FileHelper.CreateFolder(path);
                        this.lbMsg.Text = "正在下载：{0}/{1}".format(0, listUrls.Count);
                        Application.DoEvents();
                        for (int i = 0; i < listUrls.Count; i++)
                        {
                            this.lbMsg.Text = "正在下载：{0}/{1}".format(i, listUrls.Count);
                            download(listUrls[i], Path.Combine(path, (i + 1) + ".mp4"));
                        }
                        this.lbMsg.Text = "下载完毕：{0}/{1}".format(listUrls.Count, listUrls.Count);
                        Application.DoEvents();
                    }
                }
                catch (Exception ex) {
                    MsgBox.Alert("下载出错："+ex.Message);
                }
            }
            this.button1.Enabled = true;
        }
        
        /// <summary>
        /// 获取连接信息
        /// </summary>
        private HttpSimpleRequest getConnection() {
            HttpSimpleRequest request = new HttpSimpleRequest();
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.146 Safari/537.36";
            request.Method = Common.RequestMethod.GET;
            return request;
        }
        private string getUserInfo(string id) {
             if (!string.IsNullOrEmpty(id))
             {
                 //获取用户信息
                 string getUserUrl = string.Format("https://api.amemv.com/aweme/v1/discover/search/?keyword={0}&count=10&type=1&aid=1128", id);
                 Result result = client.Request(getUserUrl);
                 return result.IsSuccess ? result.Msg : string.Empty;
             }
             return string.Empty;
        }
        private List<string> getVideos(string uid,string awemeCount) {
            //获取视频播放地址集合
            List<string> urls = new List<string>();
            string getListUrl = string.Format("https://www.douyin.com/aweme/v1/aweme/post/?user_id={0}&max_cursor=0&count={1}", uid, awemeCount);
            Result listResult = client.Request(getListUrl);
            if (listResult.IsSuccess && !string.IsNullOrEmpty(listResult.Msg))
            {
                string listJson = listResult.Msg;
                JObject listObj = (JObject)JsonConvert.DeserializeObject(listJson);
                JArray listArray = (JArray)listObj["aweme_list"];
                foreach (JObject item in listArray)
                {
                    urls.Add(item["share_info"]["share_url"].toString());
                }
            }
            return urls;
        }
        private List<string> getDownloadUrls(string uid,string awemeCount) {
            List<string> downloadUrls = new List<string>();
            List<string> listUrls = getVideos(uid, awemeCount);
            foreach (var url in listUrls)
            {
                Result result = client.Request(url);
                if (result.IsSuccess && !string.IsNullOrEmpty(result.Msg))
                {
                    Document doc = NSoupClient.Parse(result.Msg);
                    Element tag = doc.GetElementsByTag("script").Last;
                    Match match = Regex.Match(tag.Data, ".*var data = \\[(.*)\\];.*");

                    if (match.Success)
                    {
                        string value = match.Groups[1].Value;
                        JObject downloadObj = (JObject)JsonConvert.DeserializeObject(value);
                        downloadUrls.Add(((JArray)downloadObj["video"]["play_addr"]["url_list"])[0].toString());
                    }
                }
            }
            return downloadUrls;
        }
        private void download(string url,string saveFileName) {
            this.progress.Value = 0;
            this.progress.Maximum = 100;
            HttpDownload conn = new HttpDownload(url, saveFileName);
            conn.OnDownloadProgress += conn_OnDownloadProgress;
            conn.Download();
        }

        void conn_OnDownloadProgress(object sender, DownloadEventArgs e)
        {
            Application.DoEvents();
            this.progress.Value = (int)Math.Round(e.Rate,0);
        }
    }
}
