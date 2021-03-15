using NetBungieAPI.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Activities
{
    /// <summary>
    /// If the activity is a playlist, this is the definition for a specific entry in the playlist: a single possible combination of Activity and Activity Mode that can be chosen.
    /// </summary>
    public class ActivityPlaylistItemEntry : IDeepEquatable<ActivityPlaylistItemEntry>
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>> ActivityModes { get; }
        public ReadOnlyCollection<DestinyActivityModeType> ActivityModeTypes { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> DirectActivityMode { get; }
        public DestinyActivityModeType DirectActivityModeType { get; }
        public int Weight { get; }

        [JsonConstructor]
        internal ActivityPlaylistItemEntry(uint activityHash, uint[] activityModeHashes, DestinyActivityModeType[] activityModeTypes, uint directActivityModeHash,
            DestinyActivityModeType directActivityModeType, int weight)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            ActivityModes = activityModeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModeDefinition>(DefinitionsEnum.DestinyActivityModeDefinition);
            ActivityModeTypes = activityModeTypes.AsReadOnlyOrEmpty();
            DirectActivityMode = new DefinitionHashPointer<DestinyActivityDefinition>(directActivityModeHash, DefinitionsEnum.DestinyActivityDefinition);
            DirectActivityModeType = directActivityModeType;
            Weight = weight;
        }

        public bool DeepEquals(ActivityPlaylistItemEntry other)
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
