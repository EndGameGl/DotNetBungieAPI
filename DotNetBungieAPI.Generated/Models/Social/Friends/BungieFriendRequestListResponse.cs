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
}