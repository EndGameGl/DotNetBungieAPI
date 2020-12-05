using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Locations
{
    public class LocationRelease
    {
        public uint ActivityBubbleName { get; }
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }
        public uint ActivityGraphNodeHash { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public uint ActivityPathBundle { get; }
        public uint ActivityPathDestination { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ActivityNavPointType NavPointType { get; }
        public uint SpawnPoint { get; }
        public List<int> WorldPosition { get; }

        [JsonConstructor]
        private LocationRelease(uint activityBubbleName, uint activityGraphHash, uint activityGraphNodeHash, uint activityHash, uint activityPathBundle,
            uint activityPathDestination, uint destinationHash, DestinyDefinitionDisplayProperties displayProperties, ActivityNavPointType navPointType, uint spawnPoint,
            List<int> worldPosition)
        {
            ActivityBubbleName = activityBubbleName;
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, "DestinyActivityGraphDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            ActivityGraphNodeHash = activityGraphNodeHash;
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, "DestinyActivityDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            ActivityPathBundle = activityPathBundle;
            ActivityPathDestination = activityPathDestination;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, "DestinyDestinationDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            DisplayProperties = displayProperties;
            NavPointType = navPointType;
            SpawnPoint = spawnPoint;
            WorldPosition = worldPosition;
        }
    }
}
