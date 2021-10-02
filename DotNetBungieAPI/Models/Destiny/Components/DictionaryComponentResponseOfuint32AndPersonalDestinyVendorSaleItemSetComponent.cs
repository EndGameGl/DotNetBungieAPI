using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record
        DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, PersonalDestinyVendorSaleItemSetComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, PersonalDestinyVendorSaleItemSetComponent>();
    }
}