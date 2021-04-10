using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemInstanceComponent> Data { get; init; } = Defaults.EmptyReadOnlyDictionary<long, DestinyItemInstanceComponent>();
    }
}
