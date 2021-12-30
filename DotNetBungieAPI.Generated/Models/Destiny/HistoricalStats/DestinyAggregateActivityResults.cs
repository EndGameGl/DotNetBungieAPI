using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyAggregateActivityResults
{

    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyAggregateActivityStats> Activities { get; init; }
}
