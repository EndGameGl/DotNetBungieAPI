using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     Indicates the type of filter to apply to Vendor results.
/// </summary>
public enum DestinyVendorFilter : int
{
    None = 0,
    ApiPurchasable = 1
}
