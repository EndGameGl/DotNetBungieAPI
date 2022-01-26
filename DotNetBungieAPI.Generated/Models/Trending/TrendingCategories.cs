namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingCategories : IDeepEquatable<TrendingCategories>
{
    [JsonPropertyName("categories")]
    public List<Trending.TrendingCategory> Categories { get; set; }

    public bool DeepEquals(TrendingCategories? other)
    {
        return other is not null &&
               Categories.DeepEqualsList(other.Categories);
    }
}