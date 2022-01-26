namespace DotNetBungieAPI.Generated.Models.Forum;

public class PostResponse : IDeepEquatable<PostResponse>
{
    [JsonPropertyName("lastReplyTimestamp")]
    public DateTime LastReplyTimestamp { get; set; }

    [JsonPropertyName("IsPinned")]
    public bool IsPinned { get; set; }

    [JsonPropertyName("urlMediaType")]
    public Forum.ForumMediaType UrlMediaType { get; set; }

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }

    [JsonPropertyName("popularity")]
    public Forum.ForumPostPopularity Popularity { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("isAnnouncement")]
    public bool IsAnnouncement { get; set; }

    [JsonPropertyName("userRating")]
    public int UserRating { get; set; }

    [JsonPropertyName("userHasRated")]
    public bool UserHasRated { get; set; }

    [JsonPropertyName("userHasMutedPost")]
    public bool UserHasMutedPost { get; set; }

    [JsonPropertyName("latestReplyPostId")]
    public long LatestReplyPostId { get; set; }

    [JsonPropertyName("latestReplyAuthorId")]
    public long LatestReplyAuthorId { get; set; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse IgnoreStatus { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    public bool DeepEquals(PostResponse? other)
    {
        return other is not null &&
               LastReplyTimestamp == other.LastReplyTimestamp &&
               IsPinned == other.IsPinned &&
               UrlMediaType == other.UrlMediaType &&
               Thumbnail == other.Thumbnail &&
               Popularity == other.Popularity &&
               IsActive == other.IsActive &&
               IsAnnouncement == other.IsAnnouncement &&
               UserRating == other.UserRating &&
               UserHasRated == other.UserHasRated &&
               UserHasMutedPost == other.UserHasMutedPost &&
               LatestReplyPostId == other.LatestReplyPostId &&
               LatestReplyAuthorId == other.LatestReplyAuthorId &&
               (IgnoreStatus is not null ? IgnoreStatus.DeepEquals(other.IgnoreStatus) : other.IgnoreStatus is null) &&
               Locale == other.Locale;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PostResponse? other)
    {
        if (other is null) return;
        if (LastReplyTimestamp != other.LastReplyTimestamp)
        {
            LastReplyTimestamp = other.LastReplyTimestamp;
            OnPropertyChanged(nameof(LastReplyTimestamp));
        }
        if (IsPinned != other.IsPinned)
        {
            IsPinned = other.IsPinned;
            OnPropertyChanged(nameof(IsPinned));
        }
        if (UrlMediaType != other.UrlMediaType)
        {
            UrlMediaType = other.UrlMediaType;
            OnPropertyChanged(nameof(UrlMediaType));
        }
        if (Thumbnail != other.Thumbnail)
        {
            Thumbnail = other.Thumbnail;
            OnPropertyChanged(nameof(Thumbnail));
        }
        if (Popularity != other.Popularity)
        {
            Popularity = other.Popularity;
            OnPropertyChanged(nameof(Popularity));
        }
        if (IsActive != other.IsActive)
        {
            IsActive = other.IsActive;
            OnPropertyChanged(nameof(IsActive));
        }
        if (IsAnnouncement != other.IsAnnouncement)
        {
            IsAnnouncement = other.IsAnnouncement;
            OnPropertyChanged(nameof(IsAnnouncement));
        }
        if (UserRating != other.UserRating)
        {
            UserRating = other.UserRating;
            OnPropertyChanged(nameof(UserRating));
        }
        if (UserHasRated != other.UserHasRated)
        {
            UserHasRated = other.UserHasRated;
            OnPropertyChanged(nameof(UserHasRated));
        }
        if (UserHasMutedPost != other.UserHasMutedPost)
        {
            UserHasMutedPost = other.UserHasMutedPost;
            OnPropertyChanged(nameof(UserHasMutedPost));
        }
        if (LatestReplyPostId != other.LatestReplyPostId)
        {
            LatestReplyPostId = other.LatestReplyPostId;
            OnPropertyChanged(nameof(LatestReplyPostId));
        }
        if (LatestReplyAuthorId != other.LatestReplyAuthorId)
        {
            LatestReplyAuthorId = other.LatestReplyAuthorId;
            OnPropertyChanged(nameof(LatestReplyAuthorId));
        }
        if (!IgnoreStatus.DeepEquals(other.IgnoreStatus))
        {
            IgnoreStatus.Update(other.IgnoreStatus);
            OnPropertyChanged(nameof(IgnoreStatus));
        }
        if (Locale != other.Locale)
        {
            Locale = other.Locale;
            OnPropertyChanged(nameof(Locale));
        }
    }
}