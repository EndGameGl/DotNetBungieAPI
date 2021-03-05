using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.TraitCategories;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Traits
{
    [DestinyDefinition(DefinitionsEnum.DestinyTraitDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyTraitDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyTraitCategoryDefinition> TraitCategory { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyTraitDefinition(DestinyDefinitionDisplayProperties displayProperties, uint traitCategoryHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            TraitCategory = new DefinitionHashPointer<DestinyTraitCategoryDefinition>(traitCategoryHash, DefinitionsEnum.DestinyTraitCategoryDefinition);
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
