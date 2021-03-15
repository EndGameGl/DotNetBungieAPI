using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class CharacterCustomizationOptionColorOptionsEntryWithMultipleValues : IDeepEquatable<CharacterCustomizationOptionColorOptionsEntryWithMultipleValues>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ReadOnlyCollection<uint> Value { get; }

        [JsonConstructor]
        internal CharacterCustomizationOptionColorOptionsEntryWithMultipleValues(DestinyDefinitionDisplayProperties displayProperties, uint[] value)
        {
            DisplayProperties = displayProperties;
            Value = value.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(CharacterCustomizationOptionColorOptionsEntryWithMultipleValues other)
        {
            return other != null &&
                DisplayProperties.DeepEquals(other.DisplayProperties) &&
                Value == other.Value;
        }
    }
}
