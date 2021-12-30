using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public sealed class BungieFriendListResponse
{

    [JsonPropertyName("friends")]
    public List<Social.Friends.BungieFriend> Friends { get; init; }
}
