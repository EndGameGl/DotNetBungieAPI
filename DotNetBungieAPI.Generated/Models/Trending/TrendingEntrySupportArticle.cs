using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Trending;

public sealed class TrendingEntrySupportArticle
{

    [JsonPropertyName("article")]
    public Content.ContentItemPublicContract Article { get; init; }
}
