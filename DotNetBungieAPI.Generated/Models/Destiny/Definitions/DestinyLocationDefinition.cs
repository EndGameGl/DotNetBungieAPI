using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyLocationDefinition
{

    [JsonPropertyName("vendorHash")]
    public uint VendorHash { get; init; }

    [JsonPropertyName("locationReleases")]
    public List<Destiny.Definitions.DestinyLocationReleaseDefinition> LocationReleases { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
