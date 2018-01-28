using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConventionMapper.Generator
{
    /// <summary>
    /// Class of mapping generation
    /// </summary>
    public struct MappingGenerator
    {
        /// <summary>
        /// The namespace that will be used in the generated classes
        /// </summary>
        public string GeneratedNamespace { get; set; }
        /// <summary>
        /// Group destination that will be used to compose some names in the generated classes
        /// </summary>
        public string DestinationGroup { get; set; }
        /// <summary>
        /// Enumerable the pairs for conversion
        /// </summary>
        public IEnumerable<KeyValuePair<Type, Type>> Pairs { get; set; }
        /// <summary>
        /// Accessibility level for the classes that will be generated (public or interna)
        /// </summary>
        public AcessibilityLevelEnum Acessibility { get; set; }

        private static string GetDestinationGroup(string generatedNameSpace)
            => generatedNameSpace.Substring(generatedNameSpace.LastIndexOf('.') + 1);

        private static bool inheritanceCriteria(Type x, Type sourceTypeBase)
            => sourceTypeBase.IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface && !x.IsEnum;

        private static bool SuffixCritteria(Type source, Type destination, string suffixCriteria)
            => source.Name + suffixCriteria == destination.Name;

        /// <summary>
        /// Returns a mapping generator based on the generatednamespace and the accessibility choosed.
        /// DestinationGroup is inferred from the namespace
        /// The source Assembly from <typeparamref name="SourceTypeBase"/>
        /// The destination assembly from <typeparamref name="DestinationTypeBase"/>.
        /// The source classes from base class <typeparamref name="SourceTypeBase"/>
        /// The destination classes from base class <typeparamref name="DestinationTypeBase"/>
        /// The association between source and type are made by the default suffix criteria (sourceClassName + suffix = destinationClassName)
        /// The suffix are inferred by the DestinationGroup
        /// </summary>
        /// <typeparam name="SourceTypeBase">Base class for all the source types</typeparam>
        /// <typeparam name="DestinationTypeBase">Base class for all the destination types</typeparam>
        /// <param name="generatedNameSpace">Namespace to be used in the generated classes</param>
        /// <param name="acessibility">public or internal</param>
        /// <returns>The mapping generator</returns>
        public static MappingGenerator Create<SourceTypeBase, DestinationTypeBase>(string generatedNameSpace, AcessibilityLevelEnum acessibility = AcessibilityLevelEnum.@public)
        {
            var destinationGroup = GetDestinationGroup(generatedNameSpace);
            return Create<SourceTypeBase, DestinationTypeBase>(typeof(SourceTypeBase).Assembly, typeof(DestinationTypeBase).Assembly,
                           generatedNameSpace, destinationGroup, acessibility);
        }

        /// <summary>
        /// Returns a mapping generator based on the generatednamespace and the accessibility choosed.
        /// The source Assembly from <typeparamref name="SourceTypeBase"/>
        /// The destination assembly from <typeparamref name="DestinationTypeBase"/>.
        /// The source classes from base class <typeparamref name="SourceTypeBase"/>
        /// The destination classes from base class <typeparamref name="DestinationTypeBase"/>
        /// The association between source and type are made by the default suffix criteria (sourceClassName + suffix = destinationClassName)
        /// The suffix are inferred by the DestinationGroup
        /// </summary>
        /// <typeparam name="SourceTypeBase">Base class for all the source types</typeparam>
        /// <typeparam name="DestinationTypeBase">Base class for all the destination types</typeparam>
        /// <param name="generatedNameSpace">Namespace to be used in the generated classes</param>
        /// <param name="destinationGroup">DestinationGroup to be used</param>
        /// <param name="acessibility">public or internal</param>
        /// <returns>The mapping generator</returns>
        public static MappingGenerator Create<SourceTypeBase, DestinationTypeBase>(string generatedNameSpace, string destinationGroup, AcessibilityLevelEnum acessibility = AcessibilityLevelEnum.@public)
            => Create<SourceTypeBase, DestinationTypeBase>(typeof(SourceTypeBase).Assembly, typeof(DestinationTypeBase).Assembly,
                generatedNameSpace, destinationGroup, acessibility);

        /// <summary>
        /// Returns a mapping generator based on the generatednamespace and the accessibility choosed.
        /// The source classes from base class <typeparamref name="SourceTypeBase"/>
        /// The destination classes from base class <typeparamref name="DestinationTypeBase"/>
        /// The association between source and type are made by the default suffix criteria (sourceClassName + suffix = destinationClassName)
        /// The suffix are inferred by the DestinationGroup
        /// </summary>
        /// <typeparam name="SourceTypeBase">Base class for all the source types</typeparam>
        /// <typeparam name="DestinationTypeBase">Base class for all the destination types</typeparam>
        /// <param name="sourceAssembly">Assembly from where the source types are obtained</param>
        /// <param name="destinationAssembly">Assembly from where the destination types are obtained</param>
        /// <param name="generatedNameSpace">Namespace to be used in the generated classes</param>
        /// <param name="destinationGroup">DestinationGroup to be used</param>
        /// <param name="acessibility">public or internal</param>
        /// <returns>The mapping generator</returns>
        public static MappingGenerator Create<SourceTypeBase, DestinationTypeBase>(
                Assembly sourceAssembly, Assembly destinationAssembly,
                string generatedNameSpace, string destinationGroup, AcessibilityLevelEnum acessibility = AcessibilityLevelEnum.@public)
            => Create<SourceTypeBase, DestinationTypeBase>(sourceAssembly, destinationAssembly,
                generatedNameSpace, destinationGroup, destinationGroup, acessibility);

        /// <summary>
        /// Returns a mapping generator based on the generatednamespace and the accessibility choosed.
        /// The source classes from base class <typeparamref name="SourceTypeBase"/>
        /// The destination classes from base class <typeparamref name="DestinationTypeBase"/>
        /// The association between source and type are made by the default suffix criteria (sourceClassName + suffixCritteria = destinationClassName)
        /// </summary>
        /// <typeparam name="SourceTypeBase">Base class for all the source types</typeparam>
        /// <typeparam name="DestinationTypeBase">Base class for all the destination types</typeparam>
        /// <param name="sourceAssembly">Assembly from where the source types are obtained</param>
        /// <param name="destinationAssembly">Assembly from where the destination types are obtained</param>
        /// <param name="suffixCriteria">Suffix to be used by the suffix criteria</param>
        /// <param name="generatedNameSpace">Namespace to be used in the generated classes</param>
        /// <param name="destinationGroup">DestinationGroup to be used</param>
        /// <param name="acessibility">public or internal</param>
        /// <returns>The mapping generator</returns>
        public static MappingGenerator Create<SourceTypeBase, DestinationTypeBase>(
                Assembly sourceAssembly, Assembly destinationAssembly, string suffixCriteria,
                string generatedNameSpace, string destinationGroup, AcessibilityLevelEnum acessibility = AcessibilityLevelEnum.@public)
            => Create<SourceTypeBase, DestinationTypeBase>(sourceAssembly, destinationAssembly,
                (s, d) => SuffixCritteria(s, d, suffixCriteria), generatedNameSpace, destinationGroup, acessibility);


        public static MappingGenerator Create<SourceTypeBase, DestinationTypeBase>(
                Assembly sourceAssembly, Assembly destinationAssembly, Func<Type, Type, bool> joinCondition,
                string generatedNameSpace, string destinationGroup, AcessibilityLevelEnum acessibility = AcessibilityLevelEnum.@public)
            => Create(sourceAssembly, typeof(SourceTypeBase),
                destinationAssembly, typeof(DestinationTypeBase),
                joinCondition, generatedNameSpace, destinationGroup, acessibility);

        public static MappingGenerator Create(Assembly sourceAssembly, Type sourceTypeBase,
                Assembly destinationAssembly, Type destinationTypeBase, Func<Type, Type, bool> joinCondition,
                string generatedNameSpace, string destinationGroup, AcessibilityLevelEnum acessibility = AcessibilityLevelEnum.@public)
            => Create(sourceAssembly, x => inheritanceCriteria(x, sourceTypeBase),
                destinationAssembly, x => inheritanceCriteria(x, destinationTypeBase),
                joinCondition, generatedNameSpace, destinationGroup, acessibility);

        public static MappingGenerator Create(Assembly sourceAssembly, Func<Type, bool> sourceCondition,
            Assembly destinationAssembly, Func<Type, bool> destinationCondition, Func<Type, Type, bool> joinCondition,
            string generatedNameSpace, string destinationGroup, AcessibilityLevelEnum acessibility = AcessibilityLevelEnum.@public)
                => Create(sourceAssembly.GetTypes().Where(sourceCondition),
                        destinationAssembly.GetTypes().Where(destinationCondition),
                        joinCondition, generatedNameSpace, destinationGroup, acessibility);

        public static MappingGenerator Create(IEnumerable<Type> source,
            IEnumerable<Type> destination, Func<Type, Type, bool> joinCondition,
            string generatedNameSpace, string destinationGroup, AcessibilityLevelEnum acessibility = AcessibilityLevelEnum.@public)
        {
            var join = source.Join(destination,
                        s => true, d => true, (s, d) => new KeyValuePair<Type, Type>(s, d));
             var pairs = join.Where(x => joinCondition(x.Key, x.Value));

            return new MappingGenerator()
            {
                GeneratedNamespace = generatedNameSpace,
                Acessibility = acessibility,
                DestinationGroup = destinationGroup,
                Pairs = pairs
            };
        }

        public MappingGenerator GetReverse(string generatedNameSpace, AcessibilityLevelEnum? acessibility = null)
            => GetReverse(generatedNameSpace, GetDestinationGroup(generatedNameSpace), acessibility);

        public MappingGenerator GetReverse(string generatedNameSpace, string newDestinationGroup, AcessibilityLevelEnum? acessibility = null)
        {
            return new MappingGenerator()
            {
                GeneratedNamespace = generatedNameSpace,
                DestinationGroup = newDestinationGroup ?? GetDestinationGroup(generatedNameSpace),
                Acessibility = acessibility == null ? Acessibility : acessibility.Value,
                Pairs = Pairs.Select(x => new KeyValuePair<Type, Type>(x.Value, x.Key))
            };
        }

        public string Generate()
        {
            var generator = new BaseMappingGenerator(this);
            var result = generator.OutputDirectory;
            generator.TransformText();

            return result;
        }
    }
}
