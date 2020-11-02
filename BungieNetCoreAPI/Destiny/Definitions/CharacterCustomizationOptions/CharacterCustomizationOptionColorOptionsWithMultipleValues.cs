using BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationCategories;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class CharacterCustomizationOptionColorOptionsWithMultipleValues
    {
        public DefinitionHashPointer<DestinyCharacterCustomizationCategoryDefinition> CustomizationCategory { get; }
        public string DisplayName { get; }
        public List<CharacterCustomizationOptionColorOptionsEntryWithMultipleValues> Options { get; }

        [JsonConstructor]
        private CharacterCustomizationOptionColorOptionsWithMultipleValues(uint customizationCategoryHash, string displayName, List<CharacterCustomizationOptionColorOptionsEntryWithMultipleValues> options)
        {
            CustomizationCategory = new DefinitionHashPointer<DestinyCharacterCustomizationCategoryDefinition>(customizationCategoryHash, "DestinyCharacterCustomizationCategoryDefinition");
            DisplayName = displayName;
            if (options == null)
                Options = new List<CharacterCustomizationOptionColorOptionsEntryWithMultipleValues>();
            else
                Options = options;
        }
    }
}
