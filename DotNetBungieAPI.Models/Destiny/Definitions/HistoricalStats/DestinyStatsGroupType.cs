namespace DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

/// <summary>
///     If the enum value is > 100, it is a "special" group that cannot be queried for directly (special cases apply to
///     when they are returned, and are not relevant in general cases)
/// </summary>
public enum DestinyStatsGroupType
{
    None = 0,
    General = 1,
    Weapons = 2,
    Medals = 3,

    /// <summary>
    ///     This is purely to serve as the dividing line between filterable and un-filterable groups. Below this number is a
    ///     group you can pass as a filter. Above it are groups used in very specific circumstances and not relevant for
    ///     filtering.
    /// </summary>
    ReservedGroups = 100,

    /// <summary>
    ///     Only applicable while generating leaderboards.
    /// </summary>
    Leaderboard = 101,

    /// <summary>
    ///     These will *only* be consumed by GetAggregateStatsByActivity
    /// </summary>
    Activity = 102,

    /// <summary>
    ///     These are only consumed and returned by GetUniqueWeaponHistory
    /// </summary>
    UniqueWeapon = 103,
    Internal = 104
}
