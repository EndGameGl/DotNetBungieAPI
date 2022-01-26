namespace DotNetBungieAPI.Generated.Models.Applications;

public class Datapoint : IDeepEquatable<Datapoint>
{
    /// <summary>
    ///     Timestamp for the related count.
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    /// <summary>
    ///     Count associated with timestamp
    /// </summary>
    [JsonPropertyName("count")]
    public double? Count { get; set; }

    public bool DeepEquals(Datapoint? other)
    {
        return other is not null &&
               Time == other.Time &&
               Count == other.Count;
    }
}