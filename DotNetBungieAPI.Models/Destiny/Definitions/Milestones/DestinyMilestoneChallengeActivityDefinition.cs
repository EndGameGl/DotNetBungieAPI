using DotNetBungieAPI.Models.Destiny.Definitions.Activities;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

public sealed record DestinyMilestoneChallengeActivityDefinition
    : IDeepEquatable<DestinyMilestoneChallengeActivityDefinition>
{
    /// <summary>
    ///     The activity for which this challenge is active.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     If the activity and its challenge is visible on any of these nodes, it will be returned.
    /// </summary>
    [JsonPropertyName("activityGraphNodes")]
    public ReadOnlyCollection<DestinyMilestoneChallengeActivityGraphNodeEntry> ActivityGraphNodes { get; init; } =
        ReadOnlyCollection<DestinyMilestoneChallengeActivityGraphNodeEntry>.Empty;

    [JsonPropertyName("challenges")]
    public ReadOnlyCollection<DestinyMilestoneChallengeDefinition> Challenges { get; init; } =
        ReadOnlyCollection<DestinyMilestoneChallengeDefinition>.Empty;

    /// <summary>
    ///     Phases related to this activity, if there are any.
    ///     <para />
    ///     These will be listed in the order in which they will appear in the actual activity.
    /// </summary>
    [JsonPropertyName("phases")]
    public ReadOnlyCollection<DestinyMilestoneChallengeActivityPhase> Phases { get; init; } =
        ReadOnlyCollection<DestinyMilestoneChallengeActivityPhase>.Empty;

    public bool DeepEquals(DestinyMilestoneChallengeActivityDefinition other)
    {
        return other != null
            && ActivityGraphNodes.DeepEqualsReadOnlyCollection(other.ActivityGraphNodes)
            && Activity.DeepEquals(other.Activity)
            && Challenges.DeepEqualsReadOnlyCollection(other.Challenges)
            && Phases.DeepEqualsReadOnlyCollection(other.Phases);
    }
}
