using NetBungieAPI.Models.Destiny.Definitions.Activities;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public sealed record DestinyMilestoneChallengeActivityDefinition : IDeepEquatable<DestinyMilestoneChallengeActivityDefinition>
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("activityGraphNodes")]
        public ReadOnlyCollection<DestinyMilestoneChallengeActivityGraphNodeEntry> ActivityGraphNodes { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneChallengeActivityGraphNodeEntry>();
        [JsonPropertyName("challenges")]
        public ReadOnlyCollection<DestinyMilestoneChallengeDefinition> Challenges { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneChallengeDefinition>();
        [JsonPropertyName("phases")]
        public ReadOnlyCollection<DestinyMilestoneChallengeActivityPhase> Phases { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneChallengeActivityPhase>();

        public bool DeepEquals(DestinyMilestoneChallengeActivityDefinition other)
        {
            return other != null &&
                   ActivityGraphNodes.DeepEqualsReadOnlyCollections(other.ActivityGraphNodes) &&
                   Activity.DeepEquals(other.Activity) &&
                   Challenges.DeepEqualsReadOnlyCollections(other.Challenges) &&
                   Phases.DeepEqualsReadOnlyCollections(other.Phases);
        }
    }
}
