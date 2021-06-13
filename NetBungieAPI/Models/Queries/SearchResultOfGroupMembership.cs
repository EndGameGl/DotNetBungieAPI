using NetBungieAPI.Models.GroupsV2;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupMembership : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMembership> Results { get; init; } = Defaults.EmptyReadOnlyCollection<GroupMembership>();
    }
}
