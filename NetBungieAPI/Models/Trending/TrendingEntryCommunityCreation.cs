using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntryCommunityCreation
    {
        [JsonPropertyName("media")] public string Media { get; init; }

        [JsonPropertyName("title")] public string Title { get; init; }

        [JsonPropertyName("author")] public string Author { get; init; }

        [JsonPropertyName("authorMembershipId")]
        public long AuthorMembershipId { get; init; }

        [JsonPropertyName("postId")] public long PostId { get; init; }

        [JsonPropertyName("body")] public string Body { get; init; }

        [JsonPropertyName("upvotes")] public int Upvotes { get; init; }
    }
}