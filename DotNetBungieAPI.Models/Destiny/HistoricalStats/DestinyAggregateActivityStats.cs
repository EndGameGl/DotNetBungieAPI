namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyAggregateActivityStats
{
    /// <summary>
    ///     Hash ID that can be looked up in the DestinyActivityTable.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> ActivityHash { get; init; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue>? Values { get; init; }
}
