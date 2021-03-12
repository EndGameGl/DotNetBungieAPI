using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockValues
{
    /// <summary>
    /// Doesn't have any meaning at this moment
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockValueDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyUnlockValueDefinition : IDestinyDefinition, IDeepEquatable<DestinyUnlockValueDefinition>
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
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyUnlockValueDefinition(int aggregationType, int scope, int mappingIndex, bool blacklisted, uint hash, int index, bool redacted)
        {
            AggregationType = aggregationType;
            Scope = scope;
            MappingIndex = mappingIndex;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public void MapValues()
        {
            return;
        }

        public bool DeepEquals(DestinyUnlockValueDefinition other)
        {
            return other != null &&
                   AggregationType == other.AggregationType &&
                   Scope == other.Scope &&
                   MappingIndex == other.MappingIndex &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
