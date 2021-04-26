using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public sealed class DestinyItemSetActionRequest
    {
        [JsonPropertyName("itemIds")]
        public long[] ItemIds { get; }
        
        [JsonPropertyName("characterId")]
        public long CharacterId { get; }
        
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; }
        
        public DestinyItemSetActionRequest(long[] itemIds, long characterId, BungieMembershipType membershipType)
        {
            ItemIds = itemIds;
            CharacterId = characterId;
            MembershipType = membershipType;
        }
    }
}