using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    ///     If an item has a related gearset, this is the list of items in that set, and an unlock expression that evaluates to
    ///     a number representing the progress toward gearset completion (a very rare use for unlock expressions!)
    /// </summary>
    public sealed record DestinyItemGearsetBlockDefinition : IDeepEquatable<DestinyItemGearsetBlockDefinition>
    {
        /// <summary>
        ///     The maximum possible number of items that can be collected.
        /// </summary>
        [JsonPropertyName("trackingValueMax")]
        public int TrackingValueMax { get; init; }

        /// <summary>
        ///     The list of DestinyInventoryItemDefinition for items in the gearset.
        /// </summary>
        [JsonPropertyName("itemList")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> Items { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>>();

        public bool DeepEquals(DestinyItemGearsetBlockDefinition other)
        {
            return other != null &&
                   TrackingValueMax == other.TrackingValueMax &&
                   Items.DeepEqualsReadOnlyCollections(other.Items);
        }
    }
}