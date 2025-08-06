namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsWithMerged
{
    [JsonPropertyName("results")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>? Results { get; init; }

    [JsonPropertyName("merged")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod? Merged { get; init; }
}
