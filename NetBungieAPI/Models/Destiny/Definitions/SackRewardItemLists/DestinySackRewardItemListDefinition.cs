using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;

namespace NetBungieAPI.Models.Destiny.Definitions.SackRewardItemLists
{
    [DestinyDefinition(DefinitionsEnum.DestinySackRewardItemListDefinition)]
    public sealed record DestinySackRewardItemListDefinition : IDestinyDefinition,
        IDeepEquatable<DestinySackRewardItemListDefinition>
    {
        public bool DeepEquals(DestinySackRewardItemListDefinition other)
        {
            return other != null &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySackRewardItemListDefinition;
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

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}