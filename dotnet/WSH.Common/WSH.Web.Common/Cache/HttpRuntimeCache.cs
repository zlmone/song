#region Using

using System;
using System.Web;
using System.Web.Caching;
using WSH.Common;
using WSH.Common.Cache;

#endregion

namespace WSH.Web.Common.Cache
{
    /// <summary>
    /// Uses the HttpRuntime.Cache
    /// </summary>
    public class HttpRuntimeCache<T> : ICache<T>
    {
        /// <summary>
        /// 根据KEY得到缓存
        /// </summary>
        /// <param name="itemKey">KEY</param>
        /// <returns></returns>
        public T Get(string itemKey)
        {
            return (T)HttpRuntime.Cache.Get(itemKey);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="itemKey"></param>
        public void Remove(string itemKey)
        {
            HttpRuntime.Cache.Remove(itemKey);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="itemKey">KEY</param>
        /// <param name="value">VALUE</param>
        /// <param name="cacheDurationInSeconds">缓存秒数</param>
        public void Insert(string itemKey, T value, int cacheDurationInSeconds)
        {
            HttpRuntime.Cache.Insert(itemKey, value, null, DateTime.Now.AddSeconds(cacheDurationInSeconds),
                                     System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 写入缓存(永不过期)
        /// </summary>
        /// <param name="itemKey">KEY</param>
        /// <param name="value">VALUE</param>
        public void Insert(string itemKey, T value)
        {
            HttpRuntime.Cache.Insert(itemKey, value);
        }
    }
}