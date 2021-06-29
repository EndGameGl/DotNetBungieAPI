using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupBan : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupBan> Results { get; init; } = Defaults.EmptyReadOnlyCollection<GroupBan>();
    }
}