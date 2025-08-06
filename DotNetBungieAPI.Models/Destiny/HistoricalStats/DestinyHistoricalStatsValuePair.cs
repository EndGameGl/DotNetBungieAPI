namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsValuePair
{
    /// <summary>
    ///     Raw value of the statistic
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value { get; init; }

    /// <summary>
    ///     Localized formated version of the value.
    /// </summary>
    [JsonPropertyName("displayValue")]
    public string DisplayValue { get; init; }
}
