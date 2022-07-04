namespace DotNetBungieAPI.Models.Social;

public sealed record PlatformFriend
{
    [JsonPropertyName("platformDisplayName")]
    public string PlatformDisplayName { get; init; }

    [JsonPropertyName("friendPlatform")] public PlatformFriendType FriendPlatform { get; init; }

    [JsonPropertyName("destinyMembershipId")]
    public long? DestinyMembershipId { get; init; }

    [JsonPropertyName("destinyMembershipType")]
    public BungieMembershipType? DestinyMembershipType { get; init; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long? BungieNetMembershipId { get; init; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; init; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; init; }
}