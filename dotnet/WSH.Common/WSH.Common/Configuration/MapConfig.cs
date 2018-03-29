using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;

namespace WSH.Common.Configuration
{
    /// <summary>
    /// 映射类配置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MapConfig<T> : XmlSerializeHelper<T> where T : class,new()
    {
        public MapConfig() { }
        public MapConfig(string fileName)
        {
            this.FileName = fileName;
        }
        public MapConfig(string name, string path = null)
        {
            this.FileName = ConfigHelper.GetConfigFileName(name, path);
        }
    }
}
