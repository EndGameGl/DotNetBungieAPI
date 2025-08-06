namespace DotNetBungieAPI.Models.Destiny.Requests.Actions;

public sealed class DestinyItemSetActionRequest
{
    [JsonPropertyName("itemIds")]
    public long[]? ItemIds { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
