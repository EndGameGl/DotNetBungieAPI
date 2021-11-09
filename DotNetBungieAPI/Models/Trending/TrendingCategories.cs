namespace DotNetBungieAPI.Models.Trending
{
    public sealed record TrendingCategories
    {
        [JsonPropertyName("categories")]
        public ReadOnlyCollection<TrendingCategory> Categories { get; init; } =
            ReadOnlyCollections<TrendingCategory>.Empty;
    }
}