using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInventoryFlyout
    {
        public string LockedDescription { get; }
        public bool SuppressNewness { get; }
        public uint FlyoutId { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<VendorInventoryFlyoutBucket> Buckets { get; }

        [JsonConstructor]
        private VendorInventoryFlyout(string lockedDescription, bool suppressNewness, uint flyoutId, DestinyDefinitionDisplayProperties displayProperties,
            List<VendorInventoryFlyoutBucket> buckets)
        {
            LockedDescription = lockedDescription;
            SuppressNewness = suppressNewness;
            FlyoutId = flyoutId;
            DisplayProperties = displayProperties;
            Buckets = buckets;
        }
    }
}
