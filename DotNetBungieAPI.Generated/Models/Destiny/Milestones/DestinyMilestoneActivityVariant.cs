using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     Represents custom data that we know about an individual variant of an activity.
/// </summary>
public sealed class DestinyMilestoneActivityVariant
{

    /// <summary>
    ///     The hash for the specific variant of the activity related to this milestone. You can pull more detailed static info from the DestinyActivityDefinition, such as difficulty level.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; } // DestinyActivityDefinition

    /// <summary>
    ///     An OPTIONAL component: if it makes sense to talk about this activity variant in terms of whether or not it has been completed or what progress you have made in it, this will be returned. Otherwise, this will be NULL.
    /// </summary>
    [JsonPropertyName("completionStatus")]
    public Destiny.Milestones.DestinyMilestoneActivityCompletionStatus CompletionStatus { get; init; }

    /// <summary>
    ///     The hash identifier of the most specific Activity Mode under which this activity is played. This is useful for situations where the activity in question is - for instance - a PVP map, but it's not clear what mode the PVP map is being played under. If it's a playlist, this will be less specific: but hopefully useful in some way.
    /// </summary>
    [JsonPropertyName("activityModeHash")]
    public uint? ActivityModeHash { get; init; } // DestinyActivityModeDefinition

    /// <summary>
    ///     The enumeration equivalent of the most specific Activity Mode under which this activity is played.
    /// </summary>
    [JsonPropertyName("activityModeType")]
    public int? ActivityModeType { get; init; }
}
