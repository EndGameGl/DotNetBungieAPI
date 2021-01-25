using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PlugSets
{
    public class PlugSetReusablePlugItem
    {
        public double Weight { get; }
        public double AlternateWeight { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; }

        [JsonConstructor]
        private PlugSetReusablePlugItem(double weight, double alternateWeight, uint plugItemHash)
        {
            Weight = weight;
            AlternateWeight = alternateWeight;
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
