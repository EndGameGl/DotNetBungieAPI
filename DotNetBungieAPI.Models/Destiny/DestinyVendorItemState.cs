namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     The possible states of Destiny Profile Records. IMPORTANT: Any given item can theoretically have many of these
///     states simultaneously: as a result, this was altered to be a flags enumeration/bitmask for v3.2.0.
/// </summary>
[Flags]
public enum DestinyVendorItemState
{
    /// <summary>
    ///     There are no augments on the item.
    /// </summary>
    None = 0,

    /// <summary>
    ///     Deprecated forever (probably). There was a time when Records were going to be implemented through Vendors, and this
    ///     field was relevant. Now they're implemented through Presentation Nodes, and this field doesn't matter anymore.
    /// </summary>
    Incomplete = 1,

    /// <summary>
    ///     Deprecated forever (probably). See the description of the "Incomplete" value for the juicy scoop.
    /// </summary>
    RewardAvailable = 2,

    /// <summary>
    ///     Deprecated forever (probably). See the description of the "Incomplete" value for the juicy scoop.
    /// </summary>
    Complete = 4,

    /// <summary>
    ///     This item is considered to be "newly available", and should have some UI showing how shiny it is.
    /// </summary>
    New = 8,

    /// <summary>
    ///     This item is being "featured", and should be shiny in a different way from items that are merely new.
    /// </summary>
    Featured = 16,

    /// <summary>
    ///     This item is only available for a limited time, and that time is approaching.
    /// </summary>
    Ending = 32,

    /// <summary>
    ///     This item is "on sale". Get it while it's hot.
    /// </summary>
    OnSale = 64,

    /// <summary>
    ///     This item is already owned.
    /// </summary>
    Owned = 128,

    /// <summary>
    ///     This item should be shown with a "wide view" instead of normal icon view.
    /// </summary>
    WideView = 256,

    /// <summary>
    ///     This indicates that you should show some kind of attention-requesting indicator on the item, in a similar manner to
    ///     items in the nexus that have such notifications.
    /// </summary>
    NexusAttention = 512,

    /// <summary>
    ///     This indicates that the item has some sort of a 'set' discount.
    /// </summary>
    SetDiscount = 1024,

    /// <summary>
    ///     This indicates that the item has a price drop.
    /// </summary>
    PriceDrop = 2048,

    /// <summary>
    ///     This indicates that the item is a daily offer.
    /// </summary>
    DailyOffer = 4096,

    /// <summary>
    ///     This indicates that the item is for charity.
    /// </summary>
    Charity = 8192,

    /// <summary>
    ///     This indicates that the item has a seasonal reward expiration.
    /// </summary>
    SeasonalRewardExpiration = 16384,

    /// <summary>
    ///     This indicates that the sale item is the best deal among different choices.
    /// </summary>
    BestDeal = 32768,

    /// <summary>
    ///     This indicates that the sale item is popular.
    /// </summary>
    Popular = 65536,

    /// <summary>
    ///     This indicates that the sale item is free.
    /// </summary>
    Free = 131072,

    /// <summary>
    ///     This indicates that the sale item is locked.
    /// </summary>
    Locked = 262144,

    /// <summary>
    ///     This indicates that the sale item is paracausal.
    /// </summary>
    Paracausal = 524288,

    Cryptarch = 1048576
}
