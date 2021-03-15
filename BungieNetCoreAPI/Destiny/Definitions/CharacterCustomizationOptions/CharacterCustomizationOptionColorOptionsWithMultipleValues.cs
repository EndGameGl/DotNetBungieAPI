using NetBungieAPI.Destiny.Definitions.CharacterCustomizationCategories;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class CharacterCustomizationOptionColorOptionsWithMultipleValues : IDeepEquatable<CharacterCustomizationOptionColorOptionsWithMultipleValues>
    {
        public DefinitionHashPointer<DestinyCharacterCustomizationCategoryDefinition> CustomizationCategory { get; }
        public string DisplayName { get; }
        public ReadOnlyCollection<CharacterCustomizationOptionColorOptionsEntryWithMultipleValues> Options { get; }

        [JsonConstructor]
        internal CharacterCustomizationOptionColorOptionsWithMultipleValues(uint customizationCategoryHash, string displayName, CharacterCustomizationOptionColorOptionsEntryWithMultipleValues[] options)
        {
            CustomizationCategory = new DefinitionHashPointer<DestinyCharacterCustomizationCategoryDefinition>(customizationCategoryHash, DefinitionsEnum.DestinyCharacterCustomizationCategoryDefinition);
            DisplayName = displayName;
            Options = options.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(CharacterCustomizationOptionColorOptionsWithMultipleValues other)
        {
            return other != null &&
                CustomizationCategory.DeepEquals(other.CustomizationCategory) &&
                DisplayName == other.DisplayName &&
                Options.DeepEqualsReadOnlyCollections(other.Options);
        }
    }
}
