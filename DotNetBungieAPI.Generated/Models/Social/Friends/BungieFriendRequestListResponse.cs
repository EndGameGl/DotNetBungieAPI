namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class BungieFriendRequestListResponse
{
    [JsonPropertyName("incomingRequests")]
    public Social.Friends.BungieFriend[]? IncomingRequests { get; set; }

    [JsonPropertyName("outgoingRequests")]
    public Social.Friends.BungieFriend[]? OutgoingRequests { get; set; }
}
