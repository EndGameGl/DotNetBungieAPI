using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyItemSocketsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<int, DestinyItemSocketsComponent>();
    }
}