namespace DotNetBungieAPI.Models.Destiny.Definitions.Collectibles;

public sealed class DestinyCollectibleStateBlock
{
    [JsonPropertyName("obscuredOverrideItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> ObscuredOverrideItemHash { get; init; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock? Requirements { get; init; }
}
