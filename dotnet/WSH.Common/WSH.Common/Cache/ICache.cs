
namespace WSH.Common.Cache
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICache<T>
    {
        /// <summary>
        /// 根据KEY得到缓存
        /// </summary>
        /// <param name="itemKey">KEY</param>
        /// <returns></returns>
        T Get(string key);

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="itemKey"></param>
        void Remove(string key);

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="itemKey">KEY</param>
        /// <param name="value">VALUE</param>
        /// <param name="cacheDurationInSeconds">缓存秒数</param>
        void Insert(string key, T value, int cacheDurationInSeconds);

        /// <summary>
        /// 写入缓存(永不过期)
        /// </summary>
        /// <param name="itemKey">KEY</param>
        /// <param name="value">VALUE</param>
        void Insert(string key, T value);

    }
}