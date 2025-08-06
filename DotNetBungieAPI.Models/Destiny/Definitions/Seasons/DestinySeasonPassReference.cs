namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines the hash, unlock flag and start time of season passes
/// </summary>
public sealed class DestinySeasonPassReference
{
    /// <summary>
    ///     The Season Pass Hash
    /// </summary>
    [JsonPropertyName("seasonPassHash")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinySeasonPassDefinition> SeasonPassHash { get; init; }

    /// <summary>
    ///     The Season Pass Start Date
    /// </summary>
    [JsonPropertyName("seasonPassStartDate")]
    public DateTime? SeasonPassStartDate { get; init; }

    /// <summary>
    ///     The Season Pass End Date
    /// </summary>
    [JsonPropertyName("seasonPassEndDate")]
    public DateTime? SeasonPassEndDate { get; init; }
}
