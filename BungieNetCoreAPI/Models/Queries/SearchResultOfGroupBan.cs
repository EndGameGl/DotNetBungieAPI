using NetBungieAPI.Models.GroupsV2;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfGroupBan : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupBan> Results { get; init; } = Defaults.EmptyReadOnlyCollection<GroupBan>();
    }
}
