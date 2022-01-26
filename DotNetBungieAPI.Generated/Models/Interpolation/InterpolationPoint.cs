namespace DotNetBungieAPI.Generated.Models.Interpolation;

public class InterpolationPoint : IDeepEquatable<InterpolationPoint>
{
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    public bool DeepEquals(InterpolationPoint? other)
    {
        return other is not null &&
               Value == other.Value &&
               Weight == other.Weight;
    }
}