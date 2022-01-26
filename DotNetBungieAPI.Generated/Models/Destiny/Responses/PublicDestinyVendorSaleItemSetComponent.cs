namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public class PublicDestinyVendorSaleItemSetComponent : IDeepEquatable<PublicDestinyVendorSaleItemSetComponent>
{
    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Components.Vendors.DestinyPublicVendorSaleItemComponent> SaleItems { get; set; }

    public bool DeepEquals(PublicDestinyVendorSaleItemSetComponent? other)
    {
        return other is not null &&
               SaleItems.DeepEqualsDictionary(other.SaleItems);
    }
}