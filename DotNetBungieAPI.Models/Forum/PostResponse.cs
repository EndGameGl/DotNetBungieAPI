namespace DotNetBungieAPI.Models.Forum;

public sealed class PostResponse
{
    [JsonPropertyName("lastReplyTimestamp")]
    public DateTime LastReplyTimestamp { get; init; }

    [JsonPropertyName("IsPinned")]
    public bool IsPinned { get; init; }

    [JsonPropertyName("urlMediaType")]
    public Forum.ForumMediaType UrlMediaType { get; init; }

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; init; }

    [JsonPropertyName("popularity")]
    public Forum.ForumPostPopularity Popularity { get; init; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; init; }

    [JsonPropertyName("isAnnouncement")]
    public bool IsAnnouncement { get; init; }

    [JsonPropertyName("userRating")]
    public int UserRating { get; init; }

    [JsonPropertyName("userHasRated")]
    public bool UserHasRated { get; init; }

    [JsonPropertyName("userHasMutedPost")]
    public bool UserHasMutedPost { get; init; }

    [JsonPropertyName("latestReplyPostId")]
    public long LatestReplyPostId { get; init; }

    [JsonPropertyName("latestReplyAuthorId")]
    public long LatestReplyAuthorId { get; init; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse? IgnoreStatus { get; init; }

    [JsonPropertyName("locale")]
    public string Locale { get; init; }
}
