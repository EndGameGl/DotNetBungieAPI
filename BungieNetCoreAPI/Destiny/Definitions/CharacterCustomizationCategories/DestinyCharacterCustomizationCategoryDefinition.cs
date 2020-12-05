using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationCategories
{
    [DestinyDefinition("DestinyCharacterCustomizationCategoryDefinition", ignoreLoad: true)]
    public class DestinyCharacterCustomizationCategoryDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }

        [JsonConstructor]
        private DestinyCharacterCustomizationCategoryDefinition(DestinyDefinitionDisplayProperties displayProperties, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
