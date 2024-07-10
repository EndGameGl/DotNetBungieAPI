using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public sealed record SearchResultOfGroupMembership : SearchResultBase
{
    [JsonPropertyName("results")]
    public ReadOnlyCollection<GroupMembership> Results { get; init; } =
        ReadOnlyCollections<GroupMembership>.Empty;
}
