namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMemberLeaveResult : IDeepEquatable<GroupMemberLeaveResult>
{
    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; set; }

    [JsonPropertyName("groupDeleted")]
    public bool GroupDeleted { get; set; }

    public bool DeepEquals(GroupMemberLeaveResult? other)
    {
        return other is not null &&
               (Group is not null ? Group.DeepEquals(other.Group) : other.Group is null) &&
               GroupDeleted == other.GroupDeleted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupMemberLeaveResult? other)
    {
        if (other is null) return;
        if (!Group.DeepEquals(other.Group))
        {
            Group.Update(other.Group);
            OnPropertyChanged(nameof(Group));
        }
        if (GroupDeleted != other.GroupDeleted)
        {
            GroupDeleted = other.GroupDeleted;
            OnPropertyChanged(nameof(GroupDeleted));
        }
    }
}