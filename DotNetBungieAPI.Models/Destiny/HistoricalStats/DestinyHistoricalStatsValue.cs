namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsValue
{
    /// <summary>
    ///     Unique ID for this stat
    /// </summary>
    [JsonPropertyName("statId")]
    public string StatId { get; init; }

    /// <summary>
    ///     Basic stat value.
    /// </summary>
    [JsonPropertyName("basic")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair? Basic { get; init; }

    /// <summary>
    ///     Per game average for the statistic, if applicable
    /// </summary>
    [JsonPropertyName("pga")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair? Pga { get; init; }

    /// <summary>
    ///     Weighted value of the stat if a weight greater than 1 has been assigned.
    /// </summary>
    [JsonPropertyName("weighted")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair? Weighted { get; init; }

    /// <summary>
    ///     When a stat represents the best, most, longest, fastest or some other personal best, the actual activity ID where that personal best was established is available on this property.
    /// </summary>
    [JsonPropertyName("activityId")]
    public long? ActivityId { get; init; }
}
