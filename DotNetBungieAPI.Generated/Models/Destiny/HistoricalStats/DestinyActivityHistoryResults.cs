namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyActivityHistoryResults : IDeepEquatable<DestinyActivityHistoryResults>
{
    /// <summary>
    ///     List of activities, the most recent activity first.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Activities { get; set; }

    public bool DeepEquals(DestinyActivityHistoryResults? other)
    {
        return other is not null &&
               Activities.DeepEqualsList(other.Activities);
    }
}