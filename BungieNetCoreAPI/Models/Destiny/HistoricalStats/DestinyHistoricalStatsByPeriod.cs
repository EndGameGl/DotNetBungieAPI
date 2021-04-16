using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsByPeriod
    {
        [JsonPropertyName("allTime")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTime { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();

        [JsonPropertyName("allTimeTier1")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier1 { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();

        [JsonPropertyName("allTimeTier2")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier2 { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();

        [JsonPropertyName("allTimeTier3")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier3 { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();

        [JsonPropertyName("daily")]
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Daily { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalStatsPeriodGroup>();

        [JsonPropertyName("monthly")]
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Monthly { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalStatsPeriodGroup>();
    }
}