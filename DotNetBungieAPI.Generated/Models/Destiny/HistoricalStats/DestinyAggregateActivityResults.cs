namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyAggregateActivityResults
{
    /// <summary>
    ///     List of all activities the player has participated in.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyAggregateActivityStats> Activities { get; set; }
}
