using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;

namespace Song.WebSite.View.page
{
    public partial class Draw : System.Web.UI.Page
    {
        public string MapArea;
        public string ReportMapPage;
        public int  ReportMapPageCount;
        public List<string> MapAreaList=new List<string> ();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder page = new StringBuilder();
            ReportMapPageCount = 10;
            for (int i = 0; i < ReportMapPageCount; i++)
            {
                page.AppendLine("<div class=\"reportPageItem\">");
                page.AppendLine("<div class=\"reportPageLeft\">" + i + "-image</div>");
                page.AppendLine("<div class=\"reportPageRight\">");
                page.AppendLine("<table>");
                page.AppendLine("<th>名称</th><th>地址</th><th>路径</th>");
                for (int j = 0; j< 10; j++)
                {
                    page.AppendLine("<tr>");
                    page.AppendLine(string.Format("<td>{0}</td><td>{1}</td><td>{2}</td>",j*i,j*i,j*i));
                    page.AppendLine("</tr>");
                }
                page.AppendLine("</table>");
                page.AppendLine("</div>");
                page.AppendLine("<div class=\"reportPageClear\"></div>");
                page.AppendLine("</div>");
            }
            ReportMapPage = page.ToString();

             CreateReportInfo();
            
        }
        /// <summary>
        /// 创建有向图
        /// </summary>
        private void CreateReportInfo() {
            CanvasConfig c = new CanvasConfig();
            c.Step = 10;
            c.Track = 10;
            c.AxisHeight = 100;
            c.AxisWidth = 80;
            c.TrackSpace = 20;
            c.Init();
            //图片热点
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<map name=\"linkmap\">");
            //文字字体
            Font font = new Font("Tahoma", 8f);
            SolidBrush brush = new SolidBrush(Color.Black);
            //声明一个画布
            Bitmap bm = new Bitmap(c.Width, c.Height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            //画边框
            g.DrawRectangle(Pens.Black, 0, 0, c.Width - 1, c.Height - 1);
            //画出中心轴
            //g.DrawEllipse(Pens.Black, c.AxisLeft, c.AxisTop, c.AxisWidth, c.AxisHeight);
            System.Drawing.Image ellipse = System.Drawing.Image.FromFile(Server.MapPath("~/old/GDI/start.png"));
            g.DrawImage(ellipse, c.AxisLeft, c.AxisTop, c.AxisWidth, c.AxisHeight);
            //步长的开始距离
            int left = c.AxisRight + c.AxisStepSpace;
            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/old/GDI/to.jpg"));
            for (int i = 0; i < c.Track; i++)
            {
                int top = c.Padding;
                //循环画出右侧轨迹
                for (int j = 0; j < c.Step; j++)
                {
                    string title = "王松华";
                    //计算轨迹的中心位置
                    int itmeCenter = top + (c.ItemHeight / 2);
                    Pen p = new Pen(Color.Gray);
                    p.DashStyle = DashStyle.Solid;
                    p.EndCap = LineCap.ArrowAnchor;
                    p.Width = 3;
                    if (i == 0)
                    {
                        //画出轨迹和中心轴之间的连线
                        g.DrawLine(p, new Point(c.AxisRight, c.YCenter), new Point(left, itmeCenter));
                    }
                    else
                    {
                        //画出轨迹和轨迹的连线
                        g.DrawLine(p, new Point(left - c.StepSpace, itmeCenter), new Point(left, itmeCenter));
                    }
                    g.DrawImage(img, left, top, c.ItemWidth, c.ItemHeight);
                    //画出图片热点
                    sb.AppendLine(c.GetMapArea(left, top, c.ItemAllWidth, c.ItemAllHeight - c.TrackSpace + 3, title));
                    //画出页面说明文字
                    g.DrawString(c.Truncate(title), font, brush, left - 3, top + c.ItemHeight);
                    top += c.ItemAllHeight;
                }
                left += c.ItemAllWidth;
            }
            int a = c.AxisRight;
            //输出图像
            string imgurl = "~/old/GDI/img.png";
            bm.Save(Server.MapPath(imgurl), ImageFormat.Png);
            bm.Dispose();
            g.Dispose();

            sb.AppendLine("</map>");
            MapAreaList.Add(sb.ToString());
            this.MapArea = sb.ToString();

            System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
            image.ImageUrl = imgurl + "?";
            image.Width = c.Width;
            image.Height = c.Height;
            image.Attributes.Add("usemap", "#linkmap");
            imgWrap.Controls.Add(image);
        }
    }
}