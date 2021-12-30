using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyStatDisplayDefinition
{

    [JsonPropertyName("statHash")]
    public uint StatHash { get; init; }

    [JsonPropertyName("maximumValue")]
    public int MaximumValue { get; init; }

    [JsonPropertyName("displayAsNumeric")]
    public bool DisplayAsNumeric { get; init; }

    [JsonPropertyName("displayInterpolation")]
    public List<Interpolation.InterpolationPoint> DisplayInterpolation { get; init; }
}
