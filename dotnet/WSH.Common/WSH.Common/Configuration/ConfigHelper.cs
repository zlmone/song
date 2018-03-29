using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WSH.Common.Helper;

namespace WSH.Common.Configuration
{
    public class ConfigHelper
    {
        public static string GetDefaultConfigName(string name) {
            return Path.Combine(PathHelper.GetConfigPath, name);
        }
        /// <summary>
        /// 获取配置文件地址
        /// </summary>
        /// <param name="fileName">配置文件名，不包含后缀</param>
        /// <returns></returns>
        public static string GetConfigFileName(string name, string path = null)
        {
            string[] exts = new string[] { ".config", ".xml", ".cfg" };
            string configPath = Path.Combine((string.IsNullOrEmpty(path) ? PathHelper.GetConfigPath : path), name);
            foreach (string ext in exts)
            {
                string fileName = configPath + ext;
                if (File.Exists(fileName))
                {
                    return fileName;
                }
            }
            return null;
        }
        /// <summary>
        /// 从配置集合里面获取指定名字的配置，没有获取默认名称配置，默认没有获取第一个配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configs"></param>
        /// <param name="name"></param>
        /// <param name="defaultName"></param>
        /// <returns></returns>
        public static T GetConfigItem<T>(Dictionary<string, T> configs, string name, string defaultName)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = defaultName;
            }
            if (string.IsNullOrEmpty(name) || !configs.ContainsKey(name))
            {
                foreach (string key in configs.Keys)
                {
                    return configs[key];
                }
                return default(T);
            }
            return configs[name];
        }
    }
}
