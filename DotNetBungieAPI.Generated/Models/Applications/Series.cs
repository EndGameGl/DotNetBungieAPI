using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Applications;

public sealed class Series
{

    [JsonPropertyName("datapoints")]
    public List<Applications.Datapoint> Datapoints { get; init; }

    [JsonPropertyName("target")]
    public string Target { get; init; }
}
