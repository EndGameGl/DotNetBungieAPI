using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyPublicVendorComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyPublicVendorComponent>();
    }
}