using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyCurrenciesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyCurrenciesComponent>();
    }
}