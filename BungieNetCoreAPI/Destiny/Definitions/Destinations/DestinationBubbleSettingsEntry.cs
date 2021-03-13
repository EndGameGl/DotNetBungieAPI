using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Destinations
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
