using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.Places;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Destinations
{
    [DestinyDefinition(name: "DestinyDestinationDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyDestinationDefinition : DestinyDefinition
    {
        public List<DestinationActivityGraphEntry> ActivityGraphEntries { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> DefaultFreeroamActivity { get; }
        public List<DestinationBubbleEntry> Bubbles { get; }
        public List<DestinationBubbleSettingsEntry> BubbleSettings { get; }
        public DefinitionHashPointer<DestinyPlaceDefinition> Place { get; }

        [JsonConstructor]
        private DestinyDestinationDefinition(DestinyDefinitionDisplayProperties displayProperties, List<DestinationActivityGraphEntry> activityGraphEntries, uint defaultFreeroamActivityHash,
            List<DestinationBubbleEntry> bubbles, List<DestinationBubbleSettingsEntry> bubbleSettings, uint? placeHash,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            if (activityGraphEntries == null)
                ActivityGraphEntries = new List<DestinationActivityGraphEntry>();
            else
                ActivityGraphEntries = activityGraphEntries;
            DefaultFreeroamActivity = new DefinitionHashPointer<DestinyActivityDefinition>(defaultFreeroamActivityHash, "DestinyActivityDefinition");
            if (bubbles == null)
                Bubbles = new List<DestinationBubbleEntry>();
            else
                Bubbles = bubbles;
            if (bubbleSettings == null)
                BubbleSettings = new List<DestinationBubbleSettingsEntry>();
            else
                BubbleSettings = bubbleSettings;
            Place = new DefinitionHashPointer<DestinyPlaceDefinition>(placeHash, "DestinyPlaceDefinition");
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
