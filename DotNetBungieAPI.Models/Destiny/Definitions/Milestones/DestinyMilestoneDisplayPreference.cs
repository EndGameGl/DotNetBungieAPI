namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

/// <summary>
///     A hint for the UI as to what display information ought to be shown. Defaults to showing the static
///     MilestoneDefinition's display properties.
///     <para />
///     If for some reason the indicated property is not populated, fall back to the MilestoneDefinition.displayProperties.
/// </summary>
public enum DestinyMilestoneDisplayPreference
{
    /// <summary>
    ///     Indicates you should show DestinyMilestoneDefinition.displayProperties for this Milestone.
    /// </summary>
    MilestoneDefinition = 0,

    /// <summary>
    ///     Indicates you should show the displayProperties for any currently active Quest Steps in
    ///     DestinyMilestone.availableQuests.
    /// </summary>
    CurrentQuestSteps = 1,

    /// <summary>
    ///     Indicates you should show the displayProperties for any currently active Activities and their Challenges in
    ///     DestinyMilestone.activities.
    /// </summary>
    CurrentActivityChallenges = 2
}
