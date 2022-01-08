namespace DotNetBungieAPI.Models.Requests;

public sealed class DestinyItemTransferRequest
{
    public DestinyItemTransferRequest(
        uint itemReferenceHash,
        int stackSize,
        bool transferToVault,
        long itemId,
        long characterId,
        BungieMembershipType membershipType)
    {
        (ItemReferenceHash, StackSize, TransferToVault, ItemId, CharacterId, MembershipType) =
            (itemReferenceHash, stackSize, transferToVault, itemId, characterId, membershipType);
    }

    [JsonPropertyName("itemReferenceHash")]
    public uint ItemReferenceHash { get; }

    [JsonPropertyName("stackSize")] public int StackSize { get; }

    [JsonPropertyName("transferToVault")] public bool TransferToVault { get; }

    [JsonPropertyName("itemId")] public long ItemId { get; }

    [JsonPropertyName("characterId")] public long CharacterId { get; }

    [JsonPropertyName("membershipType")] public BungieMembershipType MembershipType { get; }
}