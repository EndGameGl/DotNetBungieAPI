using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.EquipmentSlots;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    /// <summary>
    ///     The definition for an "inventory flyout": a UI screen where we show you part of an otherwise hidden vendor
    ///     inventory: like the Vault inventory buckets.
    /// </summary>
    public sealed record DestinyVendorInventoryFlyoutDefinition : IDeepEquatable<DestinyVendorInventoryFlyoutDefinition>
    {
        /// <summary>
        ///     If the flyout is locked, this is the reason why.
        /// </summary>
        [JsonPropertyName("lockedDescription")]
        public string LockedDescription { get; init; }

        /// <summary>
        ///     The title and other common properties of the flyout.
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     A list of inventory buckets and other metadata to show on the screen.
        /// </summary>
        [JsonPropertyName("buckets")]
        public ReadOnlyCollection<DestinyVendorInventoryFlyoutBucketDefinition> Buckets { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorInventoryFlyoutBucketDefinition>();

        /// <summary>
        ///     If this is true, don't show any of the glistening "this is a new item" UI elements, like we show on the inventory
        ///     items themselves in in-game UI.
        /// </summary>
        [JsonPropertyName("suppressNewness")]
        public bool SuppressNewness { get; init; }

        /// <summary>
        ///     An identifier for the flyout, in case anything else needs to refer to them.
        /// </summary>
        [JsonPropertyName("flyoutId")]
        public uint FlyoutId { get; init; }

        /// <summary>
        ///     If this flyout is meant to show you the contents of the player's equipment slot, this is the slot to show.
        /// </summary>
        [JsonPropertyName("equipmentSlotHash")]
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlot { get; init; } =
            DefinitionHashPointer<DestinyEquipmentSlotDefinition>.Empty;

        public bool DeepEquals(DestinyVendorInventoryFlyoutDefinition other)
        {
            return other != null &&
                   LockedDescription == other.LockedDescription &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Buckets.DeepEqualsReadOnlyCollections(other.Buckets) &&
                   SuppressNewness == other.SuppressNewness &&
                   FlyoutId == other.FlyoutId &&
                   EquipmentSlot.DeepEquals(other.EquipmentSlot);
        }
    }
}