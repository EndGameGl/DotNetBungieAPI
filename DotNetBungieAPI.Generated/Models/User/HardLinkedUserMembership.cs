namespace DotNetBungieAPI.Generated.Models.User;

public class HardLinkedUserMembership
{
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    [JsonPropertyName("CrossSaveOverriddenType")]
    public BungieMembershipType CrossSaveOverriddenType { get; set; }

    [JsonPropertyName("CrossSaveOverriddenMembershipId")]
    public long CrossSaveOverriddenMembershipId { get; set; }
}
