using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemGearsetBlock
    {
        public int TrackingValueMax { get; }
        public List<DefinitionHashPointer<DestinyInventoryItemDefinition>> Items { get; }

        [JsonConstructor]
        private InventoryItemGearsetBlock(int trackingValueMax, List<uint> itemList)
        {
            TrackingValueMax = trackingValueMax;
            Items = new List<DefinitionHashPointer<DestinyInventoryItemDefinition>>();
            if (itemList != null)
            {
                foreach (var item in itemList)
                {
                    Items.Add(new DefinitionHashPointer<DestinyInventoryItemDefinition>(item, DefinitionsEnum.DestinyInventoryItemDefinition));
                }
            }
        }
    }
}
