using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record PersonalDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("saleItems")]
        public ReadOnlyDictionary<uint, DestinyVendorSaleItemComponent> SaleItems { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyVendorSaleItemComponent>();
    }
}