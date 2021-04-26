using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public sealed class DestinyInsertPlugsActionRequest
    {
        [JsonPropertyName("actionToken")]
        public string ActionToken { get; }
        [JsonPropertyName("itemInstanceId")]
        public long ItemInstanceId { get; }
        [JsonPropertyName("plug")]
        public DestinyInsertPlugsRequestEntry Plug { get; }
        [JsonPropertyName("characterId")]
        public long CharacterId { get; }
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; }

        public DestinyInsertPlugsActionRequest(string actionToken, long itemInstanceId,
            DestinyInsertPlugsRequestEntry plug, long characterId, BungieMembershipType membershipType)
        {
            ActionToken = actionToken;
            ItemInstanceId = itemInstanceId;
            Plug = plug;
            CharacterId = characterId;
            MembershipType = membershipType;
        }
    }
}