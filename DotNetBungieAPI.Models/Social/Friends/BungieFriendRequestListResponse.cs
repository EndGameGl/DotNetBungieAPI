namespace DotNetBungieAPI.Models.Social.Friends;

public sealed class BungieFriendRequestListResponse
{
    [JsonPropertyName("incomingRequests")]
    public Social.Friends.BungieFriend[]? IncomingRequests { get; init; }

    [JsonPropertyName("outgoingRequests")]
    public Social.Friends.BungieFriend[]? OutgoingRequests { get; init; }
}
