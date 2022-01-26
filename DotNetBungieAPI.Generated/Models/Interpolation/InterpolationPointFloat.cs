namespace DotNetBungieAPI.Generated.Models.Interpolation;

public class InterpolationPointFloat : IDeepEquatable<InterpolationPointFloat>
{
    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("weight")]
    public float Weight { get; set; }

    public bool DeepEquals(InterpolationPointFloat? other)
    {
        return other is not null &&
               Value == other.Value &&
               Weight == other.Weight;
    }
}