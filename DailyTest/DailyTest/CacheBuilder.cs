using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTest
{
    public class CacheBuilder<T>
    {

        public static ICacheManager<T> CreateMemoryWithRedis(string InstanceName, int database)
        {
            var cache = CacheFactory.Build<T>(InstanceName, setting =>
            {
                setting.WithSystemRuntimeCacheHandle(InstanceName)
                        .And
                        .WithRedisConfiguration("redis", config =>
                        {
                            config.WithAllowAdmin()
                                .WithDatabase(database)
                                .WithEndpoint("localhost", 6379)
                                .WithAllowAdmin()
                                .WithPassword("")
                                .WithSsl();
                        })
                        .WithMaxRetries(100)
                        .WithRetryTimeout(50)
                        .WithRedisBackplane("redis")
                        .WithRedisCacheHandle("redis", true);
            });
            return cache;
        }

        public static ICacheManager<T> CreateMemory(string InstanceName)
        {
            var cache = CacheFactory.Build<T>(InstanceName, setting =>
            {
                setting.WithSystemRuntimeCacheHandle(InstanceName).EnableStatistics().EnablePerformanceCounters().WithExpiration(ExpirationMode.Absolute, TimeSpan.FromDays(1));
            });
            return cache;
        }
    }
}
