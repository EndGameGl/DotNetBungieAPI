using NetBungieAPI.Models.Content;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntrySupportArticle
    {
        [JsonPropertyName("article")]
        public ContentItemPublicContract Article { get; init; }
    }
}
