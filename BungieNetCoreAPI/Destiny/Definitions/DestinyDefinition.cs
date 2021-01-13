using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions
{
    /// <summary>
    /// Base parameters for any destiny definition.
    /// </summary>
    public class DestinyDefinition
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

        [JsonConstructor]
        protected DestinyDefinition(bool blacklisted, uint hash, int index, bool redacted)
        {
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
    }
}
