using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConventionMapper
{
    public static class Mapper
    {
        private static readonly Dictionary<CacheKey, Type> mappings = new Dictionary<CacheKey, Type>();

        internal static MappingBase Get<TDestination>(Type source, IConversionCache cache) where TDestination : new()
            => Reflect.New<MappingBase>(GetMapperType<TDestination>(source), new object[] { cache });

        /// <summary>
        /// Returns an instance of the IMapping for <<typeparamref name="TSource"/>, <typeparamref name="TDestination"/>> loaded
        /// </summary>
        /// <typeparam name="TSource">The source class</typeparam>
        /// <typeparam name="TDestination">The destination class</typeparam>
        /// <returns>A instance of IMapping<<typeparamref name="TSource"/>, <typeparamref name="TDestination"/>></returns>
        public static IMapping<TSource, TDestination> Get<TSource, TDestination>() where TDestination : new() 
            => Reflect.New<IMapping<TSource, TDestination>>(GetMapperType<TSource, TDestination>());

        /// <summary>
        /// Map the source object to a instance of <typeparamref name="TDestination"/>
        /// </summary>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">source instance</param>
        /// <returns>A instance of <typeparamref name="TDestination"/></returns>
        public static TDestination Map<TDestination>(object source) where TDestination : new()
        {
            var type = source.GetType();
            var method = typeof(Mapper).GetGenMethod("PairMap", type, typeof(TDestination));

            return (TDestination)method.Invoke(null, new object[] { source });
        }

        /// <summary>
        /// Explicit convert a instance of <typeparamref name="TSource"/> to <typeparamref name="TDestination"/>
        /// This method is slight more performatic than Map because of lass use of Reflection
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">A instance of <typeparamref name="TSource"/></param>
        /// <returns>A instance of <typeparamref name="TDestination"/></returns>
        public static TDestination PairMap<TSource, TDestination>(TSource source) where TDestination : new()
        {
            var mappingType = GetMapperType<TDestination>(source.GetType());
            var mapping = mappingType.New<IMapping<TSource, TDestination>>();

            return mapping.Map(source);
        }

        #region MapperTypes loaders
        /// <summary>
        /// Load all instances of IMapping<,> in the assembly of the given Type
        /// </summary>
        /// <typeparam name="PivotType">Reference type from where the Aseembly is inferred</typeparam>
        public static void Load<PivotType>()
            => Load(typeof(PivotType));

        /// <summary>
        /// Load all instances of IMapping<,> in the assembly of the given Type
        /// </summary>
        /// <param name="PivotType">Reference type from where the Aseembly is inferred</typeparam>
        public static void Load(Type pivotType)
            => Load(pivotType.Assembly);

        /// <summary>
        /// Load all instances of IMapping<,> in the assembly informed
        /// </summary>
        /// <param name="assembly">The given assembly</param>
        public static void Load(Assembly assembly)
            => Load(assembly.GetTypes());

        /// <summary>
        /// Load all the instances of IMapping<,> in the given Type enumerable
        /// </summary>
        /// <param name="types">The given Type enumerable</param>
        public static void Load(IEnumerable<Type> types)
        {
            var mappers = types.Where(x => x.BaseType != null
                    && !x.IsAbstract
                    && typeof(MappingBase).IsAssignableFrom(x)
                    && x.GetInterfaces().Any(i => i.GetGenericTypeDefinition() == typeof(IMapping<,>)));
            
            foreach (var mapper in mappers)
            {
                var interfaces = mapper.GetInterfaces()
                                    .Where(i => i.GetGenericTypeDefinition() == typeof(IMapping<,>))
                                    .Select(i => i.GetGenericArguments());
                foreach (var i in interfaces)
                    mappings[new CacheKey(i[0], i[1])] = mapper;
            }
        }
        #endregion

        #region MapperType getters
        private static Type GetMapperType<TSource, TDestination>() where TDestination : new()
            => GetMapperType(typeof(TSource), typeof(TDestination));

        private static Type GetMapperType<TDestination>(Type source) where TDestination : new()
            => GetMapperType(source, typeof(TDestination));

        private static Type GetMapperType(Type source, Type destination)
        {
            var cacheKey = new CacheKey(source, destination);
            if (!mappings.TryGetValue(cacheKey, out var mappingType))
                throw new InvalidOperationException("There's no maper loaded for this conversion");

            return mappingType;
        }
        #endregion
    }
}
