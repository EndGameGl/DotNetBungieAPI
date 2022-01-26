namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupApplicationRequest : IDeepEquatable<GroupApplicationRequest>
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    public bool DeepEquals(GroupApplicationRequest? other)
    {
        return other is not null &&
               Message == other.Message;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupApplicationRequest? other)
    {
        if (other is null) return;
        if (Message != other.Message)
        {
            Message = other.Message;
            OnPropertyChanged(nameof(Message));
        }
    }
}