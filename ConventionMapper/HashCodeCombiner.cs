using System;

namespace ConventionMapper
{
    internal static class HashCodeCombiner
    {
        internal static int Combine(object object1, object object2)
        {
            var h1 = object1.GetHashCode();
            var h2 = object2.GetHashCode();

            return ((h1 << 5) + h1) ^ h2;
        }
    }
}