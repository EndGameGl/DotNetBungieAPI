using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingCategories
    {
        [JsonPropertyName("categories")]
        public ReadOnlyCollection<TrendingCategory> Categories { get; init; } =
            Defaults.EmptyReadOnlyCollection<TrendingCategory>();
    }
}