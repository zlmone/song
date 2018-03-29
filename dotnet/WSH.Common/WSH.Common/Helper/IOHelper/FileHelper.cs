using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Net;
using WSH.Options.Common;

namespace WSH.Common.Helper
{
    public class FileHelper
    {
        #region 判断文件类型
        public static FileType GetFileTypeByFileName(string fileName)
        {
            return GetFileType(Path.GetExtension(fileName));
        }
        public static FileType GetFileType(string ext)
        {
            switch (ext.ToLower())
            {
                case ".xls":
                case ".xlsx":
                    return FileType.Excel;
                case ".doc":
                case ".docx":
                    return FileType.Word;
                case ".ppt":
                case ".pptx":
                    return FileType.PPT;
                case ".ico":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                    return FileType.Image;
                case ".txt":
                    return FileType.Txt;
                case ".htm":
                case ".html":
                case ".css":
                case ".js":
                    return FileType.Html;
                case ".swf":
                case ".fla":
                case ".as":
                    return FileType.Flash;
                case ".xml":
                case ".config":
                case ".sitemap":
                case ".cfg":
                case ".ini":
                case ".properties":
                    return FileType.Config;
                case ".aspx":
                case ".cshtml":
                case ".xaml":
                case ".cs":
                case ".ashx":
                case ".asp":
                case ".ascx":
                case ".master":
                case ".asmx":
                case ".asax":
                case ".rpt":
                case ".xsd":
                case ".resx":
                case ".dll":
                    return FileType.DotNet;
                case ".java":
                case ".jar":
                case ".jsp":
                case ".class":
                    return FileType.Java;
                case ".zip":
                case ".rar":
                case ".7z":
                    return FileType.Package;
                case ".mdf":
                case ".accdb":
                case ".mdb":
                case ".ldf":
                case ".sql":
                case ".sdf":
                case ".db":
                    return FileType.DB;
                case ".bin":
                case ".obj":
                    return FileType.Assembly;
                case ".exe":
                case ".msi":
                case ".bat":
                case ".iso":
                case ".apk":
                    return FileType.Execute;
                case ".bt":
                case ".torrent":
                    return FileType.BT;
                case ".mp4":
                case ".rm":
                case ".rmvb":
                case ".avi":
                case ".flv":
                case ".mkv":
                case ".mov":
                case ".mpeg":
                case ".mpg":
                case ".qt":
                case ".ram":
                case ".viv":
                case ".wmv":
                case ".asf":
                case ".wm":
                case ".wmp":
                case ".rpm":
                case ".dat":
                case ".amv":
                    return FileType.Video;
                case ".mp3":
                case ".wma":
                case ".aif":
                case ".aiff":
                case ".amr":
                case ".mp5":
                case ".mpa":
                case ".ogg":
                case ".wav":
                case ".mid":
                case ".mpc":
                    return FileType.Voice;
                default:
                    return FileType.Other;
            }
        }
        #endregion

        #region 目录操作
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFolder(string path, bool isChilds)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, isChilds);
            }
        }
        /// <summary>
        /// 目录复制
        /// </summary>
        /// <param name="direcSource">源目录</param>
        /// <param name="direcTarget">目标目录</param>
        public static void CopyFolder(string direcSource, string direcTarget)
        {
            if (!System.IO.Directory.Exists(direcTarget))
            {
                System.IO.Directory.CreateDirectory(direcTarget);
            }
            System.IO.DirectoryInfo direcInfo = new System.IO.DirectoryInfo(direcSource);
            System.IO.FileInfo[] files = direcInfo.GetFiles();
            foreach (System.IO.FileInfo file in files)
            {
                file.CopyTo(System.IO.Path.Combine(direcTarget, file.Name), true);
            }
            System.IO.DirectoryInfo[] direcInfoArr = direcInfo.GetDirectories();
            foreach (System.IO.DirectoryInfo dir in direcInfoArr)
            {
                CopyFolder(System.IO.Path.Combine(direcSource, dir.Name), System.IO.Path.Combine(direcTarget, dir.Name));
            }
        }
        #endregion

        #region 文件操作
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public static void WriteFile(string path, string text)
        {
            WriteFile(path, Encoding.Default.GetBytes(text));
        }
        /// <summary>
        /// 导出文件
        /// </summary>
        public static void WriteFile(string path, byte[] bytes)
        {
            if (path == null) { return; }
            using (FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();
                bytes = null;
            }
        }
        /// <summary>
        /// 得到文件的所有内容
        /// </summary>
        public static string GetFileContent(string fileName)
        {
            return GetFileContent(fileName, Encoding.Default);
        }
        /// <summary>
        /// 得到文件的所有内容
        /// </summary>
        public static string GetFileContent(string fileName, Encoding encoding)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return null;
            }
            if (!File.Exists(fileName))
            {
                return null;
            }
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(fileName, encoding);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        /// <summary>
        /// 根据文件路径读取二进制数据
        /// </summary>
        /// <param name="fullFileName">完整的文件本地路径</param>
        /// <returns></returns>
        public static byte[] GetFileBytes(string fullFileName)
        {
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(fullFileName);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                fs.Close();
                return bytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 打开指定的文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void OpenFile(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                System.Diagnostics.Process.Start(fileName);
            }
            else
            {
                throw new FileNotFoundException("指定文件不存在！");
            }
        }
        /// <summary>
        /// 打开指定的目录，并选中指定的文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="fileName">文件名（不包含路径）</param>
        public static void OpenPath(string path, string fileName = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                //剔除文件名的路径
                fileName = Path.GetFileName(fileName);
                //重新组装文件路径
                path = Path.Combine(path, fileName);
                if (!File.Exists(path))
                {
                    throw new DirectoryNotFoundException("指定文件不存在！");
                }
                else
                {
                    //如果传入了文件名，则打开文件目录并选中文件
                    path = "/select," + path;
                }
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    throw new DirectoryNotFoundException("指定目录不存在！");
                }
            }
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
        #endregion

        /// <summary>
        /// 检测是否为隐藏文件或者系统文件
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static bool IsHiddenFile(FileAttributes attr)
        {
            if ((attr & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                return true;
            }
            if ((attr & FileAttributes.System) == FileAttributes.System)
            {
                return true;
            }
            return false;
        }
    }
}
