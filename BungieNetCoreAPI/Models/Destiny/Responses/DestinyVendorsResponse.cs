using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Components;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyVendorsResponse
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
        public ReadOnlyDictionary<uint, DestinyItemComponentSetOfint32> ItemComponents { get; init; }
        
        [JsonPropertyName("currencyLookups")]
        public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; init; }
    }
}
