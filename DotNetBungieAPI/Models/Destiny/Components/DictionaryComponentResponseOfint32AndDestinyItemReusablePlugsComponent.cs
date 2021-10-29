using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyItemReusablePlugsComponent> Data { get; init; } =
            ReadOnlyDictionaries<int, DestinyItemReusablePlugsComponent>.Empty;
    }
}