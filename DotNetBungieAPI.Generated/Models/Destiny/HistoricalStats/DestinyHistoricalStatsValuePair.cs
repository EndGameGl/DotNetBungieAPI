using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsValuePair
{

    [JsonPropertyName("value")]
    public double Value { get; init; }

    [JsonPropertyName("displayValue")]
    public string DisplayValue { get; init; }
}
