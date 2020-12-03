using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemValueBlock
    {
        public List<InventoryItemValueBlockValue> ItemValue { get; }
        public string ValueDescription { get; }

        [JsonConstructor]
        private InventoryItemValueBlock(List<InventoryItemValueBlockValue> itemValue, string valueDescription)
        {
            ItemValue = itemValue;
            ValueDescription = valueDescription;
        }
    }
}
