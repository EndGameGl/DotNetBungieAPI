namespace DotNetBungieAPI.Generated.Models.Applications;

public sealed class Series
{

    /// <summary>
    ///     Collection of samples with time and value.
    /// </summary>
    [JsonPropertyName("datapoints")]
    public List<Applications.Datapoint> Datapoints { get; init; }

    /// <summary>
    ///     Target to which to datapoints apply.
    /// </summary>
    [JsonPropertyName("target")]
    public string Target { get; init; }
}
