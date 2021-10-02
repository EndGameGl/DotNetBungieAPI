using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Trending
{
    public sealed record TrendingCategories
    {
        [JsonPropertyName("categories")]
        public ReadOnlyCollection<TrendingCategory> Categories { get; init; } =
            Defaults.EmptyReadOnlyCollection<TrendingCategory>();
    }
}