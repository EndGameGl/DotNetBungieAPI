using BungieNetCoreAPI.Destiny.Definitions.SandboxPerks;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemPerk
    {
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; }
        public int PerkVisibility { get; }
        public string RequirementDisplayString { get; }

        [JsonConstructor]
        private InventoryItemPerk(uint perkHash, int perkVisibility, string requirementDisplayString)
        {
            Perk = new DefinitionHashPointer<DestinySandboxPerkDefinition>(perkHash, "DestinySandboxPerkDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            PerkVisibility = perkVisibility;
            RequirementDisplayString = requirementDisplayString;
        }
    }
}
