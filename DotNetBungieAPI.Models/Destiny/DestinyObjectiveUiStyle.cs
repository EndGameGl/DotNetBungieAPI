namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     If the objective has a known UI label, this enumeration will represent it.
/// </summary>
public enum DestinyObjectiveUiStyle : int
{
    None = 0,

    Highlighted = 1,

    CraftingWeaponLevel = 2,

    CraftingWeaponLevelProgress = 3,

    CraftingWeaponTimestamp = 4,

    CraftingMementos = 5,

    CraftingMementoTitle = 6,

    DiscoverableMystery0 = 7,

    DiscoverableMystery1 = 8,

    DiscoverableMystery2 = 9,

    DiscoverableMystery3 = 10,

    DiscoverableMystery4 = 11,

    DiscoverableExotic = 12
}
