using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public sealed class AwaPermissionRequested
    {
        [JsonPropertyName("type")]
        public AwaType Type { get; }
        [JsonPropertyName("affectedItemId")]
        public long? AffectedItemId { get; }
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; }
        [JsonPropertyName("characterId")]
        public long? CharacterId { get; }

        public AwaPermissionRequested(AwaType type, long? affectedItemId, BungieMembershipType membershipType,
            long? characterId)
        {
            Type = type;
            AffectedItemId = affectedItemId;
            MembershipType = membershipType;
            CharacterId = characterId;
        }
    }
}