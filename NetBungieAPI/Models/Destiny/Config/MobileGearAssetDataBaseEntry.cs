using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Config
{
    public sealed record MobileGearAssetDataBaseEntry
    {
        [JsonPropertyName("version")]
        public int Version { get; init; }

        [JsonPropertyName("path")]
        public string Path { get; init; }
    }
}
