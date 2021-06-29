using System.Text.Json.Serialization;
using NetBungieAPI.Models.Queries;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingCategory
    {
        [JsonPropertyName("categoryName")] public string CategoryName { get; init; }

        [JsonPropertyName("entries")] public SearchResultOfTrendingEntry Entries { get; init; }

        [JsonPropertyName("categoryId")] public string CategoryId { get; init; }
    }
}