using NetBungieApi.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryPartyMember
    {
        public long MembershipId { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; }
        public string DisplayName { get; }
        public DestinyPartyMemberStates Status { get; }

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
