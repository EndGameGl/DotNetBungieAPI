namespace DotNetBungieAPI.Models.Destiny.Requests.Actions;

public sealed class DestinyItemActionRequest
{
    /// <summary>
    ///     The instance ID of the item for this action request.
    /// </summary>
    [JsonPropertyName("itemId")]
    public long ItemId { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
