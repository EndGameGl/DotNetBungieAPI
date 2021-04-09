using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Progressions
{
    public sealed record DestinyProgressionReset
    {
        [JsonPropertyName("season")]
        public int Season { get; init; }
        [JsonPropertyName("resets")]
        public int Resets { get; init; }
    }
}
