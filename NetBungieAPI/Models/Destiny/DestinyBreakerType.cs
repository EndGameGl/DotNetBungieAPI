namespace NetBungieAPI.Models.Destiny
{
    /// <summary>
    ///     A plug can optionally have a "Breaker Type": a special ability that can affect units in unique ways. Activating
    ///     this plug can grant one of these types.
    /// </summary>
    public enum DestinyBreakerType
    {
        None = 0,
        ShieldPiercing = 1,
        Disruption = 2,
        Stagger = 3
    }
}