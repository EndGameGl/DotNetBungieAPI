namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsWithMerged
{
    [JsonPropertyName("results")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> Results { get; set; }

    [JsonPropertyName("merged")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod Merged { get; set; }
}
