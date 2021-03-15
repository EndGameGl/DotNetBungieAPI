using Newtonsoft.Json;

namespace NetBungieAPI.Content
{
    public class CommentSummary
    {
        public long TopicId { get; }
        public int CommentCount { get; }

        [JsonConstructor]
        internal CommentSummary(long topicId, int commentCount)
        {
            TopicId = topicId;
            CommentCount = commentCount;
        }
    }
}
