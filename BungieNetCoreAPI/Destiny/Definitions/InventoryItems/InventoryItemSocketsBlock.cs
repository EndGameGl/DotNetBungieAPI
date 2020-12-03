using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSocketsBlock
    {
        public string Detail { get; }
        public List<InventoryItemSocketsBlockIntrinsicSocket> IntrinsicSockets { get; }
        public List<InventoryItemSocketsBlockSocketCategory> SocketCategories { get; }
        public List<InventoryItemSocketsBlockSocketEntry> SocketEntries { get; }

        [JsonConstructor]
        private InventoryItemSocketsBlock(string detail, List<InventoryItemSocketsBlockIntrinsicSocket> intrinsicSockets, List<InventoryItemSocketsBlockSocketCategory> socketCategories,
            List<InventoryItemSocketsBlockSocketEntry> socketEntries)
        {
            Detail = detail;
            IntrinsicSockets = intrinsicSockets;
            SocketCategories = socketCategories;
            SocketEntries = socketEntries;
        }
    }
}
