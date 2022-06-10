namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class PlatformFriend
{
    [JsonPropertyName("platformDisplayName")]
    public string PlatformDisplayName { get; set; }

    [JsonPropertyName("friendPlatform")]
    public Social.Friends.PlatformFriendType FriendPlatform { get; set; }

    [JsonPropertyName("destinyMembershipId")]
    public long DestinyMembershipId { get; set; }

    [JsonPropertyName("destinyMembershipType")]
    public int DestinyMembershipType { get; set; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long BungieNetMembershipId { get; set; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short BungieGlobalDisplayNameCode { get; set; }
}
