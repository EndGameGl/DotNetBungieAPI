using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Activities
{
    /// <summary>
    /// If the activity is a playlist, this is the definition for a specific entry in the playlist: a single possible combination of Activity and Activity Mode that can be chosen.
    /// </summary>
    public sealed record DestinyActivityPlaylistItemDefinition : IDeepEquatable<DestinyActivityPlaylistItemDefinition>
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("directActivityModeHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> DirectActivityMode { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("directActivityModeType")]
        public DestinyActivityModeType? DirectActivityModeType { get; init; }
        [JsonPropertyName("activityModeHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>> ActivityModes { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>>();
        [JsonPropertyName("activityModeTypes")]
        public ReadOnlyCollection<DestinyActivityModeType> ActivityModeTypes { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyActivityModeType>();
        [JsonPropertyName("weight")]
        public int Weight { get; init; }

        public bool DeepEquals(DestinyActivityPlaylistItemDefinition other)
        {
            return other != null &&
                   Activity.DeepEquals(other.Activity) &&
                   ActivityModes.DeepEqualsReadOnlyCollections(other.ActivityModes) &&
                   ActivityModeTypes.DeepEqualsReadOnlySimpleCollection(other.ActivityModeTypes) &&
                   DirectActivityMode.DeepEquals(other.DirectActivityMode) &&
                   DirectActivityModeType == other.DirectActivityModeType &&
                   Weight == other.Weight;
        }
    }
}
