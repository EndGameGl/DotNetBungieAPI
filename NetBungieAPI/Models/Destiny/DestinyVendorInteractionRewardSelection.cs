namespace NetBungieAPI.Models.Destiny
{
    /// <summary>
    ///     When a Vendor Interaction provides rewards, they'll either let you choose one or let you have all of them. This
    ///     determines which it will be.
    /// </summary>
    public enum DestinyVendorInteractionRewardSelection
    {
        None = 0,
        One = 1,
        All = 2
    }
}