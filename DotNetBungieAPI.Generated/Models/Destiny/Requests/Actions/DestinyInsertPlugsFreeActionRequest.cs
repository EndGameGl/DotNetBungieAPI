namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyInsertPlugsFreeActionRequest
{
    /// <summary>
    ///     The plugs being inserted.
    /// </summary>
    [JsonPropertyName("plug")]
    public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry? Plug { get; set; }

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
