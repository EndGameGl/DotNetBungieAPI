namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupPotentialMember
{
    [JsonPropertyName("potentialStatus")]
    public GroupsV2.GroupPotentialMemberStatus PotentialStatus { get; init; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard? DestinyUserInfo { get; init; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard? BungieNetUserInfo { get; init; }

    [JsonPropertyName("joinDate")]
    public DateTime JoinDate { get; init; }
}
