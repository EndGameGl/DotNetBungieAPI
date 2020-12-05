using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemValueBlockValue
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }

        [JsonConstructor]
        private InventoryItemValueBlockValue(uint itemHash, int quantity)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, "DestinyInventoryItemDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            Quantity = quantity;
        }
    }
}
