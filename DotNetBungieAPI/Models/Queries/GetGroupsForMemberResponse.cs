using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record GetGroupsForMemberResponse : SearchResultBase
    {
        [JsonPropertyName("areAllMembershipsInactive")]
        public ReadOnlyDictionary<long, bool> AreAllMembershipsInactive { get; init; } =
            ReadOnlyDictionaries<long, bool>.Empty;

        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMembership> Results { get; init; } = ReadOnlyCollections<GroupMembership>.Empty;
    }
}