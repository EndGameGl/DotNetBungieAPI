﻿using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;

namespace DotNetBungieAPI.Models.Destiny.HistoricalStats;

/// <summary>
///     Summary information about the activity that was played.
/// </summary>
public sealed record DestinyHistoricalStatsActivity
{
    /// <summary>
    ///     The unique hash identifier of the DestinyActivityDefinition that was played. If I had this to do over, it'd be
    ///     named activityHash. Too late now.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public DefinitionHashPointer<DestinyActivityDefinition> ActivityReference { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     The unique hash identifier of the DestinyActivityDefinition that was played.
    /// </summary>
    [JsonPropertyName("directorActivityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> DirectorActivity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     The unique identifier for this *specific* match that was played.
    ///     <para />
    ///     This value can be used to get additional data about this activity such as who else was playing via the
    ///     GetPostGameCarnageReport endpoint.
    /// </summary>
    [JsonPropertyName("instanceId")]
    public long InstanceId { get; init; }

    /// <summary>
    ///     Indicates the most specific game mode of the activity that we could find.
    /// </summary>
    [JsonPropertyName("mode")]
    public DestinyActivityModeType Mode { get; init; }

    /// <summary>
    ///     The list of all Activity Modes to which this activity applies, including aggregates. This will let you see, for
    ///     example, whether the activity was both Clash and part of the Trials of the Nine event.
    /// </summary>
    [JsonPropertyName("modes")]
    public ReadOnlyCollection<DestinyActivityModeType> Modes { get; init; } =
        ReadOnlyCollection<DestinyActivityModeType>.Empty;

    /// <summary>
    ///     Whether or not the match was a private match.
    /// </summary>
    [JsonPropertyName("isPrivate")]
    public bool IsPrivate { get; init; }

    /// <summary>
    ///     The Membership Type indicating the platform on which this match was played.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
