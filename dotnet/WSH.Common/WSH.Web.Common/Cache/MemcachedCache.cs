using System;
using WSH.Common;
using WSH.Common.Cache;


namespace WSH.Web.Common.Cache
{
    public class MemcachedCache<T> : ICache<T>
    {
        public T Get(string itemKey)
        {
            //try
            //{
            //    return DistCache.Get(itemKey);
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
            return default(T);
        }

        public void Remove(string itemKey)
        {
            //try
            //{
            //    DistCache.Remove(itemKey);
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }

        public void Insert(string itemKey, T value, int cacheDurationInSeconds)
        {
            //try
            //{
            //    DistCache.Add(itemKey, value, cacheDurationInSeconds * 1000);
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }

        public void Insert(string itemKey, T value)
        {
            //try
            //{
            //    DistCache.Add(itemKey, value);
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }
    }
}
