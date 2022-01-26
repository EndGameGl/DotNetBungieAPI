namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupNameSearchRequest : IDeepEquatable<GroupNameSearchRequest>
{
    [JsonPropertyName("groupName")]
    public string GroupName { get; set; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; set; }

    public bool DeepEquals(GroupNameSearchRequest? other)
    {
        return other is not null &&
               GroupName == other.GroupName &&
               GroupType == other.GroupType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupNameSearchRequest? other)
    {
        if (other is null) return;
        if (GroupName != other.GroupName)
        {
            GroupName = other.GroupName;
            OnPropertyChanged(nameof(GroupName));
        }
        if (GroupType != other.GroupType)
        {
            GroupType = other.GroupType;
            OnPropertyChanged(nameof(GroupType));
        }
    }
}