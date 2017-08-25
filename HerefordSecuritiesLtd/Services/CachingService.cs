using System;
using System.Runtime.Caching;

namespace HerefordSecuritiesLtd.Services
{
    public static class CachingService
    {
        private static ObjectCache cache = MemoryCache.Default;

        public static T GetFromCache<T>(string key) where T : class
        {
            var cachedItem = cache.Get(key);
            return cachedItem as T;
        }

        public static void AddToCache<T>(string key, T obj) where T : class
        {
            // todo set the expiration in config
            cache.Set(key, obj, DateTimeOffset.UtcNow.AddDays(30));
        }

        public static void RemoveFromCache(string key)
        {
            cache.Remove(key);
        }

        public static bool HasKey(string key)
        {
            return cache.Contains(key);
        }
    }
}