using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsByPeriod
    {
        [JsonPropertyName("allTime")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTime { get; init; } =
            ReadOnlyDictionaries<string, DestinyHistoricalStatsValue>.Empty;

        [JsonPropertyName("allTimeTier1")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier1 { get; init; } =
            ReadOnlyDictionaries<string, DestinyHistoricalStatsValue>.Empty;

        [JsonPropertyName("allTimeTier2")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier2 { get; init; } =
            ReadOnlyDictionaries<string, DestinyHistoricalStatsValue>.Empty;

        [JsonPropertyName("allTimeTier3")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> AllTimeTier3 { get; init; } =
            ReadOnlyDictionaries<string, DestinyHistoricalStatsValue>.Empty;

        [JsonPropertyName("daily")]
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Daily { get; init; } =
            ReadOnlyCollections<DestinyHistoricalStatsPeriodGroup>.Empty;

        [JsonPropertyName("monthly")]
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Monthly { get; init; } =
            ReadOnlyCollections<DestinyHistoricalStatsPeriodGroup>.Empty;
    }
}