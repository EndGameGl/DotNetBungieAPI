namespace DotNetBungieAPI.Generated.Models;

public class DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent : IDeepEquatable<DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent>
{
    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> SaleItems { get; set; }

    public bool DeepEquals(DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent? other)
    {
        return other is not null &&
               SaleItems.DeepEqualsDictionary(other.SaleItems);
    }
}