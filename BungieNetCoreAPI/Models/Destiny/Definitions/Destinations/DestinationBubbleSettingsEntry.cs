using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Destinations
{
    public class DestinationBubbleSettingsEntry
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonConstructor]
        private DestinationBubbleSettingsEntry(DestinyDisplayPropertiesDefinition displayProperties, uint hash)
        {
            DisplayProperties = displayProperties;
        }
    }
}
