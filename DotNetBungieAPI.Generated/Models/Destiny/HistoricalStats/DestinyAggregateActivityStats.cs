namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyAggregateActivityStats
{
    /// <summary>
    ///     Hash ID that can be looked up in the DestinyActivityTable.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? Values { get; set; }
}
