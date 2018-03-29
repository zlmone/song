using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.Tools.Internet.Movie;
using WSH.Common.Helper;
using WSH.Options.Common;
using WSH.Tools.Internet.Movie.Request;

namespace WSH.Tools.Internet.Movie
{
    public partial class MovieMain : Form
    {
        public MovieMain()
        {
            InitializeComponent();
            this.txtUrl.Text = "UpY+fCpcIfsbipvM8+prXJvYinsPF0mWvyyXc1nujK8=";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtUrl.IsValid)
            {
                SetSearchButton("搜索中...", false);
                string url =CryptHelper.DecryptDES(this.txtUrl.Text.Trim());
                Movie365Request request = new Movie365Request();
                request.Url = url;
                List<string> linkUrls = new List<string>();
                List<string> childPages = request.GetChildPages(ref linkUrls);
                //是否搜索子页面
                if (this.checkSearchChild.Checked)
                {
                    AppendText(linkUrls);
                    if (childPages != null && childPages.Count > 0)
                    {
                        AppendText(childPages);
                        int i = 0;
                        foreach (string page in childPages)
                        {
                            i++;
                            SetSearchButton(string.Format("{0}/{1}", i, childPages.Count), false);
                            request.Url = page;
                            AppendText(request.Parse());
                        }
                    }
                }
                SetSearchButton("搜索", true);
            }
        }
        private void AppendText(List<string> texts)
        {
            if (texts != null)
            {
                texts.ForEach(o =>
                {
                    this.txtResultList.AppendText(o + "\n");
                });
            }
        }
        private void SetSearchButton(string text, bool enabled)
        {
            this.btnSearch.Text = text;
            this.btnSearch.Enabled = enabled;
            Application.DoEvents();
        }
    }
}
