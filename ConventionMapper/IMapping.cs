namespace ConventionMapper
{
    /// <summary>
    /// Converts source type to destination type
    /// </summary>
    /// <typeparam name="TSource">Source type</typeparam>
    /// <typeparam name="TDestination">Destination type</typeparam>
    public interface IMapping<in TSource, TDestination>
    {
        /// <summary>
        /// Fills destination if source equivalent properties
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <returns>Destination object</returns>
        TDestination Convert(TSource source, TDestination destination);

        /// <summary>
        /// Convert source to TDestination type
        /// </summary>
        /// <param name="source">source object</param>
        /// <returns>resultant object</returns>
        TDestination Map(TSource source);
    }
}