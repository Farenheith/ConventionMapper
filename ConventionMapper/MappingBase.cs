using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

namespace ConventionMapper
{
    public abstract class MappingBase
    {
        private readonly IConversionCache cache;
        private Dictionary<CacheKey, object> ChildMappers { get; } = new ConversionCache();
        private bool destroyCache = false;

        public MappingBase(IConversionCache _cache) => cache = _cache;
        public MappingBase() : this(new ConversionCache()) => destroyCache = true;

        protected TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class, new()
            where TDestination : class, new()
        {
            if (!cache.DoCache(source, out TDestination destination))
                destination = (this as IMapping<TSource, TDestination>).Convert(source, destination);

            return destination;
        }
        /// <summary>
        /// A virtual method with the purpose to be overriten in a partial class
        /// if you need to do any custom treatment at a mapped entity
        /// </summary>
        /// <typeparam name="TEntity">The type of the resultant entity</typeparam>
        /// <param name="result">The resultant entity</param>
        /// <returns>It must return the same entity passed by parameter</returns>
        protected virtual TEntity TreatResult<TEntity>(TEntity result) where TEntity : class, new() => result;

        /// <summary>
        /// Map the given IEnumerable to a ICollection<<typeparamref name="TModel"/>>
        /// All elements in the given list must be convertible to TModel by mapping
        /// Cache is used by this method to avoid cyclical references
        /// </summary>
        /// <typeparam name="TModel">The type os model expected to be the collection Item</typeparam>
        /// <param name="list">The enumerable of source objects</param>
        /// <returns>A collection os <typeparamref name="TModel"/></returns>
        protected ICollection<TModel> Get<TModel>(IEnumerable list) where TModel: class, new()
        {
            if (list == null)
                return null;

            if (cache.DoCache(list, out List<TModel> result))
                return result;
            foreach (var model in GetEnum<TModel>(list))
                result.Add(model);

            if (destroyCache) cache.Clear();

            return result;
        }

        private IEnumerable<TModel> GetEnum<TModel>(IEnumerable list) where TModel : class, new()
        {
            foreach (var obj in list)
                yield return InternalGet<TModel>(obj);
        }

        /// <summary>
        /// Retunrs a mapped instance of <typeparamref name="TModel"/>, base on the source object
        /// This method uses cache to avoid cyclical references
        /// </summary>
        /// <typeparam name="TModel">The type of the resultant entity</typeparam>
        /// <param name="source">Given source object</param>
        /// <returns>The resultant entity from the mapping</returns>
        protected TModel Get<TModel>(object source) where TModel : class, new()
        {
            var result = InternalGet<TModel>(source);

            if (destroyCache)
                cache.Clear();
            return result;
        }

        private TModel InternalGet<TModel>(object modelOrign) where TModel : class, new()
        {
            if (modelOrign == null)
                return null;
            if (cache.DoCache(modelOrign, out TModel result))
                return result;

            var mapping = GetMappers<TModel>(modelOrign.GetType(), cache);
            typeof(IMapping<,>).GetGenTypeMethod("Convert", modelOrign.GetType(), typeof(TModel))
                .Invoke(mapping, new object[] {modelOrign, result});
            return result;
        }

        private object GetMappers<TModel>(Type sourceType, IConversionCache cache) where TModel : class, new()
        {
            var destinationType = typeof(TModel);
            var cacheKey = new CacheKey(sourceType, destinationType);
            if (!ChildMappers.TryGetValue(cacheKey, out var mapper))
                ChildMappers[cacheKey] = mapper = Mapper.Get<TModel>(sourceType, cache);
            return mapper;
        }
    }
}
