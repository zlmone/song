using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Tools.Internet.InternetFate.Manager;
using Newtonsoft.Json.Linq;
using WSH.Common.Helper;
using System.Text.RegularExpressions;
using WSH.Tools.Internet.InternetFate.Model;
using WSH.Options.Common;

namespace WSH.Tools.Internet.InternetFate
{
    public class FateSearchRequest : HttpFateRequest
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int TotalRecord { get; set; }
        /// <summary>
        /// 搜索页面地址
        /// </summary>
        public string SearchPageUrl
        {
            get { return CryptHelper.DecryptDES("7u4kqrX33KzEVtb1klNFfJuiXZMkvlKXDdaaXoanbZ3HUK6bm0ifJahBYMoJbJbZ"); }
        }
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string KeyWord { get; set; }
        public FateSearchRequest()
        {

        }
        /// <summary>
        /// 搜索指定页
        /// </summary>
        /// <returns></returns>
        public Result SearchPage(int page = 0)
        {
            //到最后一页自动停止
            if (page > 0)
            {
                this.PageIndex = page;
            }
            if (this.PageCount > 0 && this.PageIndex == this.PageCount)
            {
                return new Result() { IsSuccess = false, Msg = "已经搜索到最后一页" };
            }
            this.Login();
            this.SetRequestParams();
            Result result = this.Request(this.SearchPageUrl);
            if (result.IsSuccess)
            {
                ParseSearchResult(result.Msg);
            }
            return result;
        }
        #region 私有方法
        private void ParseSearchResult(string searchResult)
        {
            string jsontext = StringHelper.DeleteEnd(searchResult.Replace("##jiayser##", ""), "//");
            if (string.IsNullOrWhiteSpace(jsontext))
            {
                return;
            }
            JObject jsonObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsontext);

            bool isLogin = ConvertHelper.ToBool(jsonObj["isLogin"].ToString());
            int totalRecord = ConvertHelper.ToInt32(jsonObj["count"].ToString());
            int pageCount = ConvertHelper.ToInt32(jsonObj["pageTotal"].ToString());
            this.TotalRecord = totalRecord;
            this.PageCount = pageCount;
            JArray userInfoArray = (JArray)jsonObj["userInfo"];
            foreach (JObject userInfo in userInfoArray)
            {
                string realUid = ConvertHelper.ToString(userInfo["realUid"].ToString());
                string nickname = ConvertHelper.ToString(userInfo["nickname"].ToString());
                string sex = ConvertHelper.ToString(userInfo["sex"].ToString());
                string marriage = ConvertHelper.ToString(userInfo["marriage"].ToString());
                int height = ConvertHelper.ToInt32(userInfo["height"].ToString());
                string education = ConvertHelper.ToString(userInfo["education"].ToString());
                string work_location = ConvertHelper.ToString(userInfo["work_location"].ToString());
                int age = ConvertHelper.ToInt32(userInfo["age"].ToString());
                string image = ConvertHelper.ToString(userInfo["image"].ToString());
                string randTag = ConvertHelper.ToString(userInfo["randTag"].ToString());
                string randListTag = ConvertHelper.ToString(userInfo["randListTag"].ToString());
                string shortnote = ConvertHelper.ToString(userInfo["shortnote"].ToString());
                string matchCondition = ConvertHelper.ToString(userInfo["matchCondition"].ToString());
                string rand = randTag + randListTag;
                //匹配信息，去除html标签
                string patch = "(?:<[^>]+>)(.+?)(?:</[^>]+>)";
                MatchCollection maths = Regex.Matches(rand, patch);
                List<string> mathList = new List<string>();
                if (maths != null)
                {
                    foreach (Match item in maths)
                    {
                        string tagValue = item.Groups[1].Value;
                        if (!mathList.Contains(tagValue))
                        {
                            mathList.Add(tagValue);
                        }
                    }
                } 
                rand = string.Join(",", mathList);
                FateUserInfo user = FateUserInfoManager.GetUser(realUid);
                if (user == null)
                {
                    user = new FateUserInfo()
                    {
                        CreateTime = DateTime.Now
                    };
                }
                user.ModifyTime = DateTime.Now;
                user.UserCode = realUid;
                user.Address = work_location;
                user.Age = age;
                user.HeadFileName = image;
                user.UserName = nickname;
                user.Education = education;
                user.Comment = rand;
                user.Height = height;
                user.ShortNote = shortnote;
                user.Marriage = marriage;
                //保存或更新用户
                FateUserInfoManager.SaveOrUpdateUser(user);
            }
        }
        /// <summary>
        /// 设置请求前的参数
        /// </summary>
        private void SetRequestParams()
        {
            this.ClearParamters();
            this.AddParamter("key", this.KeyWord);
            this.AddParamter("p", PageIndex <= 0 ? "1" : PageIndex.ToString());
            this.AddParamter("f", "select");
            this.AddParamter("jsversion", "v5");
            this.AddParamter("listStyle", "bigPhoto");
            this.AddParamter("pri_uid", "0");
            this.AddParamter("sex", "f");
            this.AddParamter("sn", "default");
            this.AddParamter("stc", "1:4401,2:19.25,3:155.168,23:1");
            this.AddParamter("sv", "1");
        }
        #endregion
    }
}
