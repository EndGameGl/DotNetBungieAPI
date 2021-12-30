using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public sealed class DestinyPublicVendorsResponse
{

    [JsonPropertyName("vendorGroups")]
    public SingleComponentResponseOfDestinyVendorGroupComponent VendorGroups { get; init; }

    [JsonPropertyName("vendors")]
    public DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent Vendors { get; init; }

    [JsonPropertyName("categories")]
    public DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent Categories { get; init; }

    [JsonPropertyName("sales")]
    public DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent Sales { get; init; }

    [JsonPropertyName("stringVariables")]
    public SingleComponentResponseOfDestinyStringVariablesComponent StringVariables { get; init; }
}
