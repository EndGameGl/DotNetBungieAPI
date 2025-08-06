namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Describes the type of progression that a vendor has.
/// </summary>
public enum DestinyVendorProgressionType : int
{
    /// <summary>
    ///     The original rank progression from token redemption.
    /// </summary>
    Default = 0,

    /// <summary>
    ///     Progression from ranks in ritual content. For example: Crucible (Shaxx), Gambit (Drifter), and Season 13 Battlegrounds (War Table).
    /// </summary>
    Ritual = 1,

    /// <summary>
    ///     A vendor progression with no seasonal refresh. For example: Xur in the Eternity destination for the 30th Anniversary.
    /// </summary>
    NoSeasonalRefresh = 2
}
