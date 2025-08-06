namespace DotNetBungieAPI.Models.Forum;

public sealed class PollResponse
{
    [JsonPropertyName("topicId")]
    public long TopicId { get; init; }

    [JsonPropertyName("results")]
    public Forum.PollResult[]? Results { get; init; }

    [JsonPropertyName("totalVotes")]
    public int TotalVotes { get; init; }
}
