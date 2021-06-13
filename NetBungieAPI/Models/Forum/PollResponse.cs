using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Forum
{
    public sealed record PollResponse
    {
        [JsonPropertyName("topicId"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long TopicId { get; init; }

        [JsonPropertyName("results")]
        public ReadOnlyCollection<PollResult> Results { get; init; } = Defaults.EmptyReadOnlyCollection<PollResult>();

        [JsonPropertyName("totalVotes")]
        public int TotalVotes { get; init; }
    }
}
