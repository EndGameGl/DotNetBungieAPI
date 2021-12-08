namespace DotNetBungieAPI.Models.Applications;

public sealed record Series
{
    /// <summary>
    ///     Collection of samples with time and value.
    /// </summary>
    [JsonPropertyName("datapoints")]
    public ReadOnlyCollection<Datapoint> Datapoints { get; init; } = ReadOnlyCollections<Datapoint>.Empty;

    /// <summary>
    ///     Target to which to datapoints apply.
    /// </summary>
    [JsonPropertyName("target")]
    public string Target { get; init; }
}