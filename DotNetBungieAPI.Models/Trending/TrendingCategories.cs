namespace DotNetBungieAPI.Models.Trending;

public sealed class TrendingCategories
{
    [JsonPropertyName("categories")]
    public Trending.TrendingCategory[]? Categories { get; init; }
}
