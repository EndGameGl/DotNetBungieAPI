using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupMember : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMember> Results { get; init; } = Defaults.EmptyReadOnlyCollection<GroupMember>();
    }
}