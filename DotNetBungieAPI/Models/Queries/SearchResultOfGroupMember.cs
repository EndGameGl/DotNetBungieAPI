using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupMember : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMember> Results { get; init; } = ReadOnlyCollections<GroupMember>.Empty;
    }
}