namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryNews : IDeepEquatable<TrendingEntryNews>
{
    [JsonPropertyName("article")]
    public Content.ContentItemPublicContract Article { get; set; }

    public bool DeepEquals(TrendingEntryNews? other)
    {
        return other is not null &&
               (Article is not null ? Article.DeepEquals(other.Article) : other.Article is null);
    }
}