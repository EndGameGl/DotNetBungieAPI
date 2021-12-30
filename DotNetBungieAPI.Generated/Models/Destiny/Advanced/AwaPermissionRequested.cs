using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public sealed class AwaPermissionRequested
{

    [JsonPropertyName("type")]
    public Destiny.Advanced.AwaType Type { get; init; }

    [JsonPropertyName("affectedItemId")]
    public long? AffectedItemId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    [JsonPropertyName("characterId")]
    public long? CharacterId { get; init; }
}
