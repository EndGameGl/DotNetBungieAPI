using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public sealed class DestinyDerivedItemDefinition
{

    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; init; }

    [JsonPropertyName("itemName")]
    public string ItemName { get; init; }

    [JsonPropertyName("itemDetail")]
    public string ItemDetail { get; init; }

    [JsonPropertyName("itemDescription")]
    public string ItemDescription { get; init; }

    [JsonPropertyName("iconPath")]
    public string IconPath { get; init; }

    [JsonPropertyName("vendorItemIndex")]
    public int VendorItemIndex { get; init; }
}
