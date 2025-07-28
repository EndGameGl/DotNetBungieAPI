namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     Represents a variant of an activity that's relevant to a milestone.
/// </summary>
public class DestinyPublicMilestoneActivityVariant
{
    /// <summary>
    ///     The hash identifier of this activity variant. Examine the activity's definition in the Manifest database to determine what makes it a distinct variant. Usually it will be difficulty level or whether or not it is a guided game variant of the activity, but theoretically it could be distinguished in any arbitrary way.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     The hash identifier of the most specific Activity Mode under which this activity is played. This is useful for situations where the activity in question is - for instance - a PVP map, but it's not clear what mode the PVP map is being played under. If it's a playlist, this will be less specific: but hopefully useful in some way.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityModeDefinition>("Destiny.Definitions.DestinyActivityModeDefinition")]
    [JsonPropertyName("activityModeHash")]
    public uint? ActivityModeHash { get; set; }

    /// <summary>
    ///     The enumeration equivalent of the most specific Activity Mode under which this activity is played.
    /// </summary>
    [JsonPropertyName("activityModeType")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType? ActivityModeType { get; set; }
}
