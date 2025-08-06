namespace DotNetBungieAPI.Models.Applications;

public sealed class Series
{
    /// <summary>
    ///     Collection of samples with time and value.
    /// </summary>
    [JsonPropertyName("datapoints")]
    public Applications.Datapoint[]? Datapoints { get; init; }

    /// <summary>
    ///     Target to which to datapoints apply.
    /// </summary>
    [JsonPropertyName("target")]
    public string Target { get; init; }
}
