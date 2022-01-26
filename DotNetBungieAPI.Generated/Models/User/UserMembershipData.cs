namespace DotNetBungieAPI.Generated.Models.User;

public class UserMembershipData : IDeepEquatable<UserMembershipData>
{
    /// <summary>
    ///     this allows you to see destiny memberships that are visible and linked to this account (regardless of whether or not they have characters on the world server)
    /// </summary>
    [JsonPropertyName("destinyMemberships")]
    public List<GroupsV2.GroupUserInfoCard> DestinyMemberships { get; set; }

    /// <summary>
    ///     If this property is populated, it will have the membership ID of the account considered to be "primary" in this user's cross save relationship.
    /// <para />
    ///      If null, this user has no cross save relationship, nor primary account.
    /// </summary>
    [JsonPropertyName("primaryMembershipId")]
    public long? PrimaryMembershipId { get; set; }

    [JsonPropertyName("bungieNetUser")]
    public User.GeneralUser BungieNetUser { get; set; }

    public bool DeepEquals(UserMembershipData? other)
    {
        return other is not null &&
               DestinyMemberships.DeepEqualsList(other.DestinyMemberships) &&
               PrimaryMembershipId == other.PrimaryMembershipId &&
               (BungieNetUser is not null ? BungieNetUser.DeepEquals(other.BungieNetUser) : other.BungieNetUser is null);
    }
}