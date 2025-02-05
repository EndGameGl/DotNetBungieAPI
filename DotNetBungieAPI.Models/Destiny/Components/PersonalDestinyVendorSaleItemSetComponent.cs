namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record PersonalDestinyVendorSaleItemSetComponent
{
    [JsonPropertyName("saleItems")]
    public ReadOnlyDictionary<uint, DestinyVendorSaleItemComponent> SaleItems { get; init; } =
        ReadOnlyDictionary<uint, DestinyVendorSaleItemComponent>.Empty;
}
