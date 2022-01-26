namespace DotNetBungieAPI.Generated.Models.User;

public class UserSearchResponseDetail : IDeepEquatable<UserSearchResponseDetail>
{
    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long? BungieNetMembershipId { get; set; }

    [JsonPropertyName("destinyMemberships")]
    public List<User.UserInfoCard> DestinyMemberships { get; set; }

    public bool DeepEquals(UserSearchResponseDetail? other)
    {
        return other is not null &&
               BungieGlobalDisplayName == other.BungieGlobalDisplayName &&
               BungieGlobalDisplayNameCode == other.BungieGlobalDisplayNameCode &&
               BungieNetMembershipId == other.BungieNetMembershipId &&
               DestinyMemberships.DeepEqualsList(other.DestinyMemberships);
    }
}