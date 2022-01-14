namespace DotNetBungieAPI.Generated.Models.User;

public sealed class UserSearchResponseDetail
{

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; init; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; init; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long? BungieNetMembershipId { get; init; }

    [JsonPropertyName("destinyMemberships")]
    public List<User.UserInfoCard> DestinyMemberships { get; init; }
}
