using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryPartyMember
    {
        public long MembershipId { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; init; }
        public string DisplayName { get; init; }
        public DestinyPartyMemberStates Status { get; init; }

        [JsonConstructor]
        internal DestinyProfileTransitoryPartyMember(long membershipId, uint emblemHash, string displayName, DestinyPartyMemberStates status)
        {
            MembershipId = membershipId;
            Emblem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(emblemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            DisplayName = displayName;
            Status = status;
        }
    }
}
