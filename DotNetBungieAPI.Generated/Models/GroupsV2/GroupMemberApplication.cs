namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMemberApplication
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("resolveState")]
    public GroupsV2.GroupApplicationResolveState ResolveState { get; set; }

    [JsonPropertyName("resolveDate")]
    public DateTime ResolveDate { get; set; }

    [JsonPropertyName("resolvedByMembershipId")]
    public long ResolvedByMembershipId { get; set; }

    [JsonPropertyName("requestMessage")]
    public string RequestMessage { get; set; }

    [JsonPropertyName("resolveMessage")]
    public string ResolveMessage { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard DestinyUserInfo { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }
}
