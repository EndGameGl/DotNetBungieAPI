using NetBungieAPI.Models.GroupsV2;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupPotentialMembership : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupPotentialMembership> Results { get; init; } = Defaults.EmptyReadOnlyCollection<GroupPotentialMembership>();
    }
}
