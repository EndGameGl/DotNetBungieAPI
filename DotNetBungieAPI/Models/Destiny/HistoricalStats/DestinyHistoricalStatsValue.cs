using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsValue
    {
        /// <summary>
        ///     Unique ID for this stat
        /// </summary>
        [JsonPropertyName("statId")]
        public HistoricalStatDefinitionPointer StatId { get; init; }

        /// <summary>
        ///     Basic stat value.
        /// </summary>
        [JsonPropertyName("basic")]
        public DestinyHistoricalStatsValuePair BasicValue { get; init; }

        /// <summary>
        ///     Per game average for the statistic, if applicable
        /// </summary>
        [JsonPropertyName("pga")]
        public DestinyHistoricalStatsValuePair PerGameAverage { get; init; }

        /// <summary>
        ///     Weighted value of the stat if a weight greater than 1 has been assigned.
        /// </summary>
        [JsonPropertyName("weighted")]
        public DestinyHistoricalStatsValuePair WeightedValue { get; init; }

        /// <summary>
        ///     When a stat represents the best, most, longest, fastest or some other personal best, the actual activity ID where
        ///     that personal best was established is available on this property.
        /// </summary>
        [JsonPropertyName("activityId")]
        public long? ActivityId { get; init; }
    }
}