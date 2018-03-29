using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WSH.Common.Helper;
using WSH.Web.Common.Helper;

namespace WSH.Web.Common.Attachment
{
    public class FileExplorerManager
    {
        #region 获取文件资源管理器内容项集合
        public List<FileExplorerItem> GetFileExplorerItems(string currentPath)
        {
            if (string.IsNullOrEmpty(currentPath))
            {
                return null;
            }
            List<FileExplorerItem> items = new List<FileExplorerItem>();
            DirectoryInfo root = new DirectoryInfo(currentPath);
            DirectoryInfo[] dirs = root.GetDirectories();
            FileInfo[] files = root.GetFiles();
            if (dirs.Length <= 0 && files.Length <= 0)
            {
                return null;
            }
            else
            {
                foreach (DirectoryInfo dir in dirs)
                {
                    if (!FileHelper.IsHiddenFile(dir.Attributes))
                    {
                        items.Add(new FileExplorerItem()
                        {
                            IsFile = false,
                            FullFileName = dir.FullName,
                            FileName = dir.Name
                        });
                    }
                }
                foreach (FileInfo file in files)
                {
                    if (!FileHelper.IsHiddenFile(file.Attributes))
                    {
                        items.Add(new FileExplorerItem()
                        {
                            IsFile = true,
                            FullFileName = file.FullName,
                            FileName = file.Name,
                            FileExtension = file.Extension,
                            FileLength = file.Length,
                            FileUrl = WebUrlHelper.ToVirtual(file.FullName)
                        });
                    }
                }
                return items;
            }
        }
        #endregion


    }
}
