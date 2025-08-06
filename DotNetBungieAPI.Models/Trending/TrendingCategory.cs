namespace DotNetBungieAPI.Models.Trending;

public sealed class TrendingCategory
{
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

    [JsonPropertyName("entries")]
    public SearchResultOfTrendingEntry? Entries { get; init; }

    [JsonPropertyName("categoryId")]
    public string CategoryId { get; init; }
}
