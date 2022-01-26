namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupApplicationResponse : IDeepEquatable<GroupApplicationResponse>
{
    [JsonPropertyName("resolution")]
    public GroupsV2.GroupApplicationResolveState Resolution { get; set; }

    public bool DeepEquals(GroupApplicationResponse? other)
    {
        return other is not null &&
               Resolution == other.Resolution;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupApplicationResponse? other)
    {
        if (other is null) return;
        if (Resolution != other.Resolution)
        {
            Resolution = other.Resolution;
            OnPropertyChanged(nameof(Resolution));
        }
    }
}