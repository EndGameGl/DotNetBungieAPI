namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyItemActionRequest
{
    /// <summary>
    ///     The instance ID of the item for this action request.
    /// </summary>
    [JsonPropertyName("itemId")]
    public long ItemId { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }
}
