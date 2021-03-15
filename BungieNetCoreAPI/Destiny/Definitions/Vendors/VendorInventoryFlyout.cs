using NetBungieAPI.Destiny.Definitions.EquipmentSlots;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorInventoryFlyout : IDeepEquatable<VendorInventoryFlyout>
    {
        public string LockedDescription { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ReadOnlyCollection<VendorInventoryFlyoutBucket> Buckets { get; }
        public bool SuppressNewness { get; }
        public uint FlyoutId { get; }
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlot { get; }

        [JsonConstructor]
        internal VendorInventoryFlyout(string lockedDescription, bool suppressNewness, uint flyoutId, DestinyDefinitionDisplayProperties displayProperties,
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
