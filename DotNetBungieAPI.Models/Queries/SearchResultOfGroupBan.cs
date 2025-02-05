using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public sealed record SearchResultOfGroupBan : SearchResultBase
{
    [JsonPropertyName("results")]
    public ReadOnlyCollection<GroupBan> Results { get; init; } =
        ReadOnlyCollection<GroupBan>.Empty;
}
