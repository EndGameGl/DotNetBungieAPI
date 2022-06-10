namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyActivityHistoryResults
{
    /// <summary>
    ///     List of activities, the most recent activity first.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Activities { get; set; }
}
