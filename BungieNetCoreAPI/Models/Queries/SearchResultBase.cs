using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public abstract record SearchResultBase
    {
        [JsonPropertyName("totalResults")]
        public int TotalResults { get; init; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; init; }

        [JsonPropertyName("query")]
        public PagedQuery Query { get; init; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; init; }

        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; init; }
    }
}
