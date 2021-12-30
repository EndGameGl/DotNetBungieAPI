using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorCategoryEntryDefinition
{

    [JsonPropertyName("categoryIndex")]
    public int CategoryIndex { get; init; }

    [JsonPropertyName("sortValue")]
    public int SortValue { get; init; }

    [JsonPropertyName("categoryHash")]
    public uint CategoryHash { get; init; }

    [JsonPropertyName("quantityAvailable")]
    public int QuantityAvailable { get; init; }

    [JsonPropertyName("showUnavailableItems")]
    public bool ShowUnavailableItems { get; init; }

    [JsonPropertyName("hideIfNoCurrency")]
    public bool HideIfNoCurrency { get; init; }

    [JsonPropertyName("hideFromRegularPurchase")]
    public bool HideFromRegularPurchase { get; init; }

    [JsonPropertyName("buyStringOverride")]
    public string BuyStringOverride { get; init; }

    [JsonPropertyName("disabledDescription")]
    public string DisabledDescription { get; init; }

    [JsonPropertyName("displayTitle")]
    public string DisplayTitle { get; init; }

    [JsonPropertyName("overlay")]
    public Destiny.Definitions.DestinyVendorCategoryOverlayDefinition Overlay { get; init; }

    [JsonPropertyName("vendorItemIndexes")]
    public List<int> VendorItemIndexes { get; init; }

    [JsonPropertyName("isPreview")]
    public bool IsPreview { get; init; }

    [JsonPropertyName("isDisplayOnly")]
    public bool IsDisplayOnly { get; init; }

    [JsonPropertyName("resetIntervalMinutesOverride")]
    public int ResetIntervalMinutesOverride { get; init; }

    [JsonPropertyName("resetOffsetMinutesOverride")]
    public int ResetOffsetMinutesOverride { get; init; }
}
