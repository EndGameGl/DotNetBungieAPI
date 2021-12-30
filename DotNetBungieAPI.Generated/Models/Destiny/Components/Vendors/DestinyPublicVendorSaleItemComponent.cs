using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

public sealed class DestinyPublicVendorSaleItemComponent
{

    [JsonPropertyName("vendorItemIndex")]
    public int VendorItemIndex { get; init; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("overrideStyleItemHash")]
    public uint? OverrideStyleItemHash { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("costs")]
    public List<Destiny.DestinyItemQuantity> Costs { get; init; }

    [JsonPropertyName("overrideNextRefreshDate")]
    public DateTime? OverrideNextRefreshDate { get; init; }

    [JsonPropertyName("apiPurchasable")]
    public bool? ApiPurchasable { get; init; }
}
