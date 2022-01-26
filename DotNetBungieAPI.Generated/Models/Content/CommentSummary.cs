namespace DotNetBungieAPI.Generated.Models.Content;

public class CommentSummary : IDeepEquatable<CommentSummary>
{
    [JsonPropertyName("topicId")]
    public long TopicId { get; set; }

    [JsonPropertyName("commentCount")]
    public int CommentCount { get; set; }

    public bool DeepEquals(CommentSummary? other)
    {
        return other is not null &&
               TopicId == other.TopicId &&
               CommentCount == other.CommentCount;
    }
}