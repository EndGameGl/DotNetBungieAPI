namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class PlatformFriendResponse : IDeepEquatable<PlatformFriendResponse>
{
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }

    [JsonPropertyName("platformFriends")]
    public List<Social.Friends.PlatformFriend> PlatformFriends { get; set; }

    public bool DeepEquals(PlatformFriendResponse? other)
    {
        return other is not null &&
               ItemsPerPage == other.ItemsPerPage &&
               CurrentPage == other.CurrentPage &&
               HasMore == other.HasMore &&
               PlatformFriends.DeepEqualsList(other.PlatformFriends);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PlatformFriendResponse? other)
    {
        if (other is null) return;
        if (ItemsPerPage != other.ItemsPerPage)
        {
            ItemsPerPage = other.ItemsPerPage;
            OnPropertyChanged(nameof(ItemsPerPage));
        }
        if (CurrentPage != other.CurrentPage)
        {
            CurrentPage = other.CurrentPage;
            OnPropertyChanged(nameof(CurrentPage));
        }
        if (HasMore != other.HasMore)
        {
            HasMore = other.HasMore;
            OnPropertyChanged(nameof(HasMore));
        }
        if (!PlatformFriends.DeepEqualsList(other.PlatformFriends))
        {
            PlatformFriends = other.PlatformFriends;
            OnPropertyChanged(nameof(PlatformFriends));
        }
    }
}