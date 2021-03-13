using NetBungieApi.Destiny.Definitions.Activities;
using NetBungieApi.Destiny.Definitions.ActivityGraphs;
using NetBungieApi.Destiny.Definitions.Destinations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Locations
{
    /// <summary>
    /// A specific "spot" referred to by a location. Only one of these can be active at a time for a given Location.
    /// </summary>
    public class LocationRelease : IDeepEquatable<LocationRelease>
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
        public ReadOnlyCollection<int> WorldPosition { get; }

        [JsonConstructor]
        internal LocationRelease(uint activityBubbleName, uint activityGraphHash, uint activityGraphNodeHash, uint activityHash, uint activityPathBundle,
            uint activityPathDestination, uint destinationHash, DestinyDefinitionDisplayProperties displayProperties, ActivityNavPointType navPointType, uint spawnPoint,
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
