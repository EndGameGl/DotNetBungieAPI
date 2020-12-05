using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.TraitCategories;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Traits
{
    [DestinyDefinition("DestinyTraitDefinition")]
    public class DestinyTraitDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyTraitCategoryDefinition> TraitCategory { get; }

        [JsonConstructor]
        private DestinyTraitDefinition(DestinyDefinitionDisplayProperties displayProperties, uint traitCategoryHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            TraitCategory = new DefinitionHashPointer<DestinyTraitCategoryDefinition>(traitCategoryHash, "DestinyTraitCategoryDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
