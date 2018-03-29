using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.DataAccess.Dapper;
using System.ComponentModel;

namespace WSH.Tools.Internet.Movie.Model
{
    public enum LinkAddressType
    {
        [Description("网址")]
        Url = 1,
        [Description("图片")]
        Picture = 2,
        [Description("视频")]
        Video = 3,
        [Description("音频")]
        Voice = 4,
        [Description("文件")]
        Document=5
    }
    public class LinkAddressInfo
    {
        [Id(true)]
        public int LinkAddressId { get; set; }

        public string LinkAddress { get; set; }

        public string Title { get; set; }

        public int Hits { get; set; }

        public string Comment { get; set; }

        public LinkAddressType LinkType { get; set; }

        public DateTime CreateTime { get; set; }
    }
}

