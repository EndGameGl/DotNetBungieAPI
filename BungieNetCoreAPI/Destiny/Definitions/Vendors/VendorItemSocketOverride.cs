using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorItemSocketOverride
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> SingleItem { get; }
        public int RandomizedOptionsCount { get; }
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; }

        [JsonConstructor]
        private VendorItemSocketOverride(uint singleItemHash, int randomizedOptionsCount, uint socketTypeHash)
        {
            SingleItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(singleItemHash, "DestinyInventoryItemDefinition");
            RandomizedOptionsCount = randomizedOptionsCount;
            SocketType = new DefinitionHashPointer<DestinySocketTypeDefinition>(socketTypeHash, "DestinySocketTypeDefinition");
        }
    }
}
