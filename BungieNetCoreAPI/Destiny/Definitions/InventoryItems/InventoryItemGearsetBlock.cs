using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// If an item has a related gearset, this is the list of items in that set, and an unlock expression that evaluates to a number representing the progress toward gearset completion (a very rare use for unlock expressions!)
    /// </summary>
    public class InventoryItemGearsetBlock : IDeepEquatable<InventoryItemGearsetBlock>
    {
        public int TrackingValueMax { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> Items { get; }

        [JsonConstructor]
        internal InventoryItemGearsetBlock(int trackingValueMax, uint[] itemList)
        {
            TrackingValueMax = trackingValueMax;
            Items = itemList.DefinitionsAsReadOnlyOrEmpty<DestinyInventoryItemDefinition>(DefinitionsEnum.DestinyInventoryItemDefinition);
        }

        public bool DeepEquals(InventoryItemGearsetBlock other)
        {
            return other != null &&
                   TrackingValueMax == other.TrackingValueMax &&
                   Items.DeepEqualsReadOnlyCollections(other.Items);
        }
    }
}
