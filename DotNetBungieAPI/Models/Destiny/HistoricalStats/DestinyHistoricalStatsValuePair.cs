using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsValuePair
    {
        /// <summary>
        ///     Raw value of the statistic
        /// </summary>
        [JsonPropertyName("value")]
        public double Value { get; init; }

        /// <summary>
        ///     Localized formatted version of the value.
        /// </summary>
        [JsonPropertyName("displayValue")]
        public string DisplayValue { get; init; }
    }
}