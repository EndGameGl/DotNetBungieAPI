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
}