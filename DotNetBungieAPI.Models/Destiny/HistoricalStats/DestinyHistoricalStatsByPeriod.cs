namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsByPeriod
{
    [JsonPropertyName("allTime")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? AllTime { get; init; }

    [JsonPropertyName("allTimeTier1")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? AllTimeTier1 { get; init; }

    [JsonPropertyName("allTimeTier2")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? AllTimeTier2 { get; init; }

    [JsonPropertyName("allTimeTier3")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? AllTimeTier3 { get; init; }

    [JsonPropertyName("daily")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup[]? Daily { get; init; }

    [JsonPropertyName("monthly")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup[]? Monthly { get; init; }
}
