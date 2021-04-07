using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public class PagedQuery
    {
        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; init; }

        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; init; }

        [JsonPropertyName("requestContinuationToken")]
        public string RequestContinuationToken { get; init; }
    }
}
