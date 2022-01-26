namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public class PersonalDestinyVendorSaleItemSetComponent : IDeepEquatable<PersonalDestinyVendorSaleItemSetComponent>
{
    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> SaleItems { get; set; }

    public bool DeepEquals(PersonalDestinyVendorSaleItemSetComponent? other)
    {
        return other is not null &&
               SaleItems.DeepEqualsDictionary(other.SaleItems);
    }
}