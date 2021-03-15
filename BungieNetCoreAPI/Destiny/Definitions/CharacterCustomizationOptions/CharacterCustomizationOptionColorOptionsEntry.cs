using Newtonsoft.Json;
namespace NetBungieAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class CharacterCustomizationOptionColorOptionsEntry : IDeepEquatable<CharacterCustomizationOptionColorOptionsEntry>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint Value { get; }

        [JsonConstructor]
        internal CharacterCustomizationOptionColorOptionsEntry(DestinyDefinitionDisplayProperties displayProperties, uint value)
        {
            DisplayProperties = displayProperties;
            Value = value;
        }

        public bool DeepEquals(CharacterCustomizationOptionColorOptionsEntry other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Value == other.Value;
        }
    }
}
