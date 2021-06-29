using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record
        DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, PublicDestinyVendorSaleItemSetComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, PublicDestinyVendorSaleItemSetComponent>();
    }
}