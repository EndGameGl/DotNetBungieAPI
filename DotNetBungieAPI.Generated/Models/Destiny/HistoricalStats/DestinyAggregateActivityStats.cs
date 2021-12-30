using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyAggregateActivityStats
{

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; init; }
}
