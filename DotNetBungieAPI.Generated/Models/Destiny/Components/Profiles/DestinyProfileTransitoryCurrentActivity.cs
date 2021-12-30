using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

public sealed class DestinyProfileTransitoryCurrentActivity
{

    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; init; }

    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; init; }

    [JsonPropertyName("score")]
    public float Score { get; init; }

    [JsonPropertyName("highestOpposingFactionScore")]
    public float HighestOpposingFactionScore { get; init; }

    [JsonPropertyName("numberOfOpponents")]
    public int NumberOfOpponents { get; init; }

    [JsonPropertyName("numberOfPlayers")]
    public int NumberOfPlayers { get; init; }
}
