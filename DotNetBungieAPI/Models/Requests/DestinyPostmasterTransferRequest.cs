namespace DotNetBungieAPI.Models.Requests;

public sealed record DestinyPostmasterTransferRequest
{
    public DestinyPostmasterTransferRequest(uint itemReferenceHash, int stackSize, long itemId,
        long characterId, BungieMembershipType membershipType)
    {
        (ItemReferenceHash, StackSize, ItemId, CharacterId, MembershipType) =
            (itemReferenceHash, stackSize, itemId, characterId, membershipType);
    }

    [JsonPropertyName("itemReferenceHash")]
    public uint ItemReferenceHash { get; }

    [JsonPropertyName("stackSize")] public int StackSize { get; }

    [JsonPropertyName("itemId")] public long ItemId { get; }

    [JsonPropertyName("characterId")] public long CharacterId { get; }

    [JsonPropertyName("membershipType")] public BungieMembershipType MembershipType { get; }
}