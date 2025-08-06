namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneChallengeActivityDefinition
{
    /// <summary>
    ///     The activity for which this challenge is active.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> ActivityHash { get; init; }

    [JsonPropertyName("challenges")]
    public Destiny.Definitions.Milestones.DestinyMilestoneChallengeDefinition[]? Challenges { get; init; }

    /// <summary>
    ///     If the activity and its challenge is visible on any of these nodes, it will be returned.
    /// </summary>
    [JsonPropertyName("activityGraphNodes")]
    public Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityGraphNodeEntry[]? ActivityGraphNodes { get; init; }

    /// <summary>
    ///     Phases related to this activity, if there are any.
    /// <para />
    ///     These will be listed in the order in which they will appear in the actual activity.
    /// </summary>
    [JsonPropertyName("phases")]
    public Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityPhase[]? Phases { get; init; }
}
