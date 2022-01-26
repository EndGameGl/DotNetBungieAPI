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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PollResult? other)
    {
        if (other is null) return;
        if (AnswerText != other.AnswerText)
        {
            AnswerText = other.AnswerText;
            OnPropertyChanged(nameof(AnswerText));
        }
        if (AnswerSlot != other.AnswerSlot)
        {
            AnswerSlot = other.AnswerSlot;
            OnPropertyChanged(nameof(AnswerSlot));
        }
        if (LastVoteDate != other.LastVoteDate)
        {
            LastVoteDate = other.LastVoteDate;
            OnPropertyChanged(nameof(LastVoteDate));
        }
        if (Votes != other.Votes)
        {
            Votes = other.Votes;
            OnPropertyChanged(nameof(Votes));
        }
        if (RequestingUserVoted != other.RequestingUserVoted)
        {
            RequestingUserVoted = other.RequestingUserVoted;
            OnPropertyChanged(nameof(RequestingUserVoted));
        }
    }
}