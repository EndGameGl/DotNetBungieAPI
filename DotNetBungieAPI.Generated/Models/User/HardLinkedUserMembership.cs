namespace DotNetBungieAPI.Generated.Models.User;

public class HardLinkedUserMembership : IDeepEquatable<HardLinkedUserMembership>
{
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    [JsonPropertyName("CrossSaveOverriddenType")]
    public BungieMembershipType CrossSaveOverriddenType { get; set; }

    [JsonPropertyName("CrossSaveOverriddenMembershipId")]
    public long? CrossSaveOverriddenMembershipId { get; set; }

    public bool DeepEquals(HardLinkedUserMembership? other)
    {
        return other is not null &&
               MembershipType == other.MembershipType &&
               MembershipId == other.MembershipId &&
               CrossSaveOverriddenType == other.CrossSaveOverriddenType &&
               CrossSaveOverriddenMembershipId == other.CrossSaveOverriddenMembershipId;
    }
}