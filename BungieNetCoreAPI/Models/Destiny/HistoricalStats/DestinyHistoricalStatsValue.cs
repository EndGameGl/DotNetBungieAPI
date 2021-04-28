using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsValue
    {
        [JsonPropertyName("statId")] 
        public HistoricalStatDefinitionPointer StatId { get; init; }
        [JsonPropertyName("basic")]
        public DestinyHistoricalStatsValuePair BasicValue { get; init; }
        [JsonPropertyName("pga")] 
        public DestinyHistoricalStatsValuePair PerGameAverage { get; init; }
        [JsonPropertyName("weighted")]
        public DestinyHistoricalStatsValuePair WeightedValue { get; init; }
        [JsonPropertyName("activityId")] 
        public long? ActivityId { get; init; }
    }
}