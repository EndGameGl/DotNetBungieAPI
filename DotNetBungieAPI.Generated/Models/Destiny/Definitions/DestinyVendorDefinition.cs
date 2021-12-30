using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.DestinyVendorDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("vendorProgressionType")]
    public Destiny.DestinyVendorProgressionType VendorProgressionType { get; init; }

    [JsonPropertyName("buyString")]
    public string BuyString { get; init; }

    [JsonPropertyName("sellString")]
    public string SellString { get; init; }

    [JsonPropertyName("displayItemHash")]
    public uint DisplayItemHash { get; init; }

    [JsonPropertyName("inhibitBuying")]
    public bool InhibitBuying { get; init; }

    [JsonPropertyName("inhibitSelling")]
    public bool InhibitSelling { get; init; }

    [JsonPropertyName("factionHash")]
    public uint FactionHash { get; init; }

    [JsonPropertyName("resetIntervalMinutes")]
    public int ResetIntervalMinutes { get; init; }

    [JsonPropertyName("resetOffsetMinutes")]
    public int ResetOffsetMinutes { get; init; }

    [JsonPropertyName("failureStrings")]
    public List<string> FailureStrings { get; init; }

    [JsonPropertyName("unlockRanges")]
    public List<Dates.DateRange> UnlockRanges { get; init; }

    [JsonPropertyName("vendorIdentifier")]
    public string VendorIdentifier { get; init; }

    [JsonPropertyName("vendorPortrait")]
    public string VendorPortrait { get; init; }

    [JsonPropertyName("vendorBanner")]
    public string VendorBanner { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    [JsonPropertyName("visible")]
    public bool Visible { get; init; }

    [JsonPropertyName("vendorSubcategoryIdentifier")]
    public string VendorSubcategoryIdentifier { get; init; }

    [JsonPropertyName("consolidateCategories")]
    public bool ConsolidateCategories { get; init; }

    [JsonPropertyName("actions")]
    public List<Destiny.Definitions.DestinyVendorActionDefinition> Actions { get; init; }

    [JsonPropertyName("categories")]
    public List<Destiny.Definitions.DestinyVendorCategoryEntryDefinition> Categories { get; init; }

    [JsonPropertyName("originalCategories")]
    public List<Destiny.Definitions.DestinyVendorCategoryEntryDefinition> OriginalCategories { get; init; }

    [JsonPropertyName("displayCategories")]
    public List<Destiny.Definitions.DestinyDisplayCategoryDefinition> DisplayCategories { get; init; }

    [JsonPropertyName("interactions")]
    public List<Destiny.Definitions.DestinyVendorInteractionDefinition> Interactions { get; init; }

    [JsonPropertyName("inventoryFlyouts")]
    public List<Destiny.Definitions.DestinyVendorInventoryFlyoutDefinition> InventoryFlyouts { get; init; }

    [JsonPropertyName("itemList")]
    public List<Destiny.Definitions.DestinyVendorItemDefinition> ItemList { get; init; }

    [JsonPropertyName("services")]
    public List<Destiny.Definitions.DestinyVendorServiceDefinition> Services { get; init; }

    [JsonPropertyName("acceptedItems")]
    public List<Destiny.Definitions.DestinyVendorAcceptedItemDefinition> AcceptedItems { get; init; }

    [JsonPropertyName("returnWithVendorRequest")]
    public bool ReturnWithVendorRequest { get; init; }

    [JsonPropertyName("locations")]
    public List<Destiny.Definitions.Vendors.DestinyVendorLocationDefinition> Locations { get; init; }

    [JsonPropertyName("groups")]
    public List<Destiny.Definitions.DestinyVendorGroupReference> Groups { get; init; }

    [JsonPropertyName("ignoreSaleItemHashes")]
    public List<uint> IgnoreSaleItemHashes { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
