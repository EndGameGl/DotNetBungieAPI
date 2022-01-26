namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsValuePair : IDeepEquatable<DestinyHistoricalStatsValuePair>
{
    /// <summary>
    ///     Raw value of the statistic
    /// </summary>
    [JsonPropertyName("value")]
    public double Value { get; set; }

    /// <summary>
    ///     Localized formated version of the value.
    /// </summary>
    [JsonPropertyName("displayValue")]
    public string DisplayValue { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsValuePair? other)
    {
        return other is not null &&
               Value == other.Value &&
               DisplayValue == other.DisplayValue;
    }
}