namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed record DestinyAggregateActivityResults
{
    /// <summary>
    ///     List of all activities the player has participated in.
    /// </summary>
    [JsonPropertyName("activities")]
    public ReadOnlyCollection<DestinyAggregateActivityStats> Activities { get; init; } =
        ReadOnlyCollection<DestinyAggregateActivityStats>.Empty;
}
