using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Content
{
    public sealed record CommentSummary
    {
        [JsonPropertyName("topicId")] public long TopicId { get; init; }

        [JsonPropertyName("commentCount")] public int CommentCount { get; init; }
    }
}