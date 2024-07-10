namespace DotNetBungieAPI.Models.User;

public sealed record HardLinkedUserMembership
{
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    [JsonPropertyName("membershipId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long MembershipId { get; init; }

    [JsonPropertyName("CrossSaveOverriddenType")]
    public BungieMembershipType CrossSaveOverriddenType { get; init; }

    [JsonPropertyName("CrossSaveOverriddenMembershipId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? CrossSaveOverriddenMembershipId { get; init; }
}
