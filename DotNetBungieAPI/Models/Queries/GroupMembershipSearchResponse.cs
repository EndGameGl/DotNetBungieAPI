using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public sealed record GroupMembershipSearchResponse : SearchResultBase
{
    [JsonPropertyName("results")]
    public ReadOnlyCollection<GroupMembership> Results { get; init; } = ReadOnlyCollections<GroupMembership>.Empty;
}