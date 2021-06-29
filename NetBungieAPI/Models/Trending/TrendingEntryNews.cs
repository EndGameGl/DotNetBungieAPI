using System.Text.Json.Serialization;
using NetBungieAPI.Models.Content;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntryNews
    {
        [JsonPropertyName("article")] public ContentItemPublicContract Article { get; init; }
    }
}