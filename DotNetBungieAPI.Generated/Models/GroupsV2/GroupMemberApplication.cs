using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupMemberApplication
{

    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; init; }

    [JsonPropertyName("resolveState")]
    public GroupsV2.GroupApplicationResolveState ResolveState { get; init; }

    [JsonPropertyName("resolveDate")]
    public DateTime? ResolveDate { get; init; }

    [JsonPropertyName("resolvedByMembershipId")]
    public long? ResolvedByMembershipId { get; init; }

    [JsonPropertyName("requestMessage")]
    public string RequestMessage { get; init; }

    [JsonPropertyName("resolveMessage")]
    public string ResolveMessage { get; init; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard DestinyUserInfo { get; init; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; init; }
}
