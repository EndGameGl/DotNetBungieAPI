using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Requests
{
    public sealed class DestinyItemSetActionRequest
    {
        public DestinyItemSetActionRequest(long[] itemIds, long characterId, BungieMembershipType membershipType)
        {
            ItemIds = itemIds;
            CharacterId = characterId;
            MembershipType = membershipType;
        }

        [JsonPropertyName("itemIds")] public long[] ItemIds { get; }

        [JsonPropertyName("characterId")] public long CharacterId { get; }

        [JsonPropertyName("membershipType")] public BungieMembershipType MembershipType { get; }
    }
}