namespace DotNetBungieAPI.Models.Interpolation;

public sealed record InterpolationPoint : IDeepEquatable<InterpolationPoint>
{
    [JsonPropertyName("value")] public int Value { get; init; }

    [JsonPropertyName("weight")] public int Weight { get; init; }

    public bool DeepEquals(InterpolationPoint other)
    {
        return other != null && Value == other.Value && Weight == other.Weight;
    }
}