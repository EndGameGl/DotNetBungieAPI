namespace DotNetBungieAPI.Models.Forum;

public sealed record PollResult
{
    [JsonPropertyName("answerText")]
    public string AnswerText { get; init; }

    [JsonPropertyName("answerSlot")]
    public int AnswerSlot { get; init; }

    [JsonPropertyName("lastVoteDate")]
    public DateTime LastVoteDate { get; init; }

    [JsonPropertyName("votes")]
    public int Votes { get; init; }

    [JsonPropertyName("requestingUserVoted")]
    public bool RequestingUserVoted { get; init; }
}
