using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Content;

public sealed class CommentSummary
{

    [JsonPropertyName("topicId")]
    public long TopicId { get; init; }

    [JsonPropertyName("commentCount")]
    public int CommentCount { get; init; }
}
