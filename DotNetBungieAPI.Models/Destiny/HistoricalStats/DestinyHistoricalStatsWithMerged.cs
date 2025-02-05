namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsWithMerged
{
    [JsonPropertyName("results")]
    public ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod> Results { get; init; } =
        ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>.Empty;

    [JsonPropertyName("merged")]
    public DestinyHistoricalStatsByPeriod Merged { get; init; }
}
