namespace DotNetBungieAPI.Models.Trending;

public sealed class TrendingEntryNews
{
    [JsonPropertyName("article")]
    public Content.ContentItemPublicContract? Article { get; init; }
}
