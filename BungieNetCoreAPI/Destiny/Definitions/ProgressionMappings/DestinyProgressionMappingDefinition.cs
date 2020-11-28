using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ProgressionMappings
{
    public class DestinyProgressionMappingDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string DisplayUnits { get; }

        [JsonConstructor]
        private DestinyProgressionMappingDefinition(DestinyDefinitionDisplayProperties displayProperties, string displayUnits, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            DisplayUnits = displayUnits;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
