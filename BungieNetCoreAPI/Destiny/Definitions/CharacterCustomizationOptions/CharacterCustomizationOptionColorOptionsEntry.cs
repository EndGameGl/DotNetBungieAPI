using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class CharacterCustomizationOptionColorOptionsEntry
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint Value { get; }

        [JsonConstructor]
        private CharacterCustomizationOptionColorOptionsEntry(DestinyDefinitionDisplayProperties displayProperties, uint value)
        {
            DisplayProperties = displayProperties;
            Value = value;
        }
    }
}
