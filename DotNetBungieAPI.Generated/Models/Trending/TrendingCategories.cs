using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Trending;

public sealed class TrendingCategories
{

    [JsonPropertyName("categories")]
    public List<Trending.TrendingCategory> Categories { get; init; }
}
