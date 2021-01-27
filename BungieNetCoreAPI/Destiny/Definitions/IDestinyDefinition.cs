using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions
{
    /// <summary>
    /// Base parameters for any destiny definition.
    /// </summary>
    public interface IDestinyDefinition
    {
        /// <summary>
        /// Whether this definition is blacklisted
        /// </summary>
        bool Blacklisted { get; }
        /// <summary>
        /// Unique definition ID
        /// </summary>
        uint Hash { get; }
        int Index { get; }
        bool Redacted { get; }
        /// <summary>
        /// Tries to map values so it wouldn't need to look up repository every time
        /// </summary>
        //void MapValues();
    }
}
