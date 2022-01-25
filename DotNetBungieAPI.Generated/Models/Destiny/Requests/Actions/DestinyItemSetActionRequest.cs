namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyItemSetActionRequest
{
    [JsonPropertyName("itemIds")]
    public List<long> ItemIds { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }
}
