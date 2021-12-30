using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent
{

    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> SaleItems { get; init; }
}
