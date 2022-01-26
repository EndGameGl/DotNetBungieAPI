namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyPostmasterTransferRequest : IDeepEquatable<DestinyPostmasterTransferRequest>
{
    [JsonPropertyName("itemReferenceHash")]
    public uint ItemReferenceHash { get; set; }

    [JsonPropertyName("stackSize")]
    public int StackSize { get; set; }

    /// <summary>
    ///     The instance ID of the item for this action request.
    /// </summary>
    [JsonPropertyName("itemId")]
    public long ItemId { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyPostmasterTransferRequest? other)
    {
        return other is not null &&
               ItemReferenceHash == other.ItemReferenceHash &&
               StackSize == other.StackSize &&
               ItemId == other.ItemId &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }
}