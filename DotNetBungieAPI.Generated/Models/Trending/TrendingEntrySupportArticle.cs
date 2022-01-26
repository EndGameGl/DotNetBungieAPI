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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TrendingEntrySupportArticle? other)
    {
        if (other is null) return;
        if (!Article.DeepEquals(other.Article))
        {
            Article.Update(other.Article);
            OnPropertyChanged(nameof(Article));
        }
    }
}