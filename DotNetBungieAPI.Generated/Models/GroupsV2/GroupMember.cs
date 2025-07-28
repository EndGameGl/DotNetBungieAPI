namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMember
{
    [JsonPropertyName("memberType")]
    public GroupsV2.RuntimeGroupMemberType MemberType { get; set; }

    [JsonPropertyName("isOnline")]
    public bool IsOnline { get; set; }

    [JsonPropertyName("lastOnlineStatusChange")]
    public long LastOnlineStatusChange { get; set; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard? DestinyUserInfo { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard? BungieNetUserInfo { get; set; }

    [JsonPropertyName("joinDate")]
    public DateTime JoinDate { get; set; }
}
