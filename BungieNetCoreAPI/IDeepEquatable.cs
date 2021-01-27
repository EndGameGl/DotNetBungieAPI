namespace BungieNetCoreAPI
{
    /// <summary>
    /// Provides interface for deep object equation.
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public interface IDeepEquatable<T>
    {
        /// <summary>
        /// Whether this object deeply equates another.
        /// </summary>
        /// <param name="other">Object to compare with</param>
        /// <returns></returns>
        bool DeepEquals(T other);
    }
}
