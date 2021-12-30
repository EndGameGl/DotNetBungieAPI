using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

public sealed class DestinyProfileTransitoryJoinability
{

    [JsonPropertyName("openSlots")]
    public int OpenSlots { get; init; }

    [JsonPropertyName("privacySetting")]
    public Destiny.DestinyGamePrivacySetting PrivacySetting { get; init; }

    [JsonPropertyName("closedReasons")]
    public Destiny.DestinyJoinClosedReasons ClosedReasons { get; init; }
}
