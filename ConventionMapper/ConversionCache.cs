using System;
using System.Collections.Generic;
using System.Text;

namespace ConventionMapper
{
    internal class ConversionCache : Dictionary<CacheKey, object>, IConversionCache
    {
        bool DoCache<TDestination>(object source, out TDestination destination) where TDestination : class, new()
        {
            var key = new CacheKey(source, typeof(TDestination));

            if (this.TryGetValue(key, out var thisd))
            {
                destination = (TDestination)thisd;
                return true;
            }
            this[key] = destination = new TDestination();
            return false;
        }

        bool IConversionCache.DoCache<TDestination>(object source, out TDestination destination)
            => this.DoCache(source, out destination);

        bool GetCache<TDestination>(object source, out TDestination cached)
        {
            if (this.TryGetValue(new CacheKey(source, typeof(TDestination)), out var objCached))
            {
                cached = (TDestination)objCached;
                return true;
            }
            else
                cached = default(TDestination);

            return false;
        }

        bool IConversionCache.GetCache<TDestination>(object source, out TDestination cached)
            => this.GetCache(source, out cached);
    }
}
