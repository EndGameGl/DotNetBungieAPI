namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

/// <summary>
///     Summary information about the activity that was played.
/// </summary>
public class DestinyHistoricalStatsActivity
{
    /// <summary>
    ///     The unique hash identifier of the DestinyActivityDefinition that was played. If I had this to do over, it'd be named activityHash. Too late now.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public uint? ReferenceId { get; set; }

    /// <summary>
    ///     The unique hash identifier of the DestinyActivityDefinition that was played.
    /// </summary>
    [JsonPropertyName("directorActivityHash")]
    public uint? DirectorActivityHash { get; set; }

    /// <summary>
    ///     The unique identifier for this *specific* match that was played.
    /// <para />
    ///     This value can be used to get additional data about this activity such as who else was playing via the GetPostGameCarnageReport endpoint.
    /// </summary>
    [JsonPropertyName("instanceId")]
    public long? InstanceId { get; set; }

    /// <summary>
    ///     Indicates the most specific game mode of the activity that we could find.
    /// </summary>
    [JsonPropertyName("mode")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType? Mode { get; set; }

    /// <summary>
    ///     The list of all Activity Modes to which this activity applies, including aggregates. This will let you see, for example, whether the activity was both Clash and part of the Trials of the Nine event.
    /// </summary>
    [JsonPropertyName("modes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> Modes { get; set; }

    /// <summary>
    ///     Whether or not the match was a private match.
    /// </summary>
    [JsonPropertyName("isPrivate")]
    public bool? IsPrivate { get; set; }

    /// <summary>
    ///     The Membership Type indicating the platform on which this match was played.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType? MembershipType { get; set; }
}
