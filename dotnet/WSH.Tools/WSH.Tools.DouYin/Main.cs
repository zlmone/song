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

namespace WSH.Tools.DouYin
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string id = this.txtNumber.Text.Trim();
            if(!string.IsNullOrEmpty(id)){
                string getUserUrl = string.Format("https://api.amemv.com/aweme/v1/discover/search/?keyword={0}&count=10&type=1&aid=1128",id);
                HttpSimpleRequest request = new HttpSimpleRequest();
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.146 Safari/537.36";
                request.Method = Common.RequestMethod.GET;
                Result result = request.Request(getUserUrl);
                if (result.IsSuccess && !string.IsNullOrEmpty(result.Msg))
                {
                    JObject obj = (JObject)JsonConvert.DeserializeObject(result.Msg);
                    JObject objUser = (JObject)(((JObject)((JArray)obj["user_list"])[0])["user_info"]);
                    string uid = objUser["uid"]==null ? string.Empty : objUser["uid"].ToString();
                    string awemeCount = objUser["aweme_count"] == null ? "100" : objUser["aweme_count"].ToString();
                    string nickname = objUser["nickname"] == null ? string.Empty : objUser["nickname"].ToString();
                    string uniqueid = objUser["unique_id"] == null ? string.Empty : objUser["unique_id"].ToString();
                    string getListUrl = string.Format("https://www.douyin.com/aweme/v1/aweme/post/?user_id={0}&max_cursor=0&count={1}",uid,awemeCount);
                    Result listResult = request.Request(getListUrl);
                    if(listResult.IsSuccess && !string.IsNullOrEmpty(listResult.Msg)){
                        string listJson = listResult.Msg;

                    }
                }
            }
        }
    }
}
