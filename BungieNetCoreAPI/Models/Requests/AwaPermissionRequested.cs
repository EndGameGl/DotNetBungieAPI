using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public sealed class AwaPermissionRequested
    {
        /// <summary>
        /// Type of advanced write action.
        /// </summary>
        [JsonPropertyName("type")]
        public AwaType Type { get; }

        /// <summary>
        /// Item instance ID the action shall be applied to. This is optional for all but a new AwaType values. Rule of thumb is to provide the item instance ID if one is available.
        /// </summary>
        [JsonPropertyName("affectedItemId")]
        public long? AffectedItemId { get; }

        /// <summary>
        /// Destiny membership type of the account to modify.
        /// </summary>
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; }

        /// <summary>
        /// Destiny character ID, if applicable, that will be affected by the action.
        /// </summary>
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