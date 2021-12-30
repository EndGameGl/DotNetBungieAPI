using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Interpolation;

public sealed class InterpolationPoint
{

    [JsonPropertyName("value")]
    public int Value { get; init; }

    [JsonPropertyName("weight")]
    public int Weight { get; init; }
}
