namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public sealed class DestinyArtifactTierItem
{

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; } // DestinyInventoryItemDefinition

    [JsonPropertyName("isActive")]
    public bool IsActive { get; init; }
}
