using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockValues
{
    /// <summary>
    /// Doesn't have any meaning at this moment
    /// </summary>
    [DestinyDefinition("DestinyUnlockValueDefinition")]
    public class DestinyUnlockValueDefinition : DestinyDefinition
    {
        /// <summary>
        /// Always 0 atm
        /// </summary>
        public int AggregationType { get; }
        /// <summary>
        /// Always 0 atm
        /// </summary>
        public int Scope { get; }
        /// <summary>
        /// Always 0 atm
        /// </summary>
        public int MappingIndex { get; }

        [JsonConstructor]
        private DestinyUnlockValueDefinition(int aggregationType, int scope, int mappingIndex, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            AggregationType = aggregationType;
            Scope = scope;
            MappingIndex = mappingIndex;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
