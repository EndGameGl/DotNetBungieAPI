namespace NetBungieAPI.Models.Destiny
{
    /// <summary>
    /// Base parameters for any destiny definition.
    /// </summary>
    public interface IDestinyDefinition
    {
        /// <summary>
        /// Whether this definition is blacklisted
        /// </summary>
        bool Blacklisted { get; init; }
        /// <summary>
        /// Unique definition ID
        /// </summary>
        uint Hash { get; init; }
        int Index { get; init; }
        bool Redacted { get; init; }
        /// <summary>
        /// Tries to map values so it wouldn't need to look up repository every time
        /// </summary>
        void MapValues();
    }
}
