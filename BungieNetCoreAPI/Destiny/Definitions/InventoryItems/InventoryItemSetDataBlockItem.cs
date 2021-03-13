using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Defines a particular entry in an ItemSet (AKA a particular Quest Step in a Quest)
    /// </summary>
    public class InventoryItemSetDataBlockItem : IDeepEquatable<InventoryItemSetDataBlockItem>
    {
        /// <summary>
        /// DestinyInventoryItemDefinition representing this quest step.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        /// <summary>
        /// Used for tracking which step a user reached. These values will be populated in the user's internal state, which we expose externally as a more usable DestinyQuestStatus object. If this item has been obtained, this value will be set in trackingUnlockValueHash.
        /// </summary>
        public int TrackingValue { get; }

        [JsonConstructor]
        internal InventoryItemSetDataBlockItem(uint itemHash, int trackingValue)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            TrackingValue = trackingValue;
        }

        public bool DeepEquals(InventoryItemSetDataBlockItem other)
        {
            return other != null && Item.DeepEquals(other.Item) && TrackingValue == other.TrackingValue;
        }
    }
}
