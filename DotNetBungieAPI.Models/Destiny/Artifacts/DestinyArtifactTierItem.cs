namespace DotNetBungieAPI.Models.Destiny.Artifacts;

public sealed class DestinyArtifactTierItem
{
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> ItemHash { get; init; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; init; }

    [JsonPropertyName("isVisible")]
    public bool IsVisible { get; init; }
}
