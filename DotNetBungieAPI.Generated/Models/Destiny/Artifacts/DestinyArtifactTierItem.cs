namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public class DestinyArtifactTierItem
{
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("isVisible")]
    public bool IsVisible { get; set; }
}
