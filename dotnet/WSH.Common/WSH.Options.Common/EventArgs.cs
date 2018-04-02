using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class ProgressEventArgs
    {
        public decimal Rate
        {
            get
            {
                return Math.Round(Convert.ToDecimal((this.Value / this.Max) * 100), 1);
            }
        }
        private int max;

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
    public class DownloadEventArgs
    {
        /// <summary>
        /// 百分比
        /// </summary>
        public double Rate
        {
            get
            {
                if (this.DownloadSize <= 0 || this.TotalSize<=0)
                {
                    return 0;
                }
                return Math.Round(((double)this.DownloadSize / (double)this.TotalSize) * 100, 1);
            }
        }
        private long totalSize;
        /// <summary>
        /// 总大小
        /// </summary>
        public long TotalSize
        {
            get { return totalSize; }
            set { totalSize = value; }
        }
        private long downloadSize;
        /// <summary>
        /// 已经下载大小
        /// </summary>
        public long DownloadSize
        {
            get { return downloadSize; }
            set { downloadSize = value; }
        }
        private int speed;
        /// <summary>
        /// 下载速度
        /// </summary>
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
