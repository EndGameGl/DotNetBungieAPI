using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemInvestmentStat
    {
        public bool IsConditionallyActive { get; }
        public DefinitionHashPointer<DestinyStatDefinition> StatType { get; }
        public int Value { get; }

        [JsonConstructor]
        private InventoryItemInvestmentStat(bool isConditionallyActive, uint statTypeHash, int value)
        {
            IsConditionallyActive = isConditionallyActive;
            StatType = new DefinitionHashPointer<DestinyStatDefinition>(statTypeHash, DefinitionsEnum.DestinyStatDefinition);
            Value = value;
        }
    }
}
