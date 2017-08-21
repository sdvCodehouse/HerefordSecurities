using System;
using System.Web.Caching;

namespace HerefordSecuritiesLtd.Services
{
    public static class CachingService
    {
        public static Cache Cache = new Cache();

        public static bool IsActive
        {
            get { return true; }
        }

        public static T GetFromCache<T>(string key) where T : class
        {
            return Cache.Get(key) as T;
        }

        public static void InsertToCache<T>(string key, T itemToCache)
        {
            Cache.Remove(key);
            // todo add expiry duration to config
            Cache.Insert(key, itemToCache, null, DateTime.UtcNow.AddDays(1), Cache.NoSlidingExpiration);
        }

        public static bool HasKey(string key)
        {
            return Cache[key] != null;
        }
    }
}