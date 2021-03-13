using NetBungieApi.Attributes;
using NetBungieApi.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.UnlockCountMappings
{
    /// <summary>
    /// Empty definition
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockCountMappingDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyUnlockCountMappingDefinition : IDestinyDefinition, IDeepEquatable<DestinyUnlockCountMappingDefinition>
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> UnlockValue { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyUnlockCountMappingDefinition(uint unlockValueHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            UnlockValue = new DefinitionHashPointer<DestinyUnlockDefinition>(unlockValueHash, DefinitionsEnum.DestinyUnlockDefinition);
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
            UnlockValue.TryMapValue();
        }

        public bool DeepEquals(DestinyUnlockCountMappingDefinition other)
        {
            return other != null &&
                   UnlockValue.DeepEquals(other.UnlockValue) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
