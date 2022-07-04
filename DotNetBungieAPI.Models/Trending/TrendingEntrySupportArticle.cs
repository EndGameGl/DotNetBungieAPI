using DotNetBungieAPI.Models.Content;

namespace DotNetBungieAPI.Models.Trending;

public sealed record TrendingEntrySupportArticle
{
    [JsonPropertyName("article")] public ContentItemPublicContract Article { get; init; }
}