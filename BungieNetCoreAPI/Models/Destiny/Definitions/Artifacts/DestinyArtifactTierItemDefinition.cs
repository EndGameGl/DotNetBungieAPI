using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Artifacts
{
    public sealed record DestinyArtifactTierItemDefinition : IDeepEquatable<DestinyArtifactTierItemDefinition>
    {
        [JsonPropertyName("activeUnlockHash")]
        public uint ActiveUnlockHash { get; init; }

        /// <summary>
        /// Plug Item unlocked by activating this item in the Artifact.
        /// </summary>
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        public bool DeepEquals(DestinyArtifactTierItemDefinition other)
        {
            return other != null &&
                ActiveUnlockHash == other.ActiveUnlockHash &&
                Item.DeepEquals(other.Item);
        }
    }
}
