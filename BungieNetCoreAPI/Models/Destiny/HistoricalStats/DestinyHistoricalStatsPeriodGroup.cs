using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsPeriodGroup
    {
        [JsonPropertyName("period")]
        public DateTime Period { get; init; }
        [JsonPropertyName("activityDetails")]
        public DestinyHistoricalStatsActivity ActivityDetails { get; init; }

        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();
    }
}
