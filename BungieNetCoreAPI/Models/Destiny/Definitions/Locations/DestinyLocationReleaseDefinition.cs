using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Locations
{
    /// <summary>
    /// A specific "spot" referred to by a location. Only one of these can be active at a time for a given Location.
    /// </summary>
    public sealed record DestinyLocationReleaseDefinition : IDeepEquatable<DestinyLocationReleaseDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("smallTransparentIcon")]
        public string SmallTransparentIcon { get; init; }
        [JsonPropertyName("mapIcon")]
        public string MapIcon { get; init; }
        [JsonPropertyName("largeTransparentIcon")]
        public string LargeTransparentIcon { get; init; }
        [JsonPropertyName("spawnPoint")]
        public uint SpawnPoint { get; init; }
        [JsonPropertyName("destinationHash")]
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; } = DefinitionHashPointer<DestinyDestinationDefinition>.Empty;
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("activityGraphHash")]
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; init; } = DefinitionHashPointer<DestinyActivityGraphDefinition>.Empty;
        [JsonPropertyName("activityGraphNodeHash")]
        public uint ActivityGraphNodeHash { get; init; }
        [JsonPropertyName("activityBubbleName")]
        public uint ActivityBubbleName { get; init; }
        [JsonPropertyName("activityPathBundle")]
        public uint ActivityPathBundle { get; init; }
        [JsonPropertyName("activityPathDestination")]
        public uint ActivityPathDestination { get; init; }
        [JsonPropertyName("navPointType")]
        public DestinyActivityNavPointType NavPointType { get; init; }
        [JsonPropertyName("worldPosition")]
        public ReadOnlyCollection<int> WorldPosition { get; init; } = Defaults.EmptyReadOnlyCollection<int>();

        public bool DeepEquals(DestinyLocationReleaseDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   SmallTransparentIcon == other.SmallTransparentIcon &&
                   MapIcon == other.MapIcon &&
                   LargeTransparentIcon == other.LargeTransparentIcon &&
                   SpawnPoint == other.SpawnPoint &&
                   Destination.DeepEquals(other.Destination) &&
                   Activity.DeepEquals(other.Activity) &&
                   ActivityGraph.DeepEquals(other.ActivityGraph) &&
                   ActivityGraphNodeHash == other.ActivityGraphNodeHash &&
                   ActivityBubbleName == other.ActivityBubbleName &&
                   ActivityPathBundle == other.ActivityPathBundle &&
                   ActivityPathDestination == other.ActivityPathDestination &&
                   NavPointType == other.NavPointType &&
                   WorldPosition.DeepEqualsReadOnlySimpleCollection(other.WorldPosition);
        }
    }
}
