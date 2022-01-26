namespace DotNetBungieAPI.Generated.Models.Applications;

public class Series : IDeepEquatable<Series>
{
    /// <summary>
    ///     Collection of samples with time and value.
    /// </summary>
    [JsonPropertyName("datapoints")]
    public List<Applications.Datapoint> Datapoints { get; set; }

    /// <summary>
    ///     Target to which to datapoints apply.
    /// </summary>
    [JsonPropertyName("target")]
    public string Target { get; set; }

    public bool DeepEquals(Series? other)
    {
        return other is not null &&
               Datapoints.DeepEqualsList(other.Datapoints) &&
               Target == other.Target;
    }
}