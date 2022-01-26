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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemTransferRequest? other)
    {
        if (other is null) return;
        if (ItemReferenceHash != other.ItemReferenceHash)
        {
            ItemReferenceHash = other.ItemReferenceHash;
            OnPropertyChanged(nameof(ItemReferenceHash));
        }
        if (StackSize != other.StackSize)
        {
            StackSize = other.StackSize;
            OnPropertyChanged(nameof(StackSize));
        }
        if (TransferToVault != other.TransferToVault)
        {
            TransferToVault = other.TransferToVault;
            OnPropertyChanged(nameof(TransferToVault));
        }
        if (ItemId != other.ItemId)
        {
            ItemId = other.ItemId;
            OnPropertyChanged(nameof(ItemId));
        }
        if (CharacterId != other.CharacterId)
        {
            CharacterId = other.CharacterId;
            OnPropertyChanged(nameof(CharacterId));
        }
        if (MembershipType != other.MembershipType)
        {
            MembershipType = other.MembershipType;
            OnPropertyChanged(nameof(MembershipType));
        }
    }
}