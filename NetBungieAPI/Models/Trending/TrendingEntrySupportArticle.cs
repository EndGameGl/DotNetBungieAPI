using System.Text.Json.Serialization;
using NetBungieAPI.Models.Content;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntrySupportArticle
    {
        [JsonPropertyName("article")] public ContentItemPublicContract Article { get; init; }
    }
}