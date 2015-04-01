using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Caching;

namespace LaptopsSystem.Web.Infrastructure.Cache
{
    public abstract class BaseCacheService
    {
        protected T Get<T>(string key, Func<T> getItem, int absoluteExpiration) where T:class
        {
            var item = HttpRuntime.Cache[key] as T;
            if (item == null)
            {
                item = getItem();
                HttpContext.Current.Cache.Add(key, item, null, DateTime.Now.AddSeconds(absoluteExpiration), TimeSpan.Zero, CacheItemPriority.Default, null);
            }
            return item;
        }

        protected void RemoveFromCache(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }
}