namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntrySupportArticle : IDeepEquatable<TrendingEntrySupportArticle>
{
    [JsonPropertyName("article")]
    public Content.ContentItemPublicContract Article { get; set; }

    public bool DeepEquals(TrendingEntrySupportArticle? other)
    {
        return other is not null &&
               (Article is not null ? Article.DeepEquals(other.Article) : other.Article is null);
    }
}