namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsPeriodGroup
{
    /// <summary>
    ///     Period for the group. If the stat periodType is day, then this will have a specific day. If the type is monthly, then this value will be the first day of the applicable month. This value is not set when the periodType is 'all time'.
    /// </summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; init; }

    /// <summary>
    ///     If the period group is for a specific activity, this property will be set.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity? ActivityDetails { get; init; }

    /// <summary>
    ///     Collection of stats for the period.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? Values { get; init; }
}
