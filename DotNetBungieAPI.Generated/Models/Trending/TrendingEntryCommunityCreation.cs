namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryCommunityCreation : IDeepEquatable<TrendingEntryCommunityCreation>
{
    [JsonPropertyName("media")]
    public string Media { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("authorMembershipId")]
    public long AuthorMembershipId { get; set; }

    [JsonPropertyName("postId")]
    public long PostId { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("upvotes")]
    public int Upvotes { get; set; }

    public bool DeepEquals(TrendingEntryCommunityCreation? other)
    {
        return other is not null &&
               Media == other.Media &&
               Title == other.Title &&
               Author == other.Author &&
               AuthorMembershipId == other.AuthorMembershipId &&
               PostId == other.PostId &&
               Body == other.Body &&
               Upvotes == other.Upvotes;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TrendingEntryCommunityCreation? other)
    {
        if (other is null) return;
        if (Media != other.Media)
        {
            Media = other.Media;
            OnPropertyChanged(nameof(Media));
        }
        if (Title != other.Title)
        {
            Title = other.Title;
            OnPropertyChanged(nameof(Title));
        }
        if (Author != other.Author)
        {
            Author = other.Author;
            OnPropertyChanged(nameof(Author));
        }
        if (AuthorMembershipId != other.AuthorMembershipId)
        {
            AuthorMembershipId = other.AuthorMembershipId;
            OnPropertyChanged(nameof(AuthorMembershipId));
        }
        if (PostId != other.PostId)
        {
            PostId = other.PostId;
            OnPropertyChanged(nameof(PostId));
        }
        if (Body != other.Body)
        {
            Body = other.Body;
            OnPropertyChanged(nameof(Body));
        }
        if (Upvotes != other.Upvotes)
        {
            Upvotes = other.Upvotes;
            OnPropertyChanged(nameof(Upvotes));
        }
    }
}