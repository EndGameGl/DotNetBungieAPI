using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Profiles
{
    public sealed record DestinyProfileTransitoryPartyMember
    {
        [JsonPropertyName("membershipId")]
        public long MembershipId { get; init; }
        [JsonPropertyName("emblemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }
        [JsonPropertyName("status")]
        public DestinyPartyMemberStates Status { get; init; }
    }
}
