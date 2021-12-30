using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsValue
{

    [JsonPropertyName("statId")]
    public string StatId { get; init; }

    [JsonPropertyName("basic")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Basic { get; init; }

    [JsonPropertyName("pga")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Pga { get; init; }

    [JsonPropertyName("weighted")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Weighted { get; init; }

    [JsonPropertyName("activityId")]
    public long? ActivityId { get; init; }
}
