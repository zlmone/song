using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;
using WSH.Options.Common;

namespace WSH.Tools.Internet.MovieJSK
{
    public partial class JSK : Form
    {
        public JSK()
        {
            InitializeComponent();
        }
        
        private DataTable CreateDataTable()
        {
            DataTable dt = DataTableHelper.Create("标题", "页面地址", "下载地址","文件名", "图片", "观看次数", "评分", "错误信息");
            return dt;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = CreateDataTable();
            dt.Clear();
            JSKRequest request = new JSKRequest(dt);
             
            string number = this.txtNumber.Text.Trim();
            int current = number == "" ? 0 : Convert.ToInt32(number);
            this.btnSearch.Text = "搜索主页...";
            this.btnSearch.Enabled = false;
            this.checkBox1.Checked = false;
            Application.DoEvents();
            string max = this.txtMaxNumber.Text.Trim();
            int pageSize = max == "" ? 1 : Convert.ToInt32(max);
          
            if (current > pageSize)
            {
                pageSize = current;
            }
            
            bool isEnd = false;
            for (int i = (current > 1 ? current : 1); i <= pageSize; i++)
            {
                if (this.checkBox1.Checked)
                {
                    isEnd = true;
                    break;
                }
                this.txtNumber.Text = i.ToString();
                Application.DoEvents();

                Result result = request.Request(i.ToString());
                if (result.IsSuccess == false || string.IsNullOrWhiteSpace(result.Msg))
                {
                    isEnd = true;
                    break;
                }
                this.txtResultList.Text = TxtHelper.ToTextContent(dt);
                Application.DoEvents();
            }
            //开始搜索子页
            if (!isEnd)
            {
                this.btnSearch.Text = "搜索子页...";
                Application.DoEvents();
                request.RequestSubPage((send, args) =>
                {
                    this.txtNumber.Text = args.Value.ToString();
                    Application.DoEvents();
                });
                this.txtResultList.Text = TxtHelper.ToTextContent(dt);
                Application.DoEvents();
            }
            //还原
            this.btnSearch.Text = "搜索";
            this.btnSearch.Enabled = true;
            Application.DoEvents();
        }
    }
}
