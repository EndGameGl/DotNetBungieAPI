using BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationCategories;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class CharacterCustomizationOptionColorOptions
    {
        public DefinitionHashPointer<DestinyCharacterCustomizationCategoryDefinition> CustomizationCategory { get; }
        public string DisplayName { get; }
        public List<CharacterCustomizationOptionColorOptionsEntry> Options { get; }

        [JsonConstructor]
        private CharacterCustomizationOptionColorOptions(uint customizationCategoryHash, string displayName, List<CharacterCustomizationOptionColorOptionsEntry> options)
        {
            CustomizationCategory = new DefinitionHashPointer<DestinyCharacterCustomizationCategoryDefinition>(customizationCategoryHash, DefinitionsEnum.DestinyCharacterCustomizationCategoryDefinition);
            DisplayName = displayName;
            if (options == null)
                Options = new List<CharacterCustomizationOptionColorOptionsEntry>();
            else
                Options = options;
        }
    }
}
