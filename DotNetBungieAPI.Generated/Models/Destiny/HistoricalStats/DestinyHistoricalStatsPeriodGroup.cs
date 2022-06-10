namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsPeriodGroup
{
    /// <summary>
    ///     Period for the group. If the stat periodType is day, then this will have a specific day. If the type is monthly, then this value will be the first day of the applicable month. This value is not set when the periodType is 'all time'.
    /// </summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; set; }

    /// <summary>
    ///     If the period group is for a specific activity, this property will be set.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity ActivityDetails { get; set; }

    /// <summary>
    ///     Collection of stats for the period.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }
}
