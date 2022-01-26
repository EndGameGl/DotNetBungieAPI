namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class BungieFriendRequestListResponse : IDeepEquatable<BungieFriendRequestListResponse>
{
    [JsonPropertyName("incomingRequests")]
    public List<Social.Friends.BungieFriend> IncomingRequests { get; set; }

    [JsonPropertyName("outgoingRequests")]
    public List<Social.Friends.BungieFriend> OutgoingRequests { get; set; }

    public bool DeepEquals(BungieFriendRequestListResponse? other)
    {
        return other is not null &&
               IncomingRequests.DeepEqualsList(other.IncomingRequests) &&
               OutgoingRequests.DeepEqualsList(other.OutgoingRequests);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(BungieFriendRequestListResponse? other)
    {
        if (other is null) return;
        if (!IncomingRequests.DeepEqualsList(other.IncomingRequests))
        {
            IncomingRequests = other.IncomingRequests;
            OnPropertyChanged(nameof(IncomingRequests));
        }
        if (!OutgoingRequests.DeepEqualsList(other.OutgoingRequests))
        {
            OutgoingRequests = other.OutgoingRequests;
            OnPropertyChanged(nameof(OutgoingRequests));
        }
    }
}