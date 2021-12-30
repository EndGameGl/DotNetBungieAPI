using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public sealed class BungieFriendRequestListResponse
{

    [JsonPropertyName("incomingRequests")]
    public List<Social.Friends.BungieFriend> IncomingRequests { get; init; }

    [JsonPropertyName("outgoingRequests")]
    public List<Social.Friends.BungieFriend> OutgoingRequests { get; init; }
}
