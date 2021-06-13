using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyVendorSaleItemComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<int, DestinyVendorSaleItemComponent>();
    }
}