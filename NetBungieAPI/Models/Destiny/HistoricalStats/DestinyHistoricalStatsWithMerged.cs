using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public class DestinyHistoricalStatsWithMerged
    {
        [JsonPropertyName("results")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod> Results { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>();

        [JsonPropertyName("merged")] public DestinyHistoricalStatsByPeriod Merged { get; init; }
    }
}