namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons;

public sealed record DestinySeasonActDefinition : IDeepEquatable<DestinySeasonActDefinition>
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("rankCount")]
    public int RankCount { get; init; }

    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; init; }

    public bool DeepEquals(DestinySeasonActDefinition other)
    {
        return other != null
            && DisplayName == other.DisplayName
            && RankCount == other.RankCount
            && StartTime == other.StartTime;
    }
}
