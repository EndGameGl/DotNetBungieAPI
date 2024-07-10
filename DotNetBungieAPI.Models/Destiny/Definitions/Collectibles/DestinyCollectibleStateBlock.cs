using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Collectibles;

public sealed record DestinyCollectibleStateBlock : IDeepEquatable<DestinyCollectibleStateBlock>
{
    [JsonPropertyName("obscuredOverrideItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> ObscuredOverrideItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    [JsonPropertyName("requirements")]
    public DestinyPresentationNodeRequirementsBlock Requirements { get; init; }

    public bool DeepEquals(DestinyCollectibleStateBlock other)
    {
        return other != null && Requirements.DeepEquals(other.Requirements);
    }
}
