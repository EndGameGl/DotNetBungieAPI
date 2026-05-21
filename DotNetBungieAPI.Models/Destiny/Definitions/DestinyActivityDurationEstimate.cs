namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyActivityDurationEstimate
{
    /// <summary>
    ///     The number of filled pips shown on the Portal tile
    /// </summary>
    [JsonPropertyName("durationPipsFilledCount")]
    public int DurationPipsFilledCount { get; init; }

    /// <summary>
    ///     The total number of pips shown on the Portal tile
    /// </summary>
    [JsonPropertyName("durationPipsTotalCount")]
    public int DurationPipsTotalCount { get; init; }

    /// <summary>
    ///     The text string showing the estimated time to complete this activity
    /// </summary>
    [JsonPropertyName("durationEstimateText")]
    public string DurationEstimateText { get; init; }
}
