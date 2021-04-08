using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Interpolation
{
    public sealed record InterpolationPointFloat : IDeepEquatable<InterpolationPointFloat>
    {
        [JsonPropertyName("value")]
        public float Value { get; init; }
        [JsonPropertyName("weight")]
        public float Weight { get; init; }

        public bool DeepEquals(InterpolationPointFloat other)
        {
            return other != null && Value == other.Value && Weight == other.Weight;
        }
    }
}
