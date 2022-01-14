namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

/// <summary>
///     Some basic information about whether you can be joined, how many slots are left etc. Note that this can change quickly, so it may not actually be useful. But perhaps it will be in some use cases?
/// </summary>
public sealed class DestinyProfileTransitoryJoinability
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
    public Destiny.DestinyGamePrivacySetting PrivacySetting { get; init; }

    /// <summary>
    ///     Reasons why a person can't join this person's fireteam.
    /// </summary>
    [JsonPropertyName("closedReasons")]
    public Destiny.DestinyJoinClosedReasons ClosedReasons { get; init; }
}
