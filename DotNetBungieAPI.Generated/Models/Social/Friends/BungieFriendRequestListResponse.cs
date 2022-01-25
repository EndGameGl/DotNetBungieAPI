namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class BungieFriendRequestListResponse
{
    [JsonPropertyName("incomingRequests")]
    public List<Social.Friends.BungieFriend> IncomingRequests { get; set; }

    [JsonPropertyName("outgoingRequests")]
    public List<Social.Friends.BungieFriend> OutgoingRequests { get; set; }
}
