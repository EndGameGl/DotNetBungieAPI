namespace DotNetBungieAPI.Models.Applications;

public sealed class Datapoint
{
    /// <summary>
    ///     Timestamp for the related count.
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime Time { get; init; }

    /// <summary>
    ///     Count associated with timestamp
    /// </summary>
    [JsonPropertyName("count")]
    public double? Count { get; init; }
}
