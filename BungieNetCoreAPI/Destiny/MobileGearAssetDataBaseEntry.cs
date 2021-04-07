using System.Text.Json.Serialization;

namespace NetBungieAPI.Destiny
{
    public class MobileGearAssetDataBaseEntry
    {
        [JsonPropertyName("version")]
        public int Version { get; init; }

        [JsonPropertyName("path")]
        public string Path { get; init; }
    }
}
