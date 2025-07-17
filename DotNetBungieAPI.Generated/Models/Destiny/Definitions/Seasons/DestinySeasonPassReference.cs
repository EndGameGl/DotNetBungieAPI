namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines the hash, unlock flag and start time of season passes
/// </summary>
public class DestinySeasonPassReference
{
    /// <summary>
    ///     The Season Pass Hash
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Seasons.DestinySeasonPassDefinition>("Destiny.Definitions.Seasons.DestinySeasonPassDefinition")]
    [JsonPropertyName("seasonPassHash")]
    public uint? SeasonPassHash { get; set; }

    /// <summary>
    ///     The Season Pass Start Date
    /// </summary>
    [JsonPropertyName("seasonPassStartDate")]
    public DateTime? SeasonPassStartDate { get; set; }

    /// <summary>
    ///     The Season Pass End Date
    /// </summary>
    [JsonPropertyName("seasonPassEndDate")]
    public DateTime? SeasonPassEndDate { get; set; }
}
