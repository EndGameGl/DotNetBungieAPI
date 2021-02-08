using BungieNetCoreAPI.Destiny.Definitions.SandboxPerks;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemPerk : IDeepEquatable<InventoryItemPerk>
    {
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; }
        public int PerkVisibility { get; }
        public string RequirementDisplayString { get; }

        [JsonConstructor]
        internal InventoryItemPerk(uint perkHash, int perkVisibility, string requirementDisplayString)
        {
            Perk = new DefinitionHashPointer<DestinySandboxPerkDefinition>(perkHash, DefinitionsEnum.DestinySandboxPerkDefinition);
            PerkVisibility = perkVisibility;
            RequirementDisplayString = requirementDisplayString;
        }

        public bool DeepEquals(InventoryItemPerk other)
        {
            return other != null &&
                   Perk.DeepEquals(other.Perk) &&
                   PerkVisibility == other.PerkVisibility &&
                   RequirementDisplayString == other.RequirementDisplayString;
        }
    }
}
