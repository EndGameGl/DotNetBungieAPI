using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyCraftableSocketPlugComponent
{
    [JsonPropertyName("plugItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    [JsonPropertyName("failedRequirementIndexes")]
    public ReadOnlyCollection<int> FailedRequirementIndexes { get; init; } =
        ReadOnlyCollection<int>.Empty;
}
