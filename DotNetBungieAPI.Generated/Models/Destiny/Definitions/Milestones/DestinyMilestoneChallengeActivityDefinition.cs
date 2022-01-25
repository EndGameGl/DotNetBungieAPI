namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeActivityDefinition
{
    /// <summary>
    ///     The activity for which this challenge is active.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeDefinition> Challenges { get; set; }

    /// <summary>
    ///     If the activity and its challenge is visible on any of these nodes, it will be returned.
    /// </summary>
    [JsonPropertyName("activityGraphNodes")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityGraphNodeEntry> ActivityGraphNodes { get; set; }

    /// <summary>
    ///     Phases related to this activity, if there are any.
    /// <para />
    ///     These will be listed in the order in which they will appear in the actual activity.
    /// </summary>
    [JsonPropertyName("phases")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityPhase> Phases { get; set; }
}
