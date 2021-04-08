using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Stats
{
    [DestinyDefinition(DefinitionsEnum.DestinyStatDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyStatDefinition : IDestinyDefinition, IDeepEquatable<DestinyStatDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("aggregationType")]
        public DestinyStatAggregationType AggregationType { get; init; }
        [JsonPropertyName("hasComputedBlock")]
        public bool HasComputedBlock { get; init; }
        [JsonPropertyName("statCategory")]
        public DestinyStatCategory StatCategory { get; init; }
        [JsonPropertyName("interpolate")]
        public bool Interpolate { get; init; }
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
            return;
        }
        public bool DeepEquals(DestinyStatDefinition other)
        {
            return other != null &&
                   AggregationType == other.AggregationType &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   HasComputedBlock == other.HasComputedBlock &&
                   Interpolate == other.Interpolate &&
                   StatCategory == other.StatCategory &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
