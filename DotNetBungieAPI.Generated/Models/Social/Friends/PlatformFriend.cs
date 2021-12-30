using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public sealed class PlatformFriend
{

    [JsonPropertyName("platformDisplayName")]
    public string PlatformDisplayName { get; init; }

    [JsonPropertyName("friendPlatform")]
    public Social.Friends.PlatformFriendType FriendPlatform { get; init; }

    [JsonPropertyName("destinyMembershipId")]
    public long? DestinyMembershipId { get; init; }

    [JsonPropertyName("destinyMembershipType")]
    public int? DestinyMembershipType { get; init; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long? BungieNetMembershipId { get; init; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; init; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; init; }
}
