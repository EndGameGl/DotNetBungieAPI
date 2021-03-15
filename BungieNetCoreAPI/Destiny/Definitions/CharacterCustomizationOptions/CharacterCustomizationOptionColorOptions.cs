using NetBungieAPI.Destiny.Definitions.CharacterCustomizationCategories;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class CharacterCustomizationOptionColorOptions : IDeepEquatable<CharacterCustomizationOptionColorOptions>
    {
        public DefinitionHashPointer<DestinyCharacterCustomizationCategoryDefinition> CustomizationCategory { get; }
        public string DisplayName { get; }
        public ReadOnlyCollection<CharacterCustomizationOptionColorOptionsEntry> Options { get; }

        [JsonConstructor]
        internal CharacterCustomizationOptionColorOptions(uint customizationCategoryHash, string displayName, CharacterCustomizationOptionColorOptionsEntry[] options)
        {
            CustomizationCategory = new DefinitionHashPointer<DestinyCharacterCustomizationCategoryDefinition>(customizationCategoryHash, DefinitionsEnum.DestinyCharacterCustomizationCategoryDefinition);
            DisplayName = displayName;
            Options = options.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(CharacterCustomizationOptionColorOptions other)
        {
            return other != null &&
                   CustomizationCategory.DeepEquals(other.CustomizationCategory) &&
                   DisplayName == other.DisplayName &&
                   Options.DeepEqualsReadOnlyCollections(other.Options);
        }
    }
}
