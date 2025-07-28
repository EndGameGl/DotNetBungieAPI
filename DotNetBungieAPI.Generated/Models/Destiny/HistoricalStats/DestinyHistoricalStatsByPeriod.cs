namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsByPeriod
{
    [JsonPropertyName("allTime")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? AllTime { get; set; }

    [JsonPropertyName("allTimeTier1")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? AllTimeTier1 { get; set; }

    [JsonPropertyName("allTimeTier2")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? AllTimeTier2 { get; set; }

    [JsonPropertyName("allTimeTier3")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? AllTimeTier3 { get; set; }

    [JsonPropertyName("daily")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup[]? Daily { get; set; }

    [JsonPropertyName("monthly")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup[]? Monthly { get; set; }
}
