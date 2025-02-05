namespace DotNetBungieAPI.Models.Forum;

public sealed record PollResponse
{
    [JsonPropertyName("topicId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long TopicId { get; init; }

    [JsonPropertyName("results")]
    public ReadOnlyCollection<PollResult> Results { get; init; } =
        ReadOnlyCollection<PollResult>.Empty;

    [JsonPropertyName("totalVotes")]
    public int TotalVotes { get; init; }
}
