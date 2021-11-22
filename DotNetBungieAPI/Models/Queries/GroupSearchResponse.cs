using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record GroupSearchResponse : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupV2Card> Results { get; init; } = ReadOnlyCollections<GroupV2Card>.Empty;
    }
}