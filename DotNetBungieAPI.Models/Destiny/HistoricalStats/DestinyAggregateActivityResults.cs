namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyAggregateActivityResults
{
    /// <summary>
    ///     List of all activities the player has participated in.
    /// </summary>
    [JsonPropertyName("activities")]
    public Destiny.HistoricalStats.DestinyAggregateActivityStats[]? Activities { get; init; }
}
