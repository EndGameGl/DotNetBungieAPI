using NetBungieAPI.Models.Content;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntryNews
    {
        [JsonPropertyName("article")]
        public ContentItemPublicContract Article { get; init; }
    }
}
