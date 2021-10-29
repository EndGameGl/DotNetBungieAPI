using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupPotentialMembership : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupPotentialMembership> Results { get; init; } =
            ReadOnlyCollections<GroupPotentialMembership>.Empty;
    }
}