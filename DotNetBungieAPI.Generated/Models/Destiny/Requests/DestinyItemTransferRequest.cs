namespace DotNetBungieAPI.Generated.Models.Destiny.Requests;

public class DestinyItemTransferRequest : IDeepEquatable<DestinyItemTransferRequest>
{
    [JsonPropertyName("itemReferenceHash")]
    public uint ItemReferenceHash { get; set; }

    [JsonPropertyName("stackSize")]
    public int StackSize { get; set; }

    [JsonPropertyName("transferToVault")]
    public bool TransferToVault { get; set; }

    /// <summary>
    ///     The instance ID of the item for this action request.
    /// </summary>
    [JsonPropertyName("itemId")]
    public long ItemId { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyItemTransferRequest? other)
    {
        return other is not null &&
               ItemReferenceHash == other.ItemReferenceHash &&
               StackSize == other.StackSize &&
               TransferToVault == other.TransferToVault &&
               ItemId == other.ItemId &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }
}