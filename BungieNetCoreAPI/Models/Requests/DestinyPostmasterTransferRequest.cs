using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public sealed record DestinyPostmasterTransferRequest
    {
        [JsonPropertyName("itemReferenceHash")]
        public uint ItemReferenceHash { get; }
        
        [JsonPropertyName("stackSize")] 
        public int StackSize { get; }

        [JsonPropertyName("itemId")] 
        public long ItemId { get; }

        [JsonPropertyName("characterId")] 
        public long CharacterId { get; }

        [JsonPropertyName("membershipType")] 
        public BungieMembershipType MembershipType { get; }

        public DestinyPostmasterTransferRequest(uint itemReferenceHash, int stackSize, long itemId,
            long characterId, BungieMembershipType membershipType) 
            => (ItemReferenceHash, StackSize, ItemId, CharacterId, MembershipType) = 
                (itemReferenceHash, stackSize, itemId, characterId, membershipType);
    }
}