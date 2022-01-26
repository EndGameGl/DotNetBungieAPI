namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class BungieFriendListResponse : IDeepEquatable<BungieFriendListResponse>
{
    [JsonPropertyName("friends")]
    public List<Social.Friends.BungieFriend> Friends { get; set; }

    public bool DeepEquals(BungieFriendListResponse? other)
    {
        return other is not null &&
               Friends.DeepEqualsList(other.Friends);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(BungieFriendListResponse? other)
    {
        if (other is null) return;
        if (!Friends.DeepEqualsList(other.Friends))
        {
            Friends = other.Friends;
            OnPropertyChanged(nameof(Friends));
        }
    }
}