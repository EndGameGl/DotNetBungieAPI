using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorItemDefinition
{

    [JsonPropertyName("vendorItemIndex")]
    public int VendorItemIndex { get; init; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("failureIndexes")]
    public List<int> FailureIndexes { get; init; }

    [JsonPropertyName("currencies")]
    public List<Destiny.Definitions.DestinyVendorItemQuantity> Currencies { get; init; }

    [JsonPropertyName("refundPolicy")]
    public Destiny.DestinyVendorItemRefundPolicy RefundPolicy { get; init; }

    [JsonPropertyName("refundTimeLimit")]
    public int RefundTimeLimit { get; init; }

    [JsonPropertyName("creationLevels")]
    public List<Destiny.Definitions.DestinyItemCreationEntryLevelDefinition> CreationLevels { get; init; }

    [JsonPropertyName("displayCategoryIndex")]
    public int DisplayCategoryIndex { get; init; }

    [JsonPropertyName("categoryIndex")]
    public int CategoryIndex { get; init; }

    [JsonPropertyName("originalCategoryIndex")]
    public int OriginalCategoryIndex { get; init; }

    [JsonPropertyName("minimumLevel")]
    public int MinimumLevel { get; init; }

    [JsonPropertyName("maximumLevel")]
    public int MaximumLevel { get; init; }

    [JsonPropertyName("action")]
    public Destiny.Definitions.DestinyVendorSaleItemActionBlockDefinition Action { get; init; }

    [JsonPropertyName("displayCategory")]
    public string DisplayCategory { get; init; }

    [JsonPropertyName("inventoryBucketHash")]
    public uint InventoryBucketHash { get; init; }

    [JsonPropertyName("visibilityScope")]
    public Destiny.DestinyGatingScope VisibilityScope { get; init; }

    [JsonPropertyName("purchasableScope")]
    public Destiny.DestinyGatingScope PurchasableScope { get; init; }

    [JsonPropertyName("exclusivity")]
    public BungieMembershipType Exclusivity { get; init; }

    [JsonPropertyName("isOffer")]
    public bool? IsOffer { get; init; }

    [JsonPropertyName("isCrm")]
    public bool? IsCrm { get; init; }

    [JsonPropertyName("sortValue")]
    public int SortValue { get; init; }

    [JsonPropertyName("expirationTooltip")]
    public string ExpirationTooltip { get; init; }

    [JsonPropertyName("redirectToSaleIndexes")]
    public List<int> RedirectToSaleIndexes { get; init; }

    [JsonPropertyName("socketOverrides")]
    public List<Destiny.Definitions.DestinyVendorItemSocketOverride> SocketOverrides { get; init; }

    [JsonPropertyName("unpurchasable")]
    public bool? Unpurchasable { get; init; }
}
