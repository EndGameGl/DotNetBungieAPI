using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;

namespace DotNetBungieAPI.Models.Destiny.Milestones;

/// <summary>
///     Represents a variant of an activity that's relevant to a milestone.
/// </summary>
public sealed record DestinyPublicMilestoneActivityVariant
{
    /// <summary>
    ///     The hash identifier of this activity variant. Examine the activity's definition in the Manifest database to
    ///     determine what makes it a distinct variant. Usually it will be difficulty level or whether or not it is a guided
    ///     game variant of the activity, but theoretically it could be distinguished in any arbitrary way.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     The hash identifier of the most specific Activity Mode under which this activity is played. This is useful for
    ///     situations where the activity in question is - for instance - a PVP map, but it's not clear what mode the PVP map
    ///     is being played under. If it's a playlist, this will be less specific: but hopefully useful in some way.
    /// </summary>
    [JsonPropertyName("activityModeHash")]
    public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; init; } =
        DefinitionHashPointer<DestinyActivityModeDefinition>.Empty;

    /// <summary>
    ///     The enumeration equivalent of the most specific Activity Mode under which this activity is played.
    /// </summary>
    [JsonPropertyName("activityModeType")]
    public DestinyActivityModeType? ActivityModeType { get; init; }
}
