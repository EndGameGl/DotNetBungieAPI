using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyKiosksComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyKiosksComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyKiosksComponent>();
    }
}