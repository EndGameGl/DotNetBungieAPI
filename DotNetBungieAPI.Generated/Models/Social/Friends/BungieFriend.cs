namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class BungieFriend : IDeepEquatable<BungieFriend>
{
    [JsonPropertyName("lastSeenAsMembershipId")]
    public long LastSeenAsMembershipId { get; set; }

    [JsonPropertyName("lastSeenAsBungieMembershipType")]
    public BungieMembershipType LastSeenAsBungieMembershipType { get; set; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    [JsonPropertyName("onlineStatus")]
    public Social.Friends.PresenceStatus OnlineStatus { get; set; }

    [JsonPropertyName("onlineTitle")]
    public Social.Friends.PresenceOnlineStateFlags OnlineTitle { get; set; }

    [JsonPropertyName("relationship")]
    public Social.Friends.FriendRelationshipState Relationship { get; set; }

    [JsonPropertyName("bungieNetUser")]
    public User.GeneralUser BungieNetUser { get; set; }

    public bool DeepEquals(BungieFriend? other)
    {
        return other is not null &&
               LastSeenAsMembershipId == other.LastSeenAsMembershipId &&
               LastSeenAsBungieMembershipType == other.LastSeenAsBungieMembershipType &&
               BungieGlobalDisplayName == other.BungieGlobalDisplayName &&
               BungieGlobalDisplayNameCode == other.BungieGlobalDisplayNameCode &&
               OnlineStatus == other.OnlineStatus &&
               OnlineTitle == other.OnlineTitle &&
               Relationship == other.Relationship &&
               (BungieNetUser is not null ? BungieNetUser.DeepEquals(other.BungieNetUser) : other.BungieNetUser is null);
    }
}