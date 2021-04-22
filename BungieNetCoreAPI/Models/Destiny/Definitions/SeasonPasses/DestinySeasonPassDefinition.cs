using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SeasonPasses
{
    [DestinyDefinition(DefinitionsEnum.DestinySeasonPassDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinySeasonPassDefinition : IDestinyDefinition, IDeepEquatable<DestinySeasonPassDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("rewardProgressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> RewardProgression { get; init; } = DefinitionHashPointer<DestinyProgressionDefinition>.Empty;
        [JsonPropertyName("prestigeProgressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> PrestigeProgression { get; init; } = DefinitionHashPointer<DestinyProgressionDefinition>.Empty;
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
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public void MapValues()
        {
            RewardProgression.TryMapValue();
            PrestigeProgression.TryMapValue();
        }
        public bool DeepEquals(DestinySeasonPassDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   RewardProgression.DeepEquals(other.RewardProgression) &&
                   PrestigeProgression.DeepEquals(other.PrestigeProgression) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
