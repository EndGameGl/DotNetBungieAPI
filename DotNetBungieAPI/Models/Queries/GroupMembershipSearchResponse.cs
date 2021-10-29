using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record GroupMembershipSearchResponse : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMembership> Results { get; init; } = ReadOnlyCollections<GroupMembership>.Empty;
    }
}