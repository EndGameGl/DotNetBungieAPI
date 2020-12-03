using BungieNetCoreAPI.Destiny.Definitions.TalentGrids;
using Newtonsoft.Json;
namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTalentGrid
    {
        public int HudDamageType { get; }
        public string ItemDetailString { get; }
        public DefinitionHashPointer<DestinyTalentGridDefinition> TalentGrid { get; }

        [JsonConstructor]
        private InventoryItemTalentGrid(int hudDamageType, string itemDetailString, uint talentGridHash)
        {
            HudDamageType = hudDamageType;
            ItemDetailString = itemDetailString;
            TalentGrid = new DefinitionHashPointer<DestinyTalentGridDefinition>(talentGridHash, "DestinyTalentGridDefinition");
        }
    }
}
