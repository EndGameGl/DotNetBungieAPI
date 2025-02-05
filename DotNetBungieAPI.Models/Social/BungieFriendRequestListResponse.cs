namespace DotNetBungieAPI.Models.Social;

public sealed record BungieFriendRequestListResponse
{
    [JsonPropertyName("incomingRequests")]
    public ReadOnlyCollection<BungieFriend> IncomingRequests { get; init; } =
        ReadOnlyCollection<BungieFriend>.Empty;

    [JsonPropertyName("outgoingRequests")]
    public ReadOnlyCollection<BungieFriend> OutgoingRequests { get; init; } =
        ReadOnlyCollection<BungieFriend>.Empty;
}
