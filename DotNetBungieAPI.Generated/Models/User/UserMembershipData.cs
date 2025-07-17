namespace DotNetBungieAPI.Generated.Models.User;

public class UserMembershipData
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

    /// <summary>
    ///     If this property is populated, it will have the membershipId for the Marathon Membership on this user's account
    /// <para />
    ///      If null, this user has no Marathon (i.e. "GoliathGame") membership.
    /// </summary>
    [JsonPropertyName("marathonMembershipId")]
    public long? MarathonMembershipId { get; set; }

    [JsonPropertyName("bungieNetUser")]
    public User.GeneralUser? BungieNetUser { get; set; }
}
