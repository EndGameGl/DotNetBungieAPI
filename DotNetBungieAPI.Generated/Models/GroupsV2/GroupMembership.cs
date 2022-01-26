namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMembership : IDeepEquatable<GroupMembership>
{
    [JsonPropertyName("member")]
    public GroupsV2.GroupMember Member { get; set; }

    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; set; }

    public bool DeepEquals(GroupMembership? other)
    {
        return other is not null &&
               (Member is not null ? Member.DeepEquals(other.Member) : other.Member is null) &&
               (Group is not null ? Group.DeepEquals(other.Group) : other.Group is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupMembership? other)
    {
        if (other is null) return;
        if (!Member.DeepEquals(other.Member))
        {
            Member.Update(other.Member);
            OnPropertyChanged(nameof(Member));
        }
        if (!Group.DeepEquals(other.Group))
        {
            Group.Update(other.Group);
            OnPropertyChanged(nameof(Group));
        }
    }
}