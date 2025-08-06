namespace DotNetBungieAPI.Models.Social.Friends;

public sealed class BungieFriend
{
    [JsonPropertyName("lastSeenAsMembershipId")]
    public long LastSeenAsMembershipId { get; init; }

    [JsonPropertyName("lastSeenAsBungieMembershipType")]
    public BungieMembershipType LastSeenAsBungieMembershipType { get; init; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; init; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; init; }

    [JsonPropertyName("onlineStatus")]
    public Social.Friends.PresenceStatus OnlineStatus { get; init; }

    [JsonPropertyName("onlineTitle")]
    public Social.Friends.PresenceOnlineStateFlags OnlineTitle { get; init; }

    [JsonPropertyName("relationship")]
    public Social.Friends.FriendRelationshipState Relationship { get; init; }

    [JsonPropertyName("bungieNetUser")]
    public User.GeneralUser? BungieNetUser { get; init; }
}
