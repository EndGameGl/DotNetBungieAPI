using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DestinyVendorSaleItemSetComponentOfDestinyPublicVendorSaleItemComponent
{

    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Components.Vendors.DestinyPublicVendorSaleItemComponent> SaleItems { get; init; }
}
