using NetBungieApi.Destiny.Definitions.InventoryItems;
using NetBungieApi.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Vendors
{
    public class VendorItemSocketOverride : IDeepEquatable<VendorItemSocketOverride>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> SingleItem { get; }
        public int RandomizedOptionsCount { get; }
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; }

        [JsonConstructor]
        internal VendorItemSocketOverride(uint? singleItemHash, int randomizedOptionsCount, uint socketTypeHash)
        {
            SingleItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(singleItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            RandomizedOptionsCount = randomizedOptionsCount;
            SocketType = new DefinitionHashPointer<DestinySocketTypeDefinition>(socketTypeHash, DefinitionsEnum.DestinySocketTypeDefinition);
        }

        public bool DeepEquals(VendorItemSocketOverride other)
        {
            return other != null &&
                   SingleItem.DeepEquals(other.SingleItem) &&
                   RandomizedOptionsCount == other.RandomizedOptionsCount &&
                   SocketType.DeepEquals(other.SocketType);
        }
    }
}
