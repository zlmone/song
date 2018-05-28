package song.common.cache;import java.util.concurrent.ConcurrentHashMap;/** * description: * author:          song * createDate:      2017/10/21 */public class MemoryCacheManager implements ICache {    private static ConcurrentHashMap<String, CacheValue> cacheContainer = new ConcurrentHashMap<String, CacheValue>();    public void set(String key, Object value, long expireTime) {        CacheValue cacheValue = new CacheValue(value);        if (expireTime > 0) {            //设置失效时间            long time = System.currentTimeMillis() + expireTime * 1000;            cacheValue.setExpireTime(time);        }        cacheContainer.put(key, cacheValue);    }    public void set(String key, Object value) {        set(key, value, 0);    }    public Object get(String key) {        CacheValue value = cacheContainer.get(key);        //判断过期时间        if (value != null) {            long et = value.getExpireTime();            if (et <= 0) {                //未设置过期时间，则直接返回value                return value.getValue();            } else {                long now = System.currentTimeMillis();                if (now <= et) {                    return value.getValue();                } else {                    //过期清楚缓存数据                    cacheContainer.remove(key);                }            }        }        return null;    }    public void remove(String key) {        if (cacheContainer.containsKey(key)) {            cacheContainer.remove(key);        }    }    public void clear() {        cacheContainer.clear();    }    public boolean contains(String key) {        return cacheContainer.containsKey(key);    }}