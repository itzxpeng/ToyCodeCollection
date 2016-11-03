using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTest
{
    public class MemoryCacheImpl<T>
    {
        private const string instanceName = "MemoryCache";
        private object obj = new object();
        private static Dictionary<string, ICacheManager<T>> cacheManagerDict = new Dictionary<string, ICacheManager<T>>();
        private ICacheManager<T> cacheManager;

        public MemoryCacheImpl(string cacheName, ExpirationMode expirationMode, TimeSpan timeout)
        {
            if (MemoryCacheImpl<T>.cacheManagerDict != null)
            {
                if (cacheManagerDict.ContainsKey(cacheName))
                    cacheManager = cacheManagerDict[cacheName];
                else
                {
                    cacheManager = GetCacheManager(cacheName, expirationMode, timeout);
                }
            }
        }

        private ICacheManager<T> GetCacheManager(string cacheName, ExpirationMode expirationMode, TimeSpan timeout)
        {
            lock (obj)
            {
                var cache = CacheFactory.Build<T>(cacheName,
                                settings =>
                                {
                                    settings
                                        .WithSystemRuntimeCacheHandle(instanceName)
                                        .EnableStatistics()
                                        .EnablePerformanceCounters()
                                        .WithExpiration(expirationMode, timeout);
                                });

                if (!cacheManagerDict.Keys.Contains(cacheName))
                {
                    cacheManagerDict.Add(cacheName, cache);
                    return cache;
                }
                else
                {
                    return cacheManagerDict[cacheName];
                }
            }
        }

        public void Put(string key, string region, T value)
        {
            try
            {
                cacheManager.Put(key, value, region);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Get(string key, string region)
        {
            try
            {
                T t = cacheManager.Get(key, region);
                return t;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(string key, string region, T value)
        {
            try
            {
                cacheManager.Add(key, value, region);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(string key, string region, T value)
        {
            try
            {
                T outT;
                bool isUpdate = cacheManager.TryUpdate(key, region, (t) => value, out outT);
                return isUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T AddOrUpdate(string key, string region, T value)
        {
            try
            {
                T result = cacheManager.AddOrUpdate(key, region, value, (t) => value, 50);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Clear()
        {
            try
            {
                cacheManager.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearRegion(string region)
        {
            try
            {
                cacheManager.ClearRegion(region);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(string key, string region)
        {
            try
            {
                cacheManager.Remove(key, region);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Expire(string key, string region, ExpirationMode expirationMode, TimeSpan timeout)
        {
            try
            {
                cacheManager.Expire(key, region, expirationMode, timeout);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
