using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common.Configuration;

namespace WSH.DataAccess.SongData.Config
{
    public class SongDataConfigManager
    {
        public static SongDataConfig Config;
        public static void Init(string fileName) {
            MapConfig<SongDataConfig> ser = new MapConfig<SongDataConfig>();
            ser.FileName = fileName;
            Config = ser.ReadEntity();
        }
        public static SongDataConfig Get() {
            return Config;
        }
    }
    public class SongDataConfig
    {
        /// <summary>
        /// 数据库连接信息配置
        /// </summary>
        public DbConnectionConfig DbConnectionConfig { get; set; }
    }
    public class DbConnectionConfig
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public WSH.Common.DataBaseType DbType { get; set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 数据库版本
        /// </summary>
        public string DbVersion { get; set; }

    }
}
