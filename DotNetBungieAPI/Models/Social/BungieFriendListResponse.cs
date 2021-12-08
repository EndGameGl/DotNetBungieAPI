namespace DotNetBungieAPI.Models.Social;

public sealed record BungieFriendListResponse
{
    [JsonPropertyName("friends")]
    public ReadOnlyCollection<BungieFriend> Friends { get; init; } = ReadOnlyCollections<BungieFriend>.Empty;
}