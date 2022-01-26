namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMemberApplication : IDeepEquatable<GroupMemberApplication>
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("resolveState")]
    public GroupsV2.GroupApplicationResolveState ResolveState { get; set; }

    [JsonPropertyName("resolveDate")]
    public DateTime? ResolveDate { get; set; }

    [JsonPropertyName("resolvedByMembershipId")]
    public long? ResolvedByMembershipId { get; set; }

    [JsonPropertyName("requestMessage")]
    public string RequestMessage { get; set; }

    [JsonPropertyName("resolveMessage")]
    public string ResolveMessage { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard DestinyUserInfo { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }

    public bool DeepEquals(GroupMemberApplication? other)
    {
        return other is not null &&
               GroupId == other.GroupId &&
               CreationDate == other.CreationDate &&
               ResolveState == other.ResolveState &&
               ResolveDate == other.ResolveDate &&
               ResolvedByMembershipId == other.ResolvedByMembershipId &&
               RequestMessage == other.RequestMessage &&
               ResolveMessage == other.ResolveMessage &&
               (DestinyUserInfo is not null ? DestinyUserInfo.DeepEquals(other.DestinyUserInfo) : other.DestinyUserInfo is null) &&
               (BungieNetUserInfo is not null ? BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo) : other.BungieNetUserInfo is null);
    }
}