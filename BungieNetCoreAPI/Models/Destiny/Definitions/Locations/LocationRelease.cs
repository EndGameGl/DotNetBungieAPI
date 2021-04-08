using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.ActivityGraphs;
using NetBungieAPI.Destiny.Definitions.Destinations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Locations
{
    /// <summary>
    /// A specific "spot" referred to by a location. Only one of these can be active at a time for a given Location.
    /// </summary>
    public class LocationRelease : IDeepEquatable<LocationRelease>
    {
        public uint ActivityBubbleName { get; init; }
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; init; }
        public uint ActivityGraphNodeHash { get; init; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        public uint ActivityPathBundle { get; init; }
        public uint ActivityPathDestination { get; init; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public ActivityNavPointType NavPointType { get; init; }
        public uint SpawnPoint { get; init; }
        public ReadOnlyCollection<int> WorldPosition { get; init; }

        [JsonConstructor]
        internal LocationRelease(uint activityBubbleName, uint activityGraphHash, uint activityGraphNodeHash, uint activityHash, uint activityPathBundle,
            uint activityPathDestination, uint destinationHash, DestinyDisplayPropertiesDefinition displayProperties, ActivityNavPointType navPointType, uint spawnPoint,
            int[] worldPosition)
        {
            ActivityBubbleName = activityBubbleName;
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, DefinitionsEnum.DestinyActivityGraphDefinition);
            ActivityGraphNodeHash = activityGraphNodeHash;
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            ActivityPathBundle = activityPathBundle;
            ActivityPathDestination = activityPathDestination;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, DefinitionsEnum.DestinyDestinationDefinition);
            DisplayProperties = displayProperties;
            NavPointType = navPointType;
            SpawnPoint = spawnPoint;
            WorldPosition = worldPosition.AsReadOnlyOrEmpty();
        }
        public bool DeepEquals(LocationRelease other)
        {
            return other != null &&
                   ActivityBubbleName == other.ActivityBubbleName &&
                   ActivityGraph.DeepEquals(other.ActivityGraph) &&
                   ActivityGraphNodeHash == other.ActivityGraphNodeHash &&
                   Activity.DeepEquals(other.Activity) &&
                   ActivityPathBundle == other.ActivityPathBundle &&
                   ActivityPathDestination == other.ActivityPathDestination &&
                   Destination.DeepEquals(other.Destination) &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   NavPointType == other.NavPointType &&
                   SpawnPoint == other.SpawnPoint &&
                   WorldPosition.DeepEqualsReadOnlySimpleCollection(other.WorldPosition);
        }
    }
}
