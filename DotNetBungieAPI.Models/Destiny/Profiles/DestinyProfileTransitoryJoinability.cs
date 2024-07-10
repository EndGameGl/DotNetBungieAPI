namespace DotNetBungieAPI.Models.Destiny.Profiles;

/// <summary>
///     Some basic information about whether you can be joined, how many slots are left etc. Note that this can change
///     quickly, so it may not actually be useful. But perhaps it will be in some use cases?
/// </summary>
public sealed record DestinyProfileTransitoryJoinability
{
    /// <summary>
    ///     The number of slots still available on this person's fireteam.
    /// </summary>
    [JsonPropertyName("openSlots")]
    public int OpenSlots { get; init; }

    /// <summary>
    ///     Who the person is currently allowing invites from.
    /// </summary>
    [JsonPropertyName("privacySetting")]
    public DestinyGamePrivacySetting PrivacySetting { get; init; }

    /// <summary>
    ///     Reasons why a person can't join this person's fireteam.
    /// </summary>
    [JsonPropertyName("closedReasons")]
    public DestinyJoinClosedReasons ClosedReasons { get; init; }
}
