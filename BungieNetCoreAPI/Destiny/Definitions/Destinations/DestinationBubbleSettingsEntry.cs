using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Destinations
{
    public class DestinationBubbleSettingsEntry
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }

        [JsonConstructor]
        private DestinationBubbleSettingsEntry(DestinyDefinitionDisplayProperties displayProperties, uint hash)
        {
            DisplayProperties = displayProperties;
        }
    }
}
