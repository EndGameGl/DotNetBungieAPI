using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     A Milestone can have many Challenges. Challenges are just extra Objectives that provide a fun way to mix-up play and provide extra rewards.
/// </summary>
public sealed class DestinyPublicMilestoneChallenge
{

    /// <summary>
    ///     The objective for the Challenge, which should have human-readable data about what needs to be done to accomplish the objective. Use this hash to look up the DestinyObjectiveDefinition.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; init; } // DestinyObjectiveDefinition

    /// <summary>
    ///     IF the Objective is related to a specific Activity, this will be that activity's hash. Use it to look up the DestinyActivityDefinition for additional data to show.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; init; } // DestinyActivityDefinition
}
