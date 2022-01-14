namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     A flags enumeration/bitmask indicating the versions of the game that a given user has purchased.
/// </summary>
[System.Flags]
public enum DestinyGameVersions : int
{
    None = 0,
    Destiny2 = 1,
    DLC1 = 2,
    DLC2 = 4,
    Forsaken = 8,
    YearTwoAnnualPass = 16,
    Shadowkeep = 32,
    BeyondLight = 64,
    Anniversary30th = 128,
    TheWitchQueen = 256
}
