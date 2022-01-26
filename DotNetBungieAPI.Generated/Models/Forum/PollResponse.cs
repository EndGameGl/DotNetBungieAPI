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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PollResponse? other)
    {
        if (other is null) return;
        if (TopicId != other.TopicId)
        {
            TopicId = other.TopicId;
            OnPropertyChanged(nameof(TopicId));
        }
        if (!Results.DeepEqualsList(other.Results))
        {
            Results = other.Results;
            OnPropertyChanged(nameof(Results));
        }
        if (TotalVotes != other.TotalVotes)
        {
            TotalVotes = other.TotalVotes;
            OnPropertyChanged(nameof(TotalVotes));
        }
    }
}