namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMembershipBase : IDeepEquatable<GroupMembershipBase>
{
    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; set; }

    public bool DeepEquals(GroupMembershipBase? other)
    {
        return other is not null &&
               (Group is not null ? Group.DeepEquals(other.Group) : other.Group is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupMembershipBase? other)
    {
        if (other is null) return;
        if (!Group.DeepEquals(other.Group))
        {
            Group.Update(other.Group);
            OnPropertyChanged(nameof(Group));
        }
    }
}