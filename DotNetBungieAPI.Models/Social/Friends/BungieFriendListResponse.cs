namespace DotNetBungieAPI.Models.Social.Friends;

public sealed class BungieFriendListResponse
{
    [JsonPropertyName("friends")]
    public Social.Friends.BungieFriend[]? Friends { get; init; }
}
