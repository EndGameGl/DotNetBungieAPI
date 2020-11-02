using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Destinations
{
    public class DestinationBubbleEntry
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint Hash { get; }

        [JsonConstructor]
        private DestinationBubbleEntry(DestinyDefinitionDisplayProperties displayProperties, uint hash)
        {
            DisplayProperties = displayProperties;
            Hash = hash;
        }
        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }
    }
}
