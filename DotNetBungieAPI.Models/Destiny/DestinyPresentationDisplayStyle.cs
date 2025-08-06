namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     A hint for how the presentation node should be displayed when shown in a list. How you use this is your UI is up to you.
/// </summary>
public enum DestinyPresentationDisplayStyle : int
{
    /// <summary>
    ///     Display the item as a category, through which sub-items are filtered.
    /// </summary>
    Category = 0,

    Badge = 1,

    Medals = 2,

    Collectible = 3,

    Record = 4,

    SeasonalTriumph = 5,

    GuardianRank = 6,

    CategoryCollectibles = 7,

    CategoryCurrencies = 8,

    CategoryEmblems = 9,

    CategoryEmotes = 10,

    CategoryEngrams = 11,

    CategoryFinishers = 12,

    CategoryGhosts = 13,

    CategoryMisc = 14,

    CategoryMods = 15,

    CategoryOrnaments = 16,

    CategoryShaders = 17,

    CategoryShips = 18,

    CategorySpawnfx = 19,

    CategoryUpgradeMaterials = 20
}
