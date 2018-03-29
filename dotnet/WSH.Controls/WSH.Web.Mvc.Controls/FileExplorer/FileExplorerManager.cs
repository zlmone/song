using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WSH.Common;
using System.Web;
using WSH.Common.Helper;

namespace WSH.Web.Common
{
    public class FileExplorerManager
    {
        //private string rootPath;
        ///// <summary>
        ///// 根目录
        ///// </summary>
        //public string RootPath
        //{
        //    get { return rootPath; }
        //    set { rootPath = value; }
        //}
        //private string currentPath;
        ///// <summary>
        ///// 当前的目录
        ///// </summary>
        //public string CurrentPath
        //{
        //    get { return string.IsNullOrEmpty(currentPath) ? RootPath : currentPath; }
        //    set { currentPath = value; }
        //}
        //public string CurrentPathClientID
        //{
        //    get { return "fileExplorerCurrentPath"; }
        //}
        //private string emptyText = "该目录下暂时没有文件";
        ///// <summary>
        ///// 没有文件和文件夹时显示的文字
        ///// </summary>
        //public string EmptyText
        //{
        //    get { return emptyText; }
        //    set { emptyText = value; }
        //}
        //private bool isHidden = false;
        ///// <summary>
        ///// 是否显示隐藏文件和系统文件
        ///// </summary>
        //public bool IsHidden
        //{
        //    get { return isHidden; }
        //    set { isHidden = value; }
        //}
        //public string GetCurrentPathValue()
        //{
        //    //return ClientHelper.GetInput(InputType.Hidden, CurrentPathClientID, CurrentPath);
        //    return new HtmlBuilder("input") { }.ToString();
        //}
        //private string GetHtmlFile(bool isFolder, int num, string fileName, string fileSize)
        //{
        //    string type = isFolder ? "folder" : Path.GetExtension(fileName).Substring(1).ToLower();
        //    string name = Path.GetFileName(fileName);
        //    string decodename = HttpContext.Current.Server.UrlEncode(fileName);
        //    bool isImage = false;
        //    if (!isFolder)
        //    {
        //        isImage = ImgHelper.IsImage(type);
        //    }
        //    string display = "<span>" + name + "</span>";
        //    if (isFolder)
        //    {
        //        display = "<a href=\"" + ClientHelper.NullHref + "\" onclick=\"song.fileExplorer.folder('" + decodename + "');\">" + name + "</a>";
        //    }
        //    else if (isImage)
        //    {
        //        display += GetFileCommand(fileName);
        //    }
        //    string size = isFolder ? "&nbsp;" : fileSize;
        //    string zebra = num % 2 != 0 ? "odd" : "even";
        //    string isShowImageCmd = ClientHelper.GetBool(isImage);
        //    string hover = " onmouseover=\"song.fileExplorer.over(this," + isShowImageCmd + ");\" onmouseout=\"song.fileExplorer.out(this," + isShowImageCmd + ");\"";
        //    string html = "<tr class=\"song-explorer-" + zebra + "\"" + hover + ">" +
        //                    "<td class=\"song-explorer-num\">" + num.ToString() + "</td>" +
        //                    "<td class=\"song-explorer-type\">" +
        //                        "<button disabled=\"disabled\" class=\"song-explorer-filetype filetype file-" + type + "\"></button>" +
        //                    "</td>" +
        //                    "<td>" + display + "</td>" +
        //                    "<td class=\"song-explorer-size\">" + size + "</td>" +
        //                "</tr>";
        //    return html;
        //}
        //private string GetEmpty()
        //{
        //    return string.Format("<tr><td colspan=\"4\"><span class=\"song-explorer-empty\">{0}</span></td></tr>", EmptyText);
        //}
        ///// <summary>
        ///// 文件操作按钮
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <returns></returns>
        //private string GetFileCommand(string fileName)
        //{
        //    string file = WebUrlHelper.ToVirtual(fileName);
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<span class=\"song-explorer-cmd\">[");

        //    sb.Append("<a href=\"" + ClientHelper.NullHref + "\" onclick=\"javascript:song.fileExplorer.preview('" + file + "',this);\">预览</a> | ");
        //    sb.Append("<a href=\""+ClientHelper.NullHref+"\" onclick=\"javascript:song.fileExplorer.select('" + file + "',this);\">选择</a>");

        //    sb.Append("]</span>");
        //    return sb.ToString();
        //}
    }
}