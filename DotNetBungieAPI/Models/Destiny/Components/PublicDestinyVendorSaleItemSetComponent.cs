using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record PublicDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("saleItems")]
        public ReadOnlyDictionary<int, DestinyPublicVendorSaleItemComponent> SaleItems { get; init; } =
            ReadOnlyDictionaries<int, DestinyPublicVendorSaleItemComponent>.Empty;
    }
}