namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record PublicDestinyVendorSaleItemSetComponent
{
    [JsonPropertyName("saleItems")]
    public ReadOnlyDictionary<int, DestinyPublicVendorSaleItemComponent> SaleItems { get; init; } =
        ReadOnlyDictionary<int, DestinyPublicVendorSaleItemComponent>.Empty;
}
