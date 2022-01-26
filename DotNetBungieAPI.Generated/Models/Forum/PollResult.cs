namespace DotNetBungieAPI.Generated.Models.Forum;

public class PollResult : IDeepEquatable<PollResult>
{
    [JsonPropertyName("answerText")]
    public string AnswerText { get; set; }

    [JsonPropertyName("answerSlot")]
    public int AnswerSlot { get; set; }

    [JsonPropertyName("lastVoteDate")]
    public DateTime LastVoteDate { get; set; }

    [JsonPropertyName("votes")]
    public int Votes { get; set; }

    [JsonPropertyName("requestingUserVoted")]
    public bool RequestingUserVoted { get; set; }

    public bool DeepEquals(PollResult? other)
    {
        return other is not null &&
               AnswerText == other.AnswerText &&
               AnswerSlot == other.AnswerSlot &&
               LastVoteDate == other.LastVoteDate &&
               Votes == other.Votes &&
               RequestingUserVoted == other.RequestingUserVoted;
    }
}