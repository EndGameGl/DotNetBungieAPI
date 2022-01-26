namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyAggregateActivityStats : IDeepEquatable<DestinyAggregateActivityStats>
{
    /// <summary>
    ///     Hash ID that can be looked up in the DestinyActivityTable.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }

    public bool DeepEquals(DestinyAggregateActivityStats? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               Values.DeepEqualsDictionary(other.Values);
    }
}