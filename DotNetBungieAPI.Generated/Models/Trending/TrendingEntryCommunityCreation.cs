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
}