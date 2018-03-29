using System;
using System.Collections.Generic;
using System.Web;

namespace Song.WebSite.View.page
{
    /// <summary>
    /// 该类里面所有单位均为px
    /// </summary>
    public class CanvasConfig
    {
        /// <summary>
        /// 获取图片热点区域
        /// </summary>
        public string GetMapArea(int left, int top, int width, int height, string title)
        {
            int right = left + width;
            int bottom = top + height;
            return string.Format("<area shape=\"rect\" coords=\"{0},{1},{2},{3}\" href=\"javascript:void(0)\" alt=\"{4}\" title=\"{5}\">", left, top, right, bottom, title, title);
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        public string Truncate(string str) { 
            if(str.Length>=this.TextLength){
                return str.Substring(0, this.TextLength) + "...";
            }
            return str;
        }
        #region 画布的方法
        public void Init() { 
            //计算画布的宽度
            int w = (padding*2)+axisWidth+axisStepSpace+((itemWidth+stepSpace)*step);
            //去除最后一个多余的边距
          //  w = w - stepSpace;
            this.Width = w;
            //计算画布的高度
            int h = (padding * 2)+ ((itemHeight+textHeight + trackSpace) * track);
            //去除最后一个多余的边距
            h = h - trackSpace;
            this.Height = h;
        }
        #endregion
        

        #region 动态属性
        /// <summary>
        /// 中心轴的left
        /// </summary>
        public int AxisLeft
        {
            get { return padding; }
        }
        /// <summary>
        /// 中心轴的right
        /// </summary>
        public int AxisRight
        {
            get { return AxisLeft+AxisWidth; }
        }
        /// <summary>
        /// 中心轴的top
        /// </summary>
        public int AxisTop {
            get { return YCenter-(AxisHeight/2); }
        }
        /// <summary>
        /// 每个步长的高度（包括边距）
        /// </summary>
        public int ItemAllHeight {
            get { return this.ItemHeight + this.TextHeight + this.TrackSpace; }
        }
        /// <summary>
        /// 每个步长的宽度（包括边距）
        /// </summary>
        public int ItemAllWidth {
            get { return this.ItemWidth + this.StepSpace; }
        }
        #endregion

        #region 画布的属性
        private int textLength=5;
        /// <summary>
        /// 截取的字符长度
        /// </summary>
        public int TextLength
        {
            get { return textLength; }
            set { textLength = value; }
        }
        private int padding=15;
        /// <summary>
        /// 画布的Padding
        /// </summary>
        public int Padding
        {
            get { return padding; }
            set { padding = value; }
        }
        private int width;
        /// <summary>
        /// 画布的宽度
        /// </summary>
        public int Width
        {
            get { return width; }
            set { 
                width = value;
                //计算画布的y轴中心
                this.xCenter = width / 2;
            }
        }
        private int height;
        /// <summary>
        /// 画布的高度
        /// </summary>
        public int Height
        {
            get { return height; }
            set { 
                height = value; 
                //计算画布的y轴中心
                this.yCenter = height / 2;
            }
        }
        private int xCenter;
        /// <summary>
        /// 画布的x轴中心
        /// </summary>
        public int XCenter
        {
            get { return xCenter; }
        }
        private int yCenter;
        /// <summary>
        /// 画布的y轴中心
        /// </summary>
        public int YCenter
        {
            get { return yCenter; }
        }
        private int step;
        /// <summary>
        /// 步长,最大10步
        /// </summary>
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        private int track;
        /// <summary>
        /// 轨迹数量
        /// </summary>
        public int Track
        {
            get { return track; }
            set { track = value; }
        }
        private int axisWidth=50;
        /// <summary>
        /// 中心轴的宽度
        /// </summary>
        public int AxisWidth
        {
            get { return axisWidth; }
            set { axisWidth = value; }
        }
        private int axisHeight=50;
        /// <summary>
        /// 中心轴的高度
        /// </summary>
        public int AxisHeight
        {
            get { return axisHeight; }
            set { axisHeight = value; }
        }
        private int axisStepSpace=50;
        /// <summary>
        /// 中心轴和步长的距离
        /// </summary>
        public int AxisStepSpace
        {
            get { return axisStepSpace; }
            set { axisStepSpace = value; }
        }
        private int stepSpace=50;
        /// <summary>
        /// 步长和步长之间的距离
        /// </summary>
        public int StepSpace
        {
            get { return stepSpace; }
            set { stepSpace = value; }
        }
        private int trackSpace = 30;
        /// <summary>
        /// 轨迹和轨迹之间的距离
        /// </summary>
        public int TrackSpace
        {
            get { return trackSpace; }
            set { trackSpace = value; }
        }
        private int itemWidth=25;
        /// <summary>
        /// 每一步步长的宽度
        /// </summary>
        public int ItemWidth
        {
            get { return itemWidth; }
            set { itemWidth = value; }
        }
        private int itemHeight=25;
        /// <summary>
        /// 每一步步长的高度
        /// </summary>
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        private int textHeight=12;
        /// <summary>
        /// 每一步步长的文字说明
        /// </summary>
        public int TextHeight
        {
            get { return textHeight; }
            set { textHeight = value; }
        }
        #endregion
    }
}