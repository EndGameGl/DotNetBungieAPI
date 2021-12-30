using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Applications;

public sealed class Datapoint
{

    [JsonPropertyName("time")]
    public DateTime Time { get; init; }

    [JsonPropertyName("count")]
    public double? Count { get; init; }
}
