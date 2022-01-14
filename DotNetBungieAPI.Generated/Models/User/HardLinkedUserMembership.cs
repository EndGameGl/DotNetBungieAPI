namespace DotNetBungieAPI.Generated.Models.User;

public sealed class HardLinkedUserMembership
{

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    [JsonPropertyName("CrossSaveOverriddenType")]
    public BungieMembershipType CrossSaveOverriddenType { get; init; }

    [JsonPropertyName("CrossSaveOverriddenMembershipId")]
    public long? CrossSaveOverriddenMembershipId { get; init; }
}
