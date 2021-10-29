using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyPresentationNodesComponent> Data { get; init; } =
            ReadOnlyDictionaries<long, DestinyPresentationNodesComponent>.Empty;
    }
}