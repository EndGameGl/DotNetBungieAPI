using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public sealed record UserSearchResponse
    {
        [JsonPropertyName("searchResults")]
        public ReadOnlyCollection<UserSearchResponseDetail> SearchResults { get; init; } =
            Defaults.EmptyReadOnlyCollection<UserSearchResponseDetail>();

        [JsonPropertyName("page")] public int Page { get; init; }

        [JsonPropertyName("hasMore")] public bool HasMore { get; init; }
    }
}