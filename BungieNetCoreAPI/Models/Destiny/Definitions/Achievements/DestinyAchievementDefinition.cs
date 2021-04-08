using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Achievements
{
    /// <summary>
    /// Represents account achievements, such as Steam ones
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyAchievementDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyAchievementDefinition : IDestinyDefinition, IDeepEquatable<DestinyAchievementDefinition>
    {
        [JsonPropertyName("acccumulatorThreshold")]
        public int AcccumulatorThreshold { get; init; }

        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonPropertyName("platformIndex")]
        public int PlatformIndex { get; init; }

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
            return $"{Hash} {(DisplayProperties.Name)}";
        }
        public void MapValues()
        {
            return;
        }
        public bool DeepEquals(DestinyAchievementDefinition other)
        {
            return other != null &&
                   AcccumulatorThreshold == other.AcccumulatorThreshold &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   PlatformIndex == other.PlatformIndex &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
