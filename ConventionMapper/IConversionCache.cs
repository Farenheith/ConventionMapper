using System;
using System.Collections.Generic;
using System.Text;

namespace ConventionMapper
{
    public interface IConversionCache
    {
        bool DoCache<TDestination>(object source, out TDestination destination) where TDestination : class, new();
        bool GetCache<TDestination>(object source, out TDestination cached);
        void Clear();
    }
}
