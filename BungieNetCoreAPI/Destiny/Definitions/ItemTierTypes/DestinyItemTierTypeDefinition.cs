using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ItemTierTypes
{
    [DestinyDefinition("DestinyItemTierTypeDefinition")]
    public class DestinyItemTierTypeDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ItemTierTypeInfusionProcess InfusionProcess { get; }

        [JsonConstructor]
        private DestinyItemTierTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, ItemTierTypeInfusionProcess infusionProcess,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            InfusionProcess = infusionProcess;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
