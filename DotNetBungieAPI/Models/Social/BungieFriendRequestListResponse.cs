namespace DotNetBungieAPI.Models.Social
{
    public sealed record BungieFriendRequestListResponse
    {
        [JsonPropertyName("incomingRequests")]
        public ReadOnlyCollection<BungieFriend> IncomingRequests { get; init; } =
            ReadOnlyCollections<BungieFriend>.Empty;

        [JsonPropertyName("outgoingRequests")]
        public ReadOnlyCollection<BungieFriend> OutgoingRequests { get; init; } =
            ReadOnlyCollections<BungieFriend>.Empty;
    }
}