using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSetDataBlockItem
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int TrackingValue { get; }

        [JsonConstructor]
        private InventoryItemSetDataBlockItem(uint itemHash, int trackingValue)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            TrackingValue = trackingValue;
        }
    }
}
