using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WSH.Common.Helper;
using WSH.Common;
using WSH.Tools.Internet.Movie.Model;
using WSH.Tools.Internet.Movie.Manager;
using WSH.Common.Http;
using System.Text.RegularExpressions;

namespace WSH.Tools.Internet.Movie.Request
{
    public class Movie365Request : HttpSimpleRequest
    {
        public Movie365Request()
        {
            this.Encoding = Encoding.GetEncoding("gb2312");
            this.Method =  RequestMethod.GET;
        }
        #region 私有方法
        private NSoup.Select.Elements GetLinks(string url)
        {
            WSH.Options.Common.Result result = this.Request(url);
            if (result.IsSuccess)
            {
                string htmlString = result.Msg;
                NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(htmlString);
                NSoup.Select.Elements links = doc.GetElementsByTag("a");
                NSoup.Select.Elements h3s = doc.GetElementsByTag("h3");
                NSoup.Select.Elements spans = doc.GetElementsByTag("span");
                if (links != null)
                {
                    if (h3s != null)
                    {
                        links.AddRange(h3s);
                    }
                    if (spans != null)
                    {
                        links.AddRange(spans);
                    }
                }
                return links;
            }
            else
            {
                throw new Exception(result.Msg);
            }
        }
        //获取子页面地址
        public List<string> GetChildPages(ref List<string> linkUrls)
        {
            List<string> links = GetValidPageLinkAddress();
            List<string> urls = new List<string>();
            if (links != null)
            {
                links.ForEach(o =>
                {
                    if (UriHelper.IsWebPage(o))
                    {
                        bool isWebRoot = o.StartsWith("/");
                        string webroot = UriHelper.GetUrlRoot(this.Url);
                        urls.Add(UriHelper.Combine(isWebRoot ? webroot : this.Url, o));
                    }
                });
                //获取子页面之后，解析当前页面的可下载链接
                linkUrls.AddRange(this.Parse(links));
            }
            return urls;
        }
        private List<string> GetLinkAddress(NSoup.Select.Elements links)
        {
            List<string> linkList = new List<string>();
            foreach (NSoup.Nodes.Element link in links)
            {
                //过滤重复的链接
                switch (link.TagName().ToLower())
                {
                    case "span":
                        linkList.AddRange(GetSpanContentLink(link));
                        break;
                    case "h3":
                        linkList.Add(GetContentLink(link));
                        break;
                    default:
                        linkList.Add(GetHref(link));
                        break;
                }
            }
            return linkList;
        }
        /// <summary>
        /// 解析H3中的文本链接
        /// </summary>
        private string GetContentLink(NSoup.Nodes.Element el)
        {
            string content = el.Text();
            string link = string.Empty;
            if (!string.IsNullOrWhiteSpace(content))
            {
                List<string> contents = Regex.Split(content, ":|：").ToList();
                if (contents != null && contents.Count > 1)
                {
                    contents.RemoveAt(0);
                    link = string.Join(":", contents);
                }
            }
            return link;
        }
        private List<string> GetSpanContentLink(NSoup.Nodes.Element el)
        {
            string content = el.Html();
            List<string> links = new List<string>();
            if (!string.IsNullOrEmpty(content))
            {
                List<string> contents = Regex.Split(content, "<br>|<br />|<br/>|<br >", RegexOptions.IgnoreCase).ToList();
                if (contents != null && contents.Count > 1)
                {
                    foreach (string c in contents)
                    {
                        if (IsDownloadLink(c))
                        {
                            links.Add(c);
                        }
                    }
                }
            }
            return links;
        }
        private string GetHref(NSoup.Nodes.Element el)
        {
            return (el.Attr("href") ?? string.Empty).Trim();
        }
        #endregion
        /// <summary>
        /// 获取页面验证之后的链接集合
        /// </summary>
        /// <returns></returns>
        private List<string> GetValidPageLinkAddress()
        {
            NSoup.Select.Elements links = GetLinks(this.Url);
            List<string> hrefs = new List<string>();
            if (links != null && links.Count > 0)
            {
                if (links.Count == 1 && links[0].TagName().ToLower()=="a")
                {
                    //需要点击验证
                    var website = UriHelper.GetUrlRoot(this.Url);
                    string url = UriHelper.Combine(website, GetHref(links[0]));
                    links = GetLinks(url);
                }
                if (links != null)
                {
                    hrefs = GetLinkAddress(links);
                }
            }
            return hrefs;
        }
        private FileType GetFileType(string href)
        {
            FileType fileType = FileType.Other;
            try
            {
                string ext = Path.GetExtension(href);
                if (!string.IsNullOrEmpty(ext))
                {
                    //判断如果是下载链接
                    fileType = FileHelper.GetFileType(ext);
                }
            }
            catch{}
            return fileType;
        }
        /// <summary>
        /// 判断是否是下载链接
        /// </summary>
        /// <param name="href"></param>
        /// <returns></returns>
        public bool IsDownloadLink(string href)
        {
            if (string.IsNullOrWhiteSpace(href))
            {
                return false;
            }
            //判断是否是迅雷下载链接
            bool isThunder = UriHelper.IsThunderLink(href);
            var types = new List<FileType>(){
                                FileType.Voice,
                                FileType.Video,
                                FileType.BT
                            };

            if (isThunder || types.Contains(GetFileType(href)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 解析网页可下载的链接
        /// </summary>
        /// <returns></returns>
        public List<string> Parse(List<string> hrefs = null)
        {
            List<string> list = new List<string>();
            try
            {
                if (hrefs == null)
                {
                    hrefs = GetValidPageLinkAddress();
                }
                if (hrefs != null && hrefs.Count > 0)
                {
                    foreach (string href in hrefs)
                    {
                        if (IsDownloadLink(href))
                        {
                            list.Add(href);
                            //认为是可以下载的视频
                            LinkAddressInfo linkInfo = LinkAddressInfoManager.GetLinkInfo(href);
                            if (linkInfo == null)
                            {
                                linkInfo = new LinkAddressInfo()
                                {
                                    CreateTime = DateTime.Now,
                                    LinkType = GetFileType(href) == FileType.Voice ? LinkAddressType.Voice : LinkAddressType.Video,
                                    Hits = 0,
                                    LinkAddress = href,
                                    Title = this.Url
                                };
                                LinkAddressInfoManager.SaveOrUpdateUser(linkInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                list.Add(ex.Message);
            }
            return list;
        }
    }
}
