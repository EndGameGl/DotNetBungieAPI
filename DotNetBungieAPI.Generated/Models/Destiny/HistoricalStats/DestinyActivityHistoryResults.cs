namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyActivityHistoryResults
{

    /// <summary>
    ///     List of activities, the most recent activity first.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Activities { get; init; }
}
