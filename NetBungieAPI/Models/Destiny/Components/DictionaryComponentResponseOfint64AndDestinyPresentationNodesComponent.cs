using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyPresentationNodesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyPresentationNodesComponent>();
    }
}