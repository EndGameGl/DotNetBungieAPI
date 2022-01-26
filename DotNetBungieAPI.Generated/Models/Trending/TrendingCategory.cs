namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingCategory : IDeepEquatable<TrendingCategory>
{
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; }

    [JsonPropertyName("entries")]
    public SearchResultOfTrendingEntry Entries { get; set; }

    [JsonPropertyName("categoryId")]
    public string CategoryId { get; set; }

    public bool DeepEquals(TrendingCategory? other)
    {
        return other is not null &&
               CategoryName == other.CategoryName &&
               (Entries is not null ? Entries.DeepEquals(other.Entries) : other.Entries is null) &&
               CategoryId == other.CategoryId;
    }
}