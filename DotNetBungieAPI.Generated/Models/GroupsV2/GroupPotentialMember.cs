namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupPotentialMember
{
    [JsonPropertyName("potentialStatus")]
    public GroupsV2.GroupPotentialMemberStatus PotentialStatus { get; set; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard? DestinyUserInfo { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard? BungieNetUserInfo { get; set; }

    [JsonPropertyName("joinDate")]
    public DateTime JoinDate { get; set; }
}
