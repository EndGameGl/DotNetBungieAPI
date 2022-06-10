namespace DotNetBungieAPI.Generated.Models.Forum;

public class PollResponse
{
    [JsonPropertyName("topicId")]
    public long? TopicId { get; set; }

    [JsonPropertyName("results")]
    public List<Forum.PollResult> Results { get; set; }

    [JsonPropertyName("totalVotes")]
    public int? TotalVotes { get; set; }
}
