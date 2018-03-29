using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using WSH.Common;
using System.Data;
using WSH.TransferData;
using WSH.TransferData.Common;
using WSH.Common.Helper;

namespace WSH.Tools.Common
{
    public class AddressBook
    {
        /// <summary>
        /// 解析通讯录文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Parse(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string ext = Path.GetExtension(fileName).ToLower();
                StringBuilder sb = new StringBuilder();
                try
                {
                    string text = FileHelper.GetFileContent(fileName,Encoding.UTF8);
                    FileType fileType = FileHelper.GetFileType(ext);
                    if (!string.IsNullOrEmpty(text))
                    {
                        bool isFirstColumn = false;
                        string[] columns = new string[] { "联系人", "号码", "号码类型" };
                        string templ = "{0}\t{1}\t{2}";
                        if (ext == ".vcf")
                        {
                            sb.AppendLine(string.Format(templ, columns[0], columns[1], columns[2]));
                            string regexName = @"^(?:FN:)(.*)(?:/*.*)$";
                            MatchCollection matchName = Regex.Matches(text, regexName, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                            string regexTel = @"^(?:TEL;TYPE=CELL(?:;TYPE=PREF)?:)((\+86)?\d{11,12})";
                            MatchCollection matchTel = Regex.Matches(text, regexTel, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                            if (matchName.Count > 0 && matchTel.Count > 0)
                            {
                                for (int i = 0; i < matchName.Count; i++)
                                {
                                    string name = Regex.Replace(matchName[i].Groups[1].Value, "/+.*$", "");
                                    string value = matchTel[i].Groups[1].Value;
                                    string type = Regex.IsMatch(value, @"^(\+86){1}\d{11}$") ? "联通" : "移动";
                                    string tel = Regex.Replace(value, @"^(\+86){1}", "");
                                    if(tel.StartsWith("0")){
                                        type = "座机";
                                    }
                                    sb.AppendLine(string.Format(templ, name, tel, type));
                                }
                            }
                        }
                        else if (fileType== FileType.Txt)
                        {
                            sb.Append(text);
                        }
                        else if (fileType== FileType.Excel)
                        {
                            ITransferData transfer = TransferDataFactory.GetTransferData(fileName);
                            DataTable dt= transfer.GetData(fileName,columns,isFirstColumn);
                            sb.Append(TxtHelper.ToTextContent(dt));
                        }
                    }
                }
                catch (Exception ex)
                {
                    sb.Append(ex.Message);
                }
                return sb.ToString();
            }
            return string.Empty;
        }
    }
}
