namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupApplicationListRequest : IDeepEquatable<GroupApplicationListRequest>
{
    [JsonPropertyName("memberships")]
    public List<User.UserMembership> Memberships { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    public bool DeepEquals(GroupApplicationListRequest? other)
    {
        return other is not null &&
               Memberships.DeepEqualsList(other.Memberships) &&
               Message == other.Message;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupApplicationListRequest? other)
    {
        if (other is null) return;
        if (!Memberships.DeepEqualsList(other.Memberships))
        {
            Memberships = other.Memberships;
            OnPropertyChanged(nameof(Memberships));
        }
        if (Message != other.Message)
        {
            Message = other.Message;
            OnPropertyChanged(nameof(Message));
        }
    }
}