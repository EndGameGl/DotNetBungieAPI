using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

public sealed class DestinyProfileTransitoryComponent
{

    [JsonPropertyName("partyMembers")]
    public List<Destiny.Components.Profiles.DestinyProfileTransitoryPartyMember> PartyMembers { get; init; }

    [JsonPropertyName("currentActivity")]
    public Destiny.Components.Profiles.DestinyProfileTransitoryCurrentActivity CurrentActivity { get; init; }

    [JsonPropertyName("joinability")]
    public Destiny.Components.Profiles.DestinyProfileTransitoryJoinability Joinability { get; init; }

    [JsonPropertyName("tracking")]
    public List<Destiny.Components.Profiles.DestinyProfileTransitoryTrackingEntry> Tracking { get; init; }

    [JsonPropertyName("lastOrbitedDestinationHash")]
    public uint? LastOrbitedDestinationHash { get; init; }
}
