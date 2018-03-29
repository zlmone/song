using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WSH.Options.Common;
using WSH.Manager.Models;
using WSH.Web.Mvc.Common;
using WSH.Manager.Applications;
using WSH.Web.Common;
using System.IO;
using WSH.Common;
using System.Net;
using RazorEngine;
using WSH.Common.Helper;
using WSH.Web.Common.Attachment;

namespace WSH.Manager.Controllers.Modules
{
    public class UrlsController : BaseController
    {
        public string UrlIconPath
        {
            get
            {
                return "~/img/DownUrlIcons/";
            }
        }
        #region 初始化服务类
        public readonly UrlsRepository urlsRepository;
        public UrlsController()
        {
            urlsRepository = new UrlsRepository();
        }
        #endregion

        /// <summary>
        /// 主页面
        /// </summary>
        public ActionResult Urls()
        {
            return View();
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="urls">查询条件的实体</param>
        /// <param name="sort">排序列</param>
        /// <param name="order">排序方向</param>
        /// <param name="page">页码</param>
        /// <param name="rows">页大小</param>
        public ContentResult GetUrlsList(UrlsEntity entity, string sort, string order, int page = 1, int rows = 20)
        {
            var query = urlsRepository.FindAll();
            //查询条件设置
            if (!string.IsNullOrEmpty(entity.Title))
            {
                query = query.Where(o => o.Title.Contains(entity.Title));
            }
            if (!string.IsNullOrEmpty(entity.Remark))
            {
                query = query.Where(o => o.Remark.Contains(entity.Remark));
            }
            var list = query.OrderByDescending(o => o.Hits).ToPagingList<UrlsEntity>(page, rows);
            foreach (var item in list)
            {
                item.IconUrl = GetIconUrl(item.IconName);
            }
            return GridResult<UrlsEntity>(list);
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id">主键id</param>
        public ContentResult GetUrls(string id)
        {
            var entity = urlsRepository.Get(id);
            return Content(JsonHelper.ToJson(entity));
        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        public ActionResult UrlsEdit()
        {
            return View();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="urls">保存数据的实体</param>
        public ContentResult SaveUrls(UrlsEntity entity)
        {
            return TrySaveAction(r =>
             {
                 if (urlsRepository.FindAll().Where(o => o.Title == entity.Title && entity.Id != o.Id).Count() > 0)
                 {
                     r.IsSuccess = false;
                     r.Msg = "该地址已经存在";
                 }
                 else
                 {
                     entity.CreateTime = DateTime.Now;
                     entity.IconName = DownloadUrlIcon(entity.IconUrl, entity.IconName);
                     entity = urlsRepository.SaveOrUpdate(entity);
                 }
                 return entity.Id;
             });
        }
        /// <summary>
        /// 更新点击量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContentResult UpdateHits(string id)
        {
            return TryAction(r =>
            {
                UrlsEntity entity = urlsRepository.Get(id);
                entity.Hits += 1;
                urlsRepository.Update(entity);
                r.Msg = string.Empty;
            });
        }

        /// <summary>
        /// 删除列表数据
        /// </summary>
        /// <param name="ids">删除id集合</param>
        /// <param name="result">返回信息</param>
        protected override void RemoveGridRows(string[] ids, Result result)
        {
            urlsRepository.BatchDelete(ids);
        }

        /// <summary>
        /// 加载网页图标信息
        /// </summary>
        /// <param name="iconUrl"></param>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public ContentResult LoadUrlIcon(string iconUrl, string hostname)
        {
            return TryAction(r =>
            {
                string fileName = DownloadUrlIcon(iconUrl, hostname);
                r.Add("iconUrl", Url.Content(UrlIconPath + fileName + ".png"));
            }, "获取网页图标");
        }

        /// <summary>
        /// 获取网页标题
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ContentResult GetPageTitle(string url)
        {
            return TryAction(r =>
            {
                string encoding = "utf-8";
                string html = DataMiningHelper.GetHtmlAutoEncode(url, out encoding);
                string title = DataMiningHelper.GetItemsByTab(html, "<title>", "</title>")[0];
                r.Add("title", title);
                r.Add("encoding", encoding);
            }, "获取网页标题");
        }
        /// <summary>
        /// 导入收藏夹
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public ContentResult ImportBookmarks(string files)
        {
            IList<UploadedItem> uploads = UploadedManager.Parse(files);
            return TryAction(r =>
            {
                int count = 0;
                int successCount = 0;
                int errorCount = 0;
                foreach (UploadedItem item in uploads)
                {
                    string path = Server.MapPath(UrlIconPath);
                    var fullFile = Server.MapPath(item.FilePath);
                    string fileContent = FileHelper.GetFileContent(fullFile, Encoding.GetEncoding("utf-8"));
                    List<string> listItems = DataMiningHelper.GetItemsByTab(fileContent, "<A", "</A>");
                    count += listItems.Count;
                    foreach (string listItem in listItems)
                    {
                        try
                        {
                            IDictionary<string, string> attrs = TagHelper.ParseAttributes(listItem);
                            string url = attrs["HREF"];
                            if (urlsRepository.FindAll().Where(o => o.Url == url).Count() <= 0)
                            {
                                //不存在则新增
                                string encoding = "utf-8";
                                // string html = DataMining.GetHtmlAutoEncode(url, out encoding);
                                Uri uri = new Uri(url);
                                if (attrs.ContainsKey("ICON") && !string.IsNullOrEmpty(attrs["ICON"]))
                                {
                                    string base64 = attrs["ICON"].Replace("data:image/png;base64,", "");
                                    ImgHelper.SaveBase64(base64, Path.Combine(path, uri.Host + ".png"));
                                }
                                else if (attrs.ContainsKey("ICON_URI") && !string.IsNullOrEmpty(attrs["ICON_URI"]))
                                {
                                    DownloadUrlIcon(attrs["ICON_URI"], uri.Host);
                                }
                                UrlsEntity entity = new UrlsEntity()
                                {
                                    Url = url,
                                    CreateTime = DateTime.Now,
                                    Encoding = encoding,
                                    IconName = uri.Host,
                                    IconUrl = string.Format("http://{0}/favicon.ico", uri.Host),
                                    Title = attrs["InnerText"],
                                    Remark = attrs["ADD_DATE"]
                                };
                                urlsRepository.Add(entity);
                            }
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            errorCount++;
                        }
                    }
                }
                r.Msg = string.Format("导出完毕，总共【{0}】项，成功【{1}】，失败【{2}】", count, successCount, errorCount);
            });
        }
        /// <summary>
        /// 导出收藏夹
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportBookmarks()
        {
            string templ = FileHelper.GetFileContent(Server.MapPath("~/Templete/bookmarks-template.html"), Encoding.GetEncoding("utf-8"));
            IList<UrlsEntity> list = urlsRepository.FindAll().ToList();
            if (list == null)
            {
                list = new List<UrlsEntity>();
            }
            foreach (UrlsEntity entity in list)
            {
                entity.IconName = ImgHelper.ToBase64(Server.MapPath(GetIconUrl(entity.IconName)));
            }
            string content = Razor.Parse<IList<UrlsEntity>>(templ, list);
            string fileName="bookmarks-" + DateTimeHelper.GetDateFormat(FormatHelper.Date) + ".html";
            WebDownload download = new WebDownload(fileName);
            download.DownloadContent(content);
            return View();
        }
        /// <summary>
        /// 下载图标
        /// </summary>
        /// <param name="iconUrl"></param>
        /// <param name="hostname"></param>
        /// <returns></returns>
        protected string DownloadUrlIcon(string iconUrl, string hostname)
        {
            string fileName = hostname + ".png";
            // string icoName = hostname + ".ico";
            string path = Server.MapPath(UrlIconPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string savePath = Path.Combine(path, fileName);
            if (!System.IO.File.Exists(savePath))
            {
                WebClient c = new WebClient();
                c.DownloadFile(iconUrl, savePath);
                // c.DownloadFile(iconUrl, Path.Combine(path, icoName));
            }
            return hostname;
        }
        protected string GetIconUrl(string name)
        {
            return Url.Content(UrlIconPath + name + ".png");
        }
    }
}
