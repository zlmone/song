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
    public partial class Main : SpiderForm
    {
        HttpSimpleRequest client;
        bool isDownload = true;

        public Main()
        {
            //测试id：45112660
            InitializeComponent();
            this.selectDialog1.Text = "D:\\";
            client = getConnection();
            this.dateTimePicker1.Value = DateTime.Now;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if(this.txtNumber.Text.isEmpty()){
                MsgBox.Alert("请输入抖音ID！");
                return;
            }
            isDownload = true;
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
                    List<DouYin> listUrls = getDownloadUrls(uid, awemeCount);
                    if (listUrls.Count > 0)
                    {
                        string path = Path.Combine(basePath, nickname);
                        FileHelper.CreateFolder(path);
                        this.lbMsg.Text = "正在下载：{0}/{1}".format(0, listUrls.Count);
                        Application.DoEvents();
                        for (int i = 0; i < listUrls.Count; i++)
                        {
                            if (isDownload)
                            {
                                DouYin dy = listUrls[i];
                                this.lbMsg.Text = "正在下载：{0}/{1}".format(i, listUrls.Count);
                                download(dy.DownloadUrl, Path.Combine(path, dy.Desc.replaceEmpty((i + 1) + "") + ".mp4"));
                            }
                            else
                            {
                                return;
                            }
                        }
                        this.lbMsg.Text = "下载完毕：{0}/{1}".format(listUrls.Count, listUrls.Count);
                        Application.DoEvents();
                    }
                    else {
                        this.lbMsg.Text = "当前账号不存在或者没有发布视频";
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
             if (!string.IsNullOrWhiteSpace(id))
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
                JObject listObj = parseJObject(listJson);
                JArray listArray = (JArray)listObj["aweme_list"];
                foreach (JObject item in listArray)
                {
                    urls.Add(item["share_info"]["share_url"].toString());
                }
            }
            return urls;
        }
        private List<DouYin> getDownloadUrls(string uid, string awemeCount)
        {
            List<DouYin> downloadUrls = new List<DouYin>();
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

                        DateTime createTime=  new DateTime(1970, 1, 1).AddSeconds(downloadObj["create_time"].toString().toInt());
                        string desc = downloadObj["desc"].toString();
                        string downloadurl = ((JArray)downloadObj["video"]["play_addr"]["url_list"])[0].toString().Replace("playwm", "play");
                        string vid = downloadObj["video"]["play_addr"]["uri"].toString();
                        string nickname = downloadObj["author"]["nickname"].toString();
                        DouYin douyin=new DouYin() { 
                             VideoId=vid,
                              CreateTime=createTime,
                               DownloadUrl=downloadurl,
                                Desc=desc,
                                 Nickname=nickname
                        };
                        if (this.checkBox1.Checked)
                        {
                            DateTime date = this.dateTimePicker1.Value;
                            if (createTime.CompareTo(date) >= 0)
                            {
                                downloadUrls.Add(douyin);
                            }
                        }
                        else {
                            downloadUrls.Add(douyin);                            
                        }
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

        private void button2_Click(object sender, EventArgs e)
        {
            isDownload = false;
            this.button1.Enabled = true;
        }
    }
}
