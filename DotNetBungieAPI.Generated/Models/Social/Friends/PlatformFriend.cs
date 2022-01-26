namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class PlatformFriend : IDeepEquatable<PlatformFriend>
{
    [JsonPropertyName("platformDisplayName")]
    public string PlatformDisplayName { get; set; }

    [JsonPropertyName("friendPlatform")]
    public Social.Friends.PlatformFriendType FriendPlatform { get; set; }

    [JsonPropertyName("destinyMembershipId")]
    public long? DestinyMembershipId { get; set; }

    [JsonPropertyName("destinyMembershipType")]
    public int? DestinyMembershipType { get; set; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long? BungieNetMembershipId { get; set; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    public bool DeepEquals(PlatformFriend? other)
    {
        return other is not null &&
               PlatformDisplayName == other.PlatformDisplayName &&
               FriendPlatform == other.FriendPlatform &&
               DestinyMembershipId == other.DestinyMembershipId &&
               DestinyMembershipType == other.DestinyMembershipType &&
               BungieNetMembershipId == other.BungieNetMembershipId &&
               BungieGlobalDisplayName == other.BungieGlobalDisplayName &&
               BungieGlobalDisplayNameCode == other.BungieGlobalDisplayNameCode;
    }
}