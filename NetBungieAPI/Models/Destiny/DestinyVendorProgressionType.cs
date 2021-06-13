namespace NetBungieAPI.Models.Destiny
{
    /// <summary>
    /// Describes the type of progression that a vendor has.
    /// </summary>
    public enum DestinyVendorProgressionType
    {
        /// <summary>
        /// The original rank progression from token redemption.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Progression from ranks in ritual content. For example: Crucible (Shaxx), Gambit (Drifter), and Season 13 Battlegrounds (War Table).
        /// </summary>
        Ritual = 1
    }
}