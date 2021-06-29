using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace NetBungieAPI.Models.Destiny.Artifacts
{
    public sealed record DestinyArtifactTierItem
    {
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        [JsonPropertyName("isActive")] public bool IsActive { get; init; }
    }
}