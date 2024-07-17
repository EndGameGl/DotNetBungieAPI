namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     A flags enumeration/bitmask indicating the versions of the game that a given user has purchased.
/// </summary>
[Flags]
public enum DestinyGameVersions
{
    None = 0,
    Vanilla = 1,
    Osiris = 2,
    Warmind = 4,
    Forsaken = 8,
    YearTwoAnnualPass = 16,
    Shadowkeep = 32,
    BeyondLight = 64,
    Anniversary30th = 128,
    TheWitchQueen = 256,
    Lightfall = 512,
    TheFinalShape = 1024
}
