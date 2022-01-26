namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyItemStateRequest : IDeepEquatable<DestinyItemStateRequest>
{
    [JsonPropertyName("state")]
    public bool State { get; set; }

    /// <summary>
    ///     The instance ID of the item for this action request.
    /// </summary>
    [JsonPropertyName("itemId")]
    public long ItemId { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyItemStateRequest? other)
    {
        return other is not null &&
               State == other.State &&
               ItemId == other.ItemId &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }
}