namespace DotNetBungieAPI.Generated.Models.Content;

public class CommentSummary : IDeepEquatable<CommentSummary>
{
    [JsonPropertyName("topicId")]
    public long TopicId { get; set; }

    [JsonPropertyName("commentCount")]
    public int CommentCount { get; set; }

    public bool DeepEquals(CommentSummary? other)
    {
        return other is not null &&
               TopicId == other.TopicId &&
               CommentCount == other.CommentCount;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(CommentSummary? other)
    {
        if (other is null) return;
        if (TopicId != other.TopicId)
        {
            TopicId = other.TopicId;
            OnPropertyChanged(nameof(TopicId));
        }
        if (CommentCount != other.CommentCount)
        {
            CommentCount = other.CommentCount;
            OnPropertyChanged(nameof(CommentCount));
        }
    }
}