namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public sealed class DestinyCharacterActionRequest
{

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
