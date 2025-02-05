namespace DotNetBungieAPI.Models.Social;

public sealed record BungieFriendListResponse
{
    [JsonPropertyName("friends")]
    public ReadOnlyCollection<BungieFriend> Friends { get; init; } =
        ReadOnlyCollection<BungieFriend>.Empty;
}
