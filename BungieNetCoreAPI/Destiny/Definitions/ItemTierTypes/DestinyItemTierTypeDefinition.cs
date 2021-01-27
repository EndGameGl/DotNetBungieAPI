using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ItemTierTypes
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyItemTierTypeDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyItemTierTypeDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ItemTierTypeInfusionProcess InfusionProcess { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyItemTierTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, ItemTierTypeInfusionProcess infusionProcess,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            InfusionProcess = infusionProcess;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
