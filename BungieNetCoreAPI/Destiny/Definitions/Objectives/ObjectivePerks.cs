using BungieNetCoreAPI.Destiny.Definitions.SandboxPerks;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Objectives
{
    public class ObjectivePerks
    {
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; }
        public int Style { get; }

        [JsonConstructor]
        private ObjectivePerks(uint perkHash, int style)
        {
            Perk = new DefinitionHashPointer<DestinySandboxPerkDefinition>(perkHash, "DestinySandboxPerkDefinition");
            Style = style;
        }
    }
}
