using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using NetBungieAPI.Models.Destiny.Profiles;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyProfileTransitoryComponent
    {
        [JsonPropertyName("partyMembers")]
        public ReadOnlyCollection<DestinyProfileTransitoryPartyMember> PartyMembers { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyProfileTransitoryPartyMember>();
        [JsonPropertyName("currentActivity")]
        public DestinyProfileTransitoryCurrentActivity CurrentActivity { get; init; }
        [JsonPropertyName("joinability")]
        public DestinyProfileTransitoryJoinability JoinAbility { get; init; }
        [JsonPropertyName("tracking")]
        public ReadOnlyCollection<DestinyProfileTransitoryTrackingEntry> TrackedEntities { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyProfileTransitoryTrackingEntry>();
        [JsonPropertyName("lastOrbitedDestinationHash")]
        public DefinitionHashPointer<DestinyDestinationDefinition> LastOrbitedDestination { get; init; } = DefinitionHashPointer<DestinyDestinationDefinition>.Empty;
    }
}
