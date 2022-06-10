namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class BungieFriend
{
    [JsonPropertyName("lastSeenAsMembershipId")]
    public long? LastSeenAsMembershipId { get; set; }

    [JsonPropertyName("lastSeenAsBungieMembershipType")]
    public BungieMembershipType? LastSeenAsBungieMembershipType { get; set; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string? BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    [JsonPropertyName("onlineStatus")]
    public Social.Friends.PresenceStatus? OnlineStatus { get; set; }

    [JsonPropertyName("onlineTitle")]
    public Social.Friends.PresenceOnlineStateFlags? OnlineTitle { get; set; }

    [JsonPropertyName("relationship")]
    public Social.Friends.FriendRelationshipState? Relationship { get; set; }

    [JsonPropertyName("bungieNetUser")]
    public User.GeneralUser? BungieNetUser { get; set; }
}
