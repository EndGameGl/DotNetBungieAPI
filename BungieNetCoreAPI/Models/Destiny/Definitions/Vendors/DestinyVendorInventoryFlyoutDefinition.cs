using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.EquipmentSlots;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorInventoryFlyoutDefinition : IDeepEquatable<DestinyVendorInventoryFlyoutDefinition>
    {
        [JsonPropertyName("lockedDescription")]
        public string LockedDescription { get; init; }
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("buckets")]
        public ReadOnlyCollection<DestinyVendorInventoryFlyoutBucketDefinition> Buckets { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorInventoryFlyoutBucketDefinition>();
        [JsonPropertyName("suppressNewness")]
        public bool SuppressNewness { get; init; }
        [JsonPropertyName("flyoutId")]
        public uint FlyoutId { get; init; }
        [JsonPropertyName("equipmentSlotHash")]
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlot { get; init; } = DefinitionHashPointer<DestinyEquipmentSlotDefinition>.Empty;

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
