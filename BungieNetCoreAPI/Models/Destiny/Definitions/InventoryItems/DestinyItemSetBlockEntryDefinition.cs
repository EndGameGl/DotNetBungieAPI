using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Defines a particular entry in an ItemSet (AKA a particular Quest Step in a Quest)
    /// </summary>
    public sealed record DestinyItemSetBlockEntryDefinition : IDeepEquatable<DestinyItemSetBlockEntryDefinition>
    {
        /// <summary>
        /// DestinyInventoryItemDefinition representing this quest step.
        /// </summary>
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        /// Used for tracking which step a user reached. These values will be populated in the user's internal state, which we expose externally as a more usable DestinyQuestStatus object. If this item has been obtained, this value will be set in trackingUnlockValueHash.
        /// </summary>
        [JsonPropertyName("trackingValue")]
        public int TrackingValue { get; init; }

        public bool DeepEquals(DestinyItemSetBlockEntryDefinition other)
        {
            return other != null && Item.DeepEquals(other.Item) && TrackingValue == other.TrackingValue;
        }
    }
}