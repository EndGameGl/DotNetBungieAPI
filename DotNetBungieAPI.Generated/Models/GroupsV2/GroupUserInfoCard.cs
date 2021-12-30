using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupUserInfoCard
{

    /// <summary>
    ///     This will be the display name the clan server last saw the user as. If the account is an active cross save override, this will be the display name to use. Otherwise, this will match the displayName property.
    /// </summary>
    [JsonPropertyName("LastSeenDisplayName")]
    public string LastSeenDisplayName { get; init; }

    /// <summary>
    ///     The platform of the LastSeenDisplayName
    /// </summary>
    [JsonPropertyName("LastSeenDisplayNameType")]
    public BungieMembershipType LastSeenDisplayNameType { get; init; }

    /// <summary>
    ///     A platform specific additional display name - ex: psn Real Name, bnet Unique Name, etc.
    /// </summary>
    [JsonPropertyName("supplementalDisplayName")]
    public string SupplementalDisplayName { get; init; }

    /// <summary>
    ///     URL the Icon if available.
    /// </summary>
    [JsonPropertyName("iconPath")]
    public string IconPath { get; init; }

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
    public List<BungieMembershipType> ApplicableMembershipTypes { get; init; }

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
