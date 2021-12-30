using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

public sealed class DestinyProfileTransitoryPartyMember
{

    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("status")]
    public Destiny.DestinyPartyMemberStates Status { get; init; }
}
