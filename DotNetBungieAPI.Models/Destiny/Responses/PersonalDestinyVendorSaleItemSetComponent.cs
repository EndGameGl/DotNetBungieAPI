namespace DotNetBungieAPI.Models.Destiny.Responses;

public sealed class PersonalDestinyVendorSaleItemSetComponent
{
    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent>? SaleItems { get; init; }
}
