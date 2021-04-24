using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.Queries
{
    public sealed record GroupPotentialMembershipSearchResponse : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupPotentialMembership> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<GroupPotentialMembership>();
    }
}