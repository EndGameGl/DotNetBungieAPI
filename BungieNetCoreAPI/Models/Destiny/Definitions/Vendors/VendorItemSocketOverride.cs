using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorItemSocketOverride : IDeepEquatable<VendorItemSocketOverride>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> SingleItem { get; init; }
        public int RandomizedOptionsCount { get; init; }
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; }

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
