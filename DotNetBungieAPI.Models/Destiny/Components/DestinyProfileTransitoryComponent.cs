﻿using DotNetBungieAPI.Models.Destiny.Definitions.Destinations;
using DotNetBungieAPI.Models.Destiny.Profiles;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     This is an experimental set of data that Bungie considers to be "transitory" - information that may be useful for
///     API users, but that is coming from a non-authoritative data source about information that could potentially change
///     at a more frequent pace than Bungie.net will receive updates about it.
///     <para />
///     This information is provided exclusively for convenience should any of it be useful to users: we provide no
///     guarantees to the accuracy or timeliness of data that comes from this source. Know that this data can potentially
///     be out-of-date or even wrong entirely if the user disconnected from the game or suddenly changed their status
///     before we can receive refreshed data.
/// </summary>
public sealed record DestinyProfileTransitoryComponent
{
    /// <summary>
    ///     If you have any members currently in your party, this is some (very) bare-bones information about those members.
    /// </summary>
    [JsonPropertyName("partyMembers")]
    public ReadOnlyCollection<DestinyProfileTransitoryPartyMember> PartyMembers { get; init; } =
        ReadOnlyCollection<DestinyProfileTransitoryPartyMember>.Empty;

    /// <summary>
    ///     If you are in an activity, this is some transitory info about the activity currently being played.
    /// </summary>
    [JsonPropertyName("currentActivity")]
    public DestinyProfileTransitoryCurrentActivity CurrentActivity { get; init; }

    /// <summary>
    ///     Information about whether and what might prevent you from joining this person on a fireteam.
    /// </summary>
    [JsonPropertyName("joinability")]
    public DestinyProfileTransitoryJoinability JoinAbility { get; init; }

    /// <summary>
    ///     Information about tracked entities.
    /// </summary>
    [JsonPropertyName("tracking")]
    public ReadOnlyCollection<DestinyProfileTransitoryTrackingEntry> TrackedEntities { get; init; } =
        ReadOnlyCollection<DestinyProfileTransitoryTrackingEntry>.Empty;

    /// <summary>
    ///     The hash identifier for the DestinyDestinationDefinition of the last location you were orbiting when in orbit.
    /// </summary>
    [JsonPropertyName("lastOrbitedDestinationHash")]
    public DefinitionHashPointer<DestinyDestinationDefinition> LastOrbitedDestination { get; init; } =
        DefinitionHashPointer<DestinyDestinationDefinition>.Empty;
}
