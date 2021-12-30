using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class UserMembership
{

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; init; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; init; }
}
