using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Config
{
    public sealed record MobileGearAssetDataBaseEntry
    {
        [JsonPropertyName("version")] public int Version { get; init; }

        [JsonPropertyName("path")] public string Path { get; init; }
    }
}