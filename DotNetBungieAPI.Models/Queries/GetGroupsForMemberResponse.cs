using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public sealed record GetGroupsForMemberResponse : SearchResultBase
{
    [JsonPropertyName("areAllMembershipsInactive")]
    public ReadOnlyDictionary<long, bool> AreAllMembershipsInactive { get; init; } =
        ReadOnlyDictionary<long, bool>.Empty;

    [JsonPropertyName("results")]
    public ReadOnlyCollection<GroupMembership> Results { get; init; } =
        ReadOnlyCollection<GroupMembership>.Empty;
}
