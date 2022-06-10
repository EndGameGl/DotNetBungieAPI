namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingCategory
{
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; }

    [JsonPropertyName("entries")]
    public SearchResultOfTrendingEntry Entries { get; set; }

    [JsonPropertyName("categoryId")]
    public string CategoryId { get; set; }
}
