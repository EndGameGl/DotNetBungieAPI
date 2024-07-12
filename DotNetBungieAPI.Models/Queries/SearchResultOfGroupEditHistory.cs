using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public sealed record SearchResultOfGroupEditHistory : SearchResultBase
{
    [JsonPropertyName("results")]
    public ReadOnlyCollection<GroupEditHistory> Results { get; init; } =
        ReadOnlyCollections<GroupEditHistory>.Empty;
}
