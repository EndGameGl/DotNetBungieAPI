namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupUserBase
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard? DestinyUserInfo { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard? BungieNetUserInfo { get; set; }

    [JsonPropertyName("joinDate")]
    public DateTime JoinDate { get; set; }
}
