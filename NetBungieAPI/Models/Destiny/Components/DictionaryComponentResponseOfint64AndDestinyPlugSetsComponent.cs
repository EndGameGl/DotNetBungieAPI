using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyPlugSetsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyPlugSetsComponent>();
    }
}