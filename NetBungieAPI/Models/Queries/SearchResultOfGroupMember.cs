using NetBungieAPI.Models.GroupsV2;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupMember : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupMember> Results { get; init; } = Defaults.EmptyReadOnlyCollection<GroupMember>();
    }
}
