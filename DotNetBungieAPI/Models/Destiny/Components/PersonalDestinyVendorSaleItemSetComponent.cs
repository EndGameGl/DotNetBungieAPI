using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record PersonalDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("saleItems")]
        public ReadOnlyDictionary<uint, DestinyVendorSaleItemComponent> SaleItems { get; init; } =
            ReadOnlyDictionaries<uint, DestinyVendorSaleItemComponent>.Empty;
    }
}