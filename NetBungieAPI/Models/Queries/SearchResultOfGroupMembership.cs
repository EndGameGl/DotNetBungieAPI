using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupMembership : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMembership> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<GroupMembership>();
    }
}