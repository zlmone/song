using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Tools.Internet.InternetFate.Model;
using WSH.Tools.Internet.InternetFate.Manager;
using WSH.Options.Common;
using WSH.Common.Helper;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;


namespace WSH.Tools.Internet.InternetFate
{
    public class FateHomeRequest : HttpFateRequest
    {
        /// <summary>
        /// 主页地址
        /// </summary>
        public string HomePageUrl
        {
            get { return CryptHelper.DecryptDES("oej4tTHVclzGyOjTFa3acqWyt1cA+ZBPsbb0CIo86yGKNhaUZ/8LRoozWrc/krXW"); }
        }
        
        /// <summary>
        /// 解析主页的访问用户
        /// </summary>
        /// <returns></returns>
        public void VisitParser()
        {
            this.Login();
            Result result= this.Request(this.HomePageUrl);
            string pageHtml = result.Msg;
            if (string.IsNullOrWhiteSpace(pageHtml))
            {
                return;
            }
            NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(pageHtml);
            NSoup.Nodes.Element wrapElement = doc.GetElementById("show_style_01");
            NSoup.Select.Elements userElementNodes = wrapElement.GetElementsByTag("li");
            if (userElementNodes != null && userElementNodes.Count > 0)
            {
                //倒序排列，最新的在最后面
                IEnumerable<NSoup.Nodes.Element> userElements = userElementNodes.Reverse();
                foreach (NSoup.Nodes.Element userElement in userElements)
                {
                    NSoup.Nodes.Element picElement = GetElementFirst(userElement.GetElementsByClass("pic"));
                    NSoup.Nodes.Element nameElement = GetElementFirst(userElement.GetElementsByClass("user_name"));
                    NSoup.Nodes.Element userInfoElement = GetElementFirst(userElement.GetElementsByClass("user_info"));
                    NSoup.Nodes.Element dateElement = GetElementFirst(userElement.GetElementsByClass("date"));
                    string userName =nameElement==null ? "" : nameElement.Child(0).Text();
                    string homePage = UriHelper.RemoveParams(nameElement==null ? "" : nameElement.Child(0).Attr("href"));
                    string pic = picElement.Child(0).Child(0).Attr("src");
                    DateTime date = Convert.ToDateTime(dateElement.Text().Replace("到访：", ""));
                    string[] userInfo = StringHelper.SplitWhiteSpace(userInfoElement.Child(0).Text());
                    int age = Convert.ToInt32(userInfo[0].Replace("岁", ""));
                    string addr = userInfo.Length > 1 ? userInfo[1] : string.Empty;
                    string userCode = homePage.Substring(homePage.LastIndexOf('/') + 1);

                    if (addr.Contains("广州") && !string.IsNullOrWhiteSpace(userCode))
                    {
                        FateUserInfo user = FateUserInfoManager.GetUser(userCode);
                        if (user == null)
                        {
                            user = new FateUserInfo()
                            {
                                CreateTime = DateTime.Now
                            };
                        }
                        user.ModifyTime = DateTime.Now;
                        user.UserCode = userCode;
                        user.Address = addr;
                        user.Age = age;
                        user.HeadFileName = pic;
                        user.UserName = userName;

                        FateUserInfoManager.SaveOrUpdateUser(user);
                    }
                }
            }

        }
        /// <summary>
        /// 获取第一个html元素
        /// </summary>
        /// <param name="els"></param>
        /// <returns></returns>
        public static NSoup.Nodes.Element GetElementFirst(NSoup.Select.Elements els)
        {
            if (els == null || els.Count <= 0)
            {
                return null;
            }
            return els[0];
        }


    }
}
