using System;
using System.Web.Caching;

namespace HerefordSecuritiesLtd.Services
{
    public static class CachingService
    {
        public static Cache Cache = new Cache();

        public static bool IsActive
        {
            // todo set Cache.IsActive in config
            get { return true; }
        }

        public static T GetFromCache<T>(string key) where T : class
        {
            if (IsActive && HasKey(key))
            {
                return Cache.Get(key) as T;
            }
            return null;
        }

        public static void InsertToCache<T>(string key, T itemToCache)
        {
            if (!IsActive) return;
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