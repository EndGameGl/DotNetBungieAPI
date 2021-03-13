using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.BreakerTypes
{
    [DestinyDefinition(DefinitionsEnum.DestinyBreakerTypeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyBreakerTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyBreakerTypeDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint UnlockHash { get; }
        public DestinyBreakerTypes EnumValue { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyBreakerTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, uint unlockHash, DestinyBreakerTypes enumValue,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            UnlockHash = unlockHash;
            EnumValue = enumValue;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyBreakerTypeDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   UnlockHash == other.UnlockHash &&
                   EnumValue == other.EnumValue &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
