using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsValuePair
    {
        [JsonPropertyName("value")] 
        public double Value { get; init; }
        [JsonPropertyName("displayValue")] 
        public string DisplayValue { get; init; }
    }
}
