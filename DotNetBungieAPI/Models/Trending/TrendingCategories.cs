using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Trending
{
    public sealed record TrendingCategories
    {
        [JsonPropertyName("categories")]
        public ReadOnlyCollection<TrendingCategory> Categories { get; init; } =
            ReadOnlyCollections<TrendingCategory>.Empty;
    }
}