using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using System.Collections;

namespace WSH.Compress.Common
{
    public class ZipHelper
    {
        /// <summary>
        /// 功能：压缩文件（暂时只压缩文件夹下一级目录中的文件，文件夹及其子级被忽略）
        /// </summary>
        /// <param name="dirPath">被压缩的文件夹夹路径</param>
        /// <param name="zipFilePath">生成压缩文件的路径，为空则默认与被压缩文件夹同一级目录，名称为：文件夹名+.zip</param>
        /// <param name="err">出错信息</param>
        /// <returns>是否压缩成功</returns>
        public static void ZipFolder(string dirPath, string zipFileName)
        {
            if (string.IsNullOrEmpty(dirPath) || !Directory.Exists(dirPath))
            {
                return;
            }
            zipFileName = GetDefaultName(dirPath,zipFileName);
            string[] filenames = Directory.GetFiles(dirPath);
            ZipFiles(filenames,zipFileName);
        }
        /// <summary>
        /// 如果文件名为空，压缩名为文件夹名
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipFileName"></param>
        /// <returns></returns>
        private static string GetDefaultName(string path, string zipFileName)
        {
            if (string.IsNullOrEmpty(zipFileName))
            {
                zipFileName = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".zip");
            }
            return zipFileName;
        }
        /// <summary>
        /// 压缩文件夹下的文件和子文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="zipFileName"></param>
        public static void ZipFolderAll(string dirPath, string zipFileName) {
            zipFileName = GetDefaultName(dirPath,zipFileName);
            ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipFileName));
            zipStream.SetLevel(6);  // 压缩级别 0-9
            CreateZipFiles(dirPath, zipStream, dirPath);
            zipStream.Finish();
            zipStream.Close();
        }

        /// <summary>
        /// 递归压缩文件
        /// </summary>
        /// <param name="sourceFilePath">待压缩的文件或文件夹路径</param>
        /// <param name="zipStream">打包结果的zip文件路径（类似 D:\WorkSpace\a.zip）,全路径包括文件名和.zip扩展名</param>
        /// <param name="staticFile"></param>
        private static void CreateZipFiles(string sourceFilePath, ZipOutputStream zipStream, string staticFile)
        {
            Crc32 crc = new Crc32();
            string[] filesArray = Directory.GetFileSystemEntries(sourceFilePath);
            foreach (string file in filesArray)
            {
                if (Directory.Exists(file))                     //如果当前是文件夹，递归
                {
                    CreateZipFiles(file, zipStream, staticFile);
                }
                else                                            //如果是文件，开始压缩
                {
                    FileStream fileStream = File.OpenRead(file);
                    byte[] buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);
                    string tempFile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                    ZipEntry entry = new ZipEntry(tempFile);
                    entry.DateTime = DateTime.Now;
                    entry.Size = fileStream.Length;
                    fileStream.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    zipStream.PutNextEntry(entry);

                    zipStream.Write(buffer, 0, buffer.Length);
                }
            }
        }
     
        #region 解压文件夹
        /// <summary>
        /// 功能：解压zip格式的文件（解压子文件夹）
        /// </summary>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="unZipDir">解压文件存放路径,为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹</param>
        /// <param name="err">出错信息</param>
        /// <returns>解压是否成功</returns>
        public static void UnZipAll(string zipFilePath, string unZipDir)
        {
            if (string.IsNullOrEmpty(zipFilePath) || !File.Exists(zipFilePath))
            {
                return;
            }
            //解压文件夹为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹
            if (string.IsNullOrEmpty(unZipDir))
                unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
            if (!unZipDir.EndsWith("\\"))
                unZipDir += "\\";
            if (!Directory.Exists(unZipDir))
            {
                Directory.CreateDirectory(unZipDir);
            }
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
            {

                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(unZipDir + directoryName);
                    }
                    if (!directoryName.EndsWith("\\"))
                        directoryName += "\\";
                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(unZipDir + theEntry.Name))
                        {

                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// 打包多个文件
        /// </summary>
        /// <param name="files">压缩文件名称集合</param>
        /// <param name="zipFileName">压缩后文件名称</param>
        public static void ZipFiles(string[] files, string zipFileName)
        {
            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFileName)))
            {
                s.SetLevel(6);
                byte[] buffer = new byte[4096];
                foreach (string file in files)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);
                    using (FileStream fs = File.OpenRead(file))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }
                s.Finish();
                s.Close();
            }
        }
        /// <summary>
        /// 打包单个文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="zipFileName"></param>
        public static void ZipFile(string file, string zipFileName) {
            zipFileName = GetDefaultName(file, zipFileName);
            ZipFiles(new string[] { file }, zipFileName);
        }
    }
}
