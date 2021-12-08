using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.GroupsV2;

public sealed record GroupMemberApplication
{
    [JsonPropertyName("groupId")] public long GroupId { get; init; }

    [JsonPropertyName("creationDate")] public DateTime CreationDate { get; init; }

    [JsonPropertyName("resolveState")] public GroupApplicationResolveState ResolveState { get; init; }

    [JsonPropertyName("resolveDate")] public DateTime? ResolveDate { get; init; }

    [JsonPropertyName("resolvedByMembershipId")]
    public long? ResolvedByMembershipId { get; init; }

    [JsonPropertyName("requestMessage")] public string RequestMessage { get; init; }

    [JsonPropertyName("resolveMessage")] public string ResolveMessage { get; init; }

    [JsonPropertyName("destinyUserInfo")] public GroupUserInfoCard DestinyUserInfo { get; init; }

    [JsonPropertyName("bungieNetUserInfo")]
    public UserInfoCard BungieNetUserInfo { get; init; }
}