using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupMemberApplication : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMemberApplication> Results { get; init; } =
            ReadOnlyCollections<GroupMemberApplication>.Empty;
    }
}