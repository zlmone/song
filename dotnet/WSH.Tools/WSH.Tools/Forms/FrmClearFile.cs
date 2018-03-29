using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Common;
using WSH.Options.Common;
using System.IO;
using WSH.WinForm.Common;
using WSH.Common.Configuration;

namespace WSH.Tools
{
    public partial class FrmClearFile : Form
    {
        ConfigurationData data = new ConfigurationData();
        IList<DataItem> list = new List<DataItem>();
        public FrmClearFile()
        {
            InitializeComponent();
            list = data.Get("IISFilePath");
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("开始扫描文件夹...");
            int count = 0;
            if (list.Count > 0)
            {
                foreach (DataItem DataItem in list)
                {
                    DirectoryInfo dir = new DirectoryInfo(DataItem.Text);
                    DirectoryInfo[] dirlist = dir.GetDirectories();
                    if (dirlist.Length > 0)
                    {
                        for (int i = 0; i < dirlist.Length; i++)
                        {
                            sb.AppendLine(Path.GetFileName(dirlist[i].Name));
                            count++;
                        }
                    }
                }
                sb.AppendLine("共扫描到文件夹：" + count + "个");
            }
            sb.AppendLine("扫描完毕");
            this.txtInfo.Text = sb.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(!MsgBox.Confirm("确定清理这些文件？")){
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("开始清理文件夹");
            int count = 0;
            if (list.Count > 0)
            {
                foreach (DataItem DataItem in list)
                {
                    DirectoryInfo dir = new DirectoryInfo(DataItem.Text);
                    DirectoryInfo[] dirlist = dir.GetDirectories();
                    if (dirlist.Length > 0)
                    {
                        for (int i = 0; i < dirlist.Length; i++)
                        {
                            Directory.Delete(dirlist[i].FullName, true);
                            sb.AppendLine(Path.GetFileName(dirlist[i].Name));
                        }

                        count++;
                    }
                }
                sb.AppendLine("共清理文件夹：" + count + "个");
            }
            sb.AppendLine("清理完毕");
            this.txtInfo.Text = sb.ToString();
        }
    }
}
