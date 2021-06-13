using NetBungieAPI.Models.GroupsV2;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record GroupSearchResponse : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupV2Card> Results { get; init; } = Defaults.EmptyReadOnlyCollection<GroupV2Card>();
    }
}
