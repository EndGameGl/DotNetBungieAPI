using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicMilestoneVendor
    {

        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PreviewItem { get; }

        [JsonConstructor]
        internal DestinyPublicMilestoneVendor(uint vendorHash, uint? previewItemHash)
        {
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
            PreviewItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(previewItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
