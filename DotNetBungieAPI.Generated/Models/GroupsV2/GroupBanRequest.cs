namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupBanRequest : IDeepEquatable<GroupBanRequest>
{
    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [JsonPropertyName("length")]
    public Ignores.IgnoreLength Length { get; set; }

    public bool DeepEquals(GroupBanRequest? other)
    {
        return other is not null &&
               Comment == other.Comment &&
               Length == other.Length;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupBanRequest? other)
    {
        if (other is null) return;
        if (Comment != other.Comment)
        {
            Comment = other.Comment;
            OnPropertyChanged(nameof(Comment));
        }
        if (Length != other.Length)
        {
            Length = other.Length;
            OnPropertyChanged(nameof(Length));
        }
    }
}