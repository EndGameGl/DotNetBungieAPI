using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyLoadoutItemComponent
{
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; init; }

    [JsonPropertyName("plugItemHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyInventoryItemDefinition>
    > PlugItems { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyInventoryItemDefinition>>.Empty;
}
