using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;

namespace NetBungieAPI.Models.Destiny.Definitions.SeasonPasses
{
    [DestinyDefinition(DefinitionsEnum.DestinySeasonPassDefinition)]
    public sealed record DestinySeasonPassDefinition : IDestinyDefinition, IDeepEquatable<DestinySeasonPassDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     This is the progression definition related to the progression for the initial levels 1-100 that provide item
        ///     rewards for the Season pass. Further experience after you reach the limit is provided in the "Prestige" progression
        ///     referred to by prestigeProgressionHash.
        /// </summary>
        [JsonPropertyName("rewardProgressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> RewardProgression { get; init; } =
            DefinitionHashPointer<DestinyProgressionDefinition>.Empty;

        /// <summary>
        ///     I know what you're thinking, but I promise we're not going to duplicate and drown you. Instead, we're giving you
        ///     sweet, sweet power bonuses.
        ///     <para />
        ///     Prestige progression is further progression that you can make on the Season pass after you gain max ranks, that
        ///     will ultimately increase your power/light level over the theoretical limit.
        /// </summary>
        [JsonPropertyName("prestigeProgressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> PrestigeProgression { get; init; } =
            DefinitionHashPointer<DestinyProgressionDefinition>.Empty;

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

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            RewardProgression.TryMapValue();
            PrestigeProgression.TryMapValue();
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}