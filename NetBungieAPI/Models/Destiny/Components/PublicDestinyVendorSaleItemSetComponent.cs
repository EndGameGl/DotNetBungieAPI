using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record PublicDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("saleItems")]
        public ReadOnlyDictionary<int, DestinyPublicVendorSaleItemComponent> SaleItems { get; init; } =
            Defaults.EmptyReadOnlyDictionary<int, DestinyPublicVendorSaleItemComponent>();
    }
}