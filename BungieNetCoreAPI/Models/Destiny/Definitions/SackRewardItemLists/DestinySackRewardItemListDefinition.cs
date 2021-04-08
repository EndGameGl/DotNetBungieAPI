using NetBungieAPI.Attributes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SackRewardItemLists
{
    [DestinyDefinition(DefinitionsEnum.DestinySackRewardItemListDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinySackRewardItemListDefinition : IDestinyDefinition, IDeepEquatable<DestinySackRewardItemListDefinition>
    {
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash}";
        }
        public bool DeepEquals(DestinySackRewardItemListDefinition other)
        {
            return other != null &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            return;
        }
    }
}
