namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupMember
{
    [JsonPropertyName("memberType")]
    public GroupsV2.RuntimeGroupMemberType MemberType { get; init; }

    [JsonPropertyName("isOnline")]
    public bool IsOnline { get; init; }

    [JsonPropertyName("lastOnlineStatusChange")]
    public long LastOnlineStatusChange { get; init; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard? DestinyUserInfo { get; init; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard? BungieNetUserInfo { get; init; }

    [JsonPropertyName("joinDate")]
    public DateTime JoinDate { get; init; }
}
