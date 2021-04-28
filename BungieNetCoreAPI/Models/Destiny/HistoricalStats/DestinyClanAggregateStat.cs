using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyClanAggregateStat
    {
        [JsonPropertyName("mode")]
        public DestinyActivityModeType Mode { get; init; }
        [JsonPropertyName("statId")]
        public HistoricalStatDefinitionPointer Stat { get; init; }
        [JsonPropertyName("value")]
        public DestinyHistoricalStatsValue Value { get; init; }
    }
}