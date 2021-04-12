using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Components;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyVendorResponse
    {
        [JsonPropertyName("vendor")]
        public SingleComponentResponseOfDestinyVendorComponent Vendor { get; init; }
        
        [JsonPropertyName("categories")]
        public SingleComponentResponseOfDestinyVendorCategoriesComponent Categories { get; init; }
        
        [JsonPropertyName("sales")]
        public DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent Sales { get; init; }
        
        [JsonPropertyName("itemComponents")]
        public DestinyItemComponentSetOfint32 ItemComponents { get; init; }
        
        [JsonPropertyName("currencyLookups")]
        public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; init; }
    }
}
