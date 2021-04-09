using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Profiles
{
    public sealed record DestinyProfileTransitoryJoinability
    {
        [JsonPropertyName("openSlots")]
        public int OpenSlots { get; init; }
        [JsonPropertyName("privacySetting")]
        public DestinyGamePrivacySetting PrivacySetting { get; init; }
        [JsonPropertyName("closedReasons")]
        public DestinyJoinClosedReasons ClosedReasons { get; init; }
    }
}
