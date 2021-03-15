using NetBungieAPI.Destiny.Definitions.Destinations;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryComponent
    {
        public ReadOnlyCollection<DestinyProfileTransitoryPartyMember> PartyMembers { get; }
        public DestinyProfileTransitoryCurrentActivity CurrentActivity { get; }
        public DestinyProfileTransitoryJoinability JoinAbility { get; }
        public ReadOnlyCollection<DestinyProfileTransitoryTrackingEntry> TrackedEntities { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> LastOrbitedDestination { get; }

        [JsonConstructor]
        internal DestinyProfileTransitoryComponent(DestinyProfileTransitoryPartyMember[] partyMembers, DestinyProfileTransitoryCurrentActivity currentActivity,
            DestinyProfileTransitoryJoinability joinability, DestinyProfileTransitoryTrackingEntry[] tracking, uint? lastOrbitedDestinationHash)
        {
            PartyMembers = partyMembers.AsReadOnlyOrEmpty();
            CurrentActivity = currentActivity;
            JoinAbility = joinability;
            TrackedEntities = tracking.AsReadOnlyOrEmpty();
            LastOrbitedDestination = new DefinitionHashPointer<DestinyDestinationDefinition>(lastOrbitedDestinationHash, DefinitionsEnum.DestinyDestinationDefinition);
        }
    }
}
