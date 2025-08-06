namespace DotNetBungieAPI.Models.Trending;

public sealed class TrendingEntrySupportArticle
{
    [JsonPropertyName("article")]
    public Content.ContentItemPublicContract? Article { get; init; }
}
