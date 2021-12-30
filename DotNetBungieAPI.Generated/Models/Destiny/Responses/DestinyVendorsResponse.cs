using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public sealed class DestinyVendorsResponse
{

    [JsonPropertyName("vendorGroups")]
    public SingleComponentResponseOfDestinyVendorGroupComponent VendorGroups { get; init; }

    [JsonPropertyName("vendors")]
    public DictionaryComponentResponseOfuint32AndDestinyVendorComponent Vendors { get; init; }

    [JsonPropertyName("categories")]
    public DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent Categories { get; init; }

    [JsonPropertyName("sales")]
    public DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent Sales { get; init; }

    [JsonPropertyName("itemComponents")]
    public Dictionary<uint, DestinyItemComponentSetOfint32> ItemComponents { get; init; }

    [JsonPropertyName("currencyLookups")]
    public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; init; }

    [JsonPropertyName("stringVariables")]
    public SingleComponentResponseOfDestinyStringVariablesComponent StringVariables { get; init; }
}
