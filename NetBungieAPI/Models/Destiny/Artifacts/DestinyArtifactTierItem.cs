using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

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