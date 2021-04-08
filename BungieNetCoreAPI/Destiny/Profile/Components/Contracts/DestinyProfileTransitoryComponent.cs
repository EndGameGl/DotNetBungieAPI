using NetBungieAPI.Destiny.Definitions.Destinations;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryComponent
    {
        public ReadOnlyCollection<DestinyProfileTransitoryPartyMember> PartyMembers { get; init; }
        public DestinyProfileTransitoryCurrentActivity CurrentActivity { get; init; }
        public DestinyProfileTransitoryJoinability JoinAbility { get; init; }
        public ReadOnlyCollection<DestinyProfileTransitoryTrackingEntry> TrackedEntities { get; init; }
        public DefinitionHashPointer<DestinyDestinationDefinition> LastOrbitedDestination { get; init; }

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
