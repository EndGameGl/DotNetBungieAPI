namespace DotNetBungieAPI.Generated.Models.Forum;

public sealed class PollResponse
{

    [JsonPropertyName("topicId")]
    public long TopicId { get; init; }

    [JsonPropertyName("results")]
    public List<Forum.PollResult> Results { get; init; }

    [JsonPropertyName("totalVotes")]
    public int TotalVotes { get; init; }
}
