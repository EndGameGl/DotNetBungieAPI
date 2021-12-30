using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Vendors;

public sealed class DestinyVendorSaleItemComponent
{

    [JsonPropertyName("saleStatus")]
    public Destiny.VendorItemStatus SaleStatus { get; init; }

    [JsonPropertyName("requiredUnlocks")]
    public List<uint> RequiredUnlocks { get; init; }

    [JsonPropertyName("unlockStatuses")]
    public List<Destiny.DestinyUnlockStatus> UnlockStatuses { get; init; }

    [JsonPropertyName("failureIndexes")]
    public List<int> FailureIndexes { get; init; }

    [JsonPropertyName("augments")]
    public Destiny.DestinyVendorItemState Augments { get; init; }

    [JsonPropertyName("itemValueVisibility")]
    public List<bool> ItemValueVisibility { get; init; }

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
