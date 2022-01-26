namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyAggregateActivityResults : IDeepEquatable<DestinyAggregateActivityResults>
{
    /// <summary>
    ///     List of all activities the player has participated in.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyAggregateActivityStats> Activities { get; set; }

    public bool DeepEquals(DestinyAggregateActivityResults? other)
    {
        return other is not null &&
               Activities.DeepEqualsList(other.Activities);
    }
}