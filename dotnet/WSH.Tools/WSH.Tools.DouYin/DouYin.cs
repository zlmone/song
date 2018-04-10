using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Tools.DouYin
{
   public  class DouYin
    {
        private string videoId;

        public string VideoId
        {
            get { return videoId; }
            set { videoId = value; }
        }
        private DateTime createTime;

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private string downloadUrl;

        public string DownloadUrl
        {
            get { return downloadUrl; }
            set { downloadUrl = value; }
        }
        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
    }
}
