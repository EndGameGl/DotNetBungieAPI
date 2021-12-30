using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyLeaderboardResults
{

    [JsonPropertyName("focusMembershipId")]
    public long? FocusMembershipId { get; init; }

    [JsonPropertyName("focusCharacterId")]
    public long? FocusCharacterId { get; init; }
}
