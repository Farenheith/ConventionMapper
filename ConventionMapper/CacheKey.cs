using System;
using System.Collections.Generic;
using System.Text;

namespace ConventionMapper
{
    internal struct CacheKey : IEquatable<CacheKey>
    {
        public static bool operator ==(CacheKey left, CacheKey right) => left.Equals(right);
        public static bool operator !=(CacheKey left, CacheKey right) => !left.Equals(right);

        private readonly object _source;
        private readonly object _destinationType;

        public CacheKey(object source, object destinationType)
        {
            _source = source;
            _destinationType = destinationType;
        }

        public override int GetHashCode() => HashCodeCombiner.Combine(_source, _destinationType);

        public bool Equals(CacheKey other) =>
            _source == other._source && _destinationType == other._destinationType;

        public override bool Equals(object other) =>
            other is CacheKey && Equals((CacheKey)other);
    }
}
