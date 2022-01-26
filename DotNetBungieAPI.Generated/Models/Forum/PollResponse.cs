namespace DotNetBungieAPI.Generated.Models.Forum;

public class PollResponse : IDeepEquatable<PollResponse>
{
    [JsonPropertyName("topicId")]
    public long TopicId { get; set; }

    [JsonPropertyName("results")]
    public List<Forum.PollResult> Results { get; set; }

    [JsonPropertyName("totalVotes")]
    public int TotalVotes { get; set; }

    public bool DeepEquals(PollResponse? other)
    {
        return other is not null &&
               TopicId == other.TopicId &&
               Results.DeepEqualsList(other.Results) &&
               TotalVotes == other.TotalVotes;
    }
}