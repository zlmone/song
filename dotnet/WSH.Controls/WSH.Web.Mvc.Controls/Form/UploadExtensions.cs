using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WSH.Web.Mvc.Controls
{
    public static class UploadExtensions
    {
        /// <summary>
        /// 重写上传控件，目前只支持多附件上传，单附件上传待扩展
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static MvcHtmlString Upload(this HtmlHelper html, string id, UploadOptions options)
        {
            if (options == null)
            {
                options = new UploadOptions();
            }
            string path = options.UploadPath;
            if (string.IsNullOrEmpty(path))
            {
                path = "Upload";
            }
            string exts = options.FileExtensions;
            if (string.IsNullOrEmpty(exts))
            {
                exts = ".jpg;.gif;.bmp;.png;.doc;.docx;.xls;.xlsx;.ppt;.pptx;.zip;.rar;.txt;.pdf";
            }
            int size = options.FileSize;
            if (size <= 0)
            {
                size = 5;
            }
            string qid = id + "-fileQueue";
            string listid = id + "-fileList";
            string uploadbuttonid = id + "-uploadbutton";
            StringBuilder sb = new StringBuilder();
            if (options.Editable == true)
            {
                sb.AppendLine("<input type=\"file\" id=\"" + id + "\" name=\"" + id + "\"/>");
                if(!options.Auto){
                    sb.AppendLine("<input id=\"" + uploadbuttonid + "\" style=\"width:82px;height:26px;\" type=\"button\" class=\"uploadify-button uploadify\" value=\"上传\" onclick=\"song.getCmp('" + id + "').uploadFiles()\"/>");
                }
                sb.AppendLine("<div id=\"" + qid + "\" class=\"clear\">");
                sb.AppendLine("</div>");
            }
            sb.AppendLine("<div id=\"" + listid + "\" style=\"margin-top:0px;zoom:1\">");
            sb.AppendLine("</div>");
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("    $(document).ready(function () {");
            if (!options.Auto && options.Editable)
            {
                sb.AppendLine("        song.upload.buttonHover('#" + uploadbuttonid + "');");
            }
            sb.AppendLine("        new song.upload({");
            sb.AppendLine("            id:\"" + id + "\",");
            sb.AppendLine("            maxSize:" + size + ",");
            sb.AppendLine("            multi:" + (options.Multi.HasValue ? options.Multi.ToString().ToLower() : "true") + ",");
            sb.AppendLine("            fileExt: \"" + exts + "\",");
            sb.AppendLine("            queueId: \"" + qid + "\",");
            sb.AppendLine("            listId: \"" + listid + "\",");
            if (!string.IsNullOrEmpty(options.UploadedFiles))
            {
                sb.AppendLine("            uploadedFiles:\"" + options.UploadedFiles + "\",");
            }
            if (options.Truncate > 0)
            {
                sb.AppendLine("            truncate:" + options.Truncate + ",");
            }
            if (options.Editable == false)
            {
                sb.AppendLine("            editable:false,");
            }
            if(options.Auto){
                sb.AppendLine("            auto:true,");
            }
            if (!string.IsNullOrEmpty(options.OnDeleteFile))
            {
                sb.AppendLine("            onDeleteFile:"+options.OnDeleteFile+",");
            }
            sb.AppendLine("            uploadPath:\"" + path + "\"");
            sb.AppendLine("        });");
            sb.AppendLine("    });");
            sb.AppendLine("</script>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
    public class UploadOptions
    {
        /// <summary>
        /// 是否支持多附件上传
        /// </summary>
        public bool? Multi { get; set; }
        /// <summary>
        /// 附件上传大小，单位：M，默认（5M）
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// 允许上传的文件扩展名,默认（.jpg;.gif;.bmp;.png;.doc;.docx;.xls;.xlsx;.ppt;.pptx;.zip;.rar;.txt;.pdf）
        /// </summary>
        public string FileExtensions { get; set; }
        /// <summary>
        /// 上传的目录，默认：Upload
        /// </summary>
        public string UploadPath { get; set; }
        /// <summary>
        /// 加载已经上传的文件，格式如：ftp文件名.jpg,真实文件名.jpg|ftp文件名.jpg,真实文件名.jpg
        /// </summary>
        public string UploadedFiles { get; set; }
        /// <summary>
        /// 文件名最多显示多少个文字
        /// </summary>
        public int Truncate { get; set; }

        private bool editable = true;
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool Editable
        {
            get { return editable; }
            set { editable = value; }
        }
        //是否自动上传文件
        public bool Auto { get; set; }
        /// <summary>
        /// 删除已上传的文件前执行的脚本函数
        /// </summary>
        public string OnDeleteFile { get; set; }
    }
}
