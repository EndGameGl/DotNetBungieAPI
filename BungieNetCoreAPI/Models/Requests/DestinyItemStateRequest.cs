using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public sealed class DestinyItemStateRequest
    {
        [JsonPropertyName("state")]
        public bool State { get; }
        
        [JsonPropertyName("itemId")]
        public long ItemId { get; }
        
        [JsonPropertyName("characterId")]
        public long CharacterId { get; }
        
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; }

        public DestinyItemStateRequest(bool state, long itemId, long characterId, BungieMembershipType membershipType)
        {
            State = state;
            ItemId = itemId;
            CharacterId = characterId;
            MembershipType = membershipType;
        }
    }
}