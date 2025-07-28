namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     A Milestone can have many Challenges. Challenges are just extra Objectives that provide a fun way to mix-up play and provide extra rewards.
/// </summary>
public class DestinyPublicMilestoneChallenge
{
    /// <summary>
    ///     The objective for the Challenge, which should have human-readable data about what needs to be done to accomplish the objective. Use this hash to look up the DestinyObjectiveDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; set; }

    /// <summary>
    ///     IF the Objective is related to a specific Activity, this will be that activity's hash. Use it to look up the DestinyActivityDefinition for additional data to show.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }
}
