namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyCharacterActionRequest
{
    [JsonPropertyName("characterId")]
    public long? CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType? MembershipType { get; set; }
}
