namespace DotNetBungieAPI.Models.User;

/// <summary>
///     Very basic info about a user as returned by the Account server, but including CrossSave information. Do NOT use as a request contract.
/// </summary>
public sealed class CrossSaveUserMembership
{
    /// <summary>
    ///     If there is a cross save override in effect, this value will tell you the type that is overridding this one.
    /// </summary>
    [JsonPropertyName("crossSaveOverride")]
    public BungieMembershipType CrossSaveOverride { get; init; }

    /// <summary>
    ///     The list of Membership Types indicating the platforms on which this Membership can be used.
    /// <para />
    ///      Not in Cross Save = its original membership type. Cross Save Primary = Any membership types it is overridding, and its original membership type Cross Save Overridden = Empty list
    /// </summary>
    [JsonPropertyName("applicableMembershipTypes")]
    public BungieMembershipType[]? ApplicableMembershipTypes { get; init; }

    /// <summary>
    ///     If True, this is a public user membership.
    /// </summary>
    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; init; }

    /// <summary>
    ///     Type of the membership. Not necessarily the native type.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    /// <summary>
    ///     Membership ID as they user is known in the Accounts service
    /// </summary>
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    /// <summary>
    ///     Display Name the player has chosen for themselves. The display name is optional when the data type is used as input to a platform API.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    /// <summary>
    ///     The bungie global display name, if set.
    /// </summary>
    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; init; }

    /// <summary>
    ///     The bungie global display name code, if set.
    /// </summary>
    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; init; }
}
