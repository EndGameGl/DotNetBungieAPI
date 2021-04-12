using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Components;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyPublicVendorsResponse
    {
        [JsonPropertyName("vendorGroups")]
        public SingleComponentResponseOfDestinyVendorGroupComponent VendorGroups { get; init; }
        
        [JsonPropertyName("vendors")]
        public DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent Vendors { get; init; }
        
        [JsonPropertyName("categories")]
        public DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent Categories { get; init; }
        
        [JsonPropertyName("sales")]
        public DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent Sales { get; init; }
    }
}
