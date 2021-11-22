using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Bonds
{
    [DestinyDefinition(DefinitionsEnum.DestinyBondDefinition)]
    public sealed record DestinyBondDefinition : IDestinyDefinition, IDeepEquatable<DestinyBondDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonPropertyName("providedUnlockHash")]
        public uint ProvidedUnlockHash { get; init; }

        [JsonPropertyName("providedUnlockValueHash")]
        public uint ProvidedUnlockValueHash { get; init; }

        public bool DeepEquals(DestinyBondDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   ProvidedUnlockHash == other.ProvidedUnlockHash &&
                   ProvidedUnlockValueHash == other.ProvidedUnlockValueHash &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyBondDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

        [JsonPropertyName("hash")] public uint Hash { get; init; }

        [JsonPropertyName("index")] public int Index { get; init; }

        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
        }

        public void SetPointerLocales(BungieLocales locale)
        {
        }
    }
}