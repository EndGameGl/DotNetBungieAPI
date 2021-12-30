using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public sealed class DestinyArtifactTierItem
{

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; init; }
}
