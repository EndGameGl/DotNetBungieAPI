namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryCommunityCreation
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
}
