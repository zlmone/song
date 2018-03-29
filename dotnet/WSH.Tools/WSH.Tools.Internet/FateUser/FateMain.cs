using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using WSH.Tools.Internet.InternetFate.Model;
using WSH.Tools.Internet.InternetFate.Manager;
using WSH.Options.Common;
using WSH.Windows.Common;
using System.IO;
using WSH.Common.Http;

namespace WSH.Tools.Internet.InternetFate
{
    public partial class FateMain : Form
    {
        public FateMain()
        {
            InitializeComponent();
        }
        public bool IsSearch = false;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FateHomeRequest request = new FateHomeRequest();
                request.VisitParser();
                MsgBox.Alert("请求成功");
            }
            catch (Exception ex)
            {
                MsgBox.Alert("请求失败，错误信息：" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string page = this.txtPage.Text.Trim();
            string key = this.txtKey.Text.Trim();
            try
            {
                this.lbPbText.Text = "搜索开始...";
                FateSearchRequest request = new FateSearchRequest();
                request.KeyWord = key;
                this.IsSearch = true;
                this.btnSearch.Enabled = false;
                this.btnPause.Enabled = true;
                Application.DoEvents();
                int pageIndex = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
                Result result = request.SearchPage(pageIndex);
                if (result.IsSuccess && request.PageCount > pageIndex)
                {
                    //开启自动搜索剩下页
                    this.progressBar1.Maximum = request.PageCount;
                    this.progressBar1.Value = pageIndex;
                    this.lbPbText.Text = string.Format("{0}/{1}", pageIndex, request.PageCount);
                    Application.DoEvents();
                    pageIndex++;
                    for (int i = pageIndex; i <= request.PageCount; i++)
                    {
                        if (IsSearch == false)
                        {
                            this.btnSearch.Enabled = true;
                            this.btnPause.Enabled = false;
                            break;
                        }
                        result = request.SearchPage(pageIndex);
                        if (!result.IsSuccess)
                        {
                            throw new Exception(result.Msg);
                        }
                        else
                        {
                            pageIndex++;
                            this.txtPage.Text = pageIndex.ToString();
                            this.progressBar1.Value = pageIndex;
                            this.lbPbText.Text = string.Format("{0}/{1}", pageIndex, request.PageCount);
                            Application.DoEvents();
                        }
                    }
                }
                this.lbPbText.Text = "搜索完成";
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                this.lbPbText.Text = "搜索失败，错误信息：" + ex.Message;
                this.btnSearch.Enabled = true;
                this.btnPause.Enabled = false;
            }
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            this.IsSearch = false;
            this.btnSearch.Enabled = true;
            this.btnPause.Enabled = false;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;
            if (MsgBox.Confirm("确定要同步图片到本地文件夹？"))
            {
                try
                {
                    string path = Dialog.GetFolder();
                    if (!string.IsNullOrEmpty(path))
                    {
                        IList<FateUserInfo> users = FateUserInfoManager.GetUserList();
                        if (users != null && users.Count > 0)
                        {
                            int total = users.Count;
                            this.progressSync.Maximum = total;
                            this.progressSync.Value = 0;
                            for (int i = 0; i < users.Count; i++)
                            {
                                FateUserInfo user = users[i];
                                string fileUrl = user.HeadFileName;
                                string ext = Path.GetExtension(fileUrl);
                                string newFileName = user.UserCode + ext;
                                string saveFileName = Path.Combine(path, newFileName);
                                if (!File.Exists(saveFileName))
                                {
                                    HttpDownload download = new HttpDownload(fileUrl, saveFileName);
                                    download.Download();
                                    this.progressSync.Value++;
                                    Application.DoEvents();
                                }
                            }
                            MsgBox.Alert("同步完成");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.Alert("同步失败，错误信息：" + ex.Message);
                }
            }
            this.btnSync.Enabled = true;
            
        }
    }
}
