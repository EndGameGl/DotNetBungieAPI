using NetBungieAPI.Destiny.Definitions.EquipmentSlots;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorInventoryFlyout : IDeepEquatable<VendorInventoryFlyout>
    {
        public string LockedDescription { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public ReadOnlyCollection<VendorInventoryFlyoutBucket> Buckets { get; init; }
        public bool SuppressNewness { get; init; }
        public uint FlyoutId { get; init; }
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlot { get; init; }

        [JsonConstructor]
        internal VendorInventoryFlyout(string lockedDescription, bool suppressNewness, uint flyoutId, DestinyDisplayPropertiesDefinition displayProperties,
            VendorInventoryFlyoutBucket[] buckets, uint? equipmentSlotHash)
        {
            LockedDescription = lockedDescription;
            SuppressNewness = suppressNewness;
            FlyoutId = flyoutId;
            DisplayProperties = displayProperties;
            Buckets = buckets.AsReadOnlyOrEmpty();
            EquipmentSlot = new DefinitionHashPointer<DestinyEquipmentSlotDefinition>(equipmentSlotHash, DefinitionsEnum.DestinyEquipmentSlotDefinition);
        }

        public bool DeepEquals(VendorInventoryFlyout other)
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
