using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public sealed record SearchResultOfGroupPotentialMembership : SearchResultBase
{
    [JsonPropertyName("results")]
    public ReadOnlyCollection<GroupPotentialMembership> Results { get; init; } =
        ReadOnlyCollection<GroupPotentialMembership>.Empty;
}
