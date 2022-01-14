namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public sealed class DestinyItemSetActionRequest
{

    [JsonPropertyName("itemIds")]
    public List<long> ItemIds { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
