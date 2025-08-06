namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines the name, start time and ranks included in an Act of an Episode.
/// </summary>
public sealed class DestinySeasonActDefinition
{
    /// <summary>
    ///     The name of the Act.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    /// <summary>
    ///     The start time of the Act.
    /// </summary>
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; init; }

    /// <summary>
    ///     The number of ranks included in the Act.
    /// </summary>
    [JsonPropertyName("rankCount")]
    public int RankCount { get; init; }
}
