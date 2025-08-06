namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     The action that happens when the user attempts to refund an item.
/// </summary>
public enum DestinyVendorItemRefundPolicy : int
{
    NotRefundable = 0,

    DeletesItem = 1,

    RevokesLicense = 2
}
