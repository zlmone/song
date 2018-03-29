using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common.Cache
{
    public class MemoryCache<T> : ICache<T>
    {
        /// <summary>
        /// 定义缓存字典
        /// </summary>
        private readonly static Dictionary<string, T> cache = new Dictionary<string, T>();
        public T Get(string key)
        {
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            return default(T);
        }

        public void Remove(string key)
        {
            if (cache.ContainsKey(key))
            {
                cache.Remove(key);
            }
        }

        public void Insert(string key, T value, int cacheDurationInSeconds)
        {
            this.Insert(key,value);
        }

        public void Insert(string key, T value)
        {
            if (cache.ContainsKey(key))
            {
                cache[key] = value;
            }else{
                cache.Add(key, value);
            }
        }
    }
}
