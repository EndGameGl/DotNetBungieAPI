using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ProgressionMappings
{
    [DestinyDefinition(name: "DestinyProgressionMappingDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyProgressionMappingDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string DisplayUnits { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyProgressionMappingDefinition(DestinyDefinitionDisplayProperties displayProperties, string displayUnits, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            DisplayUnits = displayUnits;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
