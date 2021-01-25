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
        public bool Blacklisted { get; }
        /// <summary>
        /// Unique definition ID
        /// </summary>
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
    }
}
