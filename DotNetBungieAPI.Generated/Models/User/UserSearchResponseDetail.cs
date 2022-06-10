namespace DotNetBungieAPI.Generated.Models.User;

public class UserSearchResponseDetail
{
    [JsonPropertyName("bungieGlobalDisplayName")]
    public string? BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long? BungieNetMembershipId { get; set; }

    [JsonPropertyName("destinyMemberships")]
    public List<User.UserInfoCard> DestinyMemberships { get; set; }
}
