using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class CharacterCustomizationOptionColorOptionsEntryWithMultipleValues
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<uint> Value { get; }

        [JsonConstructor]
        private CharacterCustomizationOptionColorOptionsEntryWithMultipleValues(DestinyDefinitionDisplayProperties displayProperties, List<uint> value)
        {
            DisplayProperties = displayProperties;
            Value = value;
        }
    }
}
